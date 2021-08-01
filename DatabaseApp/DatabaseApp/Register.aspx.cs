using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseApp
{
    public partial class Register : System.Web.UI.Page
    {
        DataTable dtbl = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int userID = Convert.ToInt32(Request.QueryString["id"]);
                    using (SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-76I47R7;initial Catalog=MojaBazaDanych;
            Integrated Security=True;"))
                    {
                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("UserViewByID", sqlCon);
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("@UserID", userID);
                        sqlDa.Fill(dtbl);

                        hfUserID.Value = userID.ToString();
                        txtLogin.Text = dtbl.Rows[0][1].ToString();
                        txtPassword.Text = dtbl.Rows[0][2].ToString();
                        txtPassword.Attributes.Add("value", dtbl.Rows[0][7].ToString());
                        txtProove.Text = dtbl.Rows[0][2].ToString();
                        txtProove.Attributes.Add("value", dtbl.Rows[0][2].ToString());
                    }
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
           
            if (txtLogin.Text == "" || txtPassword.Text == "")
                errLabelMessage.Text = "Proszę wypełnić pola";
            else if (txtPassword.Text != txtProove.Text)
                errLabelMessage.Text = "Hasła się nie zgadzają";
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-76I47R7;initial Catalog=MojaBazaDanych;
            Integrated Security=True;"))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("UserAddOrEdit", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(hfUserID.Value == "" ? "0" : hfUserID.Value));
                    sqlCmd.Parameters.AddWithValue("@Username", txtLogin.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    string sql = "SELECT COUNT(*) from TableUser WHERE username = '" + txtLogin.Text + "'";
                    SqlCommand command = new SqlCommand(sql, sqlCon);
                    var result = command.ExecuteScalar();
                    int i = Convert.ToInt32(result);
                    if (i != 0)
                    {
                        errLabelMessage.Text = "Podany użytkownik już istnieje";
                        return;
                    }
                    
                    sqlCmd.ExecuteNonQuery();
                    Clear();
                    scsLabelMessage.Text = "Rejestracja przebiegła pomyślnie";
                }
            }
        }

        void Clear()
        {
            txtLogin.Text = txtPassword.Text = txtProove.Text = "";
            hfUserID.Value = "";
            scsLabelMessage.Text = errLabelMessage.Text = "";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}