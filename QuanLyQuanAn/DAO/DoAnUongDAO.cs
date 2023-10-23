using QuanLyQuanAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DAO
{
    internal class DoAnUongDAO
    {
        private static DoAnUongDAO instance;

        private DoAnUongDAO() { }

        internal List<DoAnUong> LayDanhSachDoAnUong(int maLoaiDoAnUong)
        {
            List<DoAnUong> list = new List<DoAnUong>();
            DataTable data = CungCapDuLieu.Instance.ExecuteQuery("USP_LAYDANHSACHDOANUONG @maLoaiDoAnUong", new object[] { maLoaiDoAnUong });
            foreach (DataRow row in data.Rows) { list.Add(new DoAnUong(row)); }
            return list;
        }

        internal List<DoAnUong> GetDoAnUongs()
        {
            List<DoAnUong> list = new List<DoAnUong>();
            DataTable data = CungCapDuLieu.Instance.ExecuteQuery("USP_LAYDOANUONG");
            foreach (DataRow row in data.Rows) { list.Add(new DoAnUong(row)); }
            return list;
        }

        internal bool ThemDoAnUong(string tenDoAnUong, int maLoaiDoAnUong, float giaNiemYet)
        {
            return CungCapDuLieu.Instance.ExecuteNonQuery("USP_THEMDOANUONG @tenDoAnUong , @maLoaiDoAnUong , @giaNiemYet",
                new object[] { tenDoAnUong, maLoaiDoAnUong, giaNiemYet }) > 0;
        }

        internal bool SuaDoAnUong(int maDoAnUong, string tenDoAnUong, int maLoaiDoAnUong, float giaNiemYet)
        {
            return CungCapDuLieu.Instance.ExecuteNonQuery("USP_SUADOANUONG @maDoAnUong , @tenDoAnUong , @maLoaiDoAnUong , @giaNiemYet",
                new object[] { maDoAnUong, tenDoAnUong, maLoaiDoAnUong, giaNiemYet }) > 0;
        }

        internal bool XoaDoAnUong(int maDoAnUong)
        {
            ChiTietHoaDonDAO.Instance.XoaChiTietHoaDonTheoMaDoAnUong(maDoAnUong);
            return CungCapDuLieu.Instance.ExecuteNonQuery("USP_XOADOANUONG @maDoAnUong", new object[] { maDoAnUong }) > 0;
        }

        internal List<DoAnUong> TimKiemDoAnUongTheoTen(string tenDoAnUong)
        {
            List<DoAnUong> list = new List<DoAnUong>();
            DataTable data = CungCapDuLieu.Instance.ExecuteQuery(string.Format("SELECT * FROM DoAnUong WHERE dbo.fuConvertToUnsign1(TenDoAnUong) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", tenDoAnUong));
            foreach (DataRow row in data.Rows)
            {
                list.Add(new DoAnUong(row));
            }
            return list;
        }

        internal static DoAnUongDAO Instance
        {
            get
            {
                if (instance == null) { instance = new DoAnUongDAO(); }
                return instance;
            }
            private set { instance = value; }
        }
    }
}
