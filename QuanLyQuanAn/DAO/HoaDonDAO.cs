using QuanLyQuanAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DAO
{
    internal class HoaDonDAO
    {
        private static HoaDonDAO instance;

        private HoaDonDAO() { }

        /// <summary>
        /// Thanh cong: ma hoa don
        /// That bai: -1
        /// </summary>
        /// <param name="maBan"></param>
        /// <returns></returns>
        internal int LayMaHoaDonChuaThanhToanTheoMaBan(int maBan)
        {
            DataTable data = CungCapDuLieu.Instance.ExecuteQuery("USP_LAYMAHOADONCHUATHANHTOANTHEOMABAN @maBan", new object[] { maBan });
            if (data.Rows.Count > 0) { return new HoaDon(data.Rows[0]).MaHoaDon; }
            return -1;
        }

        internal void ThanhToan(int maHoaDon, int giamGia, float tongGia)
        {
            CungCapDuLieu.Instance.ExecuteNonQuery("USP_THANHTOAN @maHoaDon , @giamGia , @tongGia", new object[] { maHoaDon, giamGia, tongGia });
        }

        internal void ThemHoaDon(int maBan, string tenKhachHang, string soDienThoai, string maNhanVienBan)
        {
            CungCapDuLieu.Instance.ExecuteNonQuery("USP_THEMHOADON @maBan , @tenKhachHang , @soDienThoai , @maNhanVienBan",
                new object[] { maBan, tenKhachHang, soDienThoai, maNhanVienBan });
        }

        internal int LayMaHoaDonLonNhat()
        {
            try { return (int)CungCapDuLieu.Instance.ExecuteScalar("USP_LAYMAHOADONLONNHAT"); }
            catch { return 1; }
        }

        internal DataTable LayDanhSachHoaDonTheoNgayVaTrang(DateTime ngayGioKhachToi, DateTime ngayGioKhachDi, int trang)
        {
            return CungCapDuLieu.Instance.ExecuteQuery("USP_LAYDANHSACHHOADONTHEONGAYVATRANG @ngayGioKhachToi , @ngayGioKhachDi , @trang",
                new object[] { ngayGioKhachToi, ngayGioKhachDi, trang });
        }

        internal int LaySoLuongHoaDonTheoNgay(DateTime ngayGioKhachToi, DateTime ngayGioKhachDi)
        {
            return (int)CungCapDuLieu.Instance.ExecuteScalar("USP_LAYSOLUONGHOADONTHEONGAY @ngayGioKhachToi , @ngayGioKhachDi",
                new object[] { ngayGioKhachToi, ngayGioKhachDi });
        }

        internal void XoaHoaDonTheoMaNhanVien(string maNhanVienBan)
        {
            CungCapDuLieu.Instance.ExecuteQuery("USP_XOAHOADONTHEOMANHANVIEN @maNhanVienBan", new object[] { maNhanVienBan });
        }

        internal static HoaDonDAO Instance
        {
            get
            {
                if (instance == null) { instance = new HoaDonDAO(); }
                return instance;
            }
            private set { instance = value; }
        }
    }
}
