using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
namespace TP_WEB
{
	public partial class Usuario : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDni.Attributes["placeholder"] = "Ingrese su DNI";
            }
        }

        protected void txtDni_TextChanged(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();
            ClienteNegocio negocio = new ClienteNegocio();
            Cliente cliente = new Cliente { Documento = dni };

            if (negocio.ObtenerPorDNI(cliente))
            {
                // Autocompleta campos si el cliente existe
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEmail.Text = cliente.Email;
                txtDireccion.Text = cliente.Direccion;
                txtCiudad.Text = cliente.Ciudad;
                txtCP.Text = cliente.Cp.ToString();

                lblMensaje.Text = "El DNI ya está registrado. Se completaron los datos existentes.";
                lblMensaje.ForeColor = Color.Orange;
            }
            else
            {
                // Limpia los campos si no existe
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtEmail.Text = "";
                txtDireccion.Text = "";
                txtCiudad.Text = "";
                txtCP.Text = "";
                lblMensaje.Text = "";
            }
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            // Validación de campos
            if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtCiudad.Text) ||
                string.IsNullOrWhiteSpace(txtCP.Text) ||
                !chkAcepto.Checked)
            {
                lblMensaje.Text = "Todos los campos son obligatorios y debe aceptar los términos.";
                lblMensaje.ForeColor = Color.Red;
                return;
            }

            // Crear cliente
            Cliente nuevoCliente = new Cliente
            {
                Documento = txtDni.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Ciudad = txtCiudad.Text.Trim(),
                Cp = int.Parse(txtCP.Text.Trim())
            };

            // Guardar cliente
            ClienteNegocio negocio = new ClienteNegocio();
            negocio.agregar(nuevoCliente);

            // Mensaje de éxito y redirección
            string script = @"alert('Registro exitoso'); window.location='CanjearVoucher.aspx';";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }
    }
}
