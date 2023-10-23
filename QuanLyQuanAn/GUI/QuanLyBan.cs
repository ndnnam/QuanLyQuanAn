using QuanLyQuanAn.DAO;
using QuanLyQuanAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn.GUI
{
    public partial class QuanLyBan : Form
    {
        #region BienToanCuc
        private TaiKhoan taiKhoan;
        #endregion

        public QuanLyBan(TaiKhoan taiKhoan)
        {
            InitializeComponent();
            TaiKhoan = taiKhoan;
            Nap();
        }

        #region Ham
        void ThayDoiTaiKhoan(int maLoaiTaiKhoan)
        {
            btnQuanTriVien.Enabled = maLoaiTaiKhoan == 1;
            lblHoTen.Text = TaiKhoan.HoTen;
        }

        void LayBanAn()
        {
            flpBan.Controls.Clear();
            List<Ban> bans = BanDAO.Instance.GetBans();
            foreach (Ban ban in bans)
            {
                Guna.UI2.WinForms.Guna2Button btn = new Guna.UI2.WinForms.Guna2Button()
                {
                    Width = BanDAO.chieuRong,
                    Height = BanDAO.chieuDai,
                    Animated = true,
                    AutoRoundedCorners = true,
                    BackColor = Color.Transparent,
                    BorderRadius = 21,
                    Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(255, 255, 241)
                };
                btn.Text = ban.TenBan + Environment.NewLine + ban.TrangThaiBan;
                btn.Click += Btn_Click;
                btn.Tag = ban;
                switch (ban.TrangThaiBan)
                {
                    case "Không có người":
                        btn.FillColor = Color.FromArgb(129, 137, 209);
                        break;
                    default:
                        btn.FillColor = Color.FromArgb(2, 19, 176);
                        break;
                }
                flpBan.Controls.Add(btn);
            }
        }

        void HienThiHoaDon(int maBan)
        {
            lvwHoaDon.Items.Clear();
            List<ThucDon> list = ThucDonDAO.Instance.LayDanhSachThucDon(maBan);
            float tongTien = 0;
            foreach (ThucDon thucDon in list)
            {
                ListViewItem item = new ListViewItem(thucDon.TenDoAnUong.ToString());
                item.SubItems.Add(thucDon.SoLuong.ToString());
                item.SubItems.Add(thucDon.GiaNiemYet.ToString());
                item.SubItems.Add(thucDon.ThanhTien.ToString());
                item.SubItems.Add(thucDon.HoTen.ToString());
                item.SubItems.Add(thucDon.TenKhachHang.ToString());
                item.SubItems.Add(thucDon.SoDienThoaiKhachHang.ToString());
                tongTien += thucDon.ThanhTien;
                lvwHoaDon.Items.Add(item);
            }
            CultureInfo info = new CultureInfo("vi-VN");
            lblTongTien.Text = tongTien.ToString("c", info);
        }

        void LayLoaiDoAnUong()
        {
            List<LoaiDoAnUong> loaiDoAnUongs = LoaiDoAnUongDAO.Instance.GetLoaiDoAnUongs();
            cbxLoaiDoAnUong.DataSource = loaiDoAnUongs;
            cbxLoaiDoAnUong.DisplayMember = "TenLoaiDoAnUong";
        }

        void LayDanhSachDoAnUong(int maLoaiDoAnUong)
        {
            List<DoAnUong> doAnUongs = DoAnUongDAO.Instance.LayDanhSachDoAnUong(maLoaiDoAnUong);
            cbxDoAnUong.DataSource = doAnUongs;
            cbxDoAnUong.DisplayMember = "TenDoAnUong";
        }

        void LayComboboxTaiKhoan(ComboBox box)
        {
            box.DataSource = TaiKhoanDAO.Instance.GetTaiKhoans();
            box.DisplayMember = "HoTen";
        }

        void LayComboboxBan(ComboBox box)
        {
            box.DataSource = BanDAO.Instance.GetBans();
            box.DisplayMember = "TenBan";
        }

        void Nap()
        {
            LayBanAn();
            LayLoaiDoAnUong();
            LayComboboxBan(cbxChuyenBan);
            LayComboboxTaiKhoan(cbxTenNhanVien);
        }
        #endregion

        #region SuKien
        private void Btn_Click(object sender, EventArgs e)
        {
            int maBan = ((sender as Guna.UI2.WinForms.Guna2Button).Tag as Ban).MaBan;
            lvwHoaDon.Tag = (sender as Guna.UI2.WinForms.Guna2Button).Tag;
            HienThiHoaDon(maBan);
            string tenBan = ((sender as Guna.UI2.WinForms.Guna2Button).Tag as Ban).TenBan;
            lblTenBan.Text = tenBan;
        }

        private void btnQuanTriVien_Click(object sender, EventArgs e)
        {
            QuanTriVien quanTriVien = new QuanTriVien(taiKhoan);
            quanTriVien.TaiKhoan = taiKhoan;
            quanTriVien.ThemDoAnUong += QuanTriVien_ThemDoAnUong;
            quanTriVien.SuaDoAnUong += QuanTriVien_SuaDoAnUong;
            quanTriVien.XoaDoAnUong += QuanTriVien_XoaDoAnUong;
            quanTriVien.ThemLoaiDoAnUong += QuanTriVien_ThemLoaiDoAnUong;
            quanTriVien.SuaLoaiDoAnUong += QuanTriVien_SuaLoaiDoAnUong;
            quanTriVien.CapNhatTaiKhoan += QuanTriVien_CapNhatTaiKhoan;
            quanTriVien.ShowDialog();
        }

        private void QuanTriVien_CapNhatTaiKhoan(object sender, SuKienTaiKhoan e)
        {
            lblHoTen.Text = e.TaiKhoan.HoTen;
        }

        private void QuanTriVien_SuaLoaiDoAnUong(object sender, EventArgs e)
        {
            LayLoaiDoAnUong();
        }

        private void QuanTriVien_ThemLoaiDoAnUong(object sender, EventArgs e)
        {
            LayLoaiDoAnUong();
        }

        private void QuanTriVien_XoaDoAnUong(object sender, EventArgs e)
        {
            LayDanhSachDoAnUong((cbxLoaiDoAnUong.SelectedItem as LoaiDoAnUong).MaLoaiDoAnUong);
            if (lvwHoaDon.Tag != null)
            {
                HienThiHoaDon((lvwHoaDon.Tag as Ban).MaBan);
            }
            LayBanAn();
        }

        private void QuanTriVien_SuaDoAnUong(object sender, EventArgs e)
        {
            LayDanhSachDoAnUong((cbxLoaiDoAnUong.SelectedItem as LoaiDoAnUong).MaLoaiDoAnUong);
            if (lvwHoaDon.Tag != null)
            {
                HienThiHoaDon((lvwHoaDon.Tag as Ban).MaBan);
            }
        }

        private void QuanTriVien_ThemDoAnUong(object sender, EventArgs e)
        {
            LayDanhSachDoAnUong((cbxLoaiDoAnUong.SelectedItem as LoaiDoAnUong).MaLoaiDoAnUong);
            if (lvwHoaDon.Tag != null)
            {
                HienThiHoaDon((lvwHoaDon.Tag as Ban).MaBan);
            }
        }

        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            ThongTinCaNhan thongTinCaNhan = new ThongTinCaNhan(taiKhoan);
            thongTinCaNhan.CapNhatTaiKhoan += ThongTinCaNhan_CapNhatTaiKhoan;
            thongTinCaNhan.ShowDialog();
        }

        private void ThongTinCaNhan_CapNhatTaiKhoan(object sender, SuKienTaiKhoan e)
        {
            lblHoTen.Text = e.TaiKhoan.HoTen;
        }

        private void btnCapNhatMatKhau_Click(object sender, EventArgs e)
        {
            CapNhatMatKhau capNhatMatKhau = new CapNhatMatKhau(taiKhoan);
            capNhatMatKhau.ShowDialog();
            btnDangXuat_Click(sender, e);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbxLoaiDoAnUong_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maLoaiDoAnUong = 0;
            ComboBox box = sender as ComboBox;
            if (box.SelectedItem == null)
            {
                return;
            }
            LoaiDoAnUong loaiDoAnUong = box.SelectedItem as LoaiDoAnUong;
            maLoaiDoAnUong = loaiDoAnUong.MaLoaiDoAnUong;
            LayDanhSachDoAnUong(maLoaiDoAnUong);
        }

        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {
            string so = new string(txtSoDienThoai.Text.Where(char.IsDigit).ToArray());
            txtSoDienThoai.Text = so;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Ban ban = lvwHoaDon.Tag as Ban;
            if (ban == null)
            {
                Guna.UI2.WinForms.MessageDialog.Show("Hãy chọn bàn!");
                return;
            }
            if (txtHoTenKhachHang.Text == null && txtSoDienThoai == null)
            {
                Guna.UI2.WinForms.MessageDialog.Show("Hãy thêm tên khách hàng và số điện thoại của khách!");
                if (TaiKhoanDAO.Instance.KiemTraHoTen(txtHoTenKhachHang.Text))
                {
                    Guna.UI2.WinForms.MessageDialog.Show("Họ tên không hợp lệ!");
                    return;
                }
            }
            string maNhanVienBan = (cbxTenNhanVien.SelectedItem as TaiKhoan).TenDangNhap;
            int maHoaDon = HoaDonDAO.Instance.LayMaHoaDonChuaThanhToanTheoMaBan(ban.MaBan);
            int maDoAnUong = (cbxDoAnUong.SelectedItem as DoAnUong).MaDoAnUong;
            int soLuong = (int)nudSoLuong.Value;
            if (maHoaDon == -1)
            {
                HoaDonDAO.Instance.ThemHoaDon(ban.MaBan, txtHoTenKhachHang.Text, txtSoDienThoai.Text, maNhanVienBan);
                ChiTietHoaDonDAO.Instance.ThemChiTietHoaDon(HoaDonDAO.Instance.LayMaHoaDonLonNhat(), maDoAnUong, soLuong);
            }
            else
            {
                ChiTietHoaDonDAO.Instance.ThemChiTietHoaDon(maHoaDon, maDoAnUong, soLuong);
            }
            HienThiHoaDon(ban.MaBan);
            LayBanAn();
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            int maBan1 = (lvwHoaDon.Tag as Ban).MaBan;
            int maBan2 = (cbxChuyenBan.SelectedItem as Ban).MaBan;
            string maNhanVienBan = (cbxTenNhanVien.SelectedItem as TaiKhoan).TenDangNhap;
            if (Guna.UI2.WinForms.MessageDialog.Show(string.Format("Bạn có thật sự muốn chuyển {0} qua {1}",
                (lvwHoaDon.Tag as Ban).TenBan, (cbxChuyenBan.SelectedItem as Ban).TenBan), "Thông báo",
                Guna.UI2.WinForms.MessageDialogButtons.OKCancel) == DialogResult.OK)
            {
                BanDAO.Instance.ChuyenBan(maBan1, maBan2, txtHoTenKhachHang.Text, txtSoDienThoai.Text, maNhanVienBan);
                LayBanAn();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            Ban ban = lvwHoaDon.Tag as Ban;
            int maHoaDon = HoaDonDAO.Instance.LayMaHoaDonChuaThanhToanTheoMaBan(ban.MaBan);
            int giamGia = (int)nudGiamGia.Value;
            double tongGiaTruocKhiGiamGia = Convert.ToDouble(lblTongTien.Text.Split(',')[0].Replace(".", ""));
            double tongGiaSauKhiGiamGia = tongGiaTruocKhiGiamGia - (tongGiaTruocKhiGiamGia * giamGia / 100);
            if (maHoaDon != -1)
            {
                if (Guna.UI2.WinForms.MessageDialog.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho {0}\n" +
                    "Tổng tiền - (Tổng tiền * Giảm giá / 100) = {1} - ({1} * {2} / 100) = {3}",
                    ban.TenBan, tongGiaTruocKhiGiamGia, giamGia, tongGiaSauKhiGiamGia), "Thông báo",
                    Guna.UI2.WinForms.MessageDialogButtons.OKCancel) == DialogResult.OK)
                {
                    HoaDonDAO.Instance.ThanhToan(maHoaDon, giamGia, (float)tongGiaSauKhiGiamGia);
                    HienThiHoaDon(ban.MaBan);
                    LayBanAn();
                }
            }
        }
        #endregion

        public TaiKhoan TaiKhoan { get => taiKhoan; set { taiKhoan = value; ThayDoiTaiKhoan(taiKhoan.MaLoaiTaiKhoan); } }
    }
}
