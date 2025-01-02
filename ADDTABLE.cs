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
    public partial class ADDTABLE : Form2
    {
        public string TableName { get; set; }
        public int id { get; set; } = -1;
        public bool IsSaved { get; set; } = false;
        public string Size { get; set; } = string.Empty;


        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\raahi\OneDrive\Desktop\New folder\RestaurantMS.accdb;Persist Security Info=False";
        public ADDTABLE()
        {
            InitializeComponent();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string name = txtname.Text.Trim();
            string size = txtSize.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(size))
            {
                MessageBox.Show("Please enter valid table details.");
                return;
            }

            if (id > 0) // Update existing table
            {
                try
                {
                    string updateQuery = "UPDATE Tables SET TableName = ?, TableSize = ? WHERE TableID = ?";
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("?", name);
                        command.Parameters.AddWithValue("?", size);
                        command.Parameters.AddWithValue("?", id);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                    IsSaved = true;
                    MessageBox.Show("Table updated successfully.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating table: {ex.Message}");
                }
            }
            else // Add new table
            {
                try
                {
                    string insertQuery = "INSERT INTO Tables (TableName, TableSize) VALUES (?, ?)";
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    using (OleDbCommand command = new OleDbCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("?", name);
                        command.Parameters.AddWithValue("?", size);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                    IsSaved = true;
                    MessageBox.Show("Table added successfully.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding table: {ex.Message}");
                }
            }
        }

        private void ADDTABLE_Load(object sender, EventArgs e)
        {
            if (id > 0) // Edit mode
            {
                txtname.Text = TableName;
                txtSize.Text = Size; // Populate Size
                btnSave.Text = "Update Table";
            }
        }
    }
}
