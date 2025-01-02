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
    public partial class StaffCategory : Form2
    {
        string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source= C:\Users\raahi\OneDrive\Desktop\New folder\RestaurantMS.accdb; Persist Security Info=False";
        DataTable staffCategoryTable = new DataTable();
        public StaffCategory()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            STAFFFORMPROJECT StaffPage = new STAFFFORMPROJECT();
           StaffPage.Show();
        }

        private void StaffCategory_Load(object sender, EventArgs e)
        {
            // Prevent auto-generating columns
            dgvStaffCategory.AutoGenerateColumns = false;

            // Set the DataPropertyName for each column in the DataGridView
            dgvStaffCategory.Columns["dgvSno"].DataPropertyName = "StaffCategoryID";  // Bind to the database column "StaffCategoryID"
            dgvStaffCategory.Columns["dgvName"].DataPropertyName = "StaffCategory";  // Bind to the database column "StaffCategoryName"

            // Optional: Hide row headers if not needed
            dgvStaffCategory.RowHeadersVisible = false;

            // Load staff categories from the database
            LoadStaffCategories();
        }
        private void LoadStaffCategories()
        {
            try
            {
                // SQL query to fetch all rows from the StaffCategory table
                string query = "SELECT * FROM StaffCategory";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    connection.Open();

                    // Fill the DataTable with the data from the database
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    staffCategoryTable.Clear(); // Clear the DataTable before loading new data
                    adapter.Fill(staffCategoryTable);

                    // Bind the DataTable to the DataGridView
                    dgvStaffCategory.DataSource = staffCategoryTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading staff categories: {ex.Message}");
            }
        }

        private void dgvStaffCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Edit button clicked
            if (e.ColumnIndex == dgvStaffCategory.Columns["dgvedit"].Index)
            {
                int staffCategoryId = Convert.ToInt32(dgvStaffCategory.Rows[e.RowIndex].Cells["dgvSno"].Value); // Get category ID
                string staffCategoryName = dgvStaffCategory.Rows[e.RowIndex].Cells["dgvName"].Value.ToString(); // Get category name

                using (AddStaffCategory editForm = new AddStaffCategory())
                {
                    editForm.StaffCategoryName = staffCategoryName; // Pass category name
                    editForm.StaffCategoryID = staffCategoryId; // Pass category ID
                    editForm.ShowDialog(); // Open edit form

                    // If saved, reload the staff categories
                    if (editForm.IsSaved)
                    {
                        LoadStaffCategories();
                    }
                }
            }
            // Delete button clicked
            else if (e.ColumnIndex == dgvStaffCategory.Columns["dgvdel"].Index)
            {
                int staffCategoryId = Convert.ToInt32(dgvStaffCategory.Rows[e.RowIndex].Cells["dgvSno"].Value); // Get category ID

                // Confirm deletion
                var result = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Delete the category from the database
                        string deleteQuery = "DELETE FROM StaffCategory WHERE StaffCategoryID = ?";
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        using (OleDbCommand command = new OleDbCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("?", staffCategoryId);  // Pass category ID to delete
                            connection.Open();
                            command.ExecuteNonQuery();  // Execute the delete query
                        }

                        // Remove the row from the DataGridView
                        dgvStaffCategory.Rows.RemoveAt(e.RowIndex);

                        MessageBox.Show("Staff category deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting staff category: {ex.Message}");
                    }
                }
            }
        }

        private void btnAddStaffCategory_Click(object sender, EventArgs e)
        {
            using (AddStaffCategory addCategoryForm = new AddStaffCategory())
            {
                addCategoryForm.ShowDialog(); // Show AddStaffCategory form

                // If saved, reload staff categories
                if (addCategoryForm.IsSaved)
                {
                    LoadStaffCategories();
                }
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
