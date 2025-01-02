namespace LOGIN_PAGE
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.USERNAME = new System.Windows.Forms.TextBox();
            this.PASSWORD = new System.Windows.Forms.TextBox();
            this.LOGIN_BTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Maroon;
            this.richTextBox1.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(-2, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(403, 36);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "      RESTAURANT MANAGEMENT SYSTEM";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "USERNAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "PASSWORD";
            // 
            // USERNAME
            // 
            this.USERNAME.BackColor = System.Drawing.Color.Maroon;
            this.USERNAME.Location = new System.Drawing.Point(145, 231);
            this.USERNAME.Multiline = true;
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.Size = new System.Drawing.Size(222, 22);
            this.USERNAME.TabIndex = 3;
            this.USERNAME.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // PASSWORD
            // 
            this.PASSWORD.BackColor = System.Drawing.Color.Maroon;
            this.PASSWORD.Location = new System.Drawing.Point(146, 271);
            this.PASSWORD.Multiline = true;
            this.PASSWORD.Name = "PASSWORD";
            this.PASSWORD.Size = new System.Drawing.Size(222, 22);
            this.PASSWORD.TabIndex = 4;
            // 
            // LOGIN_BTN
            // 
            this.LOGIN_BTN.AutoEllipsis = true;
            this.LOGIN_BTN.BackColor = System.Drawing.Color.Maroon;
            this.LOGIN_BTN.Font = new System.Drawing.Font("Miracle Mercury", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LOGIN_BTN.Image = global::LOGIN_PAGE.Properties.Resources.login;
            this.LOGIN_BTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LOGIN_BTN.Location = new System.Drawing.Point(44, 345);
            this.LOGIN_BTN.Name = "LOGIN_BTN";
            this.LOGIN_BTN.Size = new System.Drawing.Size(318, 46);
            this.LOGIN_BTN.TabIndex = 6;
            this.LOGIN_BTN.Text = "LOGIN";
            this.LOGIN_BTN.UseVisualStyleBackColor = false;
            this.LOGIN_BTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Image = global::LOGIN_PAGE.Properties.Resources.restaurant1;
            this.label3.Location = new System.Drawing.Point(-2, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(403, 132);
            this.label3.TabIndex = 5;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(400, 403);
            this.Controls.Add(this.LOGIN_BTN);
            this.Controls.Add(this.PASSWORD);
            this.Controls.Add(this.USERNAME);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox USERNAME;
        private System.Windows.Forms.TextBox PASSWORD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button LOGIN_BTN;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

