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
    public partial class Admin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.TextBox1.ReadOnly = true;
                this.TextBox2.ReadOnly = true;
                this.TextBox3.ReadOnly = true;
                getdata();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.TextBox1.ReadOnly = false;
            this.TextBox2.ReadOnly = false;
            this.TextBox3.ReadOnly = false;;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string name = this.TextBox1.Text;
            string num = this.TextBox2.Text;
            string pwd = this.TextBox3.Text;
            string sql = "update [Library].[library].[Admin] set [Adminname]='" + name + "', [Adminnum]='" + num + "', [Adminpwd]='" + pwd + "' where [Adminid] = "+Label1.Text;

            DataManage dm = new DataManage();

            if(this.TextBox1.ReadOnly==false)
            {
                dm.ExecuteSql(sql);
                this.TextBox1.ReadOnly = true;
                this.TextBox2.ReadOnly = true;
                this.TextBox3.ReadOnly = true;
                Response.Write("<script>alert('修改成功！')</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sql = "delete from [Library].[library].[Admin] where [Adminid] = " + Label1.Text;
            DataManage dm = new DataManage();
            if(this.TextBox1.ReadOnly==true)
            {
                dm.ExecuteSql(sql);
                Response.Write("<script>alert('删除成功！')</script>");
            }
        }

        public void getdata()
        {
            string getid = Request.QueryString["ID"].ToString();
            string sql = "select * from [Library].[library].[Admin] where [Adminid] = " + getid;

            DataManage dm = new DataManage();
            DataTable dt = dm.ReadTable(sql);
            this.Label1.Text = dt.Rows[0][0].ToString();
            this.TextBox1.Text = dt.Rows[0][1].ToString();
            this.TextBox2.Text = dt.Rows[0][2].ToString();
            this.TextBox3.Text = dt.Rows[0][3].ToString();
        }
    }
}