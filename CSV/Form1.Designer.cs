namespace CSV
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
            this.label4 = new System.Windows.Forms.Label();
            this.columnsControl = new System.Windows.Forms.NumericUpDown();
            this.recordsControl = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.generateControl = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.columnsControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordsControl)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Number of columns: ";
            // 
            // columnsControl
            // 
            this.columnsControl.Location = new System.Drawing.Point(122, 7);
            this.columnsControl.Name = "columnsControl";
            this.columnsControl.ReadOnly = true;
            this.columnsControl.Size = new System.Drawing.Size(306, 20);
            this.columnsControl.TabIndex = 7;
            // 
            // recordsControl
            // 
            this.recordsControl.Location = new System.Drawing.Point(122, 33);
            this.recordsControl.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.recordsControl.Name = "recordsControl";
            this.recordsControl.Size = new System.Drawing.Size(306, 20);
            this.recordsControl.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of records: ";
            // 
            // generateControl
            // 
            this.generateControl.Location = new System.Drawing.Point(12, 413);
            this.generateControl.Name = "generateControl";
            this.generateControl.Size = new System.Drawing.Size(416, 23);
            this.generateControl.TabIndex = 9;
            this.generateControl.Text = "Generate";
            this.generateControl.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(15, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 348);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(397, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(31, 348);
            this.panel2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 446);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.recordsControl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.generateControl);
            this.Controls.Add(this.columnsControl);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.columnsControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordsControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown columnsControl;
        private System.Windows.Forms.NumericUpDown recordsControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button generateControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

