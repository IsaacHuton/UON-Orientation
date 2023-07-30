using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using _3851CMS.Utils;
using MarkdownSharp;

namespace _3851CMS.pages.front
{
    public partial class Guide : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadArticleContent("To-do List");
                string pageId = Request.QueryString["sub"];
                switch (pageId)
                {
                    case "1":
                        toKnowLink.Attributes["class"] = string.Empty;
                        toDoLink.Attributes["class"] = "highlight";
                        LoadArticleContent("To-do List");
                        break;
                    case "2":
                        toDoLink.Attributes["class"] = string.Empty;
                        toKnowLink.Attributes["class"] = "highlight";
                        LoadArticleContent("What you need to know");
                        break;
                }
            }
        }

        private void LoadArticleContent(string articleTitle)
        {
            // Get the article body for given article title
            DataTable articleTable = SQLUtils.GetTable($"SELECT Article_Body FROM Article WHERE Article_Title = '{articleTitle}'");
            if (articleTable.Rows.Count > 0)
            {
                string articleBody = articleTable.Rows[0]["Article_Body"].ToString();
                // Transform markdown to HTML
                var markdown = new Markdown();
                string articleHTML = markdown.Transform(articleBody);

                GuideLiteral.Text = articleHTML;
            }   

        }
        protected void LoadMarkdown_Click(object sender, EventArgs e)
        {
            var control = sender as HtmlAnchor;

            // Reset class for all links
            toDoLink.Attributes["class"] = string.Empty;
            toKnowLink.Attributes["class"] = string.Empty;

            // Add 'highlight' class to the clicked link
            control.Attributes["class"] = "highlight";

            string id = ((HtmlAnchor)sender).ID;
            string articleBody = string.Empty;

            if (id == "toDoLink")
            {
                DataTable dt = SQLUtils.GetTable("SELECT Article_Body FROM Article WHERE Article_Title = 'To-do List'");
                articleBody = dt.Rows[0]["Article_Body"].ToString();
            }
            else if (id == "toKnowLink")
            {
                DataTable dt = SQLUtils.GetTable("SELECT Article_Body FROM Article WHERE Article_Title = 'What you need to know'");
                articleBody = dt.Rows[0]["Article_Body"].ToString();
            }

            // Transform the Markdown text 
            var markdown = new Markdown();
            string articleHTML = markdown.Transform(articleBody);

            // Display the HTML in the Literal
            GuideLiteral.Text = articleHTML;
        }

    }
}