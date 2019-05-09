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
    public partial class Borrow : System.Web.UI.Page
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
            string rid = this.TextBox1.Text;
            DataManage dm = new DataManage();
            string sql1 = "select * from [Library].[library].[Reader] where [Rnumber] like '" + rid + "'";

            DataTable rtable = dm.ReadTable(sql1);

            this.Label2.Text = rtable.Rows[0][1].ToString();
            this.Label3.Text = rtable.Rows[0][2].ToString();
            this.Label4.Text = rtable.Rows[0][3].ToString();
            this.Label5.Text = rtable.Rows[0][4].ToString();

            //string sql2 = "select * from [Library].[library].[Borrow] where [BorrowRnum] like '" + rid + "' and [Bookstate] like 'Unreturn'";
            gridBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string rname=this.Label2.Text;  //读者姓名
            string rnum=this.Label3.Text;   //读者学/工号
            string rtype = this.Label4.Text;    //读者类型
            int bnum = Convert.ToInt32(this.Label5.Text);   //可借数量

            string bname = this.TextBox2.Text;  //图书名称
            string bid = this.TextBox3.Text;    //图书序号

            string date = DateTime.Now.ToShortDateString().ToString();  //借书日期
            string deadline = date;     //应还日期

            switch(rtype)   //改应还日期
            {
                case "本科生": deadline = DateTime.Now.AddDays(60).ToShortDateString().ToString(); break;
                case "研究生": deadline = DateTime.Now.AddDays(90).ToShortDateString().ToString(); break;
                case "博士生": deadline = DateTime.Now.AddDays(100).ToShortDateString().ToString(); break;
                case "教职工": deadline = DateTime.Now.AddDays(100).ToShortDateString().ToString(); break;
            }

            DataManage dm = new DataManage();

            string sql_1 = "select count(*) from [Library].[library].[Borrow] where [BorrowRnum] like '" + rnum + "' and [Bookstate] like 'Unreturn'";
            DataTable dt=dm.ReadTable(sql_1);

            if(Convert.ToInt32(dt.Rows[0][0])>bnum) //判断书借到限额
            {
                Response.Write("<script>alert('借书达到限额！')</script>");
            }
            else
            {
                string sql = "insert into [Library].[library].[Borrow] ([BorrowRname],[BorrowRnum],[BorrowBname],[BorrowBid],[Bookstate],[BorrowDate],[BorrowDeadline]) values ('" + rname + "','" + rnum + "','" + bname + "','" + bid + "','Unreturn','" + date + "','" + deadline + "')";            
                dm.ExecuteSql(sql);

                gridBind();

                int bookid=Convert.ToInt32(bid);
                hotdata(bookid, bname);

                this.TextBox2.Text = null;
                this.TextBox3.Text = null;
                Response.Write("<script>alert('借阅成功！')</script>");
            }
            
        }

        private void gridBind() //gridview数据绑定
        {
            string rid = this.TextBox1.Text;
            string sql = "select * from [Library].[library].[Borrow] where [BorrowRnum] like '" + rid + "' and [Bookstate] like 'Unreturn'";

            DataManage dm = new DataManage();
            DataSet ds = dm.ReadSet(sql);
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
        }

        private void hotdata(int bookid,string bookname)  //hot表插数据
        {
            int id = bookid;
            string name = bookname;

            string sql_book_search="select * from [Library].[library].[Book] where [Bid] like "+id;

            DataManage dm=new DataManage();
            DataTable dt=dm.ReadTable(sql_book_search);

            string Hbname=dt.Rows[0][1].ToString();
            string Hbwriter=dt.Rows[0][3].ToString();
            string Hbpublisher=dt.Rows[0][4].ToString();
            string Hbtype=dt.Rows[0][2].ToString();

            string sql_hot_search = "select * from [Library].[library].[Hot] where [Hbname] like '" + name + "'";
            string sql_hot_insert = "insert into [Library].[library].[Hot] ([Hbname],[Hbwriter],[Hbpublisher],[Hbtype],[Hot]) values ('" + Hbname + "','" + Hbwriter + "','" + Hbpublisher + "','" + Hbtype + "',1)";
            string sql_hot_update = string.Empty;

            DataTable dt_2 = dm.ReadTable(sql_hot_search);
            if(dt_2.Rows.Count>0)
            {
                int count=Convert.ToInt32(dt_2.Rows[0][5].ToString())+1;
                sql_hot_update = "update [Library].[library].[Hot] set [Hot] = " + count + " where [Hbname] like '" + name + "'";
                dm.ExecuteSql(sql_hot_update);
            }
            else
            {
                dm.ExecuteSql(sql_hot_insert);
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)  //续借
        {
            if (e.CommandName == "Reborrow")
            {
                string rid = this.Label3.Text;

                int index = Convert.ToInt32(e.CommandArgument);
                string bid = this.GridView1.Rows[index].Cells[0].Text.ToString();

                DateTime old_deadline=Convert.ToDateTime(this.GridView1.Rows[index].Cells[3].Text.ToString());
                string new_deadline = old_deadline.AddDays(30).ToShortDateString().ToString();

                string sql_borrow_adddays = "update [Library].[library].[Borrow] set [BorrowDeadline] = '" + new_deadline + "' where [BorrowRnum] like '" + rid + "' and [BorrowBid] like '" + bid + "'";
                DataManage dm = new DataManage();
                dm.ExecuteSql(sql_borrow_adddays);
                
                gridBind();

                Response.Write("<script>alert('续借成功！')</script>");
            }
        }
    }
}