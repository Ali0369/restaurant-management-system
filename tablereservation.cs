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
    public partial class tablereservation : Form2
    {
      
        public tablereservation()
        {
            InitializeComponent();
            LoadReservations();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            addtablereservation addReservationForm = new addtablereservation();
            addReservationForm.ShowDialog();
        }
        private void LoadReservations()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\raahi\OneDrive\Desktop\New folder\RestaurantMS.accdb;Persist Security Info=False";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                    SELECT Reservations.ReservationID, Reservations.FullName, Tables.TableName 
                    FROM Reservations 
                    INNER JOIN Tables ON Reservations.TableNo = Tables.TableID";  // Assuming TableNo links with TableID

                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable reservationData = new DataTable();
                    adapter.Fill(reservationData);

                    dgvTableReservation.Rows.Clear();

                    for (int i = 0; i < reservationData.Rows.Count; i++)
                    {
                        int rowIndex = dgvTableReservation.Rows.Add();
                        dgvTableReservation.Rows[rowIndex].Cells["dgvSno"].Value = (i + 1).ToString();
                        dgvTableReservation.Rows[rowIndex].Cells["dgvName"].Value = reservationData.Rows[i]["FullName"].ToString();
                        dgvTableReservation.Rows[rowIndex].Cells["dgvAssignedTable"].Value = reservationData.Rows[i]["TableName"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservations: {ex.Message}");
            }
        }

        private void dgvTableReservation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                if (e.ColumnIndex == dgvTableReservation.Columns["dgvedit"].Index) // Edit action
                {
                    EditReservation(e.RowIndex);
                }
                else if (e.ColumnIndex == dgvTableReservation.Columns["dgvdel"].Index) // Delete action
                {
                    DeleteReservation(e.RowIndex);
                }
            }
        }

        private void EditReservation(int rowIndex)
        {
            // Get existing reservation details
            string fullName = dgvTableReservation.Rows[rowIndex].Cells["dgvName"].Value.ToString();
            string size = dgvTableReservation.Rows[rowIndex].Cells["dgvAssignedTable"].Value.ToString(); // Assuming this contains size information

            // Open the Add Reservation form
            addtablereservation editReservationForm = new addtablereservation
            {
                Text = "Edit Reservation"
            };

            // Pre-fill the form fields
            editReservationForm.FullName = fullName;
            editReservationForm.Size = size;
            editReservationForm.ShowDialog();

            // Reload reservations if changes were saved
            if (editReservationForm.IsSaved)
            {
                LoadReservations();
            }
        }

        private void DeleteReservation(int rowIndex)
        {
            int reservationId = Convert.ToInt32(dgvTableReservation.Rows[rowIndex].Cells["ReservationID"].Value); // Assuming you store the ReservationID in a hidden column or tag.

            // Confirm deletion
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this reservation?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\raahi\OneDrive\Desktop\New folder\RestaurantMS.accdb;Persist Security Info=False";

                try
                {
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        string deleteQuery = "DELETE FROM Reservations WHERE ReservationID = ?";
                        using (OleDbCommand command = new OleDbCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("?", reservationId);
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Reservation deleted successfully.");
                    LoadReservations(); // Refresh the grid
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting reservation: {ex.Message}");
                }
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
