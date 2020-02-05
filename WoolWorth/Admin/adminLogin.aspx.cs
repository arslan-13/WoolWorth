using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WoolWorth.Admin
{
    public partial class adminLogin : System.Web.UI.Page
    {
        string constring = ConfigurationManager.ConnectionStrings["woolworth"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                string adminuserQ = "select count(*) from adminlogin where username= @username";
                SqlCommand cmd = new SqlCommand(adminuserQ, con);
                cmd.Parameters.AddWithValue("@username", usernameTextBox.Text);
                con.Open();
                int tempusername = (int)cmd.ExecuteScalar();

                if (tempusername == 1)
                {
                    string adminpassQ = "select count(*) from adminlogin where password=@password";
                    SqlCommand cmdpass = new SqlCommand(adminpassQ, con);
                    cmdpass.Parameters.AddWithValue("@password", passwordTextBox.Text);
                    int temppassword = (int)cmdpass.ExecuteScalar();
                    if (temppassword == 1)
                    {
                        Session["adminlogin"] = usernameTextBox.Text;
                        Response.Redirect("testing.aspx");
                    }
                    else
                    {
                        adminloginlbl.Text = "Your Password is incorrect";
                    }

                }
                else
                {
                    adminloginlbl.Text = "Your Email is incorrect";
                }
            }
        }
    }
}