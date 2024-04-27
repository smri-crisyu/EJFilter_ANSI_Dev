namespace EJFilter.WinForm
{
    partial class HeaderFooterVQPBOS
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
            this.Location = new System.Windows.Forms.Label();
            this.Address1Txt = new System.Windows.Forms.TextBox();
            this.ZipCode = new System.Windows.Forms.Label();
            this.ZipLocTxt = new System.Windows.Forms.TextBox();
            this.VatRegTinH = new System.Windows.Forms.Label();
            this.VatRegTin_HTxt = new System.Windows.Forms.TextBox();
            this.POSNoTxt = new System.Windows.Forms.TextBox();
            this.SerialNo = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.BranchCmb = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.StoreCmb = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TypeCmb = new System.Windows.Forms.ComboBox();
            this.VatRegTinF = new System.Windows.Forms.Label();
            this.VatRegTin_FTxt = new System.Windows.Forms.TextBox();
            this.AccrNo = new System.Windows.Forms.Label();
            this.AccrNoTxt = new System.Windows.Forms.TextBox();
            this.AccrNo2Txt = new System.Windows.Forms.TextBox();
            this.Date = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Company = new System.Windows.Forms.Label();
            this.DateFrom = new System.Windows.Forms.DateTimePicker();
            this.DateTo = new System.Windows.Forms.DateTimePicker();
            this.PosNo = new System.Windows.Forms.Label();
            this.SerialNoTxt = new System.Windows.Forms.TextBox();
            this.PermitNo = new System.Windows.Forms.Label();
            this.PermitNoTxt = new System.Windows.Forms.TextBox();
            this.MinNo = new System.Windows.Forms.Label();
            this.MinNoTxt = new System.Windows.Forms.TextBox();
            this.Address2Txt = new System.Windows.Forms.TextBox();
            this.Address3Txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ZipCodeTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CompanyCmb = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1217, 252);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Location
            // 
            this.Location.AutoSize = true;
            this.Location.Location = new System.Drawing.Point(14, 39);
            this.Location.Name = "Location";
            this.Location.Size = new System.Drawing.Size(68, 20);
            this.Location.TabIndex = 6;
            this.Location.Text = "Address";
            // 
            // Address1Txt
            // 
            this.Address1Txt.Location = new System.Drawing.Point(117, 39);
            this.Address1Txt.Name = "Address1Txt";
            this.Address1Txt.Size = new System.Drawing.Size(193, 26);
            this.Address1Txt.TabIndex = 7;
            // 
            // ZipCode
            // 
            this.ZipCode.AutoSize = true;
            this.ZipCode.Location = new System.Drawing.Point(7, 82);
            this.ZipCode.Name = "ZipCode";
            this.ZipCode.Size = new System.Drawing.Size(96, 20);
            this.ZipCode.TabIndex = 8;
            this.ZipCode.Text = "Zip Location";
            // 
            // ZipLocTxt
            // 
            this.ZipLocTxt.Location = new System.Drawing.Point(117, 83);
            this.ZipLocTxt.Name = "ZipLocTxt";
            this.ZipLocTxt.Size = new System.Drawing.Size(315, 26);
            this.ZipLocTxt.TabIndex = 9;
            // 
            // VatRegTinH
            // 
            this.VatRegTinH.AutoSize = true;
            this.VatRegTinH.Location = new System.Drawing.Point(7, 119);
            this.VatRegTinH.Name = "VatRegTinH";
            this.VatRegTinH.Size = new System.Drawing.Size(97, 60);
            this.VatRegTinH.TabIndex = 10;
            this.VatRegTinH.Text = "Vat Reg TIN\r\n(Header)\r\n\r\n";
            // 
            // VatRegTin_HTxt
            // 
            this.VatRegTin_HTxt.Location = new System.Drawing.Point(117, 119);
            this.VatRegTin_HTxt.Name = "VatRegTin_HTxt";
            this.VatRegTin_HTxt.Size = new System.Drawing.Size(232, 26);
            this.VatRegTin_HTxt.TabIndex = 11;
            // 
            // POSNoTxt
            // 
            this.POSNoTxt.Location = new System.Drawing.Point(434, 122);
            this.POSNoTxt.Name = "POSNoTxt";
            this.POSNoTxt.Size = new System.Drawing.Size(107, 26);
            this.POSNoTxt.TabIndex = 13;
            // 
            // SerialNo
            // 
            this.SerialNo.AutoSize = true;
            this.SerialNo.Location = new System.Drawing.Point(547, 122);
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.Size = new System.Drawing.Size(77, 20);
            this.SerialNo.TabIndex = 14;
            this.SerialNo.Text = "Serial No.";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(117, 212);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 35);
            this.button2.TabIndex = 21;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(301, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Branch";
            // 
            // BranchCmb
            // 
            this.BranchCmb.FormattingEnabled = true;
            this.BranchCmb.Location = new System.Drawing.Point(362, 33);
            this.BranchCmb.Name = "BranchCmb";
            this.BranchCmb.Size = new System.Drawing.Size(179, 28);
            this.BranchCmb.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(551, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = "Store";
            // 
            // StoreCmb
            // 
            this.StoreCmb.FormattingEnabled = true;
            this.StoreCmb.Location = new System.Drawing.Point(605, 33);
            this.StoreCmb.Name = "StoreCmb";
            this.StoreCmb.Size = new System.Drawing.Size(177, 28);
            this.StoreCmb.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(42, 324);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 20);
            this.label12.TabIndex = 26;
            this.label12.Text = "ConfigType";
            // 
            // TypeCmb
            // 
            this.TypeCmb.FormattingEnabled = true;
            this.TypeCmb.Location = new System.Drawing.Point(117, 33);
            this.TypeCmb.Name = "TypeCmb";
            this.TypeCmb.Size = new System.Drawing.Size(162, 28);
            this.TypeCmb.TabIndex = 27;
            // 
            // VatRegTinF
            // 
            this.VatRegTinF.AutoSize = true;
            this.VatRegTinF.Location = new System.Drawing.Point(788, 36);
            this.VatRegTinF.Name = "VatRegTinF";
            this.VatRegTinF.Size = new System.Drawing.Size(97, 40);
            this.VatRegTinF.TabIndex = 28;
            this.VatRegTinF.Text = "Vat Reg TIN\r\n(Footer)\r\n";
            // 
            // VatRegTin_FTxt
            // 
            this.VatRegTin_FTxt.Location = new System.Drawing.Point(891, 36);
            this.VatRegTin_FTxt.Name = "VatRegTin_FTxt";
            this.VatRegTin_FTxt.Size = new System.Drawing.Size(308, 26);
            this.VatRegTin_FTxt.TabIndex = 29;
            // 
            // AccrNo
            // 
            this.AccrNo.AutoSize = true;
            this.AccrNo.Location = new System.Drawing.Point(795, 86);
            this.AccrNo.Name = "AccrNo";
            this.AccrNo.Size = new System.Drawing.Size(69, 20);
            this.AccrNo.TabIndex = 30;
            this.AccrNo.Text = "Accr No.";
            // 
            // AccrNoTxt
            // 
            this.AccrNoTxt.Location = new System.Drawing.Point(891, 89);
            this.AccrNoTxt.Name = "AccrNoTxt";
            this.AccrNoTxt.Size = new System.Drawing.Size(211, 26);
            this.AccrNoTxt.TabIndex = 31;
            // 
            // AccrNo2Txt
            // 
            this.AccrNo2Txt.Location = new System.Drawing.Point(1108, 89);
            this.AccrNo2Txt.Name = "AccrNo2Txt";
            this.AccrNo2Txt.Size = new System.Drawing.Size(91, 26);
            this.AccrNo2Txt.TabIndex = 32;
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Location = new System.Drawing.Point(790, 125);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(85, 20);
            this.Date.TabIndex = 33;
            this.Date.Text = "Date From";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(219, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 35);
            this.button1.TabIndex = 35;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(332, 212);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 35);
            this.button3.TabIndex = 36;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // Company
            // 
            this.Company.AutoSize = true;
            this.Company.Location = new System.Drawing.Point(788, 33);
            this.Company.Name = "Company";
            this.Company.Size = new System.Drawing.Size(76, 20);
            this.Company.TabIndex = 37;
            this.Company.Text = "Company";
            // 
            // DateFrom
            // 
            this.DateFrom.CustomFormat = "MM/dd/yy";
            this.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateFrom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DateFrom.Location = new System.Drawing.Point(891, 125);
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.Size = new System.Drawing.Size(308, 26);
            this.DateFrom.TabIndex = 40;
            this.DateFrom.Value = new System.DateTime(2023, 12, 15, 0, 0, 0, 0);
            // 
            // DateTo
            // 
            this.DateTo.CustomFormat = "MM/dd/yy";
            this.DateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTo.Location = new System.Drawing.Point(891, 164);
            this.DateTo.Name = "DateTo";
            this.DateTo.Size = new System.Drawing.Size(308, 26);
            this.DateTo.TabIndex = 40;
            this.DateTo.Value = new System.DateTime(2023, 12, 15, 0, 0, 0, 0);
            // 
            // PosNo
            // 
            this.PosNo.AutoSize = true;
            this.PosNo.Location = new System.Drawing.Point(358, 125);
            this.PosNo.Name = "PosNo";
            this.PosNo.Size = new System.Drawing.Size(70, 20);
            this.PosNo.TabIndex = 12;
            this.PosNo.Text = "POS No.";
            // 
            // SerialNoTxt
            // 
            this.SerialNoTxt.Location = new System.Drawing.Point(630, 119);
            this.SerialNoTxt.Name = "SerialNoTxt";
            this.SerialNoTxt.Size = new System.Drawing.Size(130, 26);
            this.SerialNoTxt.TabIndex = 15;
            // 
            // PermitNo
            // 
            this.PermitNo.AutoSize = true;
            this.PermitNo.Location = new System.Drawing.Point(6, 179);
            this.PermitNo.Name = "PermitNo";
            this.PermitNo.Size = new System.Drawing.Size(82, 20);
            this.PermitNo.TabIndex = 16;
            this.PermitNo.Text = "Permit No.";
            // 
            // PermitNoTxt
            // 
            this.PermitNoTxt.Location = new System.Drawing.Point(117, 163);
            this.PermitNoTxt.Name = "PermitNoTxt";
            this.PermitNoTxt.Size = new System.Drawing.Size(322, 26);
            this.PermitNoTxt.TabIndex = 17;
            // 
            // MinNo
            // 
            this.MinNo.AutoSize = true;
            this.MinNo.Location = new System.Drawing.Point(445, 163);
            this.MinNo.Name = "MinNo";
            this.MinNo.Size = new System.Drawing.Size(66, 20);
            this.MinNo.TabIndex = 18;
            this.MinNo.Text = "MIN No.";
            // 
            // MinNoTxt
            // 
            this.MinNoTxt.Location = new System.Drawing.Point(503, 163);
            this.MinNoTxt.Name = "MinNoTxt";
            this.MinNoTxt.Size = new System.Drawing.Size(261, 26);
            this.MinNoTxt.TabIndex = 19;
            // 
            // Address2Txt
            // 
            this.Address2Txt.Location = new System.Drawing.Point(316, 39);
            this.Address2Txt.Name = "Address2Txt";
            this.Address2Txt.Size = new System.Drawing.Size(191, 26);
            this.Address2Txt.TabIndex = 43;
            // 
            // Address3Txt
            // 
            this.Address3Txt.Location = new System.Drawing.Point(513, 39);
            this.Address3Txt.Name = "Address3Txt";
            this.Address3Txt.Size = new System.Drawing.Size(251, 26);
            this.Address3Txt.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 45;
            this.label2.Text = "Zip Code";
            // 
            // ZipCodeTxt
            // 
            this.ZipCodeTxt.Location = new System.Drawing.Point(513, 83);
            this.ZipCodeTxt.Name = "ZipCodeTxt";
            this.ZipCodeTxt.Size = new System.Drawing.Size(251, 26);
            this.ZipCodeTxt.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(788, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 47;
            this.label1.Text = "Date To";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ExportBtn);
            this.groupBox1.Controls.Add(this.AccrNo2Txt);
            this.groupBox1.Controls.Add(this.DateTo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DateFrom);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.ZipCodeTxt);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Date);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.AccrNoTxt);
            this.groupBox1.Controls.Add(this.Address3Txt);
            this.groupBox1.Controls.Add(this.AccrNo);
            this.groupBox1.Controls.Add(this.Location);
            this.groupBox1.Controls.Add(this.VatRegTin_FTxt);
            this.groupBox1.Controls.Add(this.Address2Txt);
            this.groupBox1.Controls.Add(this.VatRegTinF);
            this.groupBox1.Controls.Add(this.Address1Txt);
            this.groupBox1.Controls.Add(this.ZipCode);
            this.groupBox1.Controls.Add(this.MinNoTxt);
            this.groupBox1.Controls.Add(this.ZipLocTxt);
            this.groupBox1.Controls.Add(this.MinNo);
            this.groupBox1.Controls.Add(this.VatRegTinH);
            this.groupBox1.Controls.Add(this.PermitNoTxt);
            this.groupBox1.Controls.Add(this.VatRegTin_HTxt);
            this.groupBox1.Controls.Add(this.PermitNo);
            this.groupBox1.Controls.Add(this.PosNo);
            this.groupBox1.Controls.Add(this.SerialNoTxt);
            this.groupBox1.Controls.Add(this.POSNoTxt);
            this.groupBox1.Controls.Add(this.SerialNo);
            this.groupBox1.Location = new System.Drawing.Point(28, 380);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1217, 283);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            // 
            // ExportBtn
            // 
            this.ExportBtn.Location = new System.Drawing.Point(434, 214);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(138, 35);
            this.ExportBtn.TabIndex = 91;
            this.ExportBtn.Text = "Export to CSV";
            this.ExportBtn.UseVisualStyleBackColor = true;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CompanyCmb);
            this.groupBox2.Controls.Add(this.TypeCmb);
            this.groupBox2.Controls.Add(this.BranchCmb);
            this.groupBox2.Controls.Add(this.StoreCmb);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.Company);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(28, 291);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1217, 83);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            // 
            // CompanyCmb
            // 
            this.CompanyCmb.FormattingEnabled = true;
            this.CompanyCmb.Location = new System.Drawing.Point(870, 30);
            this.CompanyCmb.Name = "CompanyCmb";
            this.CompanyCmb.Size = new System.Drawing.Size(341, 28);
            this.CompanyCmb.TabIndex = 38;
            // 
            // HeaderFooterVQPBOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 737);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "HeaderFooterVQPBOS";
            this.Text = "HeaderFooter";
            this.Load += new System.EventHandler(this.HeaderFooterVQPBOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label Location;
        private System.Windows.Forms.TextBox Address1Txt;
        private System.Windows.Forms.Label ZipCode;
        private System.Windows.Forms.TextBox ZipLocTxt;
        private System.Windows.Forms.Label VatRegTinH;
        private System.Windows.Forms.TextBox VatRegTin_HTxt;
        private System.Windows.Forms.TextBox POSNoTxt;
        private System.Windows.Forms.Label SerialNo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox BranchCmb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox StoreCmb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox TypeCmb;
        private System.Windows.Forms.Label VatRegTinF;
        private System.Windows.Forms.TextBox VatRegTin_FTxt;
        private System.Windows.Forms.Label AccrNo;
        private System.Windows.Forms.TextBox AccrNoTxt;
        private System.Windows.Forms.TextBox AccrNo2Txt;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label Company;
        private System.Windows.Forms.DateTimePicker DateFrom;
        private System.Windows.Forms.DateTimePicker DateTo;
        private System.Windows.Forms.Label PosNo;
        private System.Windows.Forms.TextBox SerialNoTxt;
        private System.Windows.Forms.Label PermitNo;
        private System.Windows.Forms.TextBox PermitNoTxt;
        private System.Windows.Forms.Label MinNo;
        private System.Windows.Forms.TextBox MinNoTxt;
        private System.Windows.Forms.TextBox Address2Txt;
        private System.Windows.Forms.TextBox Address3Txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ZipCodeTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CompanyCmb;
        private System.Windows.Forms.Button ExportBtn;
    }
}