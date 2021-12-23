using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment3
{
    public partial class New_Asset : System.Web.UI.Page
    {

        string str = ConfigurationManager.ConnectionStrings["AssetRegister"].ConnectionString;

        public void InsertAsset()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Asset values('" + TextBoxAssetName.Text + "','" + DropDownListVendorName.Text + "','" + Convert.ToDateTime(TextBoxPurchaseDate.Text) + "','" + Convert.ToDecimal(TextBoxCost.Text) + "')", con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                Response.Write("<script>alert('Plz fill all fields')</script>");
                ;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxPurchaseDate_CalendarExtender.EndDate = DateTime.Now;


            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select VendorName from Vendor1", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DropDownListVendorName.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }

            }
        }

        protected void ButtonAddAsset_Click(object sender, EventArgs e)
        {
            InsertAsset();
        }


    }





}