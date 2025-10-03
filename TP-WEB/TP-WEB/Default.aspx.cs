using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_WEB
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            VoucherNegocio negocio = new VoucherNegocio();
            string codigo = txtVoucher.Text;

            if (negocio.EstaDisponible(codigo))
            {
                // Redirigir a la pantalla de selección de artículo
            }
            else
            {
                lblErrorVoucher.Text = "El voucher no existe o ya fue utilizado.";
            }

            Response.Redirect("PagPremio.aspx", false);
        }
    }
}