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
    public partial class addtablereservation : Form2

    {
        public string FullName
        {
            get { return txtFullName.Text; }
            set { txtFullName.Text = value; }
        }

        public string Size
        {
            get { return txtSize.Text; }
            set { txtSize.Text = value; }
        }

        public bool IsSaved { get; set; } = false; // Tracks if the reservation was saved

        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\raahi\OneDrive\Desktop\New folder\RestaurantMS.accdb;Persist Security Info=False";
        public addtablereservation()
        {
            InitializeComponent();

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            int size;

            // Validate input
            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Please enter a full name.");
                return;
            }
            if (!int.TryParse(txtSize.Text.Trim(), out size) || size <= 0)
            {
                MessageBox.Show("Please enter a valid size.");
                return;
            }

            // Check for table availability
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\raahi\OneDrive\Desktop\New folder\RestaurantMS.accdb;Persist Security Info=False";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Query to find a table with the required size
                    string findTableQuery = "SELECT TableID, TableName FROM Tables WHERE TableSize = ?";
                    using (OleDbCommand command = new OleDbCommand(findTableQuery, connection))
                    {
                        command.Parameters.AddWithValue("?", size);

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int tableId = Convert.ToInt32(reader["TableID"]);
                                string tableName = reader["TableName"].ToString();

                                // Save the reservation
                                string insertReservationQuery = "INSERT INTO Reservations (FullName, TableID) VALUES (?, ?)";
                                using (OleDbCommand insertCommand = new OleDbCommand(insertReservationQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("?", fullName);
                                    insertCommand.Parameters.AddWithValue("?", tableId);

                                    insertCommand.ExecuteNonQuery();
                                }

                                MessageBox.Show($"Reservation successful! Table '{tableName}' has been assigned.");
                                this.Close();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("No table available with the specified size.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
