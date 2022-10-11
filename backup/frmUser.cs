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
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet("dsQLHD");
        SqlConnection conn = new SqlConnection(@"Data Source=TIEN-PC\SQLEXPRESS;Initial Catalog=Quanlinhansu;Integrated Security=True");
        

        public Boolean KTThongTin()
        {
            if(txtTaiKhoan.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập", "THÔNG BÁO");
                txtTaiKhoan.Focus();
                return false;
            }
            else if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu", "THÔNG BÁO");
                txtMatKhau.Focus();
                return false;
            }
            else if(cboLoaiTk.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn loại tài khoản", "THÔNG BÁO");
                return false;
            }
            return true;
        }
        public void loadDataGirdView()
        {
            string query = "select tk.ID,tk.TenDangNhap, tk.MatKhau, ltk.Tentk from TaiKhoan tk, LoaiTkhoan ltk where tk.Matk = ltk.Matk";
            dtgvDSTK.DataSource = DataProvider.Instance.ExcuteQuery(query);
        }
        void SetHeaderText()
        {
            //đặt tên cột
            dtgvDSTK.Columns["ID"].HeaderText = "ID";
            dtgvDSTK.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
            dtgvDSTK.Columns["MatKhau"].HeaderText = "Mật khẩu";
            dtgvDSTK.Columns["Tentk"].HeaderText = "Quyền";
        }
        string getMatk(string tentk)
        {
            string query = "select Matk from LoaiTkhoan where TenTk = N'" + tentk + "'";
            String str = DataProvider.Instance.ExcuteScalar(query).ToString();
            return str;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string mtk = getMatk(cboLoaiTk.Text);
            string insert = "insert into TaiKhoan(TenDangNhap,MatKhau,Matk,ID) values(N'" + txtTaiKhoan.Text + "',N'" + txtMatKhau.Text + "','" + mtk +"',N'"+ txtID.Text +"')";
            if (DataProvider.Instance.ExcuteQuery("select TenDangNhap from TaiKhoan").ToString() != txtTaiKhoan.Text)
            {
                if(KTThongTin())
                {
                    DataProvider.Instance.ExcuteNonQuery(insert);
                    dtgvDSTK.Refresh();
                    loadDataGirdView();
                    MessageBox.Show("Thêm thành công");
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string mtk = getMatk(cboLoaiTk.Text);
            string update = "update TaiKhoan SET TenDangNhap = '" + txtTaiKhoan.Text + "',MatKhau ='" + txtMatKhau.Text + "',Matk='" + mtk + "' Where ID="+txtID.Text +"";
            {
                if (KTThongTin())
                {
                    DataProvider.Instance.ExcuteNonQuery(update);
                    dtgvDSTK.Refresh();
                    loadDataGirdView();
                    MessageBox.Show("Sửa thành công");
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string delete = "delete from TaiKhoan where TenDangNhap =N'" + txtTaiKhoan.Text + "'";
            if (MessageBox.Show("Bạn có muốn xóa không", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataProvider.Instance.ExcuteNonQuery(delete);
                dtgvDSTK.Refresh();
                loadDataGirdView();
                MessageBox.Show("Đã xóa dữ liệu");
            }
            if (DataProvider.Instance.ExcuteQuery("select TenDangNhap from TaiKhoan").ToString() != txtTaiKhoan.Text)
                MessageBox.Show("Tài Khoản không tồn tại, không thể xóa");
        }
        private void frmUser_Load(object sender, EventArgs e)
        {
            loadDataGirdView();
            SetHeaderText();
            loadComboBox();
        }

        private void dtgvDSTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtTaiKhoan.Text = dtgvDSTK.Rows[i].Cells["TenDangNhap"].Value.ToString();
            txtMatKhau.Text = dtgvDSTK.Rows[i].Cells["MatKhau"].Value.ToString();
            cboLoaiTk.Text = dtgvDSTK.Rows[i].Cells["Tentk"].Value.ToString();
            txtID.Text = dtgvDSTK.Rows[i].Cells["ID"].Value.ToString();
        }
        void loadComboBox()
        {
            string query1 = "select Tentk from LoaiTkhoan";           
            cboLoaiTk.DataSource = DataProvider.Instance.ExcuteQuery(query1);
            cboLoaiTk.DisplayMember = "Tentk";
        }

        private void s(object sender, EventArgs e)
        {

        }
    }
}
