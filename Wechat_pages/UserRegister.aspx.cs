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
    public partial class UserRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = this.TextBox3.Text;
            string num = this.TextBox4.Text;
            string pwd = this.TextBox5.Text;
            string type = this.DropDownList1.SelectedItem.Text;

            int index = this.DropDownList1.SelectedIndex;
            int allocation = -1;

            switch(index)
            {
                case 0: allocation = 6; break;
                case 1: allocation = 9; break;
                case 2: allocation = 12; break;
                case 3: allocation = 12; break;
            }

            string sql_1 = "insert into [Library].[library].[Reader] ([Rname], [Rnumber],[Rtype],[Rallocation],[Rpwd]) VALUES ('" + name + "','" + num + "','" + type + "'," + allocation + ",'" + pwd + "')";

            string sql_2 = "select * from [Library].[library].[Reader] where [Rname] like '" + name + "' and [Rnumber] like '" + num + "'";

            DataManage dm = new DataManage();
            if (Page.IsValid == true)
            {
                DataTable dt = dm.ReadTable(sql_2);
                if(dt.Rows.Count>0)
                {
                    Response.Write("<script>alert('该用户已存在！')</script>");
                }
                else
                {
                    dm.ExecuteSql(sql_1);
                    Session["UserName"] = name;
                    Session["UserNumber"] = num;
                    Response.Write("<script>alert('注册成功！')</script>");
                    string url = "UserPage.aspx?name=" + Session["UserName"].ToString() + "&id=" + Session["UserNumber"].ToString();
                    Response.Redirect(url, true);
                }
                
            }
        }
    }
}