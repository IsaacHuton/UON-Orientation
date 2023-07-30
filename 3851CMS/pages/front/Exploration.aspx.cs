using _3851CMS.Utils;
using MarkdownSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _3851CMS.pages.front
{
    public partial class Exploration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadArticleContent("Live in Singapore");
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

                ExpLiteral.Text = articleHTML;
            }

        }
        protected void LoadMarkdown_Click(object sender, EventArgs e)
        {
            var control = sender as HtmlAnchor;

            // Reset class for all links
            liveLink.Attributes["class"] = string.Empty;

            // Add 'highlight' class to the clicked link
            control.Attributes["class"] = "highlight";

            string id = ((HtmlAnchor)sender).ID;
            string articleBody = string.Empty;

            if (id == "liveLink")
            {
                DataTable dt = SQLUtils.GetTable("SELECT Article_Body FROM Article WHERE Article_Title = 'Live in Singapore'");
                articleBody = dt.Rows[0]["Article_Body"].ToString();
            }

            // Transform the Markdown text 
            var markdown = new Markdown();
            string articleHTML = markdown.Transform(articleBody);

            // Display the HTML in the Literal
            ExpLiteral.Text = articleHTML;
        }
    }
}