namespace EJFilter.WinForm
{
    partial class Database
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DBName = new System.Windows.Forms.Label();
            this.DBUser = new System.Windows.Forms.Label();
            this.DBPw = new System.Windows.Forms.Label();
            this.DBNameTxt = new System.Windows.Forms.TextBox();
            this.DBUserTxt = new System.Windows.Forms.TextBox();
            this.DBPwdTxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(36, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(728, 264);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // DBName
            // 
            this.DBName.AutoSize = true;
            this.DBName.Location = new System.Drawing.Point(165, 389);
            this.DBName.Name = "DBName";
            this.DBName.Size = new System.Drawing.Size(125, 20);
            this.DBName.TabIndex = 1;
            this.DBName.Text = "Database Name";
            // 
            // DBUser
            // 
            this.DBUser.AutoSize = true;
            this.DBUser.Location = new System.Drawing.Point(165, 429);
            this.DBUser.Name = "DBUser";
            this.DBUser.Size = new System.Drawing.Size(83, 20);
            this.DBUser.TabIndex = 2;
            this.DBUser.Text = "Username";
            // 
            // DBPw
            // 
            this.DBPw.AutoSize = true;
            this.DBPw.Location = new System.Drawing.Point(165, 470);
            this.DBPw.Name = "DBPw";
            this.DBPw.Size = new System.Drawing.Size(78, 20);
            this.DBPw.TabIndex = 3;
            this.DBPw.Text = "Password";
            // 
            // DBNameTxt
            // 
            this.DBNameTxt.Location = new System.Drawing.Point(317, 386);
            this.DBNameTxt.Name = "DBNameTxt";
            this.DBNameTxt.Size = new System.Drawing.Size(252, 26);
            this.DBNameTxt.TabIndex = 4;
            // 
            // DBUserTxt
            // 
            this.DBUserTxt.Location = new System.Drawing.Point(317, 433);
            this.DBUserTxt.Name = "DBUserTxt";
            this.DBUserTxt.Size = new System.Drawing.Size(252, 26);
            this.DBUserTxt.TabIndex = 5;
            // 
            // DBPwdTxt
            // 
            this.DBPwdTxt.Location = new System.Drawing.Point(317, 474);
            this.DBPwdTxt.Name = "DBPwdTxt";
            this.DBPwdTxt.Size = new System.Drawing.Size(252, 26);
            this.DBPwdTxt.TabIndex = 6;
            this.DBPwdTxt.TextChanged += new System.EventHandler(this.DBPwdTxt_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(287, 533);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(393, 533);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 35);
            this.button2.TabIndex = 8;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(499, 533);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 35);
            this.button3.TabIndex = 9;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 38);
            this.label1.TabIndex = 10;
            this.label1.Text = "Database";
            // 
            // Database
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 613);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DBPwdTxt);
            this.Controls.Add(this.DBUserTxt);
            this.Controls.Add(this.DBNameTxt);
            this.Controls.Add(this.DBPw);
            this.Controls.Add(this.DBUser);
            this.Controls.Add(this.DBName);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Database";
            this.Text = "Database";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label DBName;
        private System.Windows.Forms.Label DBUser;
        private System.Windows.Forms.Label DBPw;
        private System.Windows.Forms.TextBox DBNameTxt;
        private System.Windows.Forms.TextBox DBUserTxt;
        private System.Windows.Forms.TextBox DBPwdTxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
    }
}