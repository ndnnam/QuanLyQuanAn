using QuanLyQuanAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DAO
{
    internal class BanDAO
    {
        private static BanDAO instance;
        internal static int chieuRong = 90;
        internal static int chieuDai = 95;

        private BanDAO() { }

        internal List<Ban> GetBans()
        {
            List<Ban> list = new List<Ban>();
            DataTable data = CungCapDuLieu.Instance.ExecuteQuery("USP_LAYBAN");
            foreach (DataRow row in data.Rows) { list.Add(new Ban(row)); }
            return list;
        }

        internal void ChuyenBan(int maBan1, int maBan2, string tenKhachHang, string soDienThoai, string maNhanVienBan)
        {
            CungCapDuLieu.Instance.ExecuteQuery("USP_CHUYANBAN @maBan1 , @maBan2 , @tenKhachHang , @soDienThoai , @maNhanVienBan",
                new object[] { maBan1, maBan2, tenKhachHang, soDienThoai, maNhanVienBan });
        }

        internal static BanDAO Instance
        {
            get
            {
                if (instance == null) { instance = new BanDAO(); }
                return instance;
            }
            private set { instance = value; }
        }
    }
}
