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
    public partial class ThongTinCaNhan : Form
    {
        #region BienToanCuc
        private TaiKhoan taiKhoan;
        bool hienThiMatKhau = false;
        #endregion

        public ThongTinCaNhan(TaiKhoan taiKhoan)
        {
            InitializeComponent();
            TaiKhoan = taiKhoan;
        }

        #region Ham
        void ThayDoiTaiKhoan(TaiKhoan taiKhoan)
        {
            txtTenDangNhap.Text = TaiKhoan.TenDangNhap;
            txtHoTen.Text = TaiKhoan.HoTen;
            txtSoDienThoai.Text = TaiKhoan.SoDienThoai;
        }

        private void btnHienThi1_Click(object sender, EventArgs e)
        {
            hienThiMatKhau = !hienThiMatKhau;
            txtMatKhau.UseSystemPasswordChar = !hienThiMatKhau;
            txtMatKhau.PasswordChar = '\0';
            btnHienThi1.Image = hienThiMatKhau ? Properties.Resources.icons8_hide_48 : Properties.Resources.icons8_show_48;
        }

        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {
            string so = new string(txtSoDienThoai.Text.Where(char.IsDigit).ToArray());
            txtSoDienThoai.Text = so;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
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
                            MessageDialog.Show("Số điện thoại không hợp lệ!");
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(txtMatKhau.Text))
                            {
                                MessageDialog.Show("Mật khẩu không được trống!");
                            }
                            else
                            {
                                if (TaiKhoanDAO.Instance.CapNhatTaiKhoan(txtTenDangNhap.Text, txtHoTen.Text, txtSoDienThoai.Text, txtMatKhau.Text))
                                {
                                    MessageDialog.Show("Cập nhật thành công");
                                    if (capNhatTaiKhoan != null)
                                    {
                                        capNhatTaiKhoan(this, new SuKienTaiKhoan(TaiKhoanDAO.Instance.LayTaiKhoanTheoTenDangNhap(txtTenDangNhap.Text)));
                                    }
                                }
                                else
                                {
                                    MessageDialog.Show("Mật khẩu không đúng!");
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageDialog.Show("Họ tên không hợp lệ!");
                }    
            }    
        }

        private event EventHandler<SuKienTaiKhoan> capNhatTaiKhoan;

        internal event EventHandler<SuKienTaiKhoan> CapNhatTaiKhoan
        {
            add { capNhatTaiKhoan += value; }
            remove { capNhatTaiKhoan -= value; }
        }
        #endregion

        public TaiKhoan TaiKhoan { get => taiKhoan; set { taiKhoan = value; ThayDoiTaiKhoan(TaiKhoan); } }
    }
}
