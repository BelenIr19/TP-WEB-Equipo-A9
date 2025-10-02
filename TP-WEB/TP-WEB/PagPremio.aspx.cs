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
    public partial class PagPremio : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            cargarArticulos();
            }         
        }

        private void cargarArticulos()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> listaArticulo = new List<Articulo>();
            List<Imagen> listaImg = new List<Imagen>();

            listaArticulo = negocio.listar();

            rptArticulos.DataSource = listaArticulo;
            rptArticulos.DataBind();
        }
    }
}