using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_WEB
{
    public partial class PagConfirmacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Validar que vengan los datos de sesión
                if (Session["ArticuloNombre"] == null || Session["EmailCliente"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lblArticulo.Text = Session["ArticuloNombre"].ToString();
                    lblEmail.Text = Session["EmailCliente"].ToString();
                }
            }
        }
    }
}