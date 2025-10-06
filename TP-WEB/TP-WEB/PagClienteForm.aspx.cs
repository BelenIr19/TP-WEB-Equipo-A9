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
            ArticuloNegocio negocioArticulo = new ArticuloNegocio();
            EmailService emailService = new EmailService();

            try
            {
                if (Session["Voucher"] == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Debe colocar un voucher antes de participar.');", true);
                    return;
                }
                else if (Session["ArticuloID"] == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Debe seleccionar un artículo antes de participar.');", true);
                    return;
                }
                    
                cliente = negocioCliente.BuscarCliente(txtDNI.Text);

                if (cliente == null)
                {
                    cliente = new Cliente();
                    cliente.Documento = txtDNI.Text;
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.Email = txtEmail.Text;
                    cliente.Direccion = txtDireccion.Text;
                    cliente.Ciudad = txtCiudad.Text;
                    cliente.CP = int.Parse(txtCP.Text);

                    negocioCliente.Agregar(cliente);
                    cliente = negocioCliente.BuscarCliente(txtDNI.Text); //Para obtener el ID del cliente recién agregado
                }
                else
                {
                    cliente.Documento = txtDNI.Text;
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.Email = txtEmail.Text;
                    cliente.Direccion = txtDireccion.Text;
                    cliente.Ciudad = txtCiudad.Text;
                    cliente.CP = int.Parse(txtCP.Text);

                    negocioCliente.Modificar(cliente);
                }

                //Agregar registro voucher a la base de datos 
                string codigoVoucher = (string)Session["Voucher"];
                int idArticulo = (int)Session["ArticuloID"];
                int idCliente = cliente.Id;
                DateTime fecha = DateTime.Now;
                negocioVoucher.agregar(codigoVoucher, idArticulo, idCliente, fecha);

                //Redirigir a la página final y mandar mail

                emailService.armarCorreo(cliente.Email, cliente.Nombre);
                emailService.enviarCorreo();

                Session["EmailCliente"] = cliente.Email;
                Session["ArticuloNombre"] = negocioArticulo.nombreArticulo(idArticulo);
                Response.Redirect("PagConfirmacion.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}