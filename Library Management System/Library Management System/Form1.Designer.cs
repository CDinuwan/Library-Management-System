namespace Library_Management_System
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnissue = new System.Windows.Forms.Button();
            this.btnIssued = new System.Windows.Forms.Button();
            this.btnStudent = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnAvailable = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 63);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.btnAvailable);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.btnAll);
            this.panel2.Controls.Add(this.btnStudent);
            this.panel2.Controls.Add(this.btnIssued);
            this.panel2.Controls.Add(this.btnissue);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 521);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(307, 63);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(877, 521);
            this.panel3.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(95, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnissue
            // 
            this.btnissue.BackColor = System.Drawing.Color.Black;
            this.btnissue.FlatAppearance.BorderSize = 0;
            this.btnissue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnissue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnissue.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnissue.ForeColor = System.Drawing.Color.White;
            this.btnissue.Location = new System.Drawing.Point(0, 133);
            this.btnissue.Name = "btnissue";
            this.btnissue.Size = new System.Drawing.Size(307, 51);
            this.btnissue.TabIndex = 1;
            this.btnissue.Text = "DASHBOAD";
            this.btnissue.UseVisualStyleBackColor = false;
            // 
            // btnIssued
            // 
            this.btnIssued.BackColor = System.Drawing.Color.Black;
            this.btnIssued.FlatAppearance.BorderSize = 0;
            this.btnIssued.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnIssued.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssued.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssued.ForeColor = System.Drawing.Color.White;
            this.btnIssued.Location = new System.Drawing.Point(0, 190);
            this.btnIssued.Name = "btnIssued";
            this.btnIssued.Size = new System.Drawing.Size(307, 51);
            this.btnIssued.TabIndex = 2;
            this.btnIssued.Text = "ISSUED BOOKS";
            this.btnIssued.UseVisualStyleBackColor = false;
            // 
            // btnStudent
            // 
            this.btnStudent.BackColor = System.Drawing.Color.Black;
            this.btnStudent.FlatAppearance.BorderSize = 0;
            this.btnStudent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudent.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudent.ForeColor = System.Drawing.Color.White;
            this.btnStudent.Location = new System.Drawing.Point(0, 359);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Size = new System.Drawing.Size(307, 51);
            this.btnStudent.TabIndex = 3;
            this.btnStudent.Text = "STUDENTS";
            this.btnStudent.UseVisualStyleBackColor = false;
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.Black;
            this.btnAll.FlatAppearance.BorderSize = 0;
            this.btnAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.ForeColor = System.Drawing.Color.White;
            this.btnAll.Location = new System.Drawing.Point(0, 247);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(307, 51);
            this.btnAll.TabIndex = 4;
            this.btnAll.Text = "ALL BOOKS";
            this.btnAll.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Black;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(0, 470);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(307, 51);
            this.button5.TabIndex = 5;
            this.button5.Text = "LOGOUT";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnAvailable
            // 
            this.btnAvailable.BackColor = System.Drawing.Color.Black;
            this.btnAvailable.FlatAppearance.BorderSize = 0;
            this.btnAvailable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnAvailable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAvailable.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAvailable.ForeColor = System.Drawing.Color.White;
            this.btnAvailable.Location = new System.Drawing.Point(0, 304);
            this.btnAvailable.Name = "btnAvailable";
            this.btnAvailable.Size = new System.Drawing.Size(307, 51);
            this.btnAvailable.TabIndex = 6;
            this.btnAvailable.Text = "AVAILABLE BOOKS";
            this.btnAvailable.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 584);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAvailable;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnStudent;
        private System.Windows.Forms.Button btnIssued;
        private System.Windows.Forms.Button btnissue;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

