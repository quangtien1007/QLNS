namespace QLNS
{
    partial class frmHopDong
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
            this.grbThongTin = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtNgayBD = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHanHD = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtgvDSNV = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.gbChon = new System.Windows.Forms.GroupBox();
            this.radHoTen = new System.Windows.Forms.RadioButton();
            this.radMaNV = new System.Windows.Forms.RadioButton();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.grbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDSNV)).BeginInit();
            this.gbChon.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbThongTin
            // 
            this.grbThongTin.Controls.Add(this.label5);
            this.grbThongTin.Controls.Add(this.txtMaHD);
            this.grbThongTin.Controls.Add(this.btnThem);
            this.grbThongTin.Controls.Add(this.cboNV);
            this.grbThongTin.Controls.Add(this.btnSua);
            this.grbThongTin.Controls.Add(this.txtMaNV);
            this.grbThongTin.Controls.Add(this.btnXoa);
            this.grbThongTin.Controls.Add(this.label4);
            this.grbThongTin.Controls.Add(this.dtNgayBD);
            this.grbThongTin.Controls.Add(this.label1);
            this.grbThongTin.Controls.Add(this.label2);
            this.grbThongTin.Controls.Add(this.txtHanHD);
            this.grbThongTin.Controls.Add(this.label8);
            this.grbThongTin.ForeColor = System.Drawing.Color.Black;
            this.grbThongTin.Location = new System.Drawing.Point(12, 93);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Size = new System.Drawing.Size(332, 391);
            this.grbThongTin.TabIndex = 23;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Nhập thông tin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 19);
            this.label5.TabIndex = 34;
            this.label5.Text = "Mã hợp dồng";
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(139, 209);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(166, 26);
            this.txtMaHD.TabIndex = 33;
            this.txtMaHD.Click += new System.EventHandler(this.txtMaHD_Click);
            // 
            // btnThem
            // 
            this.btnThem.Image = global::QLNS.Properties.Resources.Itweek_Knob_Toolbar_Knob_Add;
            this.btnThem.Location = new System.Drawing.Point(6, 279);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(102, 42);
            this.btnThem.TabIndex = 30;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cboNV
            // 
            this.cboNV.FormattingEnabled = true;
            this.cboNV.Location = new System.Drawing.Point(139, 77);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(166, 27);
            this.cboNV.TabIndex = 29;
            this.cboNV.SelectedIndexChanged += new System.EventHandler(this.cboNV_SelectedIndexChanged);
            // 
            // btnSua
            // 
            this.btnSua.Image = global::QLNS.Properties.Resources.adjust;
            this.btnSua.Location = new System.Drawing.Point(114, 278);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(102, 43);
            this.btnSua.TabIndex = 31;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // txtMaNV
            // 
            this.txtMaNV.BackColor = System.Drawing.SystemColors.Window;
            this.txtMaNV.Location = new System.Drawing.Point(139, 31);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(166, 26);
            this.txtMaNV.TabIndex = 21;
            // 
            // btnXoa
            // 
            this.btnXoa.Image = global::QLNS.Properties.Resources.garbage_bin_10420;
            this.btnXoa.Location = new System.Drawing.Point(222, 279);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(102, 44);
            this.btnXoa.TabIndex = 32;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(18, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "Tên nhân viên";
            // 
            // dtNgayBD
            // 
            this.dtNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayBD.Location = new System.Drawing.Point(139, 167);
            this.dtNgayBD.Name = "dtNgayBD";
            this.dtNgayBD.Size = new System.Drawing.Size(166, 26);
            this.dtNgayBD.TabIndex = 17;
            this.dtNgayBD.Value = new System.DateTime(2021, 12, 22, 19, 22, 25, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(18, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hạn hợp đồng";
            // 
            // txtHanHD
            // 
            this.txtHanHD.BackColor = System.Drawing.SystemColors.Window;
            this.txtHanHD.Location = new System.Drawing.Point(139, 123);
            this.txtHanHD.Name = "txtHanHD";
            this.txtHanHD.Size = new System.Drawing.Size(166, 26);
            this.txtHanHD.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(22, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 19);
            this.label8.TabIndex = 8;
            this.label8.Text = "Ngày bắt đầu";
            // 
            // dtgvDSNV
            // 
            this.dtgvDSNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgvDSNV.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvDSNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDSNV.Location = new System.Drawing.Point(354, 173);
            this.dtgvDSNV.Name = "dtgvDSNV";
            this.dtgvDSNV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvDSNV.Size = new System.Drawing.Size(611, 311);
            this.dtgvDSNV.TabIndex = 26;
            this.dtgvDSNV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDSNV_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LimeGreen;
            this.label3.Location = new System.Drawing.Point(348, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(293, 31);
            this.label3.TabIndex = 27;
            this.label3.Text = "QUẢN LÝ HỢP ĐỒNG";
            // 
            // gbChon
            // 
            this.gbChon.BackColor = System.Drawing.Color.Transparent;
            this.gbChon.Controls.Add(this.radHoTen);
            this.gbChon.Controls.Add(this.radMaNV);
            this.gbChon.Controls.Add(this.txtTimKiem);
            this.gbChon.Controls.Add(this.btnTim);
            this.gbChon.Location = new System.Drawing.Point(354, 101);
            this.gbChon.Name = "gbChon";
            this.gbChon.Size = new System.Drawing.Size(409, 66);
            this.gbChon.TabIndex = 28;
            this.gbChon.TabStop = false;
            this.gbChon.Text = "Tìm kiếm";
            // 
            // radHoTen
            // 
            this.radHoTen.AutoSize = true;
            this.radHoTen.BackColor = System.Drawing.Color.Transparent;
            this.radHoTen.Location = new System.Drawing.Point(261, 20);
            this.radHoTen.Name = "radHoTen";
            this.radHoTen.Size = new System.Drawing.Size(68, 23);
            this.radHoTen.TabIndex = 4;
            this.radHoTen.TabStop = true;
            this.radHoTen.Text = "Họ tên";
            this.radHoTen.UseVisualStyleBackColor = false;
            // 
            // radMaNV
            // 
            this.radMaNV.AutoSize = true;
            this.radMaNV.BackColor = System.Drawing.Color.Transparent;
            this.radMaNV.Location = new System.Drawing.Point(180, 21);
            this.radMaNV.Name = "radMaNV";
            this.radMaNV.Size = new System.Drawing.Size(75, 23);
            this.radMaNV.TabIndex = 3;
            this.radMaNV.TabStop = true;
            this.radMaNV.Text = "Mã NV";
            this.radMaNV.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(6, 24);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(168, 26);
            this.txtTimKiem.TabIndex = 17;
            this.txtTimKiem.Text = "Nhập thông tin tìm kiếm";
            this.txtTimKiem.Click += new System.EventHandler(this.txtTimKiem_Click);
            // 
            // btnTim
            // 
            this.btnTim.Image = global::QLNS.Properties.Resources.Itweek_Knob_Toolbar_Knob_Search;
            this.btnTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTim.Location = new System.Drawing.Point(335, 16);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(67, 43);
            this.btnTim.TabIndex = 18;
            this.btnTim.Text = "Tìm";
            this.btnTim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // frmHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 519);
            this.Controls.Add(this.gbChon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtgvDSNV);
            this.Controls.Add(this.grbThongTin);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHopDong";
            this.Load += new System.EventHandler(this.frmHopDong_Load);
            this.grbThongTin.ResumeLayout(false);
            this.grbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDSNV)).EndInit();
            this.gbChon.ResumeLayout(false);
            this.gbChon.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtNgayBD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHanHD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dtgvDSNV;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.GroupBox gbChon;
        private System.Windows.Forms.RadioButton radHoTen;
        private System.Windows.Forms.RadioButton radMaNV;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTim;
    }
}