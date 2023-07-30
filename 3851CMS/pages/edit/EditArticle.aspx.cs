using _3851CMS.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3851CMS.pages.edit
{
    public partial class EditArticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load articles into dropdown list on first page load
                LoadArticles();
                LoadImg();
            }
        }
        private void LoadImg()
        {
            string imagePath = Server.MapPath("~/img/");
            string[] files = Directory.GetFiles(imagePath);

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                ddlImages.Items.Add(new ListItem(fileName, "~/img/" + fileName));
            }
        }

        private void LoadArticles()
        {
            // Get articles from database
            DataTable dtArticles = SQLUtils.GetTable("SELECT Article_ID, Article_Title FROM Article");
            ddlArticles.DataSource = dtArticles;
            ddlArticles.DataValueField = "Article_ID";
            ddlArticles.DataTextField = "Article_Title";
            ddlArticles.DataBind();
        }

        protected void ddlArticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load selected article content into text editor
            string articleId = ddlArticles.SelectedValue;
            DataTable dtArticle = SQLUtils.GetTable($"SELECT Article_Body FROM Article WHERE Article_ID = {articleId}");
            if (dtArticle.Rows.Count > 0)
            {
                txtEditor.Text = dtArticle.Rows[0]["Article_Body"].ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Save changes to article content
            string articleId = ddlArticles.SelectedValue;
            string articleBody = txtEditor.Text;
            var parameters = new Dictionary<string, object>()
            {
                { "@articleBody", articleBody },
                { "@articleId", articleId }
            };
            string commandText = "UPDATE Article SET Article_Body = @articleBody WHERE Article_ID = @articleId";
            SQLUtils.SQLHandler(commandText, parameters);

        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            string markdownText = txtEditor.Text;

            // Convert markdown to HTML
            var md = new MarkdownSharp.Markdown();
            string html = md.Transform(markdownText);

            // Store the HTML in Session
            Session["PreviewData"] = html;

            // Open new window
            Response.Write("<script>window.open('PreviewArticle.aspx','_blank');</script>");
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                // Save the file to a directory on your server. This is just an example.
                string fileName = Path.GetFileName(fileUpload.FileName);
                string savePath = Server.MapPath("~/img/")+ fileName;
                string fileExtension =Path.GetExtension(fileUpload.FileName).ToLower();
                string[] allowedExtensions =
                    {".jpg", ".jpeg", ".png", ".webp"};
                if (allowedExtensions.Contains(fileExtension))
                {
                    fileUpload.SaveAs(savePath);
                }
                else
                {
                    string script = "alert('Invalid file type. Only .jpg, .jpeg, .png, and .webp files are allowed.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "FiletypeError", script, true);
                    return;
                }

                //Refresh page
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void ddlImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Img path 
            string imgPath = "/img/" + ddlImages.SelectedItem.Text;
            imagePath.Text = imgPath;
            // Show the preview of the selected image. 
            imgPreview.Src = ddlImages.SelectedValue;
        }

    }
}