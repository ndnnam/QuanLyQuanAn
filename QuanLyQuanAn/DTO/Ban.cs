using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    internal class Ban
    {
        private int maBan;
        private string tenBan;
        private string trangThaiBan;

        internal Ban(int maBan, string tenBan, string trangThaiBan)
        {
            MaBan = maBan;
            TenBan = tenBan;
            TrangThaiBan = trangThaiBan;
        }

        internal Ban(DataRow row)
        {
            MaBan = (int)row["maBan"];
            TenBan = row["tenBan"].ToString();
            TrangThaiBan = row["trangThaiBan"].ToString();
        }

        public int MaBan { get => maBan; set => maBan = value; }
        public string TenBan { get => tenBan; set => tenBan = value; }
        public string TrangThaiBan { get => trangThaiBan; set => trangThaiBan = value; }
    }
}
