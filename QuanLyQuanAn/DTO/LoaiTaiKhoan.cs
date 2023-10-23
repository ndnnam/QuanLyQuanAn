using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    internal class LoaiTaiKhoan
    {
        private int maLoaiTaiKhoan;
        private string tenLoaiTaiKhoan;

        internal LoaiTaiKhoan(int maLoaiTaiKhoan, string tenLoaiTaiKhoan)
        {
            MaLoaiTaiKhoan = maLoaiTaiKhoan;
            TenLoaiTaiKhoan = tenLoaiTaiKhoan;
        }

        internal LoaiTaiKhoan(DataRow row)
        {
            MaLoaiTaiKhoan = (int)row["maLoaiTaiKhoan"];
            TenLoaiTaiKhoan = row["tenLoaiTaiKhoan"].ToString();
        }

        public int MaLoaiTaiKhoan { get => maLoaiTaiKhoan; set => maLoaiTaiKhoan = value; }
        public string TenLoaiTaiKhoan { get => tenLoaiTaiKhoan; set => tenLoaiTaiKhoan = value; }
    }
}
