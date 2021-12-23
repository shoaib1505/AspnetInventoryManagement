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
    public partial class Vendor1 : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["AssetRegister"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            VendorGridDataShow();
        }
        void VendorGridDataShow()
        {

            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand sqlcom = new SqlCommand("select v.Id , v.VendorName,v.EmailId,v.Contact,c.CityName  from Vendor1 as v ,City as c where v.CityId=c.Id", con);
                SqlDataReader dr = sqlcom.ExecuteReader();
                if (dr.HasRows == true)
                {

                    GridView1.DataSource = dr;
                    GridView1.DataBind();



                }


            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {

                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        con.Open();
                        DropDownList DropDownList1 = (e.Row.FindControl("DropDownList1") as DropDownList);
                        SqlCommand cmd = new SqlCommand("select CityName from City", con);
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                        }
                        string selectedCity = DataBinder.Eval(e.Row.DataItem, "CityName").ToString();
                        DropDownList1.Items.FindByValue(selectedCity).Selected = true;

                    }

                }
            }
            catch (Exception e1)
            {

                Response.Write(e1);
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }



        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.VendorGridDataShow();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            using (SqlConnection con = new SqlConnection(str))
            {

            }

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            this.VendorGridDataShow();
        }
    }

}