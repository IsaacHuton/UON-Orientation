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
    public partial class StudentLife : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LoadArticleContent("Career Service");
                string pageId = Request.QueryString["sub"];
                switch (pageId) 
                { 
                    case "1":
                        studentClubsLink.Attributes["class"] = string.Empty;
                        careerServiceLink.Attributes["class"] = "highlight";
                        LoadArticleContent("Career Service");
                        break;
                    case "2":
                        careerServiceLink.Attributes["class"] = string.Empty;
                        studentClubsLink.Attributes["class"] = "highlight";
                        LoadArticleContent("Student Clubs");
                        break;
                }
            }
        }

        protected void LoadMarkdown_Click(object sender, EventArgs e)
        {
            var control = sender as HtmlAnchor;

            studentClubsLink.Attributes["class"] = string.Empty;
            careerServiceLink.Attributes["class"] = string.Empty;

            control.Attributes["class"] = "highlight";
            string id = ((HtmlAnchor)sender).ID;
            if(id == "careerServiceLink")
            {
                LoadArticleContent("Career Service");
            }
            else if (id == "studentClubsLink")
            {
                LoadArticleContent("Student Clubs");
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

                studentLifeLiteral.Text = articleHTML;
            }
        }
        }
}