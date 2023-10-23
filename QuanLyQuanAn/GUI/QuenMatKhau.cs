using Guna.UI2.WinForms;
using QuanLyQuanAn.DAO;
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
    public partial class QuenMatKhau : Form
    {
        #region BienToanCuc
        bool hienThiMatKhauMoi = false;
        bool hienThiXacThuc = false;
        #endregion

        public QuenMatKhau()
        {
            InitializeComponent();
        }

        #region SuKien
        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHienThi1_Click(object sender, EventArgs e)
        {
            hienThiMatKhauMoi = !hienThiMatKhauMoi;
            txtMatKhauMoi.UseSystemPasswordChar = !hienThiMatKhauMoi;
            txtMatKhauMoi.PasswordChar = '\0';
            btnHienThi1.Image = hienThiMatKhauMoi ? Properties.Resources.icons8_hide_48 : Properties.Resources.icons8_show_48;
        }

        private void btnHienThi2_Click(object sender, EventArgs e)
        {
            hienThiXacThuc = !hienThiXacThuc;
            txtXacThuc.UseSystemPasswordChar = !hienThiXacThuc;
            txtXacThuc.PasswordChar = '\0';
            btnHienThi2.Image = hienThiXacThuc ? Properties.Resources.icons8_hide_48 : Properties.Resources.icons8_show_48;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDangNhap.Text))
            {
                MessageDialog.Show("Tên đăng nhập không được trống!");
            }
            else
            {
                if (TaiKhoanDAO.Instance.KiemTraTenDangNhap(txtTenDangNhap.Text))
                {
                    MessageDialog.Show("Tên đăng nhập không tồn tại!");
                }
                else
                {
                    if (string.IsNullOrEmpty(txtMatKhauMoi.Text))
                    {
                        MessageDialog.Show("Mật khẩu mới không được trống!");
                    }
                    else
                    {
                        if (TaiKhoanDAO.Instance.KiemTraMatKhau(txtMatKhauMoi.Text))
                        {
                            if (string.IsNullOrEmpty(txtXacThuc.Text))
                            {
                                MessageDialog.Show("Hãy nhập lại mật khẩu!");
                            }
                            else
                            {
                                if (txtXacThuc.Text == txtMatKhauMoi.Text)
                                {
                                    if (TaiKhoanDAO.Instance.QuenMatKhau(txtTenDangNhap.Text, txtMatKhauMoi.Text))
                                    {
                                        MessageDialog.Show("Cập nhật thành công");
                                        Close();
                                        new DangNhap().Show();
                                    }
                                }
                                else
                                {
                                    MessageDialog.Show("Mật khẩu không hợp lệ!");
                                }    
                            }    
                        }
                        else
                        {
                            MessageDialog.Show("Mật khẩu phải từ 8 ký tự trở lên, có ít nhất một chữ thường, có ít nhất một chữ hoa, có ít nhất một số, có ít nhất một ký tự đặc biệt!");
                        }    
                    }    
                }    
            }
        }
        #endregion
    }
}