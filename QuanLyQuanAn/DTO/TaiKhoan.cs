using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    public class TaiKhoan
    {
        private string tenDangNhap;
        private string hoTen;
        private string soDienThoai;
        private string matKhau;
        private int maLoaiTaiKhoan;

        internal TaiKhoan(string tenDangNhap, string hoTen, string soDienThoai, int maLoaiTaiKhoan, string matKhau = null)
        {
            TenDangNhap = tenDangNhap;
            HoTen = hoTen;
            SoDienThoai = soDienThoai;
            MaLoaiTaiKhoan = maLoaiTaiKhoan;
            MatKhau = matKhau;
        }

        internal TaiKhoan(DataRow row)
        {
            TenDangNhap = row["tenDangNhap"].ToString();
            HoTen = row["hoTen"].ToString();
            SoDienThoai = row["soDienThoai"].ToString();
            MaLoaiTaiKhoan = (int)row["maLoaiTaiKhoan"];
            MatKhau = row["matKhau"].ToString();
        }

        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public int MaLoaiTaiKhoan { get => maLoaiTaiKhoan; set => maLoaiTaiKhoan = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
    }
}
