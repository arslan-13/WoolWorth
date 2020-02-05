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
    public partial class add_product : System.Web.UI.Page
    {


        string constring = ConfigurationManager.ConnectionStrings["woolworth"].ConnectionString;
        string a, b;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void proImgUldBtn_Click(object sender, EventArgs e)
        {
            //a = GetRandomPassword(10).ToString();
            //proImgFUld.SaveAs(Request.PhysicalApplicationPath + "./Data/images/" /*+ a*/ + proImgFUld.FileName.ToString());
            //b = "Data/images/" /*+ a*/ + proImgFUld.FileName.ToString();

            if (proNameTxb.Text == "" || proDesTxb.Text == "" || proPriceTxb.Text == "" || proQtyTxb.Text == "" || proImgFUld.HasFile == false)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('please fill all fields');", true);
            }
            else
            {
                proImgFUld.SaveAs(Request.PhysicalApplicationPath + "./Data/images/" /*+ a*/ + proImgFUld.FileName.ToString());
                b = "Data/images/" /*+ a*/ + proImgFUld.FileName.ToString();
                using (SqlConnection con = new SqlConnection(constring))
                {
                    string checkimg = "select count(*) from tbl_product where product_img='" + b + "'";
                    SqlCommand cmdimgck = new SqlCommand(checkimg, con);
                    con.Open();
                    int tempimg = (int)cmdimgck.ExecuteScalar();
                    if (tempimg == 0)
                    {
                        string insertquery = "insert into tbl_product values(@proname,@prodes,@proprice,@proqty,'" + b.ToString() + "')";
                        SqlCommand cmd = new SqlCommand(insertquery, con);
                        cmd.Parameters.AddWithValue("@proname", proNameTxb.Text);
                        cmd.Parameters.AddWithValue("@prodes", proDesTxb.Text);
                        cmd.Parameters.AddWithValue("@proprice", proPriceTxb.Text);
                        cmd.Parameters.AddWithValue("@proqty", proQtyTxb.Text);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('image already exist');", true);
                    }

                }

            }
        }

        //public static string GetRandomPassword(int length)
        //{
        //    char[] chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        //    string password = string.Empty;
        //    Random random = new Random();

        //    for (int i = 0; i < length; i++)
        //    {
        //        int x = random.Next(1, chars.Length);
        //        //For avoiding Repetation of Characters
        //        if (!password.Contains(chars.GetValue(x).ToString()))
        //            password += chars.GetValue(x);
        //        else
        //            i = i - 1;
        //    }
        //    return password;
        //}
    }
}