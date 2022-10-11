using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace QLNS
{
    public partial class frmNhanSu : Form
    {
        public frmNhanSu()
        {
            InitializeComponent();
        }

        //SqlConnection conn;
        SqlCommand cmd;
        SqlConnection conn = new SqlConnection(@"Data Source=TIEN-PC\SQLEXPRESS;Initial Catalog=Quanlinhansu;Integrated Security=True");
        // SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-01UK3N8\SQLEXPRESS;Initial Catalog=QLNSu; Integrated Security=True");

        private void LamMoi()
        {
            foreach (Control ctr in this.gbThongTin.Controls)
            {
                if (ctr is TextBox)
                    ctr.Text = "";
                if (ctr is ComboBox || ctr is DateTimePicker)
                    ctr.ResetText();
            }
            radNam.Checked = false;
            radNu.Checked = false;
            txtMaNV.Focus();
        }

        private Boolean KTThongTin()
        {
            //Kiểm tra tên không bỏ trống
            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Họ tên nhân viên không được trống", "THÔNG BÁO");
                txtHoTen.Focus();
                return false;
            }
            //Kiểm tra ngày sinh hợp lệ
            if (dtpNgaySinh.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không hợp lệ", "THÔNG BÁO");
                return false;
            }
            //Kiểm tra địa chỉ không bỏ trống
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ không được trống", "THÔNG BÁO");
                txtDiaChi.Focus();
                return false;
            }
            //Kiểm tra sdt không bỏ trống
            if (txtSDT.Text.Trim() == "")
            {
                MessageBox.Show("Số điện thoại không được trống", "THÔNG BÁO");
                txtSDT.Focus();
                return false;
            }
            else
            {
                Regex reg = new Regex(@"0(\d{9})");
                if (reg.IsMatch(this.txtSDT.Text))
                { }
                else
                {
                    MessageBox.Show("Số điện thoại không hợp lệ", "THÔNG BÁO");
                    txtSDT.Clear();
                    txtSDT.Focus();
                    return false;
                }
            }
            //Kiểm tra mã số không bỏ trống
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Mã số nhân viên không được trống", "THÔNG BÁO");
                txtMaNV.Focus();
                return false;
            }
            //Kiểm tra giới tính không chọn
            if (radNam.Checked == false && radNu.Checked == false)
            {
                MessageBox.Show("Hãy chọn giới tính", "THÔNG BÁO");
                return false;
            }

            //Kiểm tra email không bỏ trống
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Email không được trống", "THÔNG BÁO");
                txtEmail.Focus();
                return false;
            }
            else
            {
                String match = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                Regex reg = new Regex(match);
                if (reg.IsMatch(this.txtEmail.Text))
                { }
                else
                {
                    MessageBox.Show("Email không hợp lệ", "THÔNG BÁO");
                    txtEmail.Clear();
                    txtEmail.Focus();
                    return false;
                }
            }
            return true;
        }

        public void loadDataGirdView()
        {
            string query = "select nv.MaNV, nv.HoTenNV, nv.DiaChi, nv.CMND, nv.SDT, nv.GioiTinh, nv.Email, nv.NgaySinh, pb.TenPB, cv.TenCV from NhanVien nv, ChucVu cv, PhongBan pb where nv.MaCV=cv.MaCV and nv.MaPB=pb.MaPB";
            dtgvDSNV.DataSource = DataProvider.Instance.ExcuteQuery(query);
        }

        void SetHeaderText()
        {
            //đặt tên cột
            dtgvDSNV.Columns["MaNV"].HeaderText = "Mã NV";
            dtgvDSNV.Columns["HoTenNV"].HeaderText = "Họ tên";
            dtgvDSNV.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dtgvDSNV.Columns["CMND"].HeaderText = "CMND";
            dtgvDSNV.Columns["SDT"].HeaderText = "Số điện thoại";
            dtgvDSNV.Columns["GioiTinh"].HeaderText = "Giới tính";
            dtgvDSNV.Columns["Email"].HeaderText = "Email";
            dtgvDSNV.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dtgvDSNV.Columns["TenPB"].HeaderText = "Phòng ban";
            dtgvDSNV.Columns["TenCV"].HeaderText = "Chức vụ";
        }

        void loadComboBox()
        {
            string query1 = "select TenCV from ChucVu";
            string query2 = "select TenPB from PhongBan";
            cmbChucVu.DataSource = DataProvider.Instance.ExcuteQuery(query1);
            cmbPhongBan.DataSource = DataProvider.Instance.ExcuteQuery(query2);
            cmbChucVu.DisplayMember = "TenCV";
            cmbPhongBan.DisplayMember = "TenPB";
        }

        

        string getMaPB(string tenpb)
        {
            string query = "select MaPB from PhongBan where TenPB = N'" + tenpb + "'";
            String str = DataProvider.Instance.ExcuteScalar(query).ToString();
            return str;
        }

        string getMaCV(string tencv)
        {
            string query = "select MaCV from ChucVu where TenCV = N'" + tencv + "'";
            String str = DataProvider.Instance.ExcuteScalar(query).ToString();
            return str;
        }
        private void frmNhanSu_Load(object sender, EventArgs e)
        {
            loadComboBox();
            loadDataGirdView();
            SetHeaderText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            string gioitinh = "";
            if (radNam.Checked == true)
                gioitinh = "Nam";
            if (radNu.Checked == true)
                gioitinh = "Nữ";

            string mapb = getMaPB(cmbPhongBan.Text);
            string macv = getMaCV(cmbChucVu.Text);

            string insert = "exec insertNV @MaNV , @HoTenNV , @DiaChi , @CMND , @SDT , @GioiTinh , @Email , @NgaySinh , @MaCV , @MaPB";
            if (KiemTraCMND()==false)
            {
                MessageBox.Show("Số CMND đã tồn tại!!!");
                txtCMND.Text = "";
                txtCMND.Focus();
            }
            else if(KiemTraSDT() == false)
            {
                MessageBox.Show("Số điện thoại đã tồn tại!!!");
                txtSDT.Text = "";
                txtSDT.Focus();
            }
            else if (KiemTraEmail() == false)
            {
                MessageBox.Show("Email đã tồn tại!!!");
                txtEmail.Text = "";
                txtEmail.Focus();
            }
            else if (KiemTraMaNV() == false)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại!!!");
                txtMaNV.Text = "";
                txtMaNV.Focus();
            }
            else
            {
                if (KTThongTin())
                {
                    DataProvider.Instance.ExcuteNonQuery(insert, new object[] { txtMaNV.Text, txtHoTen.Text, txtDiaChi.Text, txtCMND.Text, txtSDT.Text, gioitinh, txtEmail.Text, dtpNgaySinh.Value, macv, mapb });
                    dtgvDSNV.Refresh();
                    loadDataGirdView();
                    MessageBox.Show("Thêm thành công");
                }
            }
        }
        private Boolean KiemTraEmail()
        {
            conn.Open();
            //Kiểm tra Email  có chưa
            if (txtEmail.Text.Trim() != "")
            {
                string sql = "Select Count(*) From NhanVien Where Email ='" + txtEmail.Text + "'";
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
        private Boolean KiemTraSDT()
        {
            conn.Open();
            //Kiểm tra sdt có chưa
            if (txtSDT.Text.Trim() != "")
            {
                string sql = "Select Count(*) From NhanVien Where SDT ='" + txtSDT.Text + "'";
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
        private Boolean KiemTraCMND()
        {
            conn.Open();
            //Kiểm tra cmnd có chưa
            if (txtCMND.Text.Trim() != "")
            {
                string sql = "Select Count(*) From NhanVien Where CMND ='" + txtCMND.Text + "'";
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
        private void btnSua_Click(object sender, EventArgs e)
        {
            string gioitinh = "";
            if (radNam.Checked == true)
                gioitinh = "Nam";
            if (radNu.Checked == true)
                gioitinh = "Nữ";
            string mapb = getMaPB(cmbPhongBan.Text);
            string macv = getMaCV(cmbChucVu.Text);

            string update = "update NhanVien set MaNV=N'"+ txtMaNV.Text+ "', HoTenNV = N'" + txtHoTen.Text + "',DiaChi=N'" + txtDiaChi.Text + "',CMND = N'" + txtCMND.Text + "',SDT = N'" + txtSDT.Text + "',GioiTinh = N'" + gioitinh + "',Email = N'" + txtEmail.Text + "',NgaySinh = N'" + dtpNgaySinh.Text + "',MaCV = N'" + macv + "',MaPB = N'" + mapb + "'where MaNV = N'" + txtMaNV.Text + "'";

            
            {
                if (KTThongTin())
                {
                    DataProvider.Instance.ExcuteNonQuery(update);
                    dtgvDSNV.Refresh();
                    loadDataGirdView();
                    MessageBox.Show("Sửa thành công");
                }
            }
        }
        public static string quyen;
        private Boolean KiemTraMaNV()
        {
            conn.Open();
            //Kiểm tra mã nhân viên có chưa
            if (txtMaNV.Text.Trim() != "")
            {
                string sql = "Select Count(*) From NhanVien Where MaNV ='" + txtMaNV.Text + "'";
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
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (quyen == "1")
            {
                if (KiemTraMaNV() == true)
                    MessageBox.Show("Nhân viên này chưa có bảng lương, không thể xóa!", "Thông báo");
                else
                {
                    //Câu lệnh xóa
                    string sql = "delete from NhanVien ";
                    sql += "where MaNV = '" + txtMaNV.Text + "'";
                    DataProvider.Instance.ExcuteQuery(sql);
                    dtgvDSNV.Refresh();
                    loadDataGirdView();
                    MessageBox.Show("Xóa thành công !!!");
                }
            }
            else { MessageBox.Show("Bạn không có quyền xóa !!!"); }
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
                    string query = "select * from NhanVien where MaNV like N'%" + txtTimKiem.Text + "%'";
                    dtgvDSNV.DataSource = DataProvider.Instance.ExcuteQuery(query);

                }
                else if (radHoTen.Checked == true)
                {
                    string query = "select * from NhanVien where HoTenNV like N'%" + txtTimKiem.Text + "%'";
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

        private void dtgvDSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //đổ dữ liệu lên textbox, combobox
            int i = e.RowIndex;
            txtMaNV.Text = dtgvDSNV.Rows[i].Cells["MaNV"].Value.ToString();
            txtHoTen.Text = dtgvDSNV.Rows[i].Cells["HoTenNV"].Value.ToString();
            txtDiaChi.Text = dtgvDSNV.Rows[i].Cells["DiaChi"].Value.ToString();
            txtCMND.Text = dtgvDSNV.Rows[i].Cells["CMND"].Value.ToString();
            txtSDT.Text = dtgvDSNV.Rows[i].Cells["SDT"].Value.ToString();
            if (dtgvDSNV.Rows[i].Cells["GioiTinh"].Value.ToString() == "Nam")
                radNam.Checked = true;
            else
                radNu.Checked = true;
            txtEmail.Text = dtgvDSNV.Rows[i].Cells["Email"].Value.ToString();
            dtpNgaySinh.Text = dtgvDSNV.Rows[i].Cells["NgaySinh"].Value.ToString();
            cmbPhongBan.Text = dtgvDSNV.Rows[i].Cells["TenPB"].Value.ToString();
            cmbChucVu.Text = dtgvDSNV.Rows[i].Cells["TenCV"].Value.ToString();
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

       
    }
}
