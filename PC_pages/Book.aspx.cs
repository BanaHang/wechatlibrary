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
    public partial class Book : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if(Session["AdminName"]==null)
                {
                    Response.Redirect("./AdminLogin.aspx");
                }
                else
                {
                    this.TextBox1.ReadOnly = true;
                    this.TextBox2.ReadOnly = true;
                    this.TextBox3.ReadOnly = true;
                    this.TextBox4.ReadOnly = true;
                    this.DropDownList1.Enabled = false;
                    getdata();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.TextBox1.ReadOnly = false;
            this.TextBox2.ReadOnly = false;
            this.TextBox3.ReadOnly = false;
            this.TextBox4.ReadOnly = false;
            this.DropDownList1.Enabled = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string name = this.TextBox1.Text;
            string type = this.DropDownList1.SelectedItem.Text;
            string writer = this.TextBox2.Text;
            string publish = this.TextBox3.Text;
            string price = this.TextBox4.Text;

            string sql = "update [Library].[library].[Book] set [Bname]='" + name + "', [Btype]='" + type + "', [Bwriter]='" + writer + "', [Bpublish]='" + publish + "', [Bprice]='" + price + "' where [Bid] = " + Label1.Text;

            DataManage dm = new DataManage();

            if (this.TextBox1.ReadOnly==false)
            {
                dm.ExecuteSql(sql);
                this.TextBox1.ReadOnly = true;
                this.TextBox2.ReadOnly = true;
                this.TextBox3.ReadOnly = true;
                this.TextBox4.ReadOnly = true;
                this.DropDownList1.Enabled = false;
                Response.Write("<script>alert('修改成功！')</script>");
            }
        }

        public void getdata()
        {
            string getid = Request.QueryString["ID"].ToString();
            string sql = "select * from [Library].[library].[Book] where [Bid] = " + getid;

            DataManage dm = new DataManage();
            DataTable dt = dm.ReadTable(sql);
            this.Label1.Text = dt.Rows[0][0].ToString();
            this.TextBox1.Text = dt.Rows[0][1].ToString();
            this.DropDownList1.SelectedItem.Text=dt.Rows[0][2].ToString();
            this.TextBox2.Text = dt.Rows[0][3].ToString();
            this.TextBox3.Text = dt.Rows[0][4].ToString();
            this.Label2.Text = dt.Rows[0][5].ToString();
            this.TextBox4.Text = dt.Rows[0][6].ToString();
        }

    }
}