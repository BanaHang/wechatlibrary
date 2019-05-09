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
    public partial class Reader : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["AdminName"] == null)
                {
                    Response.Write("<script>alert('管理员请登录！')</script>");
                }
                else
                {
                    this.TextBox1.ReadOnly = true;
                    this.TextBox2.ReadOnly = true;
                    this.TextBox3.ReadOnly = true;
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
            this.DropDownList1.Enabled = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string name = this.TextBox1.Text;
            string num = this.TextBox2.Text;
            string pwd = this.TextBox3.Text;
            string type = this.DropDownList1.SelectedItem.Text;
            int allocation = Convert.ToInt32(this.Label2.Text);

            int typeindex=(int)this.DropDownList1.SelectedIndex;
            switch (typeindex)
            {
                case 0: allocation=6; break;
                case 1: allocation=9; break;
                case 2: allocation=12; break;
                case 3: allocation = 12; break;
            }

            string sql = "update [Library].[library].[Reader] set [Rname]='" + name + "', [Rnumber]='" + num + "', [Rtype]='" + type + "', [Rallocation]=" + allocation + ", [Rpwd]='" + pwd + "' where [Rid] = " + Label1.Text;

            DataManage dm = new DataManage();

            if (this.TextBox1.ReadOnly==false)
            {
                dm.ExecuteSql(sql);
                this.TextBox1.ReadOnly = true;
                this.TextBox2.ReadOnly = true;
                this.TextBox3.ReadOnly = true;
                this.DropDownList1.Enabled = false;
                this.Label2.Text = allocation.ToString();
                Response.Write("<script>修改成功！</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sql = "delete from [Library].[library].[Reader] where [Rid] = " + Label1.Text;
            DataManage dm = new DataManage();
            if (this.TextBox1.ReadOnly==true)
            {
                dm.ExecuteSql(sql);
                Response.Write("<script>删除成功！</script>");
            }
        }

        public void getdata()
        {
            string getid = Request.QueryString["ID"].ToString();
            string sql = "select * from [Library].[library].[Reader] where [Rid] = " + getid;

            DataManage dm = new DataManage();
            DataTable dt = dm.ReadTable(sql);
            this.Label1.Text = dt.Rows[0][0].ToString();
            this.TextBox1.Text = dt.Rows[0][1].ToString();
            this.TextBox2.Text = dt.Rows[0][2].ToString();
            this.DropDownList1.Text=dt.Rows[0][3].ToString();
            this.Label2.Text = dt.Rows[0][4].ToString();
            this.TextBox3.Text = dt.Rows[0][5].ToString();
        }
    }
}