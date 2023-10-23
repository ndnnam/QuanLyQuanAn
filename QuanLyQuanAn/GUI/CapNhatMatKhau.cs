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
    public partial class CapNhatMatKhau : Form
    {
        #region BienToanCuc
        private TaiKhoan taiKhoan;
        bool hienThiMatKhau = false;
        bool hienThiMatKhauMoi = false;
        bool hienThiXacThuc = false;
        #endregion

        public CapNhatMatKhau(TaiKhoan taiKhoan)
        {
            InitializeComponent();
            TaiKhoan = taiKhoan;
        }

        #region Ham
        void ThayDoiTaiKhoan(TaiKhoan taiKhoan)
        {
            txtTenDangNhap.Text = TaiKhoan.TenDangNhap;
            txtHoTen.Text = TaiKhoan.HoTen;
        }
        #endregion

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
            hienThiMatKhauMoi = !hienThiMatKhauMoi;
            txtMatKhauMoi.UseSystemPasswordChar = !hienThiMatKhauMoi;
            txtMatKhauMoi.PasswordChar = '\0';
            btnHienThi2.Image = hienThiMatKhauMoi ? Properties.Resources.icons8_hide_48 : Properties.Resources.icons8_show_48;
        }

        private void btnHienThi3_Click(object sender, EventArgs e)
        {
            hienThiXacThuc = !hienThiXacThuc;
            txtXacThuc.UseSystemPasswordChar = !hienThiXacThuc;
            txtXacThuc.PasswordChar = '\0';
            btnHienThi3.Image = hienThiXacThuc ? Properties.Resources.icons8_hide_48 : Properties.Resources.icons8_show_48;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                Guna.UI2.WinForms.MessageDialog.Show("Mật khẩu không được trống!");
            }
            else
            {
                if (string.IsNullOrEmpty(txtMatKhauMoi.Text))
                {
                    Guna.UI2.WinForms.MessageDialog.Show("Mật khẩu mới không được trống!");
                }
                else
                {
                    if (TaiKhoanDAO.Instance.KiemTraMatKhau(txtMatKhauMoi.Text))
                    {
                        if (string.IsNullOrEmpty(txtXacThuc.Text))
                        {
                            Guna.UI2.WinForms.MessageDialog.Show("Hãy nhập lại mật khẩu!");
                        }
                        else
                        {
                            if (TaiKhoanDAO.Instance.CapNhatMatKhau(txtTenDangNhap.Text, txtMatKhau.Text, txtMatKhauMoi.Text))
                            {
                                Guna.UI2.WinForms.MessageDialog.Show("Cập nhật thành công");
                                if (capNhatTaiKhoan != null)
                                {
                                    capNhatTaiKhoan(this, new SuKienTaiKhoan(TaiKhoanDAO.Instance.LayTaiKhoanTheoTenDangNhap(txtTenDangNhap.Text)));
                                }
                                Close();
                                new DangNhap().Show();
                            }
                            else
                            {
                                Guna.UI2.WinForms.MessageDialog.Show("Mật khẩu cũ không đúng!");
                            }
                        }    
                    }
                    else
                    {
                        Guna.UI2.WinForms.MessageDialog.Show("Mật khẩu phải từ 8 ký tự trở lên, có ít nhất một chữ thường, có ít nhất một chữ hoa, có ít nhất một số, có ít nhất một ký tự đặc biệt!");
                    }    
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
