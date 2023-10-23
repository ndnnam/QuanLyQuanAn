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
    public partial class QuanTriVien : Form
    {
        #region BienToanCuc
        BindingSource danhSachDoAnUong = new BindingSource();
        BindingSource danhSachLoaiDoAnUong = new BindingSource();
        BindingSource danhSachTaiKhoan = new BindingSource();
        private TaiKhoan taiKhoan;
        #endregion

        public QuanTriVien(TaiKhoan taiKhoan)
        {
            InitializeComponent();
            Nap();
            TaiKhoan = taiKhoan;
        }

        #region Ham
        void ThayDoiTaiKhoan(TaiKhoan taiKhoan)
        {
            txtTenDangNhap.Text = TaiKhoan.TenDangNhap;
            txtHoTen.Text = TaiKhoan.HoTen;
        }

        void LayDateTimePickerHoaDon()
        {
            DateTime date = DateTime.Now;
            dtpNgayBatDau.Value = new DateTime(date.Year, date.Month, 1);
            dtpNgayKetThuc.Value = dtpNgayBatDau.Value.AddMonths(1).AddDays(-1);
        }

        void LayDanhSachHoaDonTheoNgay(DateTime ngayGioKhachToi, DateTime ngayGioKhachDi, int trang)
        {
            dgvHoaDon.DataSource = HoaDonDAO.Instance.LayDanhSachHoaDonTheoNgayVaTrang(ngayGioKhachToi, ngayGioKhachDi, trang);
        }

        void LayDanhSachDoAnUong()
        {
            danhSachDoAnUong.DataSource = DoAnUongDAO.Instance.GetDoAnUongs();
        }

        void LayDanhSachLoaiDoAnUong()
        {
            danhSachLoaiDoAnUong.DataSource = LoaiDoAnUongDAO.Instance.GetLoaiDoAnUongs();
        }

        void LayDanhSachTaiKhoan()
        {
            danhSachTaiKhoan.DataSource = TaiKhoanDAO.Instance.LayDanhSachTaiKhoan();
        }

        void LayLoaiDoAnUongVaoComboBox(ComboBox box)
        {
            box.DataSource = LoaiDoAnUongDAO.Instance.GetLoaiDoAnUongs();
            box.DisplayMember = "TenLoaiDoAnUong";
        }

        void LayLoaiTaiKhoanVaoComboBox(ComboBox box)
        {
            box.DataSource = LoaiTaiKhoanDAO.Instance.GetLoaiTaiKhoans();
            box.DisplayMember = "TenLoaiTaiKhoan";
        }

        void ThemRangBuocDoAnUong()
        {
            txtMaDoAnUong.DataBindings.Add(new Binding("Text", dgvDoAnUong.DataSource, "MaDoAnUong", true, DataSourceUpdateMode.Never));
            txtTenDoAnUong.DataBindings.Add(new Binding("Text", dgvDoAnUong.DataSource, "TenDoAnUong", true, DataSourceUpdateMode.Never));
            nudGiaNiemYet.DataBindings.Add(new Binding("Value", dgvDoAnUong.DataSource, "GiaNiemYet", true, DataSourceUpdateMode.Never));
        }

        void ThemRangBuocLoaiDoAnUong()
        {
            txtMaLoaiDoAnUong.DataBindings.Add(new Binding("Text", dgvLoaiDoAnUong.DataSource, "MaLoaiDoAnUong", true, DataSourceUpdateMode.Never));
            txtTenLoaiDoAnUong.DataBindings.Add(new Binding("Text", dgvLoaiDoAnUong.DataSource, "TenLoaiDoAnUong", true, DataSourceUpdateMode.Never));
        }

        void ThemRangBuocTaiKhoan()
        {
            txtTenDangNhap.DataBindings.Add(new Binding("Text", dgvTaiKhoan.DataSource, "TenDangNhap", true, DataSourceUpdateMode.Never));
            txtHoTen.DataBindings.Add(new Binding("Text", dgvTaiKhoan.DataSource, "HoTen", true, DataSourceUpdateMode.Never));
            txtSoDienThoai.DataBindings.Add(new Binding("Text", dgvTaiKhoan.DataSource, "SoDienThoai", true, DataSourceUpdateMode.Never));
        }

        List<DoAnUong> TimKiemDoAnUongTheoTen(string tenDoAnUong)
        {
            List<DoAnUong> list = DoAnUongDAO.Instance.TimKiemDoAnUongTheoTen(tenDoAnUong);
            return list;
        }

        List<LoaiDoAnUong> TimKiemLoaiDoAnUongTheoTen(string tenLoaiDoAnUong)
        {
            List<LoaiDoAnUong> list = LoaiDoAnUongDAO.Instance.TimKiemLoaiDoAnUongTheoTen(tenLoaiDoAnUong);
            return list;
        }

        List<TaiKhoan> TimKiemTaiKhoanTheoTenDangNhap(string tenDangNhap)
        {
            List<TaiKhoan> list = TaiKhoanDAO.Instance.TimKiemTaiKhoanTheoTenDangNhap(tenDangNhap);
            return list;
        }

        void Nap()
        {
            dgvDoAnUong.DataSource = danhSachDoAnUong;
            dgvDoAnUong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvLoaiDoAnUong.DataSource = danhSachLoaiDoAnUong;
            dgvTaiKhoan.DataSource = danhSachTaiKhoan;
            dgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            LayDateTimePickerHoaDon();
            LayDanhSachHoaDonTheoNgay(dtpNgayBatDau.Value, dtpNgayKetThuc.Value, Convert.ToInt32(txtTrang.Text));
            LayDanhSachDoAnUong();
            LayLoaiDoAnUongVaoComboBox(cbxLoaiDoAnUong);
            ThemRangBuocDoAnUong();
            LayDanhSachLoaiDoAnUong();
            ThemRangBuocLoaiDoAnUong();
            LayDanhSachTaiKhoan();
            ThemRangBuocTaiKhoan();
            LayLoaiTaiKhoanVaoComboBox(cbxLoaiTaiKhoan);
        }
        #endregion

        #region SuKien
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LayDanhSachHoaDonTheoNgay(dtpNgayBatDau.Value, dtpNgayKetThuc.Value, Convert.ToInt32(txtTrang.Text));
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            txtTrang.Text = "1";
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            int banGhi = HoaDonDAO.Instance.LaySoLuongHoaDonTheoNgay(dtpNgayBatDau.Value, dtpNgayKetThuc.Value);
            int trangCuoi = banGhi / 10;
            if (banGhi % 10 != 0)
            {
                trangCuoi++;
            }
            txtTrang.Text = trangCuoi.ToString();
        }

        private void txtTrang_TextChanged(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = HoaDonDAO.Instance.LayDanhSachHoaDonTheoNgayVaTrang(dtpNgayBatDau.Value, dtpNgayKetThuc.Value, Convert.ToInt32(txtTrang.Text));
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            int trang = Convert.ToInt32(txtTrang.Text);
            if (trang > 0)
            {
                trang--;
            }
            txtTrang.Text = trang.ToString();
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            int trang = Convert.ToInt32(txtTrang.Text);
            int banGhi = HoaDonDAO.Instance.LaySoLuongHoaDonTheoNgay(dtpNgayBatDau.Value, dtpNgayKetThuc.Value);
            if (trang < banGhi)
            {
                trang++;
            }
            txtTrang.Text = trang.ToString();
        }

        private void btnXemDoAnUong_Click(object sender, EventArgs e)
        {
            LayDanhSachDoAnUong();
        }

        private void btnThemDoAnUong_Click(object sender, EventArgs e)
        {
            string tenDoAnUong = txtTenDoAnUong.Text;
            int maLoaiDoAnUong = (cbxLoaiDoAnUong.SelectedItem as LoaiDoAnUong).MaLoaiDoAnUong;
            float giaNiemYet = (float)nudGiaNiemYet.Value;
            if (DoAnUongDAO.Instance.ThemDoAnUong(tenDoAnUong, maLoaiDoAnUong, giaNiemYet))
            {
                Guna.UI2.WinForms.MessageDialog.Show("Thêm đồ ăn uống thành công!");
                LayDanhSachDoAnUong();
                if (themDoAnUong != null)
                {
                    themDoAnUong(this, new EventArgs());
                }
            }
            else
            {
                Guna.UI2.WinForms.MessageDialog.Show("Có lỗi khi thêm đồ ăn uống!");
            }
        }

        private void btnSuaDoAnUong_Click(object sender, EventArgs e)
        {
            int maDoAnUong = Convert.ToInt32(txtMaDoAnUong.Text);
            string tenDoAnUong = txtTenDoAnUong.Text;
            int maLoaiDoAnUong = (cbxLoaiDoAnUong.SelectedItem as LoaiDoAnUong).MaLoaiDoAnUong;
            float giaNiemYet = (float)nudGiaNiemYet.Value;
            if (DoAnUongDAO.Instance.SuaDoAnUong(maDoAnUong, tenDoAnUong, maLoaiDoAnUong, giaNiemYet))
            {
                Guna.UI2.WinForms.MessageDialog.Show("Sửa đồ ăn uống thành công!");
                LayDanhSachDoAnUong();
                if (suaDoAnUong != null)
                {
                    suaDoAnUong(this, new EventArgs());
                }
            }
            else
            {
                Guna.UI2.WinForms.MessageDialog.Show("Có lỗi khi sửa đồ ăn uống!");
            }
        }

        private void btnXoaDoAnUong_Click(object sender, EventArgs e)
        {
            int maDoAnUong = Convert.ToInt32(txtMaDoAnUong.Text);
            if (DoAnUongDAO.Instance.XoaDoAnUong(maDoAnUong))
            {
                Guna.UI2.WinForms.MessageDialog.Show("Xóa đồ ăn uống thành công!");
                LayDanhSachDoAnUong();
                if (xoaDoAnUong != null)
                {
                    xoaDoAnUong(this, new EventArgs());
                }
            }
            else
            {
                Guna.UI2.WinForms.MessageDialog.Show("Có lỗi khi xóa đồ ăn uống!");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            danhSachDoAnUong.DataSource = TimKiemDoAnUongTheoTen(txtTimKiem.Text);
        }

        private void txtMaDoAnUong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvDoAnUong.SelectedCells.Count > 0)
                {
                    int maLoaiDoAnUong = (int)dgvDoAnUong.SelectedCells[0].OwningRow.Cells["MaLoaiDoAnUong"].Value;
                    LoaiDoAnUong loaiDoAnUong = LoaiDoAnUongDAO.Instance.LayLoaiDoAnUongTheoMa(maLoaiDoAnUong);
                    cbxLoaiDoAnUong.SelectedItem = loaiDoAnUong;
                    int mucLuc = -1, i = 0;
                    foreach (LoaiDoAnUong loai in cbxLoaiDoAnUong.Items)
                    {
                        if (loai.MaLoaiDoAnUong == loaiDoAnUong.MaLoaiDoAnUong)
                        {
                            mucLuc = i;
                            break;
                        }
                        i++;
                    }
                    cbxLoaiDoAnUong.SelectedIndex = mucLuc;
                }
            }
            catch { }
        }

        private void btnXemLoaiDoAnUong_Click(object sender, EventArgs e)
        {
            LayDanhSachLoaiDoAnUong();
        }

        private void btnThemLoaiDoAnUong_Click(object sender, EventArgs e)
        {
            string tenLoaiDoAnUong = txtTenLoaiDoAnUong.Text;
            if (LoaiDoAnUongDAO.Instance.ThemLoaiDoAnUong(tenLoaiDoAnUong))
            {
                Guna.UI2.WinForms.MessageDialog.Show("Thêm loại đồ ăn uống thành công!");
                LayDanhSachLoaiDoAnUong();
                if (themLoaiDoAnUong != null)
                {
                    themLoaiDoAnUong(this, new EventArgs());
                }
                else
                {
                    Guna.UI2.WinForms.MessageDialog.Show("Có lỗi khi thêm loại đồ ăn uống!");
                }
            }
            LayLoaiDoAnUongVaoComboBox(cbxLoaiDoAnUong);
        }

        private void btnSuaLoaiDoAnUong_Click(object sender, EventArgs e)
        {
            int maLoaiDoAnUong = Convert.ToInt32(txtMaLoaiDoAnUong.Text);
            string tenLoaiDoAnUong = txtTenLoaiDoAnUong.Text;
            if (LoaiDoAnUongDAO.Instance.SuaLoaiDoAnUong(maLoaiDoAnUong, tenLoaiDoAnUong))
            {
                Guna.UI2.WinForms.MessageDialog.Show("Sửa loại đồ ăn uống thành công!");
                LayDanhSachLoaiDoAnUong();
                if (suaLoaiDoAnUong != null)
                {
                    suaLoaiDoAnUong(this, new EventArgs());
                }
            }
            else
            {
                Guna.UI2.WinForms.MessageDialog.Show("Có lỗi khi sửa loại đồ ăn uống!");
            }
            LayLoaiDoAnUongVaoComboBox(cbxLoaiDoAnUong);
        }

        private void btnTimKiemLoaiDoAnUong_Click(object sender, EventArgs e)
        {
            danhSachLoaiDoAnUong.DataSource = TimKiemLoaiDoAnUongTheoTen(txtTimKiemLoaiDoAnUong.Text);
        }

        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {
            string so = new string(txtSoDienThoai.Text.Where(char.IsDigit).ToArray());
            txtSoDienThoai.Text = so;
        }

        private void btnXemTaiKhoan_Click(object sender, EventArgs e)
        {
            LayDanhSachTaiKhoan();
        }

        private void btnSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            int maLoaiTaiKhoan = (cbxLoaiTaiKhoan.SelectedItem as LoaiTaiKhoan).MaLoaiTaiKhoan;
            if (TaiKhoanDAO.Instance.SuaTaiKhoan(txtTenDangNhap.Text, maLoaiTaiKhoan))
            {
                Guna.UI2.WinForms.MessageDialog.Show("Sửa tài khoản thành công!");
                if (capNhatTaiKhoan != null)
                {
                    capNhatTaiKhoan(this, new SuKienTaiKhoan(TaiKhoanDAO.Instance.LayTaiKhoanTheoTenDangNhap(txtTenDangNhap.Text)));
                }
            }
            else
            {
                Guna.UI2.WinForms.MessageDialog.Show("Sửa tài khoản thất bại!");
            }
            LayDanhSachTaiKhoan();
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text;
            if (TaiKhoan.TenDangNhap.Equals(tenDangNhap))
            {
                Guna.UI2.WinForms.MessageDialog.Show("Không thể xóa khi đang đăng nhập!");
                return;
            }
            if (TaiKhoanDAO.Instance.XoaTaiKhoan(tenDangNhap))
            {
                Guna.UI2.WinForms.MessageDialog.Show("Xóa tài khoản thành công!");
            }
            else
            {
                Guna.UI2.WinForms.MessageDialog.Show("Xóa tài khoản thất bại!");
            }
            LayDanhSachTaiKhoan();
        }

        private void btnTimKiemTaiKhoan_Click(object sender, EventArgs e)
        {
            danhSachTaiKhoan.DataSource = TimKiemTaiKhoanTheoTenDangNhap(txtTimKiemTaiKhoan.Text);
        }

        private void btnDatLaiMatKhau_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text;
            if (TaiKhoanDAO.Instance.DatLaiMatKhau(tenDangNhap))
            {
                Guna.UI2.WinForms.MessageDialog.Show("Đặt lại mật khẩu thành công!");
            }
            else
            {
                Guna.UI2.WinForms.MessageDialog.Show("Đặt lại mật khẩu thất bại!");
            }
        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvTaiKhoan.SelectedCells.Count > 0)
                {
                    int maLoaiTaiKhoan = (int)dgvTaiKhoan.SelectedCells[0].OwningRow.Cells["MaLoaiTaiKhoan"].Value;
                    LoaiTaiKhoan loaiTaiKhoan = LoaiTaiKhoanDAO.Instance.LayLayLoaiTaiKhoanTheoMa(maLoaiTaiKhoan);
                    int mucLuc = -1, i = 0;
                    foreach (LoaiTaiKhoan loai in cbxLoaiTaiKhoan.Items)
                    {
                        if (loai.MaLoaiTaiKhoan == loaiTaiKhoan.MaLoaiTaiKhoan)
                        {
                            mucLuc = i;
                            break;
                        }
                        i++;
                    }
                    cbxLoaiTaiKhoan.SelectedIndex = mucLuc;
                }
            }
            catch { }
        }

        private event EventHandler themDoAnUong;

        internal event EventHandler ThemDoAnUong
        {
            add { themDoAnUong += value; }
            remove { themDoAnUong -= value; }
        }

        private event EventHandler suaDoAnUong;

        internal event EventHandler SuaDoAnUong
        {
            add { suaDoAnUong += value; }
            remove { suaDoAnUong -= value; }
        }

        private event EventHandler xoaDoAnUong;

        internal event EventHandler XoaDoAnUong
        {
            add { xoaDoAnUong += value; }
            remove { xoaDoAnUong -= value; }
        }

        private event EventHandler themLoaiDoAnUong;

        internal event EventHandler ThemLoaiDoAnUong
        {
            add { themLoaiDoAnUong += value; }
            remove { themLoaiDoAnUong -= value; }
        }

        private event EventHandler suaLoaiDoAnUong;

        internal event EventHandler SuaLoaiDoAnUong
        {
            add { suaLoaiDoAnUong += value; }
            remove { suaLoaiDoAnUong -= value; }
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