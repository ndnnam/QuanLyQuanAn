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
    public partial class DangKy : Form
    {
        #region BienToanCuc
        bool hienThiMatKhau = false;
        bool hienThiXacThuc = false;
        #endregion

        public DangKy()
        {
            InitializeComponent();
        }

        #region SuKien
        private void btnHienThi1_Click(object sender, EventArgs e)
        {
            hienThiMatKhau = !hienThiMatKhau;
            txtMatKhau.UseSystemPasswordChar = !hienThiMatKhau;
            txtMatKhau.PasswordChar = '\0';
            btnHienThi1.Image = hienThiMatKhau ? Properties.Resources.icons8_hide_48 : Properties.Resources.icons8_show_48;
        }

        private void btnHienThi2_Click(object sender, EventArgs e)
        {
            hienThiXacThuc = !hienThiXacThuc;
            txtXacThuc.UseSystemPasswordChar = !hienThiXacThuc;
            txtXacThuc.PasswordChar = '\0';
            btnHienThi2.Image = hienThiXacThuc ? Properties.Resources.icons8_hide_48 : Properties.Resources.icons8_show_48;
        }

        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {
            string so = new string(txtSoDienThoai.Text.Where(char.IsDigit).ToArray());
            txtSoDienThoai.Text = so;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDangNhap.Text))
            {
                MessageDialog.Show("Tên đăng nhập không được trống!");
            }
            else
            {
                if (TaiKhoanDAO.Instance.KiemTraTenDangNhap(txtTenDangNhap.Text))
                {
                    if (string.IsNullOrEmpty(txtHoTen.Text))
                    {
                        MessageDialog.Show("Họ tên không được trống!");
                    }
                    else
                    {
                        if (TaiKhoanDAO.Instance.KiemTraHoTen(txtHoTen.Text))
                        {
                            if (string.IsNullOrEmpty(txtSoDienThoai.Text))
                            {
                                MessageDialog.Show("Số điện thoại không được trống!");
                            }
                            else
                            {
                                if (txtSoDienThoai.Text.Length == 10)
                                {
                                    if (string.IsNullOrEmpty(txtMatKhau.Text))
                                    {
                                        MessageDialog.Show("Mật khẩu không được trống!");
                                    }
                                    else
                                    {
                                        if (TaiKhoanDAO.Instance.KiemTraMatKhau(txtMatKhau.Text))
                                        {
                                            if (string.IsNullOrEmpty(txtXacThuc.Text))
                                            {
                                                MessageDialog.Show("Hãy nhập lại mật khẩu!");
                                            }
                                            else
                                            {
                                                if (txtXacThuc.Text == txtMatKhau.Text)
                                                {
                                                    if (TaiKhoanDAO.Instance.DangKy(txtTenDangNhap.Text, txtMatKhau.Text, txtHoTen.Text, txtSoDienThoai.Text))
                                                    {
                                                        MessageDialog.Show("Đăng ký thành công!");
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
                                else
                                {
                                    MessageDialog.Show("Số điện thoại không hợp lệ!");
                                }
                            }
                        }
                        else
                        {
                            MessageDialog.Show("Họ tên không hợp lệ!");
                        }    
                    }    
                }
                else
                {
                    MessageDialog.Show("Tên đăng nhập đã tồn tại!");
                }    
            }    
        }
        #endregion
    }
}
