using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    internal class LoaiDoAnUong
    {
        private int maLoaiDoAnUong;
        private string tenLoaiDoAnUong;

        internal LoaiDoAnUong(int maLoaiDoAnUong, string tenLoaiDoAnUong)
        {
            MaLoaiDoAnUong = maLoaiDoAnUong;
            TenLoaiDoAnUong = tenLoaiDoAnUong;
        }

        internal LoaiDoAnUong(DataRow row)
        {
            MaLoaiDoAnUong = (int)row["maLoaiDoAnUong"];
            TenLoaiDoAnUong = row["tenLoaiDoAnUong"].ToString();
        }

        public int MaLoaiDoAnUong { get => maLoaiDoAnUong; set => maLoaiDoAnUong = value; }
        public string TenLoaiDoAnUong { get => tenLoaiDoAnUong; set => tenLoaiDoAnUong = value; }
    }
}
