namespace LOGIN_PAGE
{
    partial class POS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDelivery = new System.Windows.Forms.Button();
            this.newBtn = new System.Windows.Forms.Button();
            this.btnTakeaway = new System.Windows.Forms.Button();
            this.Categoryflowlayout = new System.Windows.Forms.FlowLayoutPanel();
            this.categorybtn = new System.Windows.Forms.Button();
            this.flowLayoutPanelProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.TextBox();
            this.dgvProductSummary = new System.Windows.Forms.DataGridView();
            this.dgvSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assignedtable = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvminus = new System.Windows.Forms.DataGridViewImageColumn();
            this.BackBtn = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Categoryflowlayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(34)))), ((int)(((byte)(65)))));
            this.panel1.Controls.Add(this.BackBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1060, 112);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Matura MT Script Capitals", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(142, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(783, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "P O I N T   OF   S A L E";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(34)))), ((int)(((byte)(65)))));
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.btnDelivery);
            this.panel2.Controls.Add(this.newBtn);
            this.panel2.Controls.Add(this.btnTakeaway);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 558);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1060, 94);
            this.panel2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(109)))), ((int)(((byte)(140)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 4;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.Location = new System.Drawing.Point(470, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 62);
            this.button1.TabIndex = 3;
            this.button1.Text = "CHECK RESERVATION";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(109)))), ((int)(((byte)(140)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderSize = 4;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button2.Location = new System.Drawing.Point(624, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(424, 62);
            this.button2.TabIndex = 2;
            this.button2.Text = "SEND TO KITCHEN";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDelivery
            // 
            this.btnDelivery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(109)))), ((int)(((byte)(140)))));
            this.btnDelivery.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDelivery.FlatAppearance.BorderSize = 4;
            this.btnDelivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDelivery.Location = new System.Drawing.Point(8, 20);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(148, 62);
            this.btnDelivery.TabIndex = 2;
            this.btnDelivery.Text = "DELIVERY";
            this.btnDelivery.UseVisualStyleBackColor = false;
            this.btnDelivery.Click += new System.EventHandler(this.btnDelivery_Click);
            // 
            // newBtn
            // 
            this.newBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(109)))), ((int)(((byte)(140)))));
            this.newBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.newBtn.FlatAppearance.BorderSize = 4;
            this.newBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.newBtn.Location = new System.Drawing.Point(316, 20);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(148, 62);
            this.newBtn.TabIndex = 2;
            this.newBtn.Text = "NEW";
            this.newBtn.UseVisualStyleBackColor = false;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // btnTakeaway
            // 
            this.btnTakeaway.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(109)))), ((int)(((byte)(140)))));
            this.btnTakeaway.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnTakeaway.FlatAppearance.BorderSize = 4;
            this.btnTakeaway.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeaway.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnTakeaway.Location = new System.Drawing.Point(162, 20);
            this.btnTakeaway.Name = "btnTakeaway";
            this.btnTakeaway.Size = new System.Drawing.Size(148, 62);
            this.btnTakeaway.TabIndex = 2;
            this.btnTakeaway.Text = "TAKE-AWAY";
            this.btnTakeaway.UseVisualStyleBackColor = false;
            this.btnTakeaway.Click += new System.EventHandler(this.button3_Click);
            // 
            // Categoryflowlayout
            // 
            this.Categoryflowlayout.BackColor = System.Drawing.Color.White;
            this.Categoryflowlayout.Controls.Add(this.categorybtn);
            this.Categoryflowlayout.Location = new System.Drawing.Point(5, 122);
            this.Categoryflowlayout.Name = "Categoryflowlayout";
            this.Categoryflowlayout.Size = new System.Drawing.Size(147, 427);
            this.Categoryflowlayout.TabIndex = 4;
            // 
            // categorybtn
            // 
            this.categorybtn.BackColor = System.Drawing.Color.Black;
            this.categorybtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.categorybtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.categorybtn.Location = new System.Drawing.Point(3, 3);
            this.categorybtn.Name = "categorybtn";
            this.categorybtn.Size = new System.Drawing.Size(144, 41);
            this.categorybtn.TabIndex = 0;
            this.categorybtn.Text = "button2";
            this.categorybtn.UseVisualStyleBackColor = false;
            this.categorybtn.Click += new System.EventHandler(this.categorybtn_Click_1);
            // 
            // flowLayoutPanelProducts
            // 
            this.flowLayoutPanelProducts.AutoScroll = true;
            this.flowLayoutPanelProducts.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelProducts.Location = new System.Drawing.Point(158, 122);
            this.flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            this.flowLayoutPanelProducts.Size = new System.Drawing.Size(582, 425);
            this.flowLayoutPanelProducts.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(744, 496);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "TOTAL:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // total
            // 
            this.total.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.total.Location = new System.Drawing.Point(825, 494);
            this.total.Multiline = true;
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(192, 26);
            this.total.TabIndex = 7;
            // 
            // dgvProductSummary
            // 
            this.dgvProductSummary.AllowUserToAddRows = false;
            this.dgvProductSummary.AllowUserToDeleteRows = false;
            this.dgvProductSummary.AllowUserToResizeColumns = false;
            this.dgvProductSummary.AllowUserToResizeRows = false;
            this.dgvProductSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductSummary.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductSummary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProductSummary.ColumnHeadersHeight = 25;
            this.dgvProductSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProductSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvSno,
            this.dgvName,
            this.dgvQuantity,
            this.dgvAmount,
            this.dgvminus});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductSummary.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvProductSummary.EnableHeadersVisualStyles = false;
            this.dgvProductSummary.GridColor = System.Drawing.SystemColors.MenuText;
            this.dgvProductSummary.Location = new System.Drawing.Point(748, 122);
            this.dgvProductSummary.Name = "dgvProductSummary";
            this.dgvProductSummary.ReadOnly = true;
            this.dgvProductSummary.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvProductSummary.RowHeadersVisible = false;
            this.dgvProductSummary.RowHeadersWidth = 500;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver;
            this.dgvProductSummary.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvProductSummary.Size = new System.Drawing.Size(300, 366);
            this.dgvProductSummary.TabIndex = 11;
            // 
            // dgvSno
            // 
            this.dgvSno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvSno.FillWeight = 70F;
            this.dgvSno.HeaderText = "Sr#";
            this.dgvSno.MinimumWidth = 70;
            this.dgvSno.Name = "dgvSno";
            this.dgvSno.ReadOnly = true;
            this.dgvSno.Width = 70;
            // 
            // dgvName
            // 
            this.dgvName.HeaderText = "Name";
            this.dgvName.Name = "dgvName";
            this.dgvName.ReadOnly = true;
            // 
            // dgvQuantity
            // 
            this.dgvQuantity.HeaderText = "Quantity";
            this.dgvQuantity.Name = "dgvQuantity";
            this.dgvQuantity.ReadOnly = true;
            // 
            // dgvAmount
            // 
            this.dgvAmount.HeaderText = "Amount";
            this.dgvAmount.Name = "dgvAmount";
            this.dgvAmount.ReadOnly = true;
            // 
            // assignedtable
            // 
            this.assignedtable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.assignedtable.Location = new System.Drawing.Point(825, 526);
            this.assignedtable.Multiline = true;
            this.assignedtable.Name = "assignedtable";
            this.assignedtable.Size = new System.Drawing.Size(192, 26);
            this.assignedtable.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(744, 527);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "TABLE:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::LOGIN_PAGE.Properties.Resources.delete1;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.Width = 57;
            // 
            // dgvminus
            // 
            this.dgvminus.HeaderText = "";
            this.dgvminus.Image = global::LOGIN_PAGE.Properties.Resources.delete1;
            this.dgvminus.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvminus.Name = "dgvminus";
            this.dgvminus.ReadOnly = true;
            // 
            // BackBtn
            // 
            this.BackBtn.Image = global::LOGIN_PAGE.Properties.Resources.back;
            this.BackBtn.Location = new System.Drawing.Point(0, 0);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(30, 28);
            this.BackBtn.TabIndex = 11;
            this.BackBtn.TabStop = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LOGIN_PAGE.Properties.Resources.pos_terminal1;
            this.pictureBox1.Location = new System.Drawing.Point(41, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(109)))), ((int)(((byte)(140)))));
            this.ClientSize = new System.Drawing.Size(1060, 652);
            this.Controls.Add(this.assignedtable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvProductSummary);
            this.Controls.Add(this.total);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanelProducts);
            this.Controls.Add(this.Categoryflowlayout);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "POS";
            this.Text = "POS";
            this.Load += new System.EventHandler(this.POS_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.Categoryflowlayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDelivery;
        private System.Windows.Forms.Button btnTakeaway;
        private System.Windows.Forms.FlowLayoutPanel Categoryflowlayout;
        private System.Windows.Forms.Button categorybtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProducts;
        private System.Windows.Forms.PictureBox BackBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox total;
        private System.Windows.Forms.DataGridView dgvProductSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAmount;
        private System.Windows.Forms.DataGridViewImageColumn dgvminus;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox assignedtable;
        private System.Windows.Forms.Label label3;
    }
}