namespace AnimeForm
{
    partial class SortOrderForm
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
            this.labelQuestion = new System.Windows.Forms.Label();
            this.btnAscending = new System.Windows.Forms.Button();
            this.btnDescending = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Location = new System.Drawing.Point(12, 15);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(0, 13);
            this.labelQuestion.TabIndex = 0;
            // 
            // btnAscending
            // 
            this.btnAscending.Location = new System.Drawing.Point(15, 40);
            this.btnAscending.Name = "btnAscending";
            this.btnAscending.Size = new System.Drawing.Size(120, 30);
            this.btnAscending.TabIndex = 1;
            this.btnAscending.Text = "По возрастанию (↑)";
            this.btnAscending.UseVisualStyleBackColor = true;
            this.btnAscending.Click += new System.EventHandler(this.btnAscending_Click);
            // 
            // btnDescending
            // 
            this.btnDescending.Location = new System.Drawing.Point(15, 76);
            this.btnDescending.Name = "btnDescending";
            this.btnDescending.Size = new System.Drawing.Size(120, 30);
            this.btnDescending.TabIndex = 2;
            this.btnDescending.Text = "По убыванию (↓)";
            this.btnDescending.UseVisualStyleBackColor = true;
            this.btnDescending.Click += new System.EventHandler(this.btnDescending_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(15, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // SortOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(156, 184);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDescending);
            this.Controls.Add(this.btnAscending);
            this.Controls.Add(this.labelQuestion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SortOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Сортировка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Button btnAscending;
        private System.Windows.Forms.Button btnDescending;
        private System.Windows.Forms.Button btnCancel;
    }
}
