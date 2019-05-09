using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryDemo_1.App_Code;
using System.Data.SqlClient;
using System.Data;

namespace LibraryDemo_1.Wechat_pages
{
    public partial class SearchResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            databind();
        }

        private void databind()
        {
            DataManage dm = new DataManage();
            DataTable dt = new DataTable();

            string bookname=Request.QueryString["Bookname"];
            string bookwriter=Request.QueryString["BookWriter"];

            if(bookname!=null)
            {
                //Response.Write("<script>alert('书名不空')</script>");
                string sql_1="select * from [Library].[library].[Book] where [Bname] like '" + bookname + "'";
                dt = dm.ReadTable(sql_1);
            }
            else if(bookwriter!=null)
            {
                //Response.Write("<script>alert('作者不空')</script>");
                string sql_2 = "select * from [Library].[library].[Book] where [Bwriter] like '" + bookwriter + "'";
                dt = dm.ReadTable(sql_2);
            }
            else
            {
                Response.Write("<script>alert('查找失败！')</script>");
            }

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            DataList1.DataSource = pds;
            DataList1.DataBind();
        }
    }
}