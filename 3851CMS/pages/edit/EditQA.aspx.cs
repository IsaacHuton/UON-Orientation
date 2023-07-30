using _3851CMS.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3851CMS.pages.edit
{
    public partial class EditQA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFAQs();
            }
        }

        protected void LoadFAQs()
        {
            string commandText = "SELECT [FAQ_ID], [FAQ_Q] FROM [UON_Ori].[dbo].[FAQ]";
            DataTable dt = SQLUtils.GetTable(commandText);
            ddlFAQs.DataSource = dt;
            ddlFAQs.DataValueField = "FAQ_ID";
            ddlFAQs.DataTextField = "FAQ_Q";
            ddlFAQs.DataBind();
        }

        protected void ddlFAQs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string commandText = $"SELECT [FAQ_Q], [FAQ_A] FROM [UON_Ori].[dbo].[FAQ] WHERE [FAQ_ID] = {ddlFAQs.SelectedValue}";
            DataTable dt = SQLUtils.GetTable(commandText);
            if (dt.Rows.Count > 0)
            {
                txtQuestion.Text = dt.Rows[0]["FAQ_Q"].ToString();
                txtAnswer.Text = dt.Rows[0]["FAQ_A"].ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string question = txtQuestion.Text;
            string answer = txtAnswer.Text;
            string commandText = "UPDATE [UON_Ori].[dbo].[FAQ] SET [FAQ_Q] = @question, [FAQ_A] = @answer WHERE [FAQ_ID] = @faqId";
            var parameters = new Dictionary<string, object>
            {
                {"@question", question},
                {"@answer", answer},
                {"@faqId", ddlFAQs.SelectedValue}
            };
            SQLUtils.SQLHandler(commandText, parameters);
            LoadFAQs();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string commandText = "DELETE FROM [UON_Ori].[dbo].[FAQ] WHERE [FAQ_ID] = @faqId";
            var parameters = new Dictionary<string, object>
            {
                {"@faqId", ddlFAQs.SelectedValue}
            };
            SQLUtils.SQLHandler(commandText, parameters);
            LoadFAQs();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string question = txtNewQuestion.Text;
            string answer = txtNewAnswer.Text;

            // Ensure input is not empty
            if (string.IsNullOrEmpty(question) || string.IsNullOrEmpty(answer))
            {
                // error message
                lblMessage.Text = "Question and Answer cannot be empty.";
                return;
            }

            string commandText = "INSERT INTO [UON_Ori].[dbo].[FAQ] ([FAQ_Q], [FAQ_A]) VALUES (@question, @answer)";
            var parameters = new Dictionary<string, object>
            {
                {"@question", question},
                {"@answer", answer}
            };
            SQLUtils.SQLHandler(commandText, parameters);
            LoadFAQs();
        }


    }
}