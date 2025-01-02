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
    public partial class checkReservation : Form2
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\raahi\OneDrive\Desktop\New folder\RestaurantMS.accdb;Persist Security Info=False";
        public string AssignedTable { get; private set; } = string.Empty;
        public checkReservation()
        {
            InitializeComponent();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string size = txtSize.Text.Trim();

            // Validate input
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(size))
            {
                MessageBox.Show("Please enter valid details for Full Name and Total Persons.");
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Step 1: Check if the Full Name exists in the Reservation table
                    string queryCheckFullName = "SELECT TableNo FROM Reservations WHERE FullName = @FullName";
                    using (OleDbCommand command = new OleDbCommand(queryCheckFullName, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", fullName);
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            // If the Full Name is found, assign the TableNo to the label
                            AssignedTable = result.ToString();
                            MessageBox.Show($"Reservation found. Assigned Table: {AssignedTable}");
                            this.Close();
                            return;
                        }
                    }

                    // Step 2: If Full Name is not found, check if a table of the specified size is available
                    string queryCheckSize = @"
                SELECT t.TableName
                FROM Tables t
                LEFT JOIN Reservations r ON t.TableID = r.TableID
                WHERE t.TableSize = @TableSize AND r.TableID IS NULL";  // LEFT JOIN to find available tables

                    using (OleDbCommand command = new OleDbCommand(queryCheckSize, connection))
                    {
                        command.Parameters.AddWithValue("@TableSize", size);
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            // If a table of the specified size is found
                            AssignedTable = result.ToString();

                            // Step 3: Assign the TableName to the new Full Name in the Reservation table
                            string insertQuery = "INSERT INTO Reservations (FullName, TableID) VALUES (@FullName, @TableID)";
                            using (OleDbCommand insertCommand = new OleDbCommand(insertQuery, connection))
                            {
                                // Get the TableID corresponding to the TableName
                                string queryTableID = "SELECT TableID FROM Tables WHERE TableName = @TableName";
                                using (OleDbCommand getTableIDCommand = new OleDbCommand(queryTableID, connection))
                                {
                                    getTableIDCommand.Parameters.AddWithValue("@TableName", AssignedTable);
                                    object tableID = getTableIDCommand.ExecuteScalar();

                                    if (tableID != null)
                                    {
                                        // Insert the reservation with the found TableID
                                        insertCommand.Parameters.AddWithValue("@FullName", fullName);
                                        insertCommand.Parameters.AddWithValue("@TableID", tableID.ToString());
                                        insertCommand.ExecuteNonQuery();

                                        MessageBox.Show($"Table assigned successfully. Assigned Table: {AssignedTable}");
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error: Unable to retrieve Table ID.");
                                    }
                                }
                            }
                        }
                        else
                        {
                            // If no available table is found for the specified size
                            MessageBox.Show("No table available for the specified size.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking reservation: {ex.Message}");
            }

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
