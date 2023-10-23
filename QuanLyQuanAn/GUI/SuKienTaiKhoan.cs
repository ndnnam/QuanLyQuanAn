using QuanLyQuanAn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.GUI
{
    internal class SuKienTaiKhoan
    {
        private TaiKhoan taiKhoan;

        internal SuKienTaiKhoan(TaiKhoan taiKhoan)
        {
            TaiKhoan = taiKhoan;
        }

        public TaiKhoan TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
    }
}
