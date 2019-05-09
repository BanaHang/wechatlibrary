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
    public partial class Book : System.Web.UI.Page
    {      
        protected void Page_Load(object sender, EventArgs e)
        {
            databind();
        }

        private void databind()
        {
            DataManage dm = new DataManage();
            int id = Convert.ToInt32(Request.QueryString["id"]);

            string sql_1="select * from [Library].[library].[Book] where [Bid] like " + id;
            DataTable dt_1 = dm.ReadTable(sql_1);

            int numall = Convert.ToInt32(dt_1.Rows[0][5]); //总数量

            string sql_2="select count(*) from [Library].[library].[Borrow] where [BorrowBid] like " + id + " and [Bookstate] like 'Unreturn'";
            DataTable dt_2 = dm.ReadTable(sql_2);

            int numout = Convert.ToInt32(dt_2.Rows[0][0]);  //外借数量

            int remains = numall - numout;

            if(remains>0)
            {
                this.Button1.Visible = false;
            }
            else
            {
                this.Button1.Visible = true;
            }

            this.Label1.Text = dt_1.Rows[0][0].ToString();
            this.Label2.Text = dt_1.Rows[0][1].ToString();
            this.Label3.Text = dt_1.Rows[0][2].ToString();
            this.Label4.Text = dt_1.Rows[0][3].ToString();
            this.Label5.Text = dt_1.Rows[0][4].ToString();
            this.Label6.Text = remains.ToString();
            this.Label7.Text = dt_1.Rows[0][6].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Order.aspx", true);
        }
    }
}