using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    internal class ChiTietHoaDon
    {
        private int maChiTietHoaDon;
        private int maHoaDon;
        private int maDoAnUong;
        private int soLuong;

        internal ChiTietHoaDon(int maChiTietHoaDon, int maHoaDon, int maDoAnUong, int soLuong)
        {
            MaHoaDon = maHoaDon;
            MaDoAnUong = maDoAnUong;
            SoLuong = soLuong;
            MaChiTietHoaDon = maChiTietHoaDon;
        }

        internal ChiTietHoaDon(DataRow row)
        {
            MaChiTietHoaDon = (int)row["maChiTietHoaDon"];
            MaHoaDon = (int)row["maHoaDon"];
            MaDoAnUong = (int)row["maDoAnUong"];
            SoLuong = (int)row["soLuong"];
        }

        public int MaChiTietHoaDon { get => maChiTietHoaDon; set => maChiTietHoaDon = value; }
        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public int MaDoAnUong { get => maDoAnUong; set => maDoAnUong = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
