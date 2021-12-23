using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Assignment3
{
    public partial class AssetList : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();
        string str = ConfigurationManager.ConnectionStrings["AssetRegister"].ConnectionString;

        public void dp()
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select VendorName from Vendor1", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BindGrid();
                dp();
            }


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

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Asset values ('" + TextBox2.Text + "', '" + DropDownList2.Text + "','" + Convert.ToDateTime(TextBox4.Text) + "' , '" + Convert.ToInt32(TextBox5.Text) + "')", con);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Data has Been Inserted')</script>");
                    BindGrid();
                }
            }
            catch (Exception)
            {

                Response.Write("<script>alert('Plz fill all fields')</script>");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }



        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Asset where Id='" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()) + "'", con);
                cmd.ExecuteNonQuery();
                BindGrid();
            }
        }

        void AssetListGrid()
        {
            using (SqlConnection connect = new SqlConnection(str))
            {
                connect.Open();
                SqlCommand sqlcom = new SqlCommand("select * from Asset", connect);
                SqlDataReader dr = sqlcom.ExecuteReader();
                if (dr.HasRows == true)
                {
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                }
            }
        }

        public void EditDropDown()
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select VendorName from Vendor1", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DropDownListEditVendorAsset.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }
            }
        }
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            DropDownListEditVendorAsset.Items.Clear();

            TextBoxEditAssetId.Text = GridView1.Rows[e.NewSelectedIndex].Cells[0].Text;
            TextBoxEditAssetName.Text = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text;
            DropDownListEditVendorAsset.Items.Insert(0, new ListItem(GridView1.Rows[e.NewSelectedIndex].Cells[2].Text));
            EditDropDown();
            TextBoxEditPurchase.Text = GridView1.Rows[e.NewSelectedIndex].Cells[3].Text;
            TextBoxEditCost.Text = GridView1.Rows[e.NewSelectedIndex].Cells[4].Text;
        }

        protected void ButtonEditAsset_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Asset set AssetName='" + TextBoxEditAssetName.Text + "',VendorName='" + DropDownListEditVendorAsset.Text + "', PurchaseDate='" + Convert.ToDateTime(TextBoxEditPurchase.Text) + "', Cost='" + Convert.ToDecimal(TextBoxEditCost.Text) + "' where Id='" + Convert.ToInt32(TextBoxEditAssetId.Text) + "'", con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                Response.Write("<script>alert('Plz fill all fields')</script>");
            }

            BindGrid();
            Clear();
        }
        public void Clear()
        {
            TextBoxEditAssetId.Text = "";
            TextBoxEditAssetName.Text = "";
            DropDownListEditVendorAsset.Items.Clear();
            TextBoxEditPurchase.Text = "";
            TextBoxEditCost.Text = "";
        }

        protected void ButtonCancelEdit_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select Id,AssetName,VendorName,PurchaseDate,Cost from Asset where AssetName like '" + txtsearch.Text + "%'", con);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    GridView1.DataSource = dataSet;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}