using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3851CMS.pages.front
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string username = Login1.UserName;
            string password = Login1.Password;

            bool isValidUser = CheckUserInDatabase(username, password);

            if (isValidUser)
            {
                if (isValidUser)
                {
                    // Create new auth ticker
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                      username,
                      DateTime.Now,
                      DateTime.Now.AddMinutes(30),
                      false,
                      "Admin", // user role
                      FormsAuthentication.FormsCookiePath);

                    // encrypt ticket
                    string encTicket = FormsAuthentication.Encrypt(ticket);

                    // create a cookie to store the ticket
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

                    // add to response
                    Response.Cookies.Add(cookie);

                    // redirect to admin page
                    Response.Redirect("/pages/edit/admin.aspx");
                }
            }
        }

        private bool CheckUserInDatabase(string username, string password)
        {
            // simple check
            if (username == "admin" && password == "adminimda")
            { 
                return true;
            }
            else 
            {
                return false;
            }
        }

    }
}