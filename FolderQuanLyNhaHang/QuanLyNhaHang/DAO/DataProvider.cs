using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    internal class DataProvider
    {
        private string connectionString = $@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=QuanLyNhaHang;Integrated Security=True";
        
        private static DataProvider intance;

        internal static DataProvider Intance { get { if (intance == null) intance = new DataProvider(); return DataProvider.intance; } private set => intance = value; }

        private DataProvider() { }
        public DataTable ExcuteQuery(String query, object[] parameter = null)
        {
            DataTable dt = new DataTable();

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query,conn);


                if(parameter != null)
                {
                    string[] listPare = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPare)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i++]);
                        }
                    }
                    
                }


                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
                conn.Close();
            }

            return dt;
        }

        public int ExcuteNonQuery(String query, object[] parameter = null)
        {
            int dt = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);


                if (parameter != null)
                {
                    string[] listPare = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPare)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i++]);
                        }
                    }

                }


                dt = cmd.ExecuteNonQuery();
                conn.Close();
            }

            return dt;
        }

        public object ExcuteScala(String query, object[] parameter = null)
        {
            object dt = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);


                if (parameter != null)
                {
                    string[] listPare = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPare)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i++]);
                        }
                    }

                }


                dt = (object)cmd.ExecuteScalar();
                conn.Close();
            }

            return dt;
        }

    }
}
