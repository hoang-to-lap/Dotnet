using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myproject
{
    public partial class Form1 : Form
    {
        string tentaikhoan = "admin";
        string matkhau = "admin";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(KiemTraDangNhap(txtTaiKhoan.Text , txtMatKhau.Text))
            {
                MainForm f = new MainForm();
                f.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu ", "Lỗi");
            }
            
        }
        bool KiemTraDangNhap(string tentaikhoan , string matkhau)
        {
            if(tentaikhoan== this.tentaikhoan && matkhau == this.matkhau)
            {
                return true;
            }

            return false;
        }
    }
}
