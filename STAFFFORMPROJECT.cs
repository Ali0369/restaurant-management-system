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
    public partial class STAFFFORMPROJECT : Form2
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source= C:\Users\raahi\OneDrive\Desktop\New folder\RestaurantMS.accdb; Persist Security Info=False";
        DataTable staffTable = new DataTable();
        public STAFFFORMPROJECT()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = search.Text.Trim();  // Get the text from the search box

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Load staff data based on the search query
            LoadStaffData(searchText);
        }
        private void LoadStaffData(string searchQuery = "")
        {
            try
            {
                // SQL query to fetch all rows from the Staff table
                string query = "SELECT * FROM Staff WHERE StaffName LIKE ? OR StaffPhone LIKE ? OR StaffRole LIKE ?";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Add search query as a parameter (for LIKE search)
                    command.Parameters.AddWithValue("?", "%" + searchQuery + "%");  // StaffName search
                    command.Parameters.AddWithValue("?", "%" + searchQuery + "%");  // StaffPhone search
                    command.Parameters.AddWithValue("?", "%" + searchQuery + "%");  // StaffRole search

                    connection.Open();

                    // Fill the DataTable with the data from the database
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    staffTable.Clear(); // Clear the DataTable before loading new data
                    adapter.Fill(staffTable);

                    // Bind the DataTable to the DataGridView
                    dgvStaff.DataSource = staffTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading staff data: {ex.Message}");
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void STAFFFORMPROJECT_Load(object sender, EventArgs e)
        {
            // Prevent auto-generating columns
            dgvStaff.AutoGenerateColumns = false;

            // Set the DataPropertyName for each column in the DataGridView
            dgvStaff.Columns["dgvSno"].DataPropertyName = "StaffID";  // Not used for Sr#, will be dynamically added
            dgvStaff.Columns["dgvName"].DataPropertyName = "StaffName";
            dgvStaff.Columns["dgvPhone"].DataPropertyName = "StaffPhone";
            dgvStaff.Columns["dgvRole"].DataPropertyName = "StaffRole";

            // Optional: Hide row headers if not needed
            dgvStaff.RowHeadersVisible = false;

            // Load staff data from the database
            LoadStaffData();
        }
        private void LoadStaffData()
        {
            try
            {
                string query = "SELECT * FROM Staff"; // Replace with your actual table name

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    staffTable.Clear(); // Clear the DataTable before loading new data
                    adapter.Fill(staffTable);

                    // Update Sr# dynamically
                    int srNo = 1; // Starting Sr# value

                    // Bind the DataTable to the DataGridView
                    dgvStaff.DataSource = staffTable;

                    // Recalculate Sr# for each row
                    foreach (DataGridViewRow row in dgvStaff.Rows)
                    {
                        row.Cells["dgvSno"].Value = srNo++; // Assign Sr# (1, 2, 3,...)
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading staff data: {ex.Message}");
            }
        }

        private void AddStaffBtn_Click(object sender, EventArgs e)
        {

            using (AddStaff addStaffForm = new AddStaff())
            {
                addStaffForm.ShowDialog();

                if (addStaffForm.IsSaved) // Refresh if a staff member was added
                {
                    LoadStaffData();
                }
            }
        }

        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the Edit button was clicked
            if (e.ColumnIndex == dgvStaff.Columns["dgvedit"].Index) // Edit button clicked
            {
                int staffId = Convert.ToInt32(dgvStaff.Rows[e.RowIndex].Cells["dgvSno"].Value); // Get staff ID
                string staffName = dgvStaff.Rows[e.RowIndex].Cells["dgvName"].Value.ToString(); // Get staff name
                string staffPhone = dgvStaff.Rows[e.RowIndex].Cells["dgvPhone"].Value.ToString(); // Get staff phone
                string staffRole = dgvStaff.Rows[e.RowIndex].Cells["dgvRole"].Value.ToString(); // Get staff role

                using (AddStaff editForm = new AddStaff())
                {
                    // Pass the staff information to the edit form
                    editForm.StaffName = staffName;
                    editForm.StaffPhone = staffPhone;
                    editForm.StaffRole = staffRole;
                    editForm.StaffID = staffId; // Pass the staff ID
                    editForm.ShowDialog();

                    if (editForm.IsSaved) // If changes were saved
                    {
                        LoadStaffData(); // Reload staff data after editing
                    }
                }
            }

            // Handle the Delete button click
            else if (e.ColumnIndex == dgvStaff.Columns["dgvdel"].Index) // Delete button clicked
            {
                int staffId = Convert.ToInt32(dgvStaff.Rows[e.RowIndex].Cells["dgvSno"].Value); // Get staff ID

                // Confirm deletion
                var result = MessageBox.Show("Are you sure you want to delete this staff member?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Delete the staff from the database
                        string deleteQuery = "DELETE FROM Staff WHERE StaffID = ?";
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        using (OleDbCommand command = new OleDbCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("?", staffId); // Pass staff ID to delete

                            connection.Open();
                            command.ExecuteNonQuery(); // Execute the delete query
                        }

                        // Remove the row from the DataGridView
                        dgvStaff.Rows.RemoveAt(e.RowIndex);

                        // Reload the staff data after deletion
                        LoadStaffData();

                        MessageBox.Show("Staff member deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting staff: {ex.Message}");
                    }
                }
            }
        
    }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            MainPageProject MainPage = new MainPageProject();
            MainPage.Show();
        }

        private void staffCategoryBtn_Click(object sender, EventArgs e)
        {
            // Open the StaffCategoryPage when the button is clicked
            StaffCategory staffCategoryPage = new StaffCategory();
            staffCategoryPage.ShowDialog(); // Open the form as a dialog
        }
    }
}
