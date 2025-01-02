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
    public partial class TABLE : Form2

    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\raahi\OneDrive\Desktop\New folder\RestaurantMS.accdb;Persist Security Info=False";
        DataTable tableData = new DataTable();
        public TABLE()
        {
            InitializeComponent();
        }

        private void TABLE_Load(object sender, EventArgs e)
        {
            LoadTables();

        }
        private void LoadTables()
        {
            //try
            //{
            //    string query = "SELECT * FROM Tables"; // Replace 'Tables' with your actual table name
            //    using (OleDbConnection connection = new OleDbConnection(connectionString))
            //    using (OleDbCommand command = new OleDbCommand(query, connection))
            //    {
            //        connection.Open();
            //        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            //        tableData.Clear();
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
                string query = "SELECT TableID, TableName, TableSize FROM Tables"; // Include TableSize
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    DataTable tableData = new DataTable();
                    adapter.Fill(tableData);

                    dvgTable.Rows.Clear();

                    for (int i = 0; i < tableData.Rows.Count; i++)
                    {
                        int tableId = Convert.ToInt32(tableData.Rows[i]["TableID"]);
                        string tableName = tableData.Rows[i]["TableName"].ToString();
                        string tableSize = tableData.Rows[i]["TableSize"].ToString(); // Retrieve TableSize

                        int rowIndex = dvgTable.Rows.Add();
                        dvgTable.Rows[rowIndex].Cells["dgvSno"].Value = (i + 1).ToString();
                        dvgTable.Rows[rowIndex].Cells["dgvName"].Value = tableName;
                        dvgTable.Rows[rowIndex].Cells["dgvTableSize"].Value = tableSize; // Assign to dgvTableSize column
                    }
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
            int tableId = Convert.ToInt32(dvgTable.Rows[rowIndex].Cells["dgvSno"].Value);
            string tableName = dvgTable.Rows[rowIndex].Cells["dgvName"].Value.ToString();
            string tableSize = dvgTable.Rows[rowIndex].Cells["dgvTableSize"].Value.ToString(); // Get Size

            using (ADDTABLE editForm = new ADDTABLE())
            {
                editForm.TableName = tableName;
                editForm.id = tableId;
                editForm.Size = tableSize; // Pass Size
                editForm.ShowDialog();

                if (editForm.IsSaved)
                {
                    LoadTables();
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

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            MainPageProject MainPage = new MainPageProject();

            
            MainPage.Show();

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
