using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IS385SC_HuaPhuMinhHieu_5649
{
    public class DatabaseConnect
    {
        private SqlConnection connection;
        private void Connect()
        {
           
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Hua Hieu\Downloads\IS385SC_HuaPhuMinhHieu_5649\IS385SC_HuaPhuMinhHieu_5649\IS385SC_HuaPhuMinhHieu_5649\App_Data\QuanLiBanHang.mdf"";Integrated Security=True");
            connection.Open();
        }
        private void Disconnect()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public DataTable getData(string querry)
        {
            DataTable dataTable = new DataTable();
            try
            {
                Connect();
                SqlDataAdapter adapter = new SqlDataAdapter(querry,connection);
                adapter.Fill(dataTable);
            }
            catch (Exception)
            {
                dataTable = null;
            }
            finally
            {
                Disconnect();
            }
            return dataTable;
        }
    }
}