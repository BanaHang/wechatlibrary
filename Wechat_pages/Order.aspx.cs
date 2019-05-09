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
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void dataoperator()
        {
            DataManage dm = new DataManage();
            string rname = this.TextBox3.Text;
            string rnum = this.TextBox4.Text;
            string bid = this.TextBox5.Text;
            string bname = this.TextBox6.Text;

            string sql = "insert into [Library].[library].[Order] ([OrderRname], [OrderRnum],[OrderBname],[OrderBid]) VALUES ('" + rname + "','" + rnum + "','" + bname + "'," + bid + ")";

            if (Page.IsValid == true)
            {
                dm.ExecuteSql(sql);
                Response.Write("<script>预约成功！</script>");
                Response.Redirect("Success.aspx", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            dataoperator();
        }
    }
}