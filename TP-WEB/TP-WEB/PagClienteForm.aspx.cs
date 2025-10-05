using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TP_WEB
{
    public partial class PagClienteForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Al cargar la página inicial, no hace nada.
            }
        }

        protected void txtDNI_TextChanged(object sender, EventArgs e)
        {
            string dni = txtDNI.Text;
            if(!string.IsNullOrEmpty(dni))
            {
                ClienteNegocio negocio = new ClienteNegocio();

                Cliente cliente = negocio.BuscarCliente(dni);

                if (cliente != null)
                {
                    txtNombre.Text = cliente.Nombre;
                    txtApellido.Text = cliente.Apellido;
                    txtEmail.Text = cliente.Email;
                    txtDireccion.Text = cliente.Direccion;
                    txtCiudad.Text = cliente.Ciudad;
                    txtCP.Text = cliente.CP.ToString();
                }
            }
        }
        
        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteNegocio negocioCliente = new ClienteNegocio();
            VoucherNegocio negocioVoucher = new VoucherNegocio();
            try
            { 
                cliente = negocioCliente.BuscarCliente(txtDNI.Text);
                if (cliente == null)
                {
                    cliente.Documento = txtDNI.Text;
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.Email = txtEmail.Text;
                    cliente.Direccion = txtDireccion.Text;
                    cliente.Ciudad = txtCiudad.Text;
                    cliente.CP = int.Parse(txtCP.Text);

                    negocioCliente.Agregar(cliente);
                }
                else
                {
                    //Cliente ya existe. No se agrega.
                }

                //Agregar registro voucher a la base de datos 
                string codigoVoucher = (string)Session["Voucher"];
                int idArticulo = (int)Session["ArticuloID"];
                int idCliente = cliente.Id;
                DateTime fecha = DateTime.Now;

                negocioVoucher.agregar(codigoVoucher, idArticulo, idCliente, fecha);

                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Agregado! Gracias por participar');", true);
                //Response.Redirect("PagFinal.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}