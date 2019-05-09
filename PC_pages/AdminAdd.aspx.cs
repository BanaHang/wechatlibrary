using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryDemo_1.App_Code;
using System.Data.SqlClient;
using System.Data;

namespace LibraryDemo_1.PC_pages
{
    public partial class AdminAdd1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataManage dm = new DataManage();
            string name = TextBox3.Text;
            string num = TextBox4.Text;
            string pwd = TextBox5.Text;

            string sql = "insert into [Library].[library].[Admin] ([Adminname], [Adminnum],[Adminpwd]) VALUES ('" + name + "','" + num + "','" + pwd + "')";
            if (Page.IsValid == true)
            {
                dm.ExecuteSql(sql);
                Session["AdminName"] = name;
                Response.Write("<script>注册成功！</script>");
                Response.Redirect("./AdminPage.aspx", true);
            }
        }

        protected void CustomValidate_1(object source, ServerValidateEventArgs args)
        {
            DataManage dm = new DataManage();
            string name = TextBox1.Text;
            string pwd = TextBox2.Text;
            string sql = "select * from [Library].[library].[Admin] where [Adminname] like '" + name + "' and [Adminpwd] like '" + pwd + "'";
            SqlDataReader reader = dm.RowReader(sql);
            if (reader != null)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}