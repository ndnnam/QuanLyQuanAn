using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    internal class DoAnUong
    {
        private int maDoAnUong;
        private string tenDoAnUong;
        private int maLoaiDoAnUong;
        private float giaNiemYet;

        internal DoAnUong(int maDoAnUong, string tenDoAnUong, int maLoaiDoAnUong, float giaNiemYet)
        {
            MaDoAnUong = maDoAnUong;
            TenDoAnUong = tenDoAnUong;
            MaLoaiDoAnUong = maLoaiDoAnUong;
            GiaNiemYet = giaNiemYet;
        }

        internal DoAnUong(DataRow row)
        {
            MaDoAnUong = (int)row["maDoAnUong"];
            TenDoAnUong = row["tenDoAnUong"].ToString();
            MaLoaiDoAnUong = (int)row["maLoaiDoAnUong"];
            GiaNiemYet = (float)Convert.ToDouble(row["giaNiemYet"].ToString());
        }

        public int MaDoAnUong { get => maDoAnUong; set => maDoAnUong = value; }
        public string TenDoAnUong { get => tenDoAnUong; set => tenDoAnUong = value; }
        public int MaLoaiDoAnUong { get => maLoaiDoAnUong; set => maLoaiDoAnUong = value; }
        public float GiaNiemYet { get => giaNiemYet; set => giaNiemYet = value; }
    }
}
