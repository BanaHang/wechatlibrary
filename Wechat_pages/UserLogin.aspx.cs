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
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                string url = "UserPage.aspx?name=" + Session["UserName"].ToString() + "&id=" + Session["UserNumber"].ToString();
                Response.Redirect(url, true); ;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = this.TextBox1.Text;
            string pwd = this.TextBox2.Text;

            string sql = "select * from [Library].[library].[Reader] where [Rname] like '" + name + "' and [Rpwd] like '" + pwd + "'";

            DataManage dm = new DataManage();
            DataTable dt = dm.ReadTable(sql);
            if(dt.Rows.Count>0)
            {
                Session["UserName"] = name;
                Session["UserNumber"] = dt.Rows[0][2].ToString();
                string url = "UserPage.aspx?name=" + Session["UserName"].ToString() + "&id=" + Session["UserNumber"].ToString();
                Response.Redirect(url, true);
            }
            else
            {
                Response.Write("<script>alert('登陆失败！')</script>");
            }
        }
    }
}