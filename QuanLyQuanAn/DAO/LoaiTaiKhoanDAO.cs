using QuanLyQuanAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DAO
{
    internal class LoaiTaiKhoanDAO
    {
        private static LoaiTaiKhoanDAO instance;

        private LoaiTaiKhoanDAO() { }

        internal List<LoaiTaiKhoan> GetLoaiTaiKhoans()
        {
            List<LoaiTaiKhoan> list = new List<LoaiTaiKhoan>();
            DataTable data = CungCapDuLieu.Instance.ExecuteQuery("USP_LAYLOAITAIKHOAN");
            foreach (DataRow row in data.Rows) { list.Add(new LoaiTaiKhoan(row)); }
            return list;
        }

        internal LoaiTaiKhoan LayLayLoaiTaiKhoanTheoMa(int maLoaiTaiKhoan)
        {
            LoaiTaiKhoan loaiTaiKhoan = null;
            DataTable data = CungCapDuLieu.Instance.ExecuteQuery("USP_LAYLOAITAIKHOANTHEOMA @maLoaiTaiKhoan", new object[] { maLoaiTaiKhoan });
            foreach (DataRow dr in data.Rows)
            {
                loaiTaiKhoan = new LoaiTaiKhoan(dr);
                return loaiTaiKhoan;
            }
            return loaiTaiKhoan;
        }

        internal static LoaiTaiKhoanDAO Instance
        {
            get
            {
                if (instance == null) { instance = new LoaiTaiKhoanDAO(); }
                return instance;
            }
            private set { instance = value; }
        }
    }
}
