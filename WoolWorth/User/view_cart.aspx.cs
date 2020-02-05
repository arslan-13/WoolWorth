using System;
using System.Data;


namespace WoolWorth.User
{
    public partial class view_cart : System.Web.UI.Page
    {

        string s, t;
        string[] a = new string[6];
        int total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void checkout_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("checkout.aspx");
        }

        protected void cartView_btn_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("product_name"), new DataColumn("product_desc"), new DataColumn("product_price"), new DataColumn("product_qty"), new DataColumn("product_img"), new DataColumn("id"), new DataColumn("product_id") });

            if (Request.Cookies["cart"] != null)
            {
                s = Convert.ToString(Request.Cookies["cart"].Value);

                string[] strArr = s.Split('|');

                for (int i = 0; i < strArr.Length; i++)
                {
                    t = Convert.ToString(strArr[i].ToString());
                    string[] strArr1 = t.Split(',');
                    for (int j = 0; j < strArr1.Length; j++)
                    {
                        a[j] = strArr1[j].ToString();
                    }

                    dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString(), i.ToString(), a[5].ToString());

                    total = total + (Convert.ToInt32(a[2].ToString()) * Convert.ToInt32(a[3].ToString()));

                }
            }


            dl_cart.DataSource = dt;
            dl_cart.DataBind();

            total_lbl.Text = "You total Bill is: " + total.ToString();
        }
    }
}