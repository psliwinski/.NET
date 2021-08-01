using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalculatorCSharp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public class Kalkulator
        {
            public int a;
            public int b;
            public string op;
            public int c;

            public Kalkulator()
            {
                //this.a = a;
                //this.b = b;
                //this.op = op ?? throw new ArgumentNullException(nameof(op));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var obj = Session["Kalkulator"];

                if (obj != null)
                {
                    var kalkulator = (Kalkulator)obj;
                    TextBox1.Text = kalkulator.a.ToString();
                    TextBox2.Text = kalkulator.b.ToString();
                    DropDownList1.SelectedValue = kalkulator.op;
                    TextBox3.Text = kalkulator.c.ToString();
                }
                else
                {
                    if (Request.Cookies["Kalkulator"] != null)
                    {

                        TextBox1.Text = Request.Cookies["Kalkulator"].Values["a"];
                        TextBox2.Text = Request.Cookies["Kalkulator"].Values["b"];
                        DropDownList1.SelectedValue = Request.Cookies["Kalkulator"].Values["op"];
                        TextBox3.Text = Request.Cookies["Kalkulator"].Values["c"];
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var kalkulator = new Kalkulator();

            kalkulator.a = int.Parse(TextBox1.Text);
            kalkulator.b = int.Parse(TextBox2.Text);
            kalkulator.op = DropDownList1.SelectedValue;
            //kalkulator.c = int.Parse(TextBox3.Text);

            if (DropDownList1.Text == "+")
            {
                var wynik = float.Parse(TextBox1.Text) + float.Parse(TextBox2.Text);
                TextBox3.Text = Convert.ToString(wynik);
                kalkulator.c = int.Parse(TextBox3.Text);
            }
            else if (DropDownList1.Text == "-")
            {
                var wynik = float.Parse(TextBox1.Text) - float.Parse(TextBox2.Text);
                TextBox3.Text = Convert.ToString(wynik);
                kalkulator.c = int.Parse(TextBox3.Text);
            }
            else if (DropDownList1.Text == "*")
            {
                var wynik = float.Parse(TextBox1.Text) * float.Parse(TextBox2.Text);
                TextBox3.Text = Convert.ToString(wynik);
                kalkulator.c = int.Parse(TextBox3.Text);
            }
            else if (DropDownList1.Text == "/")
            {
                var wynik = float.Parse(TextBox1.Text) / float.Parse(TextBox2.Text);
                TextBox3.Text = Convert.ToString(wynik);
                kalkulator.c = int.Parse(TextBox3.Text);
            }

            Response.Cookies["Kalkulator"].Values["a"] = kalkulator.a.ToString();
            Response.Cookies["Kalkulator"].Values["b"] = kalkulator.b.ToString();
            Response.Cookies["Kalkulator"].Values["op"] = kalkulator.op;
            Response.Cookies["Kalkulator"].Values["c"] = kalkulator.c.ToString();
            Response.Cookies["Kalkulator"].Expires = DateTime.Now.AddSeconds(60);
        }



    }
}