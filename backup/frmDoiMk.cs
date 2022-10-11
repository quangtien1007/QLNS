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
    public partial class frmDoiMk : Form
    {
        public frmDoiMk()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet("dsQLMK");
        SqlCommand cmd;
        SqlConnection conn = new SqlConnection(@"Data Source=TIEN-PC\SQLEXPRESS;Initial Catalog=Quanlinhansu;Integrated Security=True");
        private Boolean KiemTraMaNV()
        {
            conn.Open();
            //Kiểm tra xem mã nhân viên này đã có hợp đồng chưa 
            if (txtMKCu.Text.Trim() != "")
            {
                string sql = "Select Count(*) From TaiKhoan Where MatKhau ='" + txtMKCu.Text + "'";
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
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập", "THÔNG BÁO");
                txtTaiKhoan.Focus();
            }
            else
            {
                if (txtMKCu.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu", "THÔNG BÁO");
                    txtMKCu.Focus();
                }
                else if (txtMKMoi.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu mới", "THÔNG BÁO");
                    txtMKMoi.Focus();
                }
                else if (txtXacNhanMK.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập lại mật khẩu", "THÔNG BÁO");
                    txtXacNhanMK.Focus();
                }
                else if (KiemTraMaNV() == true)
                    MessageBox.Show("Mật khẩu không trùng khớp");
                else
                {
                    if (txtMKMoi.Text == txtXacNhanMK.Text)
                    {
                        string update = "update TaiKhoan SET MatKhau='" + txtMKMoi.Text + "' where (TenDangNhap = N'" + txtTaiKhoan.Text + "'and MatKhau='" + txtMKCu.Text + "')";
                        DataProvider.Instance.ExcuteNonQuery(update);
                        MessageBox.Show("Bạn đã thay đổi mật khẩu thành công", "THÔNG BÁO");
                        this.Close();
                    }
                }

            }

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
