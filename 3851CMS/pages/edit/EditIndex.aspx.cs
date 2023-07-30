using _3851CMS.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Label = System.Web.UI.WebControls.Label;

namespace _3851CMS.pages
{
    public partial class EditIndex : System.Web.UI.Page
    {
        public DataTable tmls;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tmls = SQLUtils.GetTable("SELECT * FROM Testimonial");
                DataTable homePage = SQLUtils.GetTable("SELECT * FROM HomePage");
                WelcomeTitle.Text = homePage.Rows[0]["Part_Body"].ToString();
                WelcomeMessage.Text = homePage.Rows[1]["Part_Body"].ToString();
                videoUrl.Text = homePage.Rows[2]["Part_Body"].ToString();
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
        protected void ddlImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Img path 
            string imgPath = "/img/" + ddlImages.SelectedItem.Text;
            imagePath.Text = imgPath;
            // Show the preview of the selected image. 
            imgPreview.Src = ddlImages.SelectedValue;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                // Save the file to a directory on your server. This is just an example.
                string fileName = Path.GetFileName(FileUpload1.FileName);
                string savePath = Server.MapPath("~/img/") + fileName;
                string fileExtension = Path.GetExtension(FileUpload1.FileName).ToLower();
                string[] allowedExtensions =
                    {".jpg", ".jpeg", ".png", ".webp"};
                if (allowedExtensions.Contains(fileExtension))
                {
                    FileUpload1.SaveAs(savePath);
                    string imageUrl = "/img/" + FileUpload1.FileName;
                    TextBox imgLabel = (TextBox)DetailsView1.FindControl("LabelInsert");
                    imgLabel.Text = imageUrl;
                }
                else
                {
                    string script = "alert('Invalid file type. Only .jpg, .jpeg, .png, and .webp files are allowed.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "FiletypeError", script, true);
                    return;
                }

            }
        }
        protected void ValidImg(object sender, DetailsViewInsertEventArgs e)
        {
            // Find the Label control that contains the image URL.
            TextBox imgLabel = (TextBox)DetailsView1.FindControl("LabelInsert");

            // Add the image URL to the values to be inserted.
            e.Values["Img_Url"] = imgLabel.Text;


            if (string.IsNullOrEmpty(imgLabel.Text))
            {
                string script = "alert('You have not upload any image');";
                ScriptManager.RegisterStartupScript(this, GetType(), "FiletypeError", script, true);
                e.Cancel = true;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string welcomeTitle = WelcomeTitle.Text;
            string welcomeMessage = WelcomeMessage.Text;

            var sqlCommands = new List<(string commandText, Dictionary<string, object> parameters)>
            {
                ("UPDATE Homepage SET Part_Body = @WelcomeTitle WHERE Part_ID = 1",
                 new Dictionary<string, object>() { { "@WelcomeTitle", welcomeTitle } }),

                ("UPDATE Homepage SET Part_Body = @WelcomeMessage WHERE Part_ID = 2",
                 new Dictionary<string, object>() { { "@WelcomeMessage", welcomeMessage } })
            };

            foreach (var command in sqlCommands)
            {
                SQLUtils.SQLHandler(command.commandText, command.parameters);
            }
        }

        protected void editBtn_Click(object sender, EventArgs e)
        {
            // enable the textbox for editing
            videoUrl.ReadOnly = false;
            editBtn.Visible = false;
            saveBtn.Visible = true;
            cancelBtn.Visible = true;
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            // Save new URL to database 
            videoUrl.ReadOnly = true;
            editBtn.Visible = true;
            saveBtn.Visible = false;
            cancelBtn.Visible = false;
            string cmdText = "UPDATE HomePage SET Part_Body = @videoUrl WHERE Part_ID = 3";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@videoUrl", videoUrl.Text } };
            SQLUtils.SQLHandler(cmdText, parameters);
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {

            DataTable homePage = SQLUtils.GetTable("SELECT * FROM HomePage");
            videoUrl.Text = homePage.Rows[2]["Part_Body"].ToString();
            videoUrl.ReadOnly = true;
            editBtn.Visible = true;
            saveBtn.Visible = false;
            cancelBtn.Visible = false;
        }
    }
}
