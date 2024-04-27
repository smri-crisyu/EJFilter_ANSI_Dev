namespace EJFilter.WinForm
{
    partial class ImportFilesTPLinux
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
            this.UploadDocBtn = new System.Windows.Forms.Button();
            this.BrowseFileBtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Filename = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UploadDocBtn
            // 
            this.UploadDocBtn.Location = new System.Drawing.Point(699, 30);
            this.UploadDocBtn.Name = "UploadDocBtn";
            this.UploadDocBtn.Size = new System.Drawing.Size(161, 45);
            this.UploadDocBtn.TabIndex = 5;
            this.UploadDocBtn.Text = "Upload Document";
            this.UploadDocBtn.UseVisualStyleBackColor = true;
            this.UploadDocBtn.Click += new System.EventHandler(this.UploadDocBtn_Click);
            // 
            // BrowseFileBtn
            // 
            this.BrowseFileBtn.Location = new System.Drawing.Point(518, 30);
            this.BrowseFileBtn.Name = "BrowseFileBtn";
            this.BrowseFileBtn.Size = new System.Drawing.Size(161, 45);
            this.BrowseFileBtn.TabIndex = 4;
            this.BrowseFileBtn.Text = "Browse File";
            this.BrowseFileBtn.UseVisualStyleBackColor = true;
            this.BrowseFileBtn.Click += new System.EventHandler(this.BrowseFileBtn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // Filename
            // 
            this.Filename.AutoSize = true;
            this.Filename.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filename.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Filename.Location = new System.Drawing.Point(26, 107);
            this.Filename.Name = "Filename";
            this.Filename.Size = new System.Drawing.Size(111, 33);
            this.Filename.TabIndex = 7;
            this.Filename.Text = "Filename";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 38);
            this.label1.TabIndex = 8;
            this.label1.Text = "Import Files";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UploadDocBtn);
            this.groupBox1.Controls.Add(this.BrowseFileBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(880, 109);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // ImportFilesTPLinux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 217);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Filename);
            this.Controls.Add(this.groupBox1);
            this.Name = "ImportFilesTPLinux";
            this.Text = "ImportFilesTPLinux";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button UploadDocBtn;
        private System.Windows.Forms.Button BrowseFileBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label Filename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}