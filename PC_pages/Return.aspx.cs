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
    public partial class Return : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["AdminName"] == null)
                {
                    Response.Redirect("./AdminLogin.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            gridBind();
        }

        private void gridBind()  //gridview数据绑定
        {
            string tag = this.DropDownList1.Text;
            int tagindex = (int)this.DropDownList1.SelectedIndex;
            string keyword = this.TextBox1.Text;
            string sql = " ";
            DataManage dm = new DataManage();

            switch (tagindex)
            {
                case 0: sql = "select * from [Library].[library].[Borrow] where [BorrowBname] like '" + keyword + "' and [Bookstate] like 'Unreturn'"; break;
                case 1: sql = "select * from [Library].[library].[Borrow] where [BorrowBid] like '" + keyword + "' and [Bookstate] like 'Unreturn'"; break;
                case 2: sql = "select * from [Library].[library].[Borrow] where [BorrowRname] like '" + keyword + "' and [Bookstate] like 'Unreturn'"; break;
                case 3: sql = "select * from [Library].[library].[Borrow] where [BorrowRnum] like '" + keyword + "' and [Bookstate] like 'Unreturn'"; break;
            }

            DataTable dt = dm.ReadTable(sql);

            DataTable table = new DataTable();

            DataColumn dc1 = new DataColumn("BorrowBid");
            DataColumn dc2 = new DataColumn("BorrowBname");
            DataColumn dc3 = new DataColumn("BorrowRname");
            DataColumn dc4 = new DataColumn("BorrowRnum");
            DataColumn dc5 = new DataColumn("BorrowDate");
            DataColumn dc6 = new DataColumn("BorrowDeadline");
            DataColumn dc7 = new DataColumn("Bookstate");
            DataColumn dc8 = new DataColumn("IsOutDate");
            DataColumn dc9 = new DataColumn("Borrowid");

            table.Columns.Add(dc1);
            table.Columns.Add(dc2);
            table.Columns.Add(dc3);
            table.Columns.Add(dc4);
            table.Columns.Add(dc5);
            table.Columns.Add(dc6);
            table.Columns.Add(dc7);
            table.Columns.Add(dc8);
            table.Columns.Add(dc9);

            foreach (DataRow dr in dt.Rows)
            {
                DataRow row = table.NewRow();
                row["Borrowid"] = dr["Borrowid"];
                row["BorrowBid"] = dr["BorrowBid"];
                row["BorrowBname"] = dr["BorrowBname"];
                row["BorrowRname"] = dr["BorrowRname"];
                row["BorrowRnum"] = dr["BorrowRnum"];
                row["BorrowDate"] = dr["BorrowDate"];
                row["BorrowDeadline"] = dr["BorrowDeadline"];
                row["Bookstate"] = dr["Bookstate"];

                DateTime dt1 = Convert.ToDateTime(dr["BorrowDeadline"]);
                DateTime dt2 = DateTime.Now;

                if(dt1>=dt2)
                {
                    row["IsOutDate"] = "Not";
                }
                else
                {
                    row["IsOutDate"] = "Yes";
                }

                table.Rows.Add(row);
            }

            this.GridView1.DataSource = table;
            this.GridView1.DataBind();
        }



        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "return")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string borrowid = this.GridView1.Rows[index].Cells[0].Text.ToString();

                string sql = "update [Library].[library].[Borrow] set [Bookstate] ='return' where [Borrowid] = " + borrowid;
               
                DataManage dm = new DataManage();
                dm.ExecuteSql(sql);
                Response.Write("<script>alert('还书成功！')</script>");

                gridBind();
            }
        }
    }
}