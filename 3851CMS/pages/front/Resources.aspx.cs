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
    public partial class Resources : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
                // Get all disciplines from the database
                DataTable dtDisciplines = SQLUtils.GetTable("SELECT * FROM Discipline");

                // Fill the dropdownlist
                ddlDiscipline.DataTextField = "Discipline_Name";
                ddlDiscipline.DataValueField = "Discipline_ID";
                ddlDiscipline.DataSource = dtDisciplines;
                ddlDiscipline.DataBind();
                ddlDiscipline.SelectedIndex = 0;
                LoadCourses();

                LoadArticleContent("Academic Support");
                string pageId = Request.QueryString["sub"];
                switch (pageId)
                {
                    case "1":
                        disciplineLink.Attributes["class"] = string.Empty;
                        academicSupportLink.Attributes["class"] = "highlight";
                        LoadArticleContent("Academic Support");
                        break;
                    case "2":
                        academicSupportLink.Attributes["class"] = string.Empty;
                        disciplineLink.Attributes["class"] = "highlight";
                        CourseTable.Visible = true;
                        ResourcesLiteral.Text = string.Empty;
                        break;
                }
            }
        }
        protected void ddlDiscipline_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCourses();
            ResourcesLiteral.Text = string.Empty;
        }
        protected void LoadCourses()
        {
            // Get the selected discipline id
            string disciplineId = ddlDiscipline.SelectedValue;

            // Get all courses related to the discipline from the database
            DataTable dtCourses = SQLUtils.GetTable($"SELECT Course.Course_Code, Course.Course_Name FROM Course INNER JOIN Discipline_Course ON Course.Course_ID = Discipline_Course.Course_ID WHERE Discipline_Course.Discipline_ID = {disciplineId}");

            // Fill the gridview
            gvCourses.DataSource = dtCourses;
            gvCourses.DataBind();
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

                ResourcesLiteral.Text = articleHTML;
            }

        }
        protected void LoadMarkdown_Click(object sender, EventArgs e)
        {
            var control = sender as HtmlAnchor;

            // Reset class for all links
            academicSupportLink.Attributes["class"] = string.Empty;
            disciplineLink.Attributes["class"] = string.Empty;

            // Add 'highlight' class to the clicked link
            control.Attributes["class"] = "highlight";

            string id = ((HtmlAnchor)sender).ID;
            if (id == "academicSupportLink")
            {
                LoadArticleContent("Academic Support");
                CourseTable.Visible = false;
            }
            else if (id == "disciplineLink")
            {
                CourseTable.Visible = true;
                ResourcesLiteral.Text = string.Empty;
            }

        }
    }
}