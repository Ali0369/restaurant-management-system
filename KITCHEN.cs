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
using System.Windows.Forms.VisualStyles;

namespace LOGIN_PAGE
{
   
    public partial class KITCHEN : Form
    {
        string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source= C:\Users\raahi\OneDrive\Desktop\New folder\RestaurantMS.accdb; Persist Security Info=False";
        string orderType;
        public KITCHEN()
        {
            this.orderType = orderType;
            InitializeComponent();
        }



        public void LoadOrderForKitchen(int orderId)
        {
            try
            {
                string query = "SELECT o.OrderID, o.TableNo, o.TotalAmount, od.ProductName, od.Quantity " +
                               "FROM Orders o " +
                               "JOIN OrderDetails od ON o.OrderID = od.OrderID " +
                               "WHERE o.OrderID = ?";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", orderId);
                        connection.Open();

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string productName = reader["ProductName"].ToString();
                                    int quantity = Convert.ToInt32(reader["Quantity"]);
                                    string tableNo = reader["TableNo"].ToString();
                                    decimal totalAmount = Convert.ToDecimal(reader["TotalAmount"]);

                                    // Create a panel for the order details and add to kitchen page
                                    Panel orderPanel = new Panel();
                                    orderPanel.Controls.Add(new Label() { Text = "Order ID: " + orderId });
                                    orderPanel.Controls.Add(new Label() { Text = "Table: " + tableNo });
                                    orderPanel.Controls.Add(new Label() { Text = "Total: " + totalAmount });
                                    orderPanel.Controls.Add(new Label() { Text = productName + " - " + quantity });

                                    // Assuming you have a panel in the Kitchen form to add the order details
                                    flowLayoutPanelOrders.Controls.Add(orderPanel);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No orders found for this ID.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order for kitchen: {ex.Message}");
            }
        }

    }
}
