using Guna.UI2.WinForms;
using QuanLyQuanAn.DAO;
using QuanLyQuanAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn.GUI
{
    public partial class DangNhap : Form
    {
        #region BienToanCuc
        bool hienThiMatKhau = false;
        #endregion

        public DangNhap()
        {
            InitializeComponent();
        }

        #region SuKien
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            hienThiMatKhau = !hienThiMatKhau;
            txtMatKhau.UseSystemPasswordChar = !hienThiMatKhau;
            txtMatKhau.PasswordChar = '\0';
            btnHienThi.Image = hienThiMatKhau ? Properties.Resources.icons8_hide_48 : Properties.Resources.icons8_show_48;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDangNhap.Text))
            {
                MessageDialog.Show("Tên đăng nhập không được trống!");
            }
            else
            {
                if (string.IsNullOrEmpty(txtMatKhau.Text))
                {
                    MessageDialog.Show("Mật khẩu không được trống!");
                }
                else
                {
                    if (TaiKhoanDAO.Instance.DangNhap(txtTenDangNhap.Text, txtMatKhau.Text))
                    {
                        TaiKhoan taiKhoan = TaiKhoanDAO.Instance.LayTaiKhoanTheoTenDangNhap(txtTenDangNhap.Text);
                        QuanLyBan quanLyBan = new QuanLyBan(taiKhoan);
                        Hide();
                        quanLyBan.ShowDialog();
                        Show();
                    }
                    else
                    {
                        MessageDialog.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
                    }
                }    
            }    
        }

        private void lblQuenMatKhau_Click(object sender, EventArgs e)
        {
            Hide();
            new QuenMatKhau().ShowDialog();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            new DangKy().ShowDialog();
        }
        #endregion
    }
}
