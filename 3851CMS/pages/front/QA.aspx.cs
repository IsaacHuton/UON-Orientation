using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;
using _3851CMS.Utils;

namespace _3851CMS.pages.front
{
    public partial class QA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = SQLUtils.GetTable("SELECT TOP (1000) [FAQ_ID], [FAQ_Q], [FAQ_A] FROM [UON_Ori].[dbo].[FAQ]");

                faqRepeater.DataSource = dt;
                faqRepeater.DataBind();
            }
        }
    }
}
