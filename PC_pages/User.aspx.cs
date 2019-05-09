using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryDemo_1.PC_pages
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminName"] == null)
            {
                Response.Redirect("./AdminLogin.aspx");
            }
            else
            {
                this.iframe1.Attributes["src"] = "./ReaderInfo.aspx";
            }
        }


        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (this.Menu1.Items[0].Selected)
            {
                this.iframe1.Attributes["src"] = "./ReaderInfo.aspx";
            }
            else if (this.Menu1.Items[1].Selected)
            {
                this.iframe1.Attributes["src"] = "./AdminInfo.aspx";
            }
        }



    }
}