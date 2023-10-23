using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    internal class ThucDon
    {
        private string tenDoAnUong;
        private int soLuong;
        private float giaNiemYet;
        private float thanhTien;
        private string hoTen;
        private string tenKhachHang;
        private string soDienThoaiKhachHang;

        internal ThucDon(string tenDoAnUong, int soLuong, float giaNiemYet, float thanhTien, string hoTen, string tenKhachHang, string soDienThoaiKhachHang)
        {
            TenDoAnUong = tenDoAnUong;
            SoLuong = soLuong;
            GiaNiemYet = giaNiemYet;
            ThanhTien = thanhTien;
            HoTen = hoTen;
            TenKhachHang = tenKhachHang;
            SoDienThoaiKhachHang = soDienThoaiKhachHang;
        }

        internal ThucDon(DataRow row)
        {
            TenDoAnUong = row["tenDoAnUong"].ToString();
            SoLuong = (int)row["soLuong"];
            GiaNiemYet = (float)Convert.ToDouble(row["giaNiemYet"].ToString());
            ThanhTien = (float)Convert.ToDouble(row["thanhTien"].ToString());
            HoTen = row["hoTen"].ToString();
            TenKhachHang = row["tenKhachHang"].ToString();
            SoDienThoaiKhachHang = row["soDienThoaiKhachHang"].ToString();
        }

        public string TenDoAnUong { get => tenDoAnUong; set => tenDoAnUong = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public float GiaNiemYet { get => giaNiemYet; set => giaNiemYet = value; }
        public float ThanhTien { get => thanhTien; set => thanhTien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string TenKhachHang { get => tenKhachHang; set => tenKhachHang = value; }
        public string SoDienThoaiKhachHang { get => soDienThoaiKhachHang; set => soDienThoaiKhachHang = value; }
    }
}
