using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DAO
{
    internal class ChiTietHoaDonDAO
    {
        private static ChiTietHoaDonDAO instance;

        private ChiTietHoaDonDAO() { }

        internal void ThemChiTietHoaDon(int maHoaDon, int maDoAnUong, int soLuong)
        {
            CungCapDuLieu.Instance.ExecuteNonQuery("USP_THEMCHITIETHOADON @maHoaDon , @maDoAnUong , @soLuong",
                new object[] { maHoaDon, maDoAnUong, soLuong });
        }

        internal void XoaChiTietHoaDonTheoMaDoAnUong(int maDoAnUong)
        {
            CungCapDuLieu.Instance.ExecuteQuery("USP_XOACHITIETHOADONTHEOMADOANUONG @maDoAnUong",
                new object[] { maDoAnUong });
        }

        internal static ChiTietHoaDonDAO Instance
        {
            get
            {
                if (instance == null) { instance = new ChiTietHoaDonDAO(); }
                return instance;
            }
            private set { instance = value; }
        }
    }
}
