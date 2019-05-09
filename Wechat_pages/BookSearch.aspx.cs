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
    public partial class BookSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            this.TextBox1.Attributes.Add("Value", "请输入图书名称或者作者名称");
            this.TextBox1.Attributes.Add("OnFocus", "if(this.value=='请输入图书名称或者作者名称') {this.value=''}");
            this.TextBox1.Attributes.Add("OnBlur", "if(this.value==''){this.value='请输入图书名称或者作者名称'}");

            databind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string keyword = this.TextBox1.Text;

            DataManage dm = new DataManage();

            string sql_1 = "select * from [Library].[library].[Book] where [Bname] like '" + keyword + "'";
            string sql_2 = "select * from [Library].[library].[Book] where [Bwriter] like '" + keyword + "'";

            DataTable dt_1 = dm.ReadTable(sql_1);
            DataTable dt_2 = dm.ReadTable(sql_2);

            if(dt_1.Rows.Count>0)
            {
                string url_1 = "SearchResult.aspx?Bookname=" + keyword;
                Response.Redirect(url_1,true);
            }
            else if(dt_2.Rows.Count>0)
            {
                string url_2 = "SearchResult.aspx?BookWriter=" + keyword;
                Response.Redirect(url_2, true);
            }
            else
            {
                Response.Redirect("NotFound.aspx", true);
            }
        }

        private void databind()
        {
            DataManage dm = new DataManage();
            string sql = "select top 20 * from [Library].[library].[Hot] order by [Hot] desc";
            DataTable dt = dm.ReadTable(sql);
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            DataList1.DataSource = pds;
            DataList1.DataBind();
        }

    }
}