using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGIN_PAGE
{
    public partial class MainPageProject : Form
    {
        public MainPageProject()
        {
            InitializeComponent();
        }
     public void AddControls(Form f)
{
    centerpanel.Controls.Clear();
    f.Dock = DockStyle.Fill;
    f.TopLevel = false;
    centerpanel.Controls.Add(f);
    f.Show();
}


        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainPageProject_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }
        private void Tabless_Click(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {
            //tables tablepage = new tables();

            //tablepage.Show();
            
          
            // Hide the current form (MainForm in this case)
            //this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {



        }

        private void label18_Click_1(object sender, EventArgs e)
        {

        }


        
        private void label23_Click(object sender, EventArgs e)
        {
            //addtablereservation TableReservationPage = new addtablereservation();

            //TableReservationPage.Show();

            //// Hide the current form (MainForm in this case)
            //this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        //Sampleview categoryPage = new Sampleview();

        //categoryPage.Show();

        //    // Hide the current form (MainForm in this case)
        //    this.Hide();

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void staff_Click(object sender, EventArgs e)
        {
            STAFFFORMPROJECT staffPage = new STAFFFORMPROJECT();

            staffPage.Show();

            // Hide the current form (MainForm in this case)
            this.Hide();
        }


        private void reservation(object sender, EventArgs e)
        {

            //TABLES tablePage = new TABLES(); // Open the TABLES form
            //tablePage.ShowDialog(); // Show it as a modal dialog
          
        }

        private void centerpanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

            //TABLES tablePage = new TABLES(); // Open the TABLES form
            //tablePage.ShowDialog(); // Show it as a modal dialog
            TABLE tablePage = new TABLE();
            tablePage.ShowDialog();
            this.Hide();
        }

        //CATEGORIES///
        private void label4_Click(object sender, EventArgs e)
        {
            Sampleview categoryPage = new Sampleview();

            categoryPage.Show();

            // Hide the current form (MainForm in this case)
            this.Hide();
        }

        private void PRODUCTS_Click(object sender, EventArgs e)
        {
            products ProductPage = new products();

            ProductPage.Show();

            // Hide the current form (MainForm in this case)
            this.Hide();
        }

        private void POS_Click(object sender, EventArgs e)
        {
            POS POSPage = new POS();

            POSPage.Show();

            // Hide the current form (MainForm in this case)
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            tablereservation reservationPage = new tablereservation();
            reservationPage.ShowDialog();
            this.Hide();
        }
    }
}
