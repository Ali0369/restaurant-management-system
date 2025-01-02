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
using System.Xml.Linq;

namespace LOGIN_PAGE
{
    public partial class AddStaff : Form2
    {
        // Define properties for staff data
        public string StaffName { get; set; }
        public int StaffID { get; set; }
        public string StaffPhone { get; set; }
        public string StaffRole { get; set; }
        public bool IsSaved { get; private set; }
        string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source= C:\Users\raahi\OneDrive\Desktop\New folder\RestaurantMS.accdb; Persist Security Info=False";
        public AddStaff()
        {
            InitializeComponent();
            IsSaved = false;
        }

        private void AddStaff_Load(object sender, EventArgs e)
        {
            txtname.Text = StaffName;
            txtPhone.Text = StaffPhone;
            txtRole.Text = StaffRole;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        { // Get the values from the input fields
            StaffName = txtname.Text;
            StaffPhone = txtPhone.Text;
            StaffRole = txtRole.Text;

            // Check if it's a new staff or an existing one (for updating)
            if (StaffID == 0) // New staff
            {
                AddNewStaff();
            }
            else // Update existing staff
            {
                UpdateStaff();
            }
        }

        private void AddNewStaff()
        {
            try
            {
                // Insert new staff record into the database
                string query = "INSERT INTO Staff (StaffName, StaffPhone, StaffRole) VALUES (?, ?, ?)";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("?", StaffName);
                    command.Parameters.AddWithValue("?", StaffPhone);
                    command.Parameters.AddWithValue("?", StaffRole);

                    connection.Open();
                    command.ExecuteNonQuery();
                    IsSaved = true; // Mark as saved
                    MessageBox.Show("Staff added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding staff: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();   // Close the form after saving
        }
        private void UpdateStaff()
        {
            try
            {
                // Update existing staff record
                string query = "UPDATE Staff SET StaffName = ?, StaffPhone = ?, StaffRole = ? WHERE StaffID = ?";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("?", StaffName);
                    command.Parameters.AddWithValue("?", StaffPhone);
                    command.Parameters.AddWithValue("?", StaffRole);
                    command.Parameters.AddWithValue("?", StaffID);

                    connection.Open();
                    command.ExecuteNonQuery();
                    IsSaved = true; // Mark as saved
                    MessageBox.Show("Staff updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating staff: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();   // Close the form after updating
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
