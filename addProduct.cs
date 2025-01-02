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
using System.IO;

namespace LOGIN_PAGE
{
    public partial class addProduct : Form2
    {
        string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source= C:\Users\raahi\OneDrive\Desktop\New folder\RestaurantMS.accdb; Persist Security Info=False";
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductID { get; set; }
        public bool IsSaved { get; private set; }
        public string ProductFilePath { get; set; } // File path for the product image

        public addProduct()
        {
            InitializeComponent();
            IsSaved = false;
        }

        private void addProduct_Load(object sender, EventArgs e)
        {
            // Populate fields if editing an existing product
            txtname.Text = ProductName;
            txtcategory.Text = ProductCategory;
            txtprice.Text = ProductPrice > 0 ? ProductPrice.ToString() : string.Empty;
            txtquantity.Text = ProductQuantity > 0 ? ProductQuantity.ToString() : string.Empty;
            textBox1.Text = ProductFilePath;

            // Load the product image if a valid path exists
            if (!string.IsNullOrEmpty(ProductFilePath) && File.Exists(ProductFilePath))
            {
                addPicture.Image = Image.FromFile(ProductFilePath);
            }
        }

        private bool CategoryExists(string categoryName)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM CATEGORIES WHERE categoryName = ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", categoryName);

                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0; // Returns true if the category exists
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
                string.IsNullOrWhiteSpace(txtcategory.Text) ||
                string.IsNullOrWhiteSpace(txtprice.Text) ||
                string.IsNullOrWhiteSpace(txtquantity.Text) ||
                string.IsNullOrWhiteSpace(ProductFilePath))  // Ensure ProductFilePath is set correctly
            {
                MessageBox.Show("Please fill out all fields and upload a product image.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtprice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtquantity.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate the category
            if (!CategoryExists(txtcategory.Text.Trim()))
            {
                MessageBox.Show("The entered category does not exist. Please enter a valid category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to insert or update the record
                    string query;
                    if (string.IsNullOrWhiteSpace(ProductName)) // Add new product
                    {
                        query = "INSERT INTO Products (ProductName, ProductCategory, ProductPrice, ProductQuantity, ProductFilePath) VALUES (?, ?, ?, ?, ?)";
                    }
                    else // Update existing product
                    {
                        query = "UPDATE Products SET ProductCategory = ?, ProductPrice = ?, ProductQuantity = ?, ProductFilePath = ? WHERE ProductName = ?";
                    }

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        if (string.IsNullOrWhiteSpace(ProductName)) // Parameters for insert
                        {
                            command.Parameters.AddWithValue("?", txtname.Text.Trim());
                            command.Parameters.AddWithValue("?", txtcategory.Text.Trim());
                            command.Parameters.AddWithValue("?", price);
                            command.Parameters.AddWithValue("?", quantity);
                            command.Parameters.AddWithValue("?", ProductFilePath);  // Use ProductFilePath here
                        }
                        else // Parameters for update
                        {
                            command.Parameters.AddWithValue("?", txtcategory.Text.Trim());
                            command.Parameters.AddWithValue("?", price);
                            command.Parameters.AddWithValue("?", quantity);
                            command.Parameters.AddWithValue("?", ProductFilePath);  // Use ProductFilePath here
                            command.Parameters.AddWithValue("?", ProductName);
                        }

                        command.ExecuteNonQuery();
                    }
                }

                // Save values and mark as saved
                ProductName = txtname.Text.Trim();
                ProductCategory = txtcategory.Text.Trim();
                ProductPrice = price;
                ProductQuantity = quantity;
                IsSaved = true;

                MessageBox.Show("Product saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Close the form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            // Open a file dialog to select the image
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Set the PictureBox to display the selected image
                        addPicture.Image = Image.FromFile(openFileDialog.FileName);

                        // Set the TextBox to show the file path
                        textBox1.Text = openFileDialog.FileName;

                        // Update the ProductFilePath property
                        ProductFilePath = openFileDialog.FileName;

                        // Optional: Set PictureBox SizeMode
                        addPicture.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
