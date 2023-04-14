using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace DACN_To_chuc_thi.Models
{
    public class DataProvider
    {
        private static DataProvider thuc_Thi; 
        public static DataProvider Thuc_Thi
        {
            get
            {
                if (thuc_Thi == null)
                {
                    thuc_Thi = new DataProvider();
                }
                return thuc_Thi;
            }
        }

        string connectionString = @"Data Source=LAPTOP-HAD0QVLJ\SQL_2019;Initial Catalog=DACN_To_Chuc_Thi;Integrated Security=True";


        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int res;
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listParameter = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParameter)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                return res = cmd.ExecuteNonQuery();
            }
        }
        public DataTable GetData(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cm = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listParameter = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParameter)
                    {
                        if (item.Contains('@'))
                        {
                            cm.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cm);
                adapter.Fill(data);

                return data;
            }
        }

        public object ExcuteScalar(string query, object[] parameter = null)
        {
            object x = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listParameter = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParameter)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                } 
                x = cmd.ExecuteScalar();
            } 
            return x;
        }


    }
}