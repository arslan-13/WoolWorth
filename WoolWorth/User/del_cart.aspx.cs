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
    public partial class del_cart : System.Web.UI.Page
    {
        string s, t;
        string[] a = new string[6];
        int id;
        string product_name, product_desc, product_price, product_qty, product_img;
        int count = 0;
        int product_id, qty;
        protected void Page_Load(object sender, EventArgs e)
        {

            string constring = ConfigurationManager.ConnectionStrings["woolworth"].ConnectionString;
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("view_cart.aspx");
            }
            else
            {
                id = Convert.ToInt32(Request.QueryString["id"].ToString());

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

                    }
                }
                count = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    if (count == id)
                    {
                        product_id = Convert.ToInt32(dr["product_id"].ToString());
                        qty = Convert.ToInt32(dr["product_qty"].ToString());
                    }
                    count = count + 1;
                }
                count = 0;

                using (SqlConnection con = new SqlConnection(constring))
                {
                    string delUpdatecart = "update tbl_product set product_qty=product_qty+" + qty + "where id=" + product_id;

                    SqlCommand cmd = new SqlCommand(delUpdatecart, con);
                    con.Open();
                    cmd.ExecuteNonQuery();


                }

                dt.Rows.RemoveAt(id);

                Response.Cookies["cart"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["cart"].Expires = DateTime.Now.AddDays(-1);

                foreach (DataRow dr in dt.Rows)
                {
                    product_name = dr["product_name"].ToString();
                    product_desc = dr["product_desc"].ToString();
                    product_price = dr["product_price"].ToString();
                    product_qty = dr["product_qty"].ToString();
                    product_img = dr["product_img"].ToString();
                    product_id = Convert.ToInt32(dr["product_id"].ToString());

                    count = count + 1;
                    if (count == 1)
                    {
                        Response.Cookies["cart"].Value = product_name.ToString() + "," + product_desc.ToString() + "," + product_price.ToString() + "," + product_qty.ToString() + "," + product_img.ToString() + "," + product_id.ToString();
                        Response.Cookies["cart"].Expires = DateTime.Now.AddDays(1);
                    }
                    else
                    {
                        Response.Cookies["cart"].Value = Request.Cookies["cart"].Value + "|" + product_name.ToString() + "," + product_desc.ToString() + "," + product_price.ToString() + "," + product_qty.ToString() + "," + product_img.ToString() + "," + product_id.ToString();
                        Response.Cookies["cart"].Expires = DateTime.Now.AddDays(1);
                    }
                }
                Response.Redirect("view_cart.aspx");
            }
        }
    }
}