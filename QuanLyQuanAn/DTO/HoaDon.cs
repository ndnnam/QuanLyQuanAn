using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    internal class HoaDon
    {
        private int maHoaDon;
        private DateTime? ngayGioKhachToi;
        private DateTime? ngayGioKhachDi;
        private int trangThaiThanhToan;
        private int giamGia;

        internal HoaDon(int maHoaDon, DateTime? ngayGioKhachToi, DateTime? ngayGioKhachDi, int trangThaiThanhToan, int giamGia = 0)
        {
            MaHoaDon = maHoaDon;
            NgayGioKhachToi = ngayGioKhachToi;
            NgayGioKhachDi = ngayGioKhachDi;
            TrangThaiThanhToan = trangThaiThanhToan;
            GiamGia = giamGia;
        }

        internal HoaDon(DataRow row)
        {
            MaHoaDon = (int)row["maHoaDon"];
            NgayGioKhachToi = (DateTime?)row["ngayGioKhachToi"];
            var date = row["ngayGioKhachDi"];
            if (date.ToString() != "") { NgayGioKhachDi = (DateTime?)date; }
            TrangThaiThanhToan = (int)row["trangThaiThanhToan"];
            if (row["giamGia"].ToString() != "") { GiamGia = (int)row["giamGia"]; }
        }

        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public DateTime? NgayGioKhachToi { get => ngayGioKhachToi; set => ngayGioKhachToi = value; }
        public DateTime? NgayGioKhachDi { get => ngayGioKhachDi; set => ngayGioKhachDi = value; }
        public int TrangThaiThanhToan { get => trangThaiThanhToan; set => trangThaiThanhToan = value; }
        public int GiamGia { get => giamGia; set => giamGia = value; }
    }
}
