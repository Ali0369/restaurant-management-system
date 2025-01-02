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
    public partial class btnaddtabl : Form2
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\raahi\OneDrive\Desktop\New folder\RestaurantMS.accdb;Persist Security Info=False";
        DataTable tableData = new DataTable();
        public btnaddtabl()
        {
            InitializeComponent();
        }

        private void tables_Load(object sender, EventArgs e)
        {
            LoadTables();
        }
        private void LoadTables()
        {
            //try
            //{
            //    string query = "SELECT TableID, TableName FROM Tables";  // Replace 'Tables' with your actual table name
            //    using (OleDbConnection connection = new OleDbConnection(connectionString))
            //    using (OleDbCommand command = new OleDbCommand(query, connection))
            //    {
            //        connection.Open();
            //        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            //        //tableData.Clear(); 
            //        DataTable tableData = new DataTable();
            //        adapter.Fill(tableData);

            //        // Add Sr# dynamically
            //        for (int i = 0; i < tableData.Rows.Count; i++)
            //        {
            //            tableData.Rows[i]["Sr#"] = (i + 1).ToString();
            //        }

            //        // Bind data to the existing DataGridView
            //        dvgTable.DataSource = tableData;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error loading tables: {ex.Message}");
            //}

            try
            {
                string query = "SELECT TableID, TableName FROM Tables";  // Replace 'Tables' with your actual table name
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    DataTable tableData = new DataTable();
                    adapter.Fill(tableData);

                    // Add Sr# column dynamically to the DataTable
                    tableData.Columns.Add("Sr#", typeof(string));

                    // Populate Sr# with row numbers
                    for (int i = 0; i < tableData.Rows.Count; i++)
                    {
                        tableData.Rows[i]["Sr#"] = (i + 1).ToString();  // Adding Sr# (1-based index)
                    }

                    // Set DataGridView DataSource
                    dvgTable.DataSource = tableData;

                    // Bind columns to the DataGridView
                    dvgTable.Columns["dgvSno"].DataPropertyName = "Sr#"; // Bind to dynamically added Sr#
                    dvgTable.Columns["dgvName"].DataPropertyName = "TableName"; // Bind to TableName from database
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tables: {ex.Message}");
            }

        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            using (ADDTABLE addTableForm = new ADDTABLE())
            {
                addTableForm.ShowDialog();

                if (addTableForm.IsSaved)
                {
                    LoadTables(); // Refresh table list after adding a new one
                }
            }
        }

        private void dvgTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dvgTable.Columns["dgvedit"].Index) // Edit button
            {
                EditTable(e.RowIndex);
            }
            else if (e.ColumnIndex == dvgTable.Columns["dgvdel"].Index) // Delete button
            {
                DeleteTable(e.RowIndex);
            }
        }
        private void EditTable(int rowIndex)
        {
            // Get the tableID and tableName from the DataGridView
            int tableId = Convert.ToInt32(dvgTable.Rows[rowIndex].Cells["dgvSno"].Value);
            string tableName = dvgTable.Rows[rowIndex].Cells["dgvName"].Value.ToString();

            using (ADDTABLE editForm = new ADDTABLE())
            {
                editForm.TableName = tableName;
                editForm.id = tableId;
                editForm.ShowDialog();

                if (editForm.IsSaved)
                {
                    LoadTables(); // Reload tables after editing
                }
            }
        }
        private void DeleteTable(int rowIndex)
        {
            int tableId = Convert.ToInt32(dvgTable.Rows[rowIndex].Cells["dgvSno"].Value);

            // Confirm deletion
            var result = MessageBox.Show("Are you sure you want to delete this table?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string deleteQuery = "DELETE FROM Tables WHERE TableID = ?";
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    using (OleDbCommand command = new OleDbCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("?", tableId);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                    LoadTables(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting table: {ex.Message}");
                }
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
