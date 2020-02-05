using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WoolWorth.User
{
    public partial class displayproducts : System.Web.UI.Page
    {
        string constring = ConfigurationManager.ConnectionStrings["woolworth"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            //using (SqlConnection con = new SqlConnection(constring))
            //{
            //    string displayquery = "select * from tbl_product";
            //    SqlDataAdapter da = new SqlDataAdapter(displayquery, con);
            //    //SqlCommand cmd = new SqlCommand(displayquery, con);
            //    con.Open();
            //    da.SelectCommand.ExecuteNonQuery();
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);
            //    Repeater1.DataSource = dt;
            //    Repeater1.DataBind();
            //}

        }
    }
}