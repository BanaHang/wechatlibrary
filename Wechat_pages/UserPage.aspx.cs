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
    public partial class UserPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("UserLogin.aspx", true);
            }
            else
            {
                string name = Request.QueryString["name"];
                string id = Request.QueryString["id"];
                
                if(name==null||id==null)
                {
                    Response.Redirect("UserLogin.aspx", true);
                }
                else
                {
                    databind(name,id);
                
                    gridbind_1(name, id);

                    gridbind_2(name, id);
                }
                
            }
                        
        }

        private void databind(string name,string id) //table绑定
        {
            string sql = "select * from [Library].[library].[Reader] where [Rname] = '" + name + "' and [Rnumber]='" + id + "'";
            DataManage dm = new DataManage();
            DataTable dt = dm.ReadTable(sql);

            this.Label1.Text = dt.Rows[0][0].ToString();
            this.Label2.Text = dt.Rows[0][1].ToString();
            this.Label3.Text = dt.Rows[0][2].ToString();
            this.Label4.Text = dt.Rows[0][3].ToString();
            this.Label5.Text = dt.Rows[0][4].ToString();
        }

        private void gridbind_1(string name, string id)  //gridview_1绑定
        {
            string sql = "select * from [Library].[library].[Borrow] where [BorrowRname] like '" + name + "' and [BorrowRnum] like '" + id + "' and [Bookstate] like 'Unreturn'";
            DataManage dm = new DataManage();
            DataTable dt = dm.ReadTable(sql);

            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }

        private void gridbind_2(string name, string id) //gridview_2绑定
        {
            DataManage dm = new DataManage();

            string sql = "select * from [Library].[library].[Order] where [OrderRname] like '" + name + "' and [OrderRnum] like '" + id + "'";
            DataTable dt = dm.ReadTable(sql);

            DataTable table = new DataTable();
            table.Columns.Add("OrderBname");
            table.Columns.Add("Contains");

            foreach(DataRow dr in dt.Rows)
            {
                int bookid = Convert.ToInt32(dr[4]);
                string sql_1 = "select count(*) from [Library].[library].[Borrow] where [BorrowBid] like " + bookid + " and [Bookstate] like 'Unreturn'";
                DataTable dt_1 = dm.ReadTable(sql_1);
                int numout = Convert.ToInt32(dt_1.Rows[0][0]);  //外借数量

                string sql_2 = "select * from [Library].[library].[Book] where [Bid] like " + bookid;
                DataTable dt_2 = dm.ReadTable(sql_2);
                int numall = 0; //总数量

                if(dt_2.Rows.Count>0)
                {
                    numall=Convert.ToInt32(dt_2.Rows[0][5]);
                }
                else
                {
                    numall=0;
                }
                
                int remains = numall - numout;  //剩余数量

                DataRow row = table.NewRow();
                row["OrderBname"] = dr[3].ToString();
                row["Contains"] = remains.ToString();
                table.Rows.Add(row);
            }

            this.GridView2.DataSource = table;
            this.GridView2.DataBind();
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                string reader = this.Label2.Text;

                int index = Convert.ToInt32(e.CommandArgument);
                string book = this.GridView2.Rows[index].Cells[0].Text.ToString();

                string sql_order_delete = "delete from [Library].[library].[Order] where [OrderRname] like '" + reader + "' and [OrderBname] like '" + book + "'";
                DataManage dm = new DataManage();
                dm.ExecuteSql(sql_order_delete);

                Response.Write("<script>alert('取消成功！')</script>");
            }
        }
    }
}