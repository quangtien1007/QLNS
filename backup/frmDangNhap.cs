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
using System.Data.Sql;
using QLNS.Thumuc;

namespace QLNS
{
    public partial class frmDangNhap : Form
    {
        
        public frmDangNhap()
        {
            InitializeComponent();
            
        }
        
        string getMatk()
        {
           string query = "select Matk from TaiKhoan where TenDangNhap like N'" + txtTenDangNhap.Text + "' and MatKhau ='"+txtMatKhau.Text+"'";
           return DataProvider.Instance.ExcuteScalar(query).ToString();
        }
        
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text;
            string password = txtMatKhau.Text;
            
             if(Login(username,password))
            {
                if (getMatk() == "1")
                {
                    MessageBox.Show("Đăng nhập thành công (Admin) !!!");
                    frmMain f = new frmMain();
                    f.quyen = getMatk();
                    frmHopDong.quyen = getMatk();
                    frmLuong.quyen = getMatk();
                    frmNghiPhep.quyen = getMatk();
                    frmNhanSu.quyen = getMatk();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else if(getMatk()=="2")
                {
                    MessageBox.Show("Đăng nhập thành công (User) !!!");
                    frmMain f = new frmMain();
                    f.quyen = getMatk();
                    frmHopDong.quyen = getMatk();
                    frmLuong.quyen = getMatk();
                    frmNghiPhep.quyen = getMatk();
                    frmNhanSu.quyen = getMatk();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!!!");
                txtTenDangNhap.Text = "";
                txtMatKhau.Text = "";
                txtTenDangNhap.Focus();
                
            }
            
        }
        bool Login(string username, string password)
        {
            return Account.Instance.Login(username,password);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }
        
        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
        
    }
}
