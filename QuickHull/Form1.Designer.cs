
namespace QuickHull
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.QuickHullBtn = new System.Windows.Forms.Button();
            this.MergeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // QuickHullBtn
            // 
            this.QuickHullBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.QuickHullBtn.Location = new System.Drawing.Point(185, 118);
            this.QuickHullBtn.Name = "QuickHullBtn";
            this.QuickHullBtn.Size = new System.Drawing.Size(130, 50);
            this.QuickHullBtn.TabIndex = 0;
            this.QuickHullBtn.Text = "QuickHull";
            this.QuickHullBtn.UseVisualStyleBackColor = true;
            this.QuickHullBtn.Click += new System.EventHandler(this.QuickHullBtn_Click);
            // 
            // MergeBtn
            // 
            this.MergeBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MergeBtn.Location = new System.Drawing.Point(160, 188);
            this.MergeBtn.Name = "MergeBtn";
            this.MergeBtn.Size = new System.Drawing.Size(180, 70);
            this.MergeBtn.TabIndex = 1;
            this.MergeBtn.Text = "Divide and Conquer Merge";
            this.MergeBtn.UseVisualStyleBackColor = true;
            this.MergeBtn.Click += new System.EventHandler(this.MergeBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.MergeBtn);
            this.Controls.Add(this.QuickHullBtn);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button QuickHullBtn;
        private System.Windows.Forms.Button MergeBtn;
    }
}

