using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLNS
{
    public partial class frmHopDong : Form
    {
        public static string quyen;
        public frmHopDong()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet("dsQLHD");
        SqlCommand cmd;
        SqlDataAdapter daNhanVien;
        SqlConnection conn = new SqlConnection(@"Data Source=TIEN-PC\SQLEXPRESS;Initial Catalog=Quanlinhansu;Integrated Security=True");
       // SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-01UK3N8\SQLEXPRESS;Initial Catalog=QLNSu; Integrated Security=True");
        private void ResetTT()
        {
            //Trả thông tin nhập về trống như ban đầu
            txtHanHD.Text = "";
            cboNV.ResetText();
            dtNgayBD.ResetText();
            txtHanHD.Focus();
        }
        private void Connectionsql()
        {
            //Mở kết nối
            conn.Open();
            //lấy dữ liệu trong bản Hợp đồng
            String SQL = "select n.*, c.HoTenNV from HopDong n, NhanVien c where n.manv = c.manv";
            //Bắt đầu truy vấn
            SqlCommand com = new SqlCommand(SQL, conn);
            com.CommandType = CommandType.Text;
            //Chuyển dữ liệu về
            SqlDataAdapter data = new SqlDataAdapter(com);
            //Tạo một kho ảo để lưu trữ dữ liệu
            DataTable dt = new DataTable();
            //Đổ dữ liệu vào kho
            data.Fill(dt);
            //Đóng kết nối
            conn.Close();
            //Đổ dữ liệu vào datagridview
            dtgvDSNV.DataSource = dt;
            //Reset thông tin trên hàng nhập
            txtMaNV.Enabled = false;
            ResetTT();
        }
        private Boolean KiemTraTT()
        {
            //Kiểm tra ngày ký hợp đồng hợp lệ
            if (dtNgayBD.Value > DateTime.Now)
            {
                ResetTT();
                MessageBox.Show("Ngày ký hợp đồng không hợp lệ!", "Thông báo");
                return false;
            }
            //Kiểm tra hạn hợp đồng không bỏ trống
            if (txtHanHD.Text.Trim() == "")
            {
                ResetTT();
                MessageBox.Show("Không được để trống hạn hợp đồng nhân viên!", "Thông báo");
                return false;
            }

            return true;
        }
        private Boolean KiemTraMaNV()
        {
            conn.Open();
            //Kiểm tra xem mã nhân viên này đã có hợp đồng chưa 
            if (txtMaNV.Text.Trim() != "")
            {
                string sql = "Select Count(*) From HopDong Where MaNV ='" + txtMaNV.Text + "'";
                cmd = new SqlCommand(sql, conn);
                int val = (int)cmd.ExecuteScalar();
                if (val > 0)
                {
                    conn.Close();
                    //Nếu có return false
                    return false;
                }
            }
            conn.Close();
            //Nếu chưa return true
            return true;
        }
        public void loadDataGirdView()
        {
            string query = "select nv.MaNV, nv.HoTenNV, cv.TenCV, pb.TenPB, l.Thuong, l.PhuCap, l.LuongCB, l.HSL, l.KiLuat, l.GhiChu from NhanVien nv, ChucVu cv, PhongBan pb, Luong l where nv.MaCV=cv.MaCV and nv.MaPB=pb.MaPB and nv.MaNV=l.MaNV";
            dtgvDSNV.DataSource = DataProvider.Instance.ExcuteQuery(query);
        }
        private void frmHopDong_Load(object sender, EventArgs e)
        {
            Connectionsql();
            // Dữ liệu combobox nhân viên
            string sQueryNhanVien = @"select * from NhanVien";
            daNhanVien = new SqlDataAdapter(sQueryNhanVien, conn);
            daNhanVien.Fill(ds, "tblNhanVien");
            cboNV.DataSource = ds.Tables["tblNhanVien"];
            cboNV.DisplayMember = "HoTenNV";
            cboNV.ValueMember = "MaNV";
            txtMaNV.Text = cboNV.SelectedValue.ToString();
            SetHeaderText();
        }

        private void cboNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Khi thay đổi combobox tên NV thì textbox mã NV thay đổi theo
            txtMaNV.Text = cboNV.SelectedValue.ToString();
        }

        public void btnXoa_Click(object sender, EventArgs e)
        {
            if (quyen == "1")
            {
                if (KiemTraMaNV() == true)
                    MessageBox.Show("Nhân viên này chưa có hợp đồng, không thể xóa!", "Thông báo");
                else
                {
                    //Câu lệnh xóa
                    string sql = "delete from HopDong ";
                    sql += "where MaNV = '" + txtMaNV.Text + "'";
                    //Thực thi lệnh
                    conn.Open();
                    var cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Connectionsql();
                    MessageBox.Show("Xóa thành công !!!");
                }
            }
            else { MessageBox.Show("Bạn không có quyền xóa !!!"); }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dtNgayBD.Format = DateTimePickerFormat.Custom;
            dtNgayBD.CustomFormat = "yyyy/MM/dd";
            
            if (KiemTraTT() == true)
                if (KiemTraMaNV() == false)
                    MessageBox.Show("Nhân viên này đã có hợp đồng!", "Thông báo");
                else
                {
                    //Lưu biến tạm thời
                    string nbd = dtNgayBD.Value.ToString("yyyy/MM/dd");
                    //Các thông tin nhân viên cần thêm
                    string sql = "insert into HopDong(MaHD,NgayBD,HanHD,MaNV) values (";
                    sql += "'" + txtMaHD.Text + "'";
                    sql += ",'" + nbd + "'";
                    sql += ",'" + txtHanHD.Text + "'";
                    sql += ",'" + txtMaNV.Text + "')";
                    //Thực thi lệnh
                    conn.Open();
                    var cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Connectionsql();
                    MessageBox.Show("Thêm thành công !!!");
                }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KiemTraTT() == true)
                if (KiemTraMaNV() == true)
                    MessageBox.Show("Nhân viên này chưa có hợp đồng, không thể sửa, hãy thêm hợp đồng!", "Thông báo");
                else
                {
                    //Lưu biến tạm thời
                    string nbd = dtNgayBD.Value.ToString("yyyy/MM/dd");
                    //Các thông tin nhân viên cần thêm
                    string sql = "Update HopDong SET ";
                    sql += "MaHD ='" + txtMaHD.Text + "'";
                    sql += ",NgayBD = '" + nbd + "'";
                    sql += ", HanHD = " + txtHanHD.Text;
                    sql += " Where MaNV = '" + txtMaNV.Text + "'";
                    //Thực thi lệnh
                    conn.Open();
                    var cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Connectionsql();
                    MessageBox.Show("Sửa thành công !!!");
                }
        }

        private void dtgvDSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string nbd = dtNgayBD.Value.ToString("yyyy/MM/dd");
            int i = e.RowIndex;
            txtMaHD.Text = dtgvDSNV.Rows[i].Cells["MaHD"].Value.ToString();
            txtMaNV.Text = dtgvDSNV.Rows[i].Cells["MaNV"].Value.ToString();
            cboNV.Text = dtgvDSNV.Rows[i].Cells["HoTenNV"].Value.ToString();
            txtHanHD.Text = dtgvDSNV.Rows[i].Cells["HanHD"].Value.ToString();
            dtNgayBD.Text = dtgvDSNV.Rows[i].Cells["NgayBD"].Value.ToString();
        }
        void SetHeaderText()
        {
            //đặt tên cột
            dtgvDSNV.Columns["MaHD"].HeaderText = "Mã hợp đồng";
            dtgvDSNV.Columns["NgayBD"].HeaderText = "Ngày bắt đầu";
            dtgvDSNV.Columns["HanHD"].HeaderText = "Hạn HĐ";
            dtgvDSNV.Columns["MaNV"].HeaderText = "Mã NV";
            dtgvDSNV.Columns["HoTenNV"].HeaderText = "Tên NV";
        }

        private void txtMaHD_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = "HD";
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if ((txtTimKiem.Text == "") || (txtTimKiem.Text == "Nhập thông tin tìm kiếm"))
            {
                MessageBox.Show("Bạn chưa nhập thông tin cần tìm", "THÔNG BÁO");
                txtTimKiem.Focus();
            }
            else
            {
                if (radMaNV.Checked == true)
                {
                    string query = "select * from HopDong where MaNV like N'%" + txtTimKiem.Text + "%'";
                    dtgvDSNV.DataSource = DataProvider.Instance.ExcuteQuery(query);

                }
                else if (radHoTen.Checked == true)
                {
                    string query = "select hd.*, nv.HoTenNV from NhanVien nv,HopDong hd where nv.MaNV=hd.MaNV and nv.HoTenNV like N'%" + txtTimKiem.Text + "%'";
                    dtgvDSNV.DataSource = DataProvider.Instance.ExcuteQuery(query);
                }
                else
                    MessageBox.Show("Không tìm thấy thông tin", "THÔNG BÁO");
            }
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
        }
    }
}
