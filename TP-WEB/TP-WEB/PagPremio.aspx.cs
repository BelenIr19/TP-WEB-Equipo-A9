using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

            listaArticulo = negocio.listar();

            rptArticulos.DataSource = listaArticulo;
            rptArticulos.DataBind();

        }

        protected void rptArticulos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var rptImagenes = (Repeater)e.Item.FindControl("rptImagenes");
                var articulo = (Articulo)e.Item.DataItem;
                
                rptImagenes.DataSource = articulo.Imagenes;
                rptImagenes.DataBind();
            }
        }
    }
}