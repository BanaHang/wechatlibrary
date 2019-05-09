using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryDemo_1.App_Code;
using System.Data.SqlClient;


namespace LibraryDemo_1.PC_pages
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["AdminName"]!=null)
            {
                Response.Redirect("./AdminPage.aspx",true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            string pwd = TextBox2.Text;

            DataManage dm = new DataManage();

            string sql = "select * from [Library].[library].[Admin] where [Adminname] like '" + name + "' and [Adminpwd] like '" + pwd + "'";
            SqlDataReader reader = dm.RowReader(sql);
            if(reader!=null)
            {
                Session["AdminName"] = name;
                Response.Redirect("AdminPage.aspx",true);
            }
            else
            {
                Response.Write("<script>alert('登陆失败！')</script>");
            }
        }
    }
}