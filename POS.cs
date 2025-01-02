using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace LOGIN_PAGE
{
    public partial class POS : Form
    {
        string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source= C:\Users\raahi\OneDrive\Desktop\New folder\RestaurantMS.accdb; Persist Security Info=False";
        public POS()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void POS_Load(object sender, EventArgs e)
        {
            // Load categories on form load
            LoadCategories();
        }






        // Method to load categories from the database and display them as buttons in CategoryFlowLayoutPanel
        private void LoadCategories()
        {
            DataTable categoryData = FetchCategoryData();
            Categoryflowlayout.Controls.Clear();

            // Add the "All" button
            Button allButton = new Button
            {
                Text = "All",
                Tag = "All",
                Width = 100,
                Height = 50
            };
            allButton.Click += CategoryBtn_Click;
            Categoryflowlayout.Controls.Add(allButton);

            foreach (DataRow row in categoryData.Rows)
            {
                Button categoryBtn = new Button
                {
                    Text = row["categoryName"].ToString(),
                    Tag = row["categoryName"].ToString(),
                    Width = 100,
                    Height = 50
                };
                categoryBtn.Click += CategoryBtn_Click;
                Categoryflowlayout.Controls.Add(categoryBtn);
            }
        }


        // Event handler for when a category button is clicked
        private void CategoryBtn_Click(object sender, EventArgs e)
        {
            string categoryName = ((Button)sender).Tag.ToString();
            foreach (Control control in Categoryflowlayout.Controls)
            {
                if (control is Button btn)
                {
                    btn.BackColor = Color.LightGray;
                }
            }

            ((Button)sender).BackColor = Color.LightBlue;
            LoadProducts(categoryName);
        }


        // Method to load products based on the selected category
        private void LoadProducts(string categoryName)
        {

            DataTable productData = string.IsNullOrEmpty(categoryName) || categoryName == "All"
                 ? FetchAllProducts()
                 : FetchProductDataByCategory(categoryName);

            flowLayoutPanelProducts.Controls.Clear();

            foreach (DataRow row in productData.Rows)
            {
                Button productButton = new Button
                {
                    Text = row["ProductName"].ToString(),
                    Tag = new { Price = Convert.ToDecimal(row["ProductPrice"]), ImagePath = row["ProductFilePath"].ToString() },
                    Width = 150,
                    Height = 100,
                    TextAlign = ContentAlignment.BottomCenter
                };

                string imagePath = row["ProductFilePath"].ToString();
                if (File.Exists(imagePath))
                {
                    productButton.BackgroundImage = Image.FromFile(imagePath);
                    productButton.BackgroundImageLayout = ImageLayout.Stretch;
                }

                productButton.Click += ProductButton_Click;
                flowLayoutPanelProducts.Controls.Add(productButton);
            }
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string productName = clickedButton.Text;
            dynamic tagData = clickedButton.Tag;
            decimal productPrice = tagData.Price;

            AddProductToSummary(productName, productPrice);
        }
        // Method to fetch product data by category from the Products table
        private DataTable FetchProductDataByCategory(string categoryName)
        {

            string query = "SELECT ProductName, ProductPrice, ProductFilePath FROM Products WHERE ProductCategory = ?";
            DataTable dt = new DataTable();

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", categoryName);
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching product data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }
        private DataTable FetchAllProducts()
        {
            string query = "SELECT ProductName, ProductPrice, ProductFilePath FROM Products";
            DataTable dt = new DataTable();

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching all products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        // Method to fetch categories data from the Categories table
        private DataTable FetchCategoryData()
        {
            string query = "SELECT categoryName FROM Categories";
            DataTable dt = new DataTable();

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching category data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }


        // Method to show the bill in a new form
        private void ShowBill(string billContent)
        {
            //Form billForm = new Form();
            //billForm.Text = "Order Bill";

            //TextBox billTextBox = new TextBox();
            //billTextBox.Multiline = true;
            //billTextBox.Dock = DockStyle.Fill;
            //billTextBox.Text = billContent;
            //billTextBox.ReadOnly = true;

            //billForm.Controls.Add(billTextBox);
            //billForm.ShowDialog();

            Form billForm = new Form
            {
                Text = "Order Bill",
                Width = 400,
                Height = 600,
                StartPosition = FormStartPosition.CenterScreen
            };

            TextBox billTextBox = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                Text = billContent,
                ReadOnly = true,
                Font = new Font("Courier New", 10, FontStyle.Regular), // Use a monospaced font for better alignment
                ScrollBars = ScrollBars.Vertical
            };

            billForm.Controls.Add(billTextBox);
            billForm.ShowDialog();
        }
        // Method to generate and display the bill
        private void GenerateBillAndDisplay()
        {
            //StringBuilder billText = new StringBuilder();

            //billText.AppendLine("----------------------------------------------------------");
            //billText.AppendLine("                             RESTAURANT BILL                 ");
            //billText.AppendLine("------------------------------------------------------------");
            //billText.AppendLine("Product Name          Quantity     Amount");
            //billText.AppendLine("-------------------------------------------------");

            //foreach (DataGridViewRow row in dgvProductSummary.Rows)
            //{
            //    if (row.Cells["dgvName"].Value != null)
            //    {
            //        string productName = row.Cells["dgvName"].Value.ToString();
            //        int quantity = Convert.ToInt32(row.Cells["dgvQuantity"].Value);
            //        decimal amount = Convert.ToDecimal(row.Cells["dgvAmount"].Value);

            //        billText.AppendLine($"{productName,-20} {quantity,-10} {amount:C}");
            //    }
            //}

            //billText.AppendLine("-------------------------------------------------");
            //billText.AppendLine($"Total: {total.Text}");
            //billText.AppendLine("-------------------------------------------------");
            //billText.AppendLine("Thank you for dining with us!");
            //billText.AppendLine("-------------------------------------------------");

            //ShowBill(billText.ToString());
            StringBuilder billText = new StringBuilder();
            decimal totalAmount = 0;

            // Header
            billText.AppendLine("==================================================");
            billText.AppendLine("                 RESTAURANT BILL                 ");
            billText.AppendLine("==================================================");
            billText.AppendLine("Date: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            billText.AppendLine($"Order Type: {selectedOrderType}");
            if (!string.IsNullOrEmpty(assignedtable.Text))
                billText.AppendLine($"Table: {assignedtable.Text}");
            billText.AppendLine("==================================================");

            // Column Headers
            billText.AppendLine(string.Format("{0,-25}{1,-10}{2,10}", "Product Name", "Qty", "Amount"));
            billText.AppendLine("--------------------------------------------------");

            // Bill Items
            foreach (DataGridViewRow row in dgvProductSummary.Rows)
            {
                if (row.Cells["dgvName"].Value != null)
                {
                    string productName = row.Cells["dgvName"].Value.ToString();
                    int quantity = Convert.ToInt32(row.Cells["dgvQuantity"].Value);
                    decimal amount = Convert.ToDecimal(row.Cells["dgvAmount"].Value);
                    totalAmount += amount;

                    billText.AppendLine(string.Format("{0,-25}{1,-10}{2,10:C2}", productName, quantity, amount));
                }
            }

            // Footer
            billText.AppendLine("==================================================");
            billText.AppendLine(string.Format("{0,-35}{1,10:C2}", "Total Amount:", totalAmount));
            billText.AppendLine("==================================================");
            billText.AppendLine("       Thank you for dining with us!             ");
            billText.AppendLine("==================================================");

            ShowBill(billText.ToString());
        }

        // Method to show the bill in a new form
        //private void ShowBill(string billContent)
        //{
        //    Form billForm = new Form();
        //    billForm.Text = "Order Bill";

        //    TextBox billTextBox = new TextBox();
        //    billTextBox.Multiline = true;
        //    billTextBox.Dock = DockStyle.Fill;
        //    billTextBox.Text = billContent;
        //    billTextBox.ReadOnly = true;

        //    billForm.Controls.Add(billTextBox);
        //    billForm.ShowDialog();
        //}



        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            MainPageProject MainPage = new MainPageProject();


            MainPage.Show();
        }

        private void categorybtn_Click_1(object sender, EventArgs e)
        {

            // Get the category name from the clicked button's Tag
            string categoryName = ((Button)sender).Tag.ToString();

            // Reset the background color of all buttons
            foreach (Control control in Categoryflowlayout.Controls)
            {
                if (control is Button)
                {
                    Button btn = (Button)control;
                    btn.BackColor = Color.LightGray; // Reset the background color to light gray (unselected state)
                }
            }

    // Set the background color of the clicked button to indicate selection
    ((Button)sender).BackColor = Color.LightBlue; // Change color when selected

            // If the "All" button is clicked, load all products
            if (categoryName == "All")
            {
                LoadProducts(""); // Passing an empty string will load all products
            }
            else
            {
                // Load the products for the selected category
                LoadProducts(categoryName);
            }
        }
        // Event handler for when a product is clicked
      

        // Method to fetch product price from the Products table based on the product name
        private decimal FetchProductPriceFromDatabase(string productName)
        {
            decimal price = -1; // Default value if not found

            string query = "SELECT ProductPrice FROM Products WHERE ProductName = ?";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", productName);
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            price = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching product price: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return price;
        }

        // Event handler for clicking the "Minus" button in the dgvminus column
        private void dgvProductSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {// Check if the "Minus" button is clicked
            if (e.ColumnIndex == dgvProductSummary.Columns["dgvminus"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProductSummary.Rows[e.RowIndex];
                int quantity = Convert.ToInt32(row.Cells["dgvQuantity"].Value);

                if (quantity > 1)
                {
                    // Reduce quantity and update amount
                    row.Cells["dgvQuantity"].Value = quantity - 1;
                    decimal productPrice = Convert.ToDecimal(row.Cells["dgvAmount"].Value) / quantity;
                    row.Cells["dgvAmount"].Value = (quantity - 1) * productPrice;
                }
                else
                {
                    // Remove the product if quantity becomes zero
                    dgvProductSummary.Rows.RemoveAt(e.RowIndex);
                }

                // Update the total amount after modification
                UpdateTotalAmount();
            }
        }

        // Method to add product to DataGridView and calculate total
        //private void AddProductToSummary(string productName, decimal productPrice, int quantity)
        //{
        //    decimal amount = productPrice * quantity;

        //    int rowIndex = dgvProductSummary.Rows.Add();
        //    dgvProductSummary.Rows[rowIndex].Cells["dgvSno"].Value = rowIndex + 1;
        //    dgvProductSummary.Rows[rowIndex].Cells["dgvName"].Value = productName;
        //    dgvProductSummary.Rows[rowIndex].Cells["dgvQuantity"].Value = quantity;
        //    dgvProductSummary.Rows[rowIndex].Cells["dgvAmount"].Value = amount;
        //}
        private void AddProductToSummary(string productName, decimal productPrice)
        {
            bool productExists = false;

            foreach (DataGridViewRow row in dgvProductSummary.Rows)
            {
                if (row.Cells["dgvName"].Value != null && row.Cells["dgvName"].Value.ToString() == productName)
                {
                    int existingQuantity = Convert.ToInt32(row.Cells["dgvQuantity"].Value);
                    row.Cells["dgvQuantity"].Value = existingQuantity + 1;
                    decimal newAmount = Convert.ToDecimal(row.Cells["dgvAmount"].Value) + productPrice;
                    row.Cells["dgvAmount"].Value = newAmount;
                    productExists = true;
                    break;
                }
            }

            if (!productExists)
            {
                int rowIndex = dgvProductSummary.Rows.Add();
                dgvProductSummary.Rows[rowIndex].Cells["dgvSno"].Value = dgvProductSummary.Rows.Count;
                dgvProductSummary.Rows[rowIndex].Cells["dgvName"].Value = productName;
                dgvProductSummary.Rows[rowIndex].Cells["dgvQuantity"].Value = 1;
                dgvProductSummary.Rows[rowIndex].Cells["dgvAmount"].Value = productPrice;
            }

            UpdateTotalAmount();
        }
        // Method to update the total amount in the DataGridView
        private void UpdateTotalAmount()
        {
            decimal totalAmount = 0;
            foreach (DataGridViewRow row in dgvProductSummary.Rows)
            {
                if (row.Cells["dgvAmount"].Value != null)
                {
                    totalAmount += Convert.ToDecimal(row.Cells["dgvAmount"].Value);
                }
            }

            total.Text = totalAmount.ToString("C");
        }
        // Event handler for the product click event


        private void ProductClick(object sender, EventArgs e)
        {
            // Your previous handling of product click event
            // This is no longer needed
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            // Reset the order details for a new order
            dgvProductSummary.Rows.Clear();
            total.Text = "0.00";
            assignedtable.Text = string.Empty;
        }
        private string selectedOrderType = "Dine In"; // Default value is Dine In

        private void button3_Click(object sender, EventArgs e)
        {
            selectedOrderType = "Takeaway";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkReservation checkReservationForm = new checkReservation();
            checkReservationForm.ShowDialog();

            if (!string.IsNullOrEmpty(checkReservationForm.AssignedTable))
            {
                assignedtable.Text = checkReservationForm.AssignedTable;
                MessageBox.Show($"Assigned Table: {assignedtable.Text}", "Reservation Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private int GetOrderId(int tableNo)
            {
                // Query to get the OrderID for the given TableNo
                string selectQuery = "SELECT MAX(OrderID) FROM Orders WHERE TableNo = ?";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("?", tableNo);
                    connection.Open();

                    object result = command.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToInt32(result) : -1; // Return OrderID
                }


            }

        private string GetOrderType()
        {
            return selectedOrderType; // Return the selected order type
        }
        private void btnDelivery_Click(object sender, EventArgs e)
        {
            selectedOrderType = "Delivery";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(assignedtable.Text))
            {
                MessageBox.Show("Please check reservation or assign a table.");
                return;
            }

            GenerateBillAndDisplay();
        }
    }
}

