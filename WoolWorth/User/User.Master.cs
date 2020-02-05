using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WoolWorth.User
{
    public partial class User : System.Web.UI.MasterPage
    {
        string s, t;
        string[] a = new string[6];
        int total = 0;
        int totalCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {


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

                    total = total + (Convert.ToInt32(a[2].ToString()) * Convert.ToInt32(a[3].ToString()));
                    totalCount += 1;
                    totlItem_lbl.Text = totalCount.ToString();
                    totlCost_lbl.Text = total.ToString();
                }
            }
        }
    }
}