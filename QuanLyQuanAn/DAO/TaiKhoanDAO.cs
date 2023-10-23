using QuanLyQuanAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DAO
{
    internal class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;

        private TaiKhoanDAO() { }

        internal bool KiemTraMatKhau(string chuoi) => Regex.IsMatch(chuoi, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,}$");

        internal bool KiemTraHoTen(string chuoi)
        {
            if (string.IsNullOrWhiteSpace(chuoi))
                return false;

            string[] words = chuoi.Split(' ');
            foreach (string word in words)
            {
                if (string.IsNullOrWhiteSpace(word))
                    continue;

                if (!char.IsUpper(word[0]) || !word.Substring(1).All(char.IsLower))
                    return false;
            }

            return true;
        }

        string BamMatKhau(string matKhau)
        {
            byte[] tam = ASCIIEncoding.ASCII.GetBytes(matKhau);
            byte[] bamDuLieu = new MD5CryptoServiceProvider().ComputeHash(tam);
            string bamMatKhau = "";
            foreach (byte b in bamDuLieu)
            {
                bamMatKhau += b;
            }
            return bamMatKhau;
        }

        internal bool DangNhap(string tenDangNhap, string matKhau)
        {
            return CungCapDuLieu.Instance.ExecuteQuery("USP_DANGNHAP @tenDangNhap , @matKhau",
                new object[] { tenDangNhap, BamMatKhau(matKhau) }).Rows.Count > 0;
        }

        internal bool DangKy(string tenDangNhap, string matKhau, string hoTen, string soDienThoai)
        {
            return CungCapDuLieu.Instance.ExecuteNonQuery("USP_DANGKY @tenDangNhap , @matKhau , @hoTen , @soDienThoai",
                new object[] { tenDangNhap, BamMatKhau(matKhau), hoTen, soDienThoai }) > 0;
        }

        internal bool KiemTraTenDangNhap(string tenDangNhap)
        {
            return !(CungCapDuLieu.Instance.ExecuteQuery("USP_KIEMTRATENDANGNHAP @tenDangNhap", new object[] { tenDangNhap }).Rows.Count > 0);
        }

        internal bool CapNhatTaiKhoan(string tenDangNhap, string hoTen, string soDienThoai, string matKhau)
        {
            return CungCapDuLieu.Instance.ExecuteNonQuery("USP_CAPNHATTAIKHOAN @tenDangNhap , @hoTen , @soDienThoai , @matKhau",
                new object[] { tenDangNhap, hoTen, soDienThoai, BamMatKhau(matKhau) }) > 0;
        }

        internal bool CapNhatMatKhau(string tenDangNhap, string matKhau, string matKhauMoi)
        {
            return CungCapDuLieu.Instance.ExecuteNonQuery("USP_CAPNHATMATKHAU @tenDangNhap , @matKhau , @matKhauMoi",
                new object[] { tenDangNhap, BamMatKhau(matKhau), BamMatKhau(matKhauMoi) }) > 0;
        }

        internal TaiKhoan LayTaiKhoanTheoTenDangNhap(string tenDangNhap)
        {
            DataTable data = CungCapDuLieu.Instance.ExecuteQuery("USP_LAYTAIKHOANTHEOTENDANGNHAP @tenDangNhap", new object[] { tenDangNhap });
            foreach (DataRow row in data.Rows) { return new TaiKhoan(row); }
            return null;
        }

        internal DataTable LayDanhSachTaiKhoan()
        {
            return CungCapDuLieu.Instance.ExecuteQuery("USP_LAYDANHSACHTAIKHOAN");
        }

        internal List<TaiKhoan> GetTaiKhoans()
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            DataTable data = CungCapDuLieu.Instance.ExecuteQuery("USP_LAYTAIKHOAN");
            foreach (DataRow row in data.Rows) { list.Add(new TaiKhoan(row)); }
            return list;
        }

        internal bool ThemTaiKhoan(string tenDangNhap, string hoTen, string soDienThoai, int maLoaiTaiKhoan)
        {
            return CungCapDuLieu.Instance.ExecuteNonQuery("USP_THEMTAIKHOAN @tenDangNhap , @matKhau , @hoTen , @soDienThoai , @maLoaiTaiKhoan",
                new object[] { tenDangNhap, "223018912569815552702387813134219207146", hoTen, soDienThoai, maLoaiTaiKhoan }) > 0;
        }

        internal bool SuaTaiKhoan(string tenDangNhap, int maLoaiTaiKhoan)
        {
            return CungCapDuLieu.Instance.ExecuteNonQuery("USP_SUATAIKHOAN @tenDangNhap , @maLoaiTaiKhoan",
                new object[] { tenDangNhap, maLoaiTaiKhoan }) > 0;
        }

        internal bool XoaTaiKhoan(string tenDangNhap)
        {
            HoaDonDAO.Instance.XoaHoaDonTheoMaNhanVien(tenDangNhap);
            return CungCapDuLieu.Instance.ExecuteNonQuery("USP_XOATAIKHOAN @tenDangNhap", new object[] { tenDangNhap }) > 0;
        }

        internal bool DatLaiMatKhau(string tenDangNhap)
        {
            return CungCapDuLieu.Instance.ExecuteNonQuery("USP_DATLAIMATKHAU @tenDangNhap", new object[] { tenDangNhap }) > 0;
        }

        internal bool QuenMatKhau(string tenDangNhap, string matKhauMoi)
        {
            return CungCapDuLieu.Instance.ExecuteNonQuery("USP_QUENMATKHAU @tenDangNhap , @matKhauMoi",
                new object[] { tenDangNhap, BamMatKhau(matKhauMoi) }) > 0;
        }

        internal List<TaiKhoan> TimKiemTaiKhoanTheoTenDangNhap(string tenDangNhap)
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            DataTable data = CungCapDuLieu.Instance.ExecuteQuery(string.Format("SELECT * FROM TaiKhoan WHERE dbo.fuConvertToUnsign1(TenDangNhap) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", tenDangNhap));
            foreach (DataRow row in data.Rows)
            {
                list.Add(new TaiKhoan(row));
            }
            return list;
        }

        internal static TaiKhoanDAO Instance
        {
            get
            {
                if (instance == null) { instance = new TaiKhoanDAO(); }
                return instance;
            }
            private set { instance = value; }
        }
    }
}
