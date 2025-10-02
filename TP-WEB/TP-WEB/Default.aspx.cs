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
            string voucherCode = txtVoucher.Text;

            if (!string.IsNullOrEmpty(voucherCode))
            {
                //Lógica para verificar el voucher en la base de datos
                Response.Write("Código ingresado: " + voucherCode);
            }
            else
            {
                //Mostrar un mensaje de error si el campo está vacío
                Response.Write("<script>alert('Debe ingresar un código de voucher.');</script>");
            }
            Response.Redirect("PagPremio.aspx", false);
        }
    }
}