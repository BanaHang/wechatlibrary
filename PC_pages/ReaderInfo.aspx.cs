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
    public partial class ReaderInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string tag = this.DropDownList1.Text;
            int tagindex = (int)this.DropDownList1.SelectedIndex;
            string keyword = this.TextBox1.Text;
            string sql = " ";
            DataManage dm = new DataManage();

            if (tagindex == 0)
            {
                sql = "select [Rid],[Rname],[Rnumber],[Rtype],[Rallocation] from [Library].[library].[Reader] where [Rname] like '" + keyword + "'";
            }
            else if (tagindex == 1)
            {
                sql = "select [Rid],[Rname],[Rnumber],[Rtype],[Rallocation] from [Library].[library].[Reader] where [Rnumber] like '" + keyword + "'";
            }
            else
            {
                Response.Write("<script>找不到该用户！</script>");
            }

            DataSet ds = dm.ReadSet(sql);
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
        }
    }
}