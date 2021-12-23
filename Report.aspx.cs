using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment3
{
    public partial class Report : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["AssetRegister"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
            CostCalc();
        }
        private void BindGrid()
        {

            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select Id, AssetName, VendorName, PurchaseDate, Cost from Asset", con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);


                DataTable dt = new DataTable();

                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        void CostCalc()
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select sum(Cost) as total from Asset", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Label1.Text = ds.Tables[0].Rows[0][0].ToString();
            }
        }
    }
}