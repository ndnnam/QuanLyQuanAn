using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DAO
{
    internal class CungCapDuLieu
    {
        private static CungCapDuLieu instance;
        private string chuoiKetNoi = "Data Source=.\\NHUTNAM;Initial Catalog=QuanLyQuanAn;Integrated Security=True";

        private CungCapDuLieu() { }

        internal DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(chuoiKetNoi))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string para in listPara)
                    {
                        if (para.Contains('@'))
                        {
                            command.Parameters.AddWithValue(para, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
            }
            return data;
        }

        internal int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(chuoiKetNoi))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string para in listPara)
                    {
                        if (para.Contains('@'))
                        {
                            command.Parameters.AddWithValue(para, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
            }
            return data;
        }

        internal object ExecuteScalar(string query, object[] parameter = null)
        {
            using (SqlConnection connection = new SqlConnection(chuoiKetNoi))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string para in listPara)
                    {
                        if (para.Contains('@'))
                        {
                            command.Parameters.AddWithValue(para, parameter[i]);
                            i++;
                        }
                    }
                }
                return command.ExecuteScalar();
            }
        }

        internal static CungCapDuLieu Instance
        {
            get
            {
                if (instance == null) { instance = new CungCapDuLieu(); }
                return instance;
            }
            private set { instance = value; }
        }
    }
}
