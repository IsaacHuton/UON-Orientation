using _3851CMS.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3851CMS.pages.front
{
    public partial class index : System.Web.UI.Page
    {
        public DataTable tmls;
        public DataTable homePage;
        public DataTable homeSwiper;
        protected void Page_Load(object sender, EventArgs e)
        {
            tmls = SQLUtils.GetTable("SELECT * FROM Testimonial");
            homePage = SQLUtils.GetTable("SELECT * FROM HomePage");
            homeSwiper = SQLUtils.GetTable("SELECT * FROM HomePageSwiper");
        }
    }
}