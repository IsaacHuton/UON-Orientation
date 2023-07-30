using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3851CMS.pages.edit
{
    public partial class PreviewArticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PreviewData"] != null)
            {
                string html = Session["PreviewData"].ToString();

                // Display the HTML
                litPreview.Text = html;
            }
        }

    }
}