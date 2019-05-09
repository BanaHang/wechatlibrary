using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace LibraryDemo_1.App_Code
{
    public class DataManage
    {
        string ConnStr{get;set;} //数据库连接字段

        public DataManage()
        {
            ConnStr = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
            //ConnStr="Server=106.15.186.200; Database=library; User ID=accountforlogin; Password=Banahang2018";
        }

        #region  数据库操作方法

        public DataTable ReadTable(string Sql)  //查找返回datatable
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = Sql;
            SqlDataAdapter adp=new SqlDataAdapter();
            adp.SelectCommand = cmd;
            adp.Fill(dt);
            cmd.Dispose();
            conn.Close();
            return dt;
        }

        public DataSet ReadSet(string Sql)  //查找返回dataset
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = Sql;
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = cmd;
            adp.Fill(ds);
            cmd.Dispose();
            conn.Close();
            return ds;
        }

        public SqlDataReader RowReader(string Sql)  //查找返回datareader，按顺序返回一行
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = Sql;
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                cmd.Dispose();
                return reader;
            }
            else
            {
                cmd.Dispose();
                return null;
            }
        }

        public void ExecuteSql(string Sql)  //执行更新语句
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = Sql;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
        

        #endregion
    }
    
}