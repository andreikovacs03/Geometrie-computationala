
namespace QuickHull
{
    partial class QuickHullForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.RandomBtn = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Info;
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Controls.Add(this.RandomBtn);
            this.flowLayoutPanel1.Controls.Add(this.textBox2);
            this.flowLayoutPanel1.Controls.Add(this.GenerateBtn);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(666, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(106, 174);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Number of points";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 1;
            // 
            // RandomBtn
            // 
            this.RandomBtn.Location = new System.Drawing.Point(3, 32);
            this.RandomBtn.Name = "RandomBtn";
            this.RandomBtn.Size = new System.Drawing.Size(100, 23);
            this.RandomBtn.TabIndex = 0;
            this.RandomBtn.Text = "Random";
            this.RandomBtn.UseVisualStyleBackColor = true;
            this.RandomBtn.Click += new System.EventHandler(this.RandomBtn_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(3, 61);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.PlaceholderText = "Point coordinates on each line";
            this.textBox2.Size = new System.Drawing.Size(100, 78);
            this.textBox2.TabIndex = 2;
            // 
            // GenerateBtn
            // 
            this.GenerateBtn.Location = new System.Drawing.Point(3, 145);
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.Size = new System.Drawing.Size(103, 23);
            this.GenerateBtn.TabIndex = 3;
            this.GenerateBtn.Text = "Generate";
            this.GenerateBtn.UseVisualStyleBackColor = true;
            this.GenerateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.Color.White;
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(784, 681);
            this.Canvas.TabIndex = 1;
            this.Canvas.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.Canvas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 681);
            this.panel1.TabIndex = 2;
            // 
            // QuickHullForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 681);
            this.Controls.Add(this.panel1);
            this.Name = "QuickHullForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuickHullForm";
            this.Load += new System.EventHandler(this.QuickHullForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button RandomBtn;
        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button GenerateBtn;
    }
}