using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LOGIN_PAGE
{
    public partial class Sampleview : Form
    {
        string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source= C:\Users\raahi\OneDrive\Desktop\New folder\RestaurantMS.accdb; Persist Security Info=False";
        DataTable categoryTable = new DataTable();
        public Sampleview()
        {
            InitializeComponent();
           
          
        }

        private void Sampleview_Load(object sender, EventArgs e)
        {
            // Prevent auto-generating columns
            dvgCategory.AutoGenerateColumns = false;

            // Set the DataPropertyName for each column in the DataGridView
            dvgCategory.Columns["dgvSno"].DataPropertyName = "categoryID";   // Bind to the database column "categoryID"
            dvgCategory.Columns["dgvName"].DataPropertyName = "categoryName"; // Bind to the database column "categoryName"

            // Optional: Hide row headers if not needed
            dvgCategory.RowHeadersVisible = false;

            // Load categories from the database
            LoadCategories();

        }

        private void LoadCategories()
        {
            //try
            //{
            //    // SQL query to fetch all rows from the Categories table
            //    string query = "SELECT * FROM Categories";

            //    using (OleDbConnection connection = new OleDbConnection(connectionString))
            //    using (OleDbCommand command = new OleDbCommand(query, connection))
            //    {
            //        connection.Open();

            //        // Fill the DataTable with the data from the database
            //        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            //        categoryTable.Clear(); // Clear the DataTable before loading new data
            //        adapter.Fill(categoryTable);

            //        // Bind the DataTable to the DataGridView
            //        dvgCategory.DataSource = categoryTable;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error loading categories: {ex.Message}");
            //}

            try
            {
                string query = "SELECT * FROM Categories"; // Ensure the correct table name

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    categoryTable.Clear(); // Clear the DataTable before loading new data
                    adapter.Fill(categoryTable);

                    // Update the Sr# dynamically
                    int srNo = 1; // Starting Sr# value

                    // Bind the DataTable to the DataGridView
                    dvgCategory.DataSource = categoryTable;

                    // Recalculate Sr# for each row
                    foreach (DataGridViewRow row in dvgCategory.Rows)
                    {
                        row.Cells["dgvSno"].Value = srNo++; // Assign Sr# (1, 2, 3,...)
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}");
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            using (addcategory addCategoryForm = new addcategory())
            {
                addCategoryForm.ShowDialog();

                if (addCategoryForm.IsSaved) // Refresh if a category was added.
                {
                    LoadCategories();
                }
            }

        }
        public void AddCategoryToGrid(string categoryName)
        {
            DataRow newRow = categoryTable.NewRow();
            newRow["categoryName"] = categoryName;
            categoryTable.Rows.Add(newRow);
            dvgCategory.Refresh(); // Refresh the DataGridView

           
        }
        private void dvgCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the Edit button was clicked
            if (e.ColumnIndex == dvgCategory.Columns["dgvedit"].Index) // Edit button clicked
            {
                int categoryId = Convert.ToInt32(dvgCategory.Rows[e.RowIndex].Cells["dgvSno"].Value); // Get category ID
                string categoryName = dvgCategory.Rows[e.RowIndex].Cells["dgvName"].Value.ToString(); // Get category name

                using (addcategory editForm = new addcategory())
                {
                    editForm.CategoryName = categoryName; // Set the category name in the form
                    editForm.id = categoryId; // Pass the category ID to the form
                    editForm.ShowDialog(); // Show the edit form

                    if (editForm.IsSaved) // If changes were saved
                    {
                        // Update the category in the database
                        try
                        {
                            string updateQuery = "UPDATE Categories SET categoryName = ? WHERE categoryID = ?";
                            using (OleDbConnection connection = new OleDbConnection(connectionString))
                            using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                            {
                                command.Parameters.AddWithValue("?", editForm.CategoryName); // Get updated name from form
                                command.Parameters.AddWithValue("?", categoryId); // Pass category ID to update

                                connection.Open();
                                command.ExecuteNonQuery(); // Execute the update query
                            }

                            // Reload the categories to refresh DataGridView
                            LoadCategories();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error updating category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            // Handle the Delete button click (already implemented)
            else if (e.ColumnIndex == dvgCategory.Columns["dgvdel"].Index) // Delete button clicked
            {
                int categoryId = Convert.ToInt32(dvgCategory.Rows[e.RowIndex].Cells["dgvSno"].Value); // Get category ID

                // Confirm deletion
                var result = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Delete the category from the database
                        string deleteQuery = "DELETE FROM Categories WHERE categoryID = ?";
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        using (OleDbCommand command = new OleDbCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("?", categoryId); // Pass category ID to delete
                            connection.Open();
                            command.ExecuteNonQuery(); // Execute the delete query
                        }

                        // Remove the row from the DataGridView
                        dvgCategory.Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show("Category deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void EditCategory(int rowIndex)
        {
            //// Get the categoryID and categoryName from the DataGridView
            //int categoryId = Convert.ToInt32(dvgCategory.Rows[rowIndex].Cells["dgvSno"].Value);
            //string categoryName = dvgCategory.Rows[rowIndex].Cells["dgvName"].Value.ToString();

            //using (addcategory editForm = new addcategory())
            //{
            //    // Set the category name in the edit form
            //    editForm.CategoryName = categoryName;
            //    editForm.id = categoryId; // Pass the category ID to the form
            //    editForm.ShowDialog();

            //    if (editForm.IsSaved) // If changes were saved
            //    {
            //        // Update the category in the database
            //        try
            //        {
            //            string updateQuery = "UPDATE Categories SET categoryName = ? WHERE categoryID = ?";
            //            using (OleDbConnection connection = new OleDbConnection(connectionString))
            //            using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
            //            {
            //                command.Parameters.AddWithValue("?", editForm.CategoryName); // Use the property for updated name
            //                command.Parameters.AddWithValue("?", categoryId);

            //                connection.Open();
            //                command.ExecuteNonQuery();
            //            }

            //            // Reload the categories in the DataGridView
            //            LoadCategories();
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show($"Error updating category: {ex.Message}");
            //        }
            //    }
            //}
            int categoryId = Convert.ToInt32(dvgCategory.Rows[rowIndex].Cells["dgvSno"].Value);
            string categoryName = dvgCategory.Rows[rowIndex].Cells["dgvName"].Value.ToString();

            using (addcategory editForm = new addcategory())
            {
                // Pass the category information to the edit form
                editForm.CategoryName = categoryName;
                editForm.id = categoryId; // Pass the category ID to the form
                editForm.ShowDialog();

                // If changes were saved in the edit form, reload the categories
                if (editForm.IsSaved)
                {
                    LoadCategories(); // Reload the categories after editing
                }
            }
        }
        private void DeleteCategory(int rowIndex)
        {
            // Get the categoryID from the DataGridView
            int categoryId = Convert.ToInt32(dvgCategory.Rows[rowIndex].Cells["dgvSno"].Value);

            // Confirm deletion
            var result = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Delete the category from the database
                    string deleteQuery = "DELETE FROM Categories WHERE categoryID = ?";
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    using (OleDbCommand command = new OleDbCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("?", categoryId);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                    // Remove the row from the DataGridView
                    dvgCategory.Rows.RemoveAt(rowIndex);

                    MessageBox.Show("Category deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting category: {ex.Message}");
                }
            }
        }


        private void search_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = search.Text.Trim(); // Get the text from the search box

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Use a query to search for the category
                string query = "SELECT * FROM Categories WHERE categoryName LIKE ?";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Add the parameter for the LIKE query
                    command.Parameters.AddWithValue("?", "%" + searchText + "%");

                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                    DataTable searchResult = new DataTable();
                    adapter.Fill(searchResult);

                    if (searchResult.Rows.Count > 0)
                    {
                        dvgCategory.DataSource = searchResult; // Display search results in DataGridView
                    }
                    else
                    {
                        MessageBox.Show("No matching categories found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dvgCategory.DataSource = null; // Clear the DataGridView
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during search: {ex.Message}");
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            MainPageProject MainPage = new MainPageProject();


            MainPage.Show();
        }
    }
}
