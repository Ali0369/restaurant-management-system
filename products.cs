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
    public partial class products : Form2
    {
        string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source= C:\Users\raahi\OneDrive\Desktop\New folder\RestaurantMS.accdb; Persist Security Info=False";
        DataTable productTable = new DataTable();
        public products()
        {
            InitializeComponent();
        }

        private void products_Load(object sender, EventArgs e)
        {
            // Prevent auto-generating columns
            dgvProducts.AutoGenerateColumns = false;

            // Bind DataGridView columns to database fields
            dgvProducts.Columns["dgvSno"].DataPropertyName = "ProductID";   // For Sr#
            dgvProducts.Columns["dgvName"].DataPropertyName = "ProductName"; // For Product Name
            dgvProducts.Columns["dgvPrice"].DataPropertyName = "ProductPrice"; // For Price
            dgvProducts.Columns["dgvCategory"].DataPropertyName = "ProductCategory"; // For Category
            dgvProducts.Columns["dgvQuantity"].DataPropertyName = "ProductQuantity"; // For Quantity

            // Optional: Hide row headers
            dgvProducts.RowHeadersVisible = false;

            // Load products into the DataGridView
            LoadProducts();
        }
        private void LoadProducts()
        {
            try
            {
                // SQL query to fetch products
                string query = "SELECT * FROM Products";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    connection.Open();

                    // Fill the DataTable with data
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    productTable.Clear(); // Clear before loading
                    adapter.Fill(productTable);

                    // Bind the DataTable to the DataGridView
                    dgvProducts.DataSource = productTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = search.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Search query
                string query = "SELECT * FROM Products WHERE ProductName LIKE ?";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", "%" + searchText + "%");

                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                    DataTable searchResult = new DataTable();
                    adapter.Fill(searchResult);

                    if (searchResult.Rows.Count > 0)
                    {
                        dgvProducts.DataSource = searchResult; // Show search results
                    }
                    else
                    {
                        MessageBox.Show("No matching products found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvProducts.DataSource = null; // Clear DataGridView
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during search: {ex.Message}");
            }
        }

        private void AddStaffBtn_Click(object sender, EventArgs e)
        {
            using (addProduct addProductForm = new addProduct())
            {
                addProductForm.ShowDialog();

                if (addProductForm.IsSaved) // Refresh if product was added
                {
                    LoadProducts();
                }
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProducts.Columns["dgvedit"].Index) // Edit button clicked
            {
                int productId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["dgvSno"].Value);
                string productName = dgvProducts.Rows[e.RowIndex].Cells["dgvName"].Value.ToString();
                string productCategory = dgvProducts.Rows[e.RowIndex].Cells["dgvCategory"].Value.ToString();
                decimal productPrice = Convert.ToDecimal(dgvProducts.Rows[e.RowIndex].Cells["dgvPrice"].Value);
                int productQuantity = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["dgvQuantity"].Value);

                using (addProduct editProductForm = new addProduct())
                {
                    // Pass product details to the edit form
                    editProductForm.ProductID = productId;
                    editProductForm.ProductName = productName;
                    editProductForm.ProductCategory = productCategory;
                    editProductForm.ProductPrice = productPrice;
                    editProductForm.ProductQuantity = productQuantity;

                    editProductForm.ShowDialog();

                    if (editProductForm.IsSaved) // Refresh after editing
                    {
                        LoadProducts();
                    }
                }
            }
            else if (e.ColumnIndex == dgvProducts.Columns["dgvdel"].Index) // Delete button clicked
            {
                int productId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["dgvSno"].Value);

                var result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Delete query
                        string deleteQuery = "DELETE FROM Products WHERE ProductID = ?";

                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        using (OleDbCommand command = new OleDbCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("?", productId);

                            connection.Open();
                            command.ExecuteNonQuery();
                        }

                        // Remove the row from DataGridView
                        dgvProducts.Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show("Product deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting product: {ex.Message}");
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

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
