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
    public partial class BookInfo : System.Web.UI.Page
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
            GridBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            GridBind();
            
        }

        private void GridBind() //gridview数据绑定
        {
            string tag = this.DropDownList1.Text;
            int tagindex = (int)this.DropDownList1.SelectedIndex;
            string keyword = this.TextBox1.Text;
            string sql = " ";
            DataManage dm = new DataManage();

            switch (tagindex)
            {
                case 0: sql = "select * from [Library].[library].[Book] where [Bname] like '" + keyword + "'"; break;
                case 1: sql = "select * from [Library].[library].[Book] where [Bwriter] like '" + keyword + "'"; break;
                case 2: sql = "select * from [Library].[library].[Book] where [Bpublish] like '" + keyword + "'"; break;
                case 3: sql = "select * from [Library].[library].[Book] where [Btype] like '" + keyword + "'"; break;
            }

            DataSet ds = dm.ReadSet(sql);

            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
        }

    }
}