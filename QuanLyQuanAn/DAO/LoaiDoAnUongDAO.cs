using QuanLyQuanAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DAO
{
    internal class LoaiDoAnUongDAO
    {
        private static LoaiDoAnUongDAO instance;

        private LoaiDoAnUongDAO() { }

        internal List<LoaiDoAnUong> GetLoaiDoAnUongs()
        {
            List<LoaiDoAnUong> list = new List<LoaiDoAnUong>();
            DataTable data = CungCapDuLieu.Instance.ExecuteQuery("USP_LAYLOAIDOANUONG");
            foreach (DataRow row in data.Rows) { list.Add(new LoaiDoAnUong(row)); }
            return list;
        }

        internal LoaiDoAnUong LayLoaiDoAnUongTheoMa(int maLoaiDoAnUong)
        {
            LoaiDoAnUong loaiDoAnUong = null;
            DataTable data = CungCapDuLieu.Instance.ExecuteQuery("USP_LAYLOAIDOANUONGTHEOMA @maLoaiDoAnUong", new object[] { maLoaiDoAnUong });
            foreach (DataRow dr in data.Rows)
            {
                loaiDoAnUong = new LoaiDoAnUong(dr);
                return loaiDoAnUong;
            }
            return loaiDoAnUong;
        }

        internal bool ThemLoaiDoAnUong(string tenLoaiDoAnUong)
        {
            return CungCapDuLieu.Instance.ExecuteNonQuery("USP_THEMLOAIDOANUONG @tenLoaiDoAnUong", new object[] { tenLoaiDoAnUong }) > 0;
        }

        internal bool SuaLoaiDoAnUong(int maLoaiDoAnUong, string tenLoaiDoAnUong)
        {
            return CungCapDuLieu.Instance.ExecuteNonQuery("USP_SUALOAIDOANUONG @maLoaiDoAnUong , @tenLoaiDoAnUong",
                new object[] { maLoaiDoAnUong, tenLoaiDoAnUong }) > 0;
        }

        internal List<LoaiDoAnUong> TimKiemLoaiDoAnUongTheoTen(string tenLoaiDoAnUong)
        {
            List<LoaiDoAnUong> list = new List<LoaiDoAnUong>();
            DataTable data = CungCapDuLieu.Instance.ExecuteQuery(string.Format("SELECT * FROM LoaiDoAnUong WHERE dbo.fuConvertToUnsign1(TenLoaiDoAnUong) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", tenLoaiDoAnUong));
            foreach (DataRow row in data.Rows)
            {
                list.Add(new LoaiDoAnUong(row));
            }
            return list;
        }

        internal static LoaiDoAnUongDAO Instance
        {
            get
            {
                if (instance == null) { instance = new LoaiDoAnUongDAO(); }
                return instance;
            }
            private set { instance = value; }
        }
    }
}
