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
    public partial class Apply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = this.TextBox3.Text;
            string writer = this.TextBox4.Text;
            string publish = this.TextBox5.Text;
            string date = DateTime.Now.ToShortDateString().ToString();

            DataManage dm = new DataManage();

            string sql = "insert into [Library].[library].[Apply] ([ApplyBname], [ApplyBwriter],[ApplyBpublish],[ApplyDate]) VALUES ('" + name + "','" + writer + "','" + publish + "','" + date + "')";

            if (Page.IsValid == true)
            {
                dm.ExecuteSql(sql);
                Response.Write("<script>alert('申请成功！')</script>");
                Response.Redirect("Success.aspx", true);
            }
        }
    }
}