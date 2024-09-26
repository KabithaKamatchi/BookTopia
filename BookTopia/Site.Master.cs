using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookTopia
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddBook_Click(object sender, EventArgs e)
        {

            Response.Redirect($"~/BookTopia/AddBooks.aspx");
        }

        protected void btnViewBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BookTopia/ViewBooks.aspx");
        }
    }
}