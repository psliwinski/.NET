using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errLabelMessage.Visible = false;
            errInput.Visible = false;
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-76I47R7;initial Catalog=MojaBazaDanych;
            Integrated Security=True;"))
            {
                sqlCon.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Produkt, Kategoria, [Cena netto], Vat, [Cena brutto] FROM TableProduct", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dgv1.DataSource = dtbl;
                dgv1.DataBind();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-76I47R7;initial Catalog=MojaBazaDanych;
            Integrated Security=True;"))
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM TableUser WHERE username=@username AND password=@password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@username", txtLogin.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Session["username"] = txtLogin.Text.Trim();
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    errLabelMessage.Visible = true;
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void btnSortAZ_Click(object sender, EventArgs e)
        {
            DataTable dt = dgv1.DataSource as DataTable;

            DataView dv = dt.DefaultView;

            dv.Sort = "Produkt asc";

            DataTable dt2 = dv.ToTable();

            dgv1.DataSource = dt2;

            dgv1.DataBind();
        }

        protected void btnSortZA_Click(object sender, EventArgs e)
        {
            DataTable dt = dgv1.DataSource as DataTable;

            DataView dv = dt.DefaultView;

            dv.Sort = "Produkt desc";

            DataTable dt2 = dv.ToTable();

            dgv1.DataSource = dt2;

            dgv1.DataBind();
        }

        protected void btnSortPriceAsc_Click(object sender, EventArgs e)
        {
            DataTable dt = dgv1.DataSource as DataTable;

            DataView dv = dt.DefaultView;

            dv.Sort = "[Cena brutto] asc";

            DataTable dt2 = dv.ToTable();

            dgv1.DataSource = dt2;

            dgv1.DataBind();
        }

        protected void btnSortPriceDesc_Click(object sender, EventArgs e)
        {
            DataTable dt = dgv1.DataSource as DataTable;

            DataView dv = dt.DefaultView;

            dv.Sort = "[Cena brutto] desc";
            
            DataTable dt2 = dv.ToTable();

            dgv1.DataSource = dt2;

            dgv1.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            DataTable dt = dgv1.DataSource as DataTable;

            DataView dv = dt.DefaultView;

            if (float.TryParse(Cena1.Text, out _) && float.TryParse(Cena2.Text, out _))
            {
                dv.RowFilter = String.Format("[Cena brutto] > '{0}' AND [Cena brutto] < {1} ", Cena1.Text, Cena2.Text);
            }
            else if (float.TryParse(Cena1.Text, out _) && !float.TryParse(Cena2.Text, out _)) {
                dv.RowFilter = String.Format("[Cena brutto] > '{0}'", Cena1.Text);
            }
            else if (!float.TryParse(Cena1.Text, out _) && float.TryParse(Cena2.Text, out _))
            {
                dv.RowFilter = String.Format("[Cena brutto] < '{0}' ", Cena2.Text);
            }
            else
            {
                errInput.Visible = true;
            }

            DataTable dt2 = dv.ToTable();

            dgv1.DataSource = dt2;

            dgv1.DataBind();
        }
    }
}