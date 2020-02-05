using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WoolWorth.User
{
    public partial class product_description : System.Web.UI.Page
    {
        string constring = ConfigurationManager.ConnectionStrings["woolworth"].ConnectionString;

        int id;
        int qty;

        string product_name, product_desc, product_price, product_qty, product_img;


        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("displayproducts.aspx");
                }
                else
                {

                    id = Convert.ToInt32(Request.QueryString["id"].ToString());
                    string displayquery = "select * from tbl_product where id='" + id + "'";
                    SqlDataAdapter da = new SqlDataAdapter(displayquery, con);
                    con.Open();
                    da.SelectCommand.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Repeater1.DataSource = dt;
                    Repeater1.DataBind();
                }

                qty = get_qty(id);

                if (qty == 0)
                {
                    qty_lbl.Visible = false;
                    pro_qtytxbx.Visible = false;
                    cardbtnProdDesc.Visible = false;
                    erorlbl_qty.Text = "There is no available Quantity";
                }
            }
        }

        protected void cardbtnProdDesc_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {

                string displayquery = "select * from tbl_product where id=" + id;
                SqlDataAdapter da = new SqlDataAdapter(displayquery, con);
                con.Open();
                da.SelectCommand.ExecuteNonQuery();
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    product_name = dr["product_name"].ToString();
                    product_desc = dr["product_desc"].ToString();
                    product_price = dr["product_price"].ToString();
                    product_qty = dr["product_qty"].ToString();
                    product_img = dr["product_img"].ToString();
                }
            }

            if (Convert.ToInt32(pro_qtytxbx.Text) > Convert.ToInt32(product_qty))
            {
                erorlbl_qty.Text = "Please enter lower qunatity";
            }
            else
            {
                erorlbl_qty.Text = "";

                if (Request.Cookies["cart"] == null)
                {
                    Response.Cookies["cart"].Value = product_name.ToString() + "," + product_desc.ToString() + "," + product_price.ToString() + "," + pro_qtytxbx.Text + "," + product_img.ToString() + "," + id.ToString();
                    Response.Cookies["cart"].Expires = DateTime.Now.AddDays(1);
                }
                else
                {
                    Response.Cookies["cart"].Value = product_name.ToString() + "|" + product_desc.ToString() + "," + product_price.ToString() + "," + pro_qtytxbx.Text + "," + product_img.ToString() + "," + id.ToString();
                    Response.Cookies["cart"].Expires = DateTime.Now.AddDays(1);
                }
                using (SqlConnection con = new SqlConnection(constring))
                {

                    string UpdateQtyquery = "update tbl_product set product_qty = product_qty -" + pro_qtytxbx.Text + " where id=" + id;
                    SqlDataAdapter da = new SqlDataAdapter(UpdateQtyquery, con);
                    con.Open();
                    da.SelectCommand.ExecuteNonQuery();
                    Response.Redirect("product_description.aspx?id=" + id.ToString());

                }
            }



        }

        public int get_qty(int id)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                string GetQtyquery = "select * from tbl_product where id=" + id;
                SqlDataAdapter da = new SqlDataAdapter(GetQtyquery, con);
                con.Open();
                da.SelectCommand.ExecuteNonQuery();
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    qty = Convert.ToInt32(dr["product_qty"].ToString());
                }

                return qty;
            }
        }
    }
}