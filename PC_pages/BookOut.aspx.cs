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
    public partial class BookOut : System.Web.UI.Page
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
            databind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int amount = Convert.ToInt32(this.TextBox2.Text);
            int tagindex=-1;

            foreach (GridViewRow GR in this.GridView1.Rows)
            {
                CheckBox CB = (CheckBox)GR.FindControl("CheckBox1");
                if (CB.Checked)
                {
                    tagindex = GR.RowIndex;
                }
            }  

            int bookamount = Convert.ToInt32(this.GridView1.Rows[tagindex].Cells[5].Text);
            int decrease = bookamount - amount;

            DataManage dm = new DataManage();

            if(decrease>0)
            {
                string sql = "update [Library].[library].[Book] set [Bamount] =" + decrease + "where [Bname] like '" + this.GridView1.Rows[tagindex].Cells[1].Text + "' and [Btype] like '" + this.GridView1.Rows[tagindex].Cells[2].Text + "' and [Bwriter] like '" + this.GridView1.Rows[tagindex].Cells[3].Text + "' and [Bpublish] like '" + this.GridView1.Rows[tagindex].Cells[4].Text + "'";
                dm.ExecuteSql(sql);
            }
            else
            {
                string sql = "delete from [Library].[library].[Book] where [Bname] like '" + this.GridView1.Rows[tagindex].Cells[1].Text + "' and [Btype] like '" + this.GridView1.Rows[tagindex].Cells[2].Text + "' and [Bwriter] like '" + this.GridView1.Rows[tagindex].Cells[3].Text + "' and [Bpublish] like '" + this.GridView1.Rows[tagindex].Cells[4].Text + "'";
                dm.ExecuteSql(sql);
            }

            Response.Write("<script>alert('出库成功！')</script>");
            databind();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType==DataControlRowType.DataRow)
            {
                if(e.Row.RowType==DataControlRowType.DataRow)
                {
                    if(e.Row.FindControl("CheckBox1")!=null)
                    {
                        CheckBox cb = (CheckBox)e.Row.FindControl("CheckBox1");
                        cb.AutoPostBack = true;
                        cb.CheckedChanged += new EventHandler(CheckChanged);
                    }
                }
            }
        }

        private void CheckChanged(object sender,EventArgs e)
        {
            var cb = sender as CheckBox;
            foreach(GridViewRow gvr in this.GridView1.Rows)
            {
                if(gvr.RowType==DataControlRowType.DataRow)
                {
                    var cb1 = (CheckBox)gvr.FindControl("CheckBox1");

                    if(cb==cb1)
                    {
                        cb.Checked = true;
                    }
                    if(cb!=cb1&&cb1.Checked)
                    {
                        cb1.Checked = false;
                    }
                }
            }
        }

        private void databind()
        {
            string tag = this.DropDownList1.Text;
            int tagindex = (int)this.DropDownList1.SelectedIndex;
            string keyword = TextBox1.Text;
            string sql = " ";
            DataManage dm = new DataManage();

            if (tagindex == 0)
            {
                sql = "select * from [Library].[library].[Book] where [Bname] like '" + keyword + "'";
            }
            else if (tagindex == 1)
            {
                sql = "select * from [Library].[library].[Book] where [Bwriter] like '" + keyword + "'";
            }
            else
            {
                sql = "select * from [Library].[library].[Book] where [Bpublish] like '" + keyword + "'";
            }

            DataSet ds = dm.ReadSet(sql);
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
        }
    }
}