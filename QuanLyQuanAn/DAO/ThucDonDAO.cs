using QuanLyQuanAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DAO
{
    internal class ThucDonDAO
    {
        private static ThucDonDAO instance;

        private ThucDonDAO() { }

        internal List<ThucDon> LayDanhSachThucDon(int maBan)
        {
            List<ThucDon> list = new List<ThucDon>();
            DataTable data = CungCapDuLieu.Instance.ExecuteQuery("USP_LAYDANHSACHTHUCDON @maBan", new object[] { maBan });
            foreach (DataRow row in data.Rows) { list.Add(new ThucDon(row)); }
            return list;
        }

        internal static ThucDonDAO Instance
        {
            get
            {
                if (instance == null) { instance = new ThucDonDAO(); }
                return instance;
            }
            private set { instance = value; }
        }
    }
}
