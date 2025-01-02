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
    public partial class AddStaffCategory : Form2

    {
        string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source= C:\Users\raahi\OneDrive\Desktop\New folder\RestaurantMS.accdb; Persist Security Info=False";

        public string StaffCategoryName { get; set; }
        public int StaffCategoryID { get; set; }
        public bool IsSaved { get; set; } = false;

        public AddStaffCategory()
        {
            InitializeComponent();
        }

        private void AddStaffCategory_Load(object sender, EventArgs e)
        {
            if (StaffCategoryID > 0)
            {
                txtname.Text = StaffCategoryName; // Pre-fill with existing name
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string categoryName = txtname.Text.Trim();

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Category name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query;

                    if (StaffCategoryID > 0)
                    {
                        // Update existing category
                        query = "UPDATE StaffCategory SET StaffCategory = ? WHERE StaffCategoryID = ?";
                    }
                    else
                    {
                        // Insert new category
                        query = "INSERT INTO StaffCategory (StaffCategory) VALUES (?)";
                    }

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", categoryName); // Category name

                        if (StaffCategoryID > 0)
                        {
                            command.Parameters.AddWithValue("?", StaffCategoryID); // Existing category ID for update
                        }

                        command.ExecuteNonQuery();
                    }

                    IsSaved = true;
                    this.Close();  // Close the form after saving
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving staff category: {ex.Message}");
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
