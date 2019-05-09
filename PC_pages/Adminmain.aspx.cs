using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryDemo_1.PC_pages
{
    public partial class Adminmain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminName"] == null)
            {
                Response.Redirect("AdminLogin.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    Label1.Text = Session["AdminName"].ToString();
                    Label2.Text = Application["online"].ToString();
                }

            }
        }
    }
}