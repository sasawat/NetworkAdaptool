namespace NetworkAdaptool
{
    partial class ProfileNaming
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
            this.tbxProfileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLetsGo = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxProfileName
            // 
            this.tbxProfileName.Location = new System.Drawing.Point(54, 13);
            this.tbxProfileName.Name = "tbxProfileName";
            this.tbxProfileName.Size = new System.Drawing.Size(422, 20);
            this.tbxProfileName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // btnLetsGo
            // 
            this.btnLetsGo.Location = new System.Drawing.Point(16, 41);
            this.btnLetsGo.Name = "btnLetsGo";
            this.btnLetsGo.Size = new System.Drawing.Size(236, 23);
            this.btnLetsGo.TabIndex = 2;
            this.btnLetsGo.Text = "Confirm";
            this.btnLetsGo.UseVisualStyleBackColor = true;
            this.btnLetsGo.Click += new System.EventHandler(this.btnLetsGo_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(259, 40);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(217, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ProfileNaming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 76);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLetsGo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxProfileName);
            this.Name = "ProfileNaming";
            this.Text = "ProfileNaming";
            this.Load += new System.EventHandler(this.ProfileNaming_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxProfileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLetsGo;
        private System.Windows.Forms.Button btnCancel;
    }
}