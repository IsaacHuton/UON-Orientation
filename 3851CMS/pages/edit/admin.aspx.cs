using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3851CMS.pages.edit
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string pageId = Request.QueryString["page"];
                if (string.IsNullOrEmpty(pageId))
                {
                    pageId = "1"; //default 
                }
                switch (pageId)
                {
                    case "1":
                        webContent.Attributes["src"] = "/pages/edit/EditIndex.aspx";
                        break;
                    case "2":
                        webContent.Attributes["src"] = "/pages/edit/EditArticle.aspx";
                        break;
                    case "3":
                        webContent.Attributes["src"] = "/pages/edit/EditQA.aspx";
                        break;
                    case "4":
                        webContent.Attributes["src"] = "/pages/edit/EditDiscipline.aspx";
                        break;
                }
            }
        }
    }
}