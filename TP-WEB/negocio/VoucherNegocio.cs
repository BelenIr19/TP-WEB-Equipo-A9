using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class VoucherNegocio
    {
        public bool EstaDisponible(string codigoVoucher)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Vouchers WHERE CodigoVoucher = @codigo AND IdCliente IS NULL");
                datos.setearParametro("@codigo", codigoVoucher);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int cantidad = (int)datos.Lector[0];
                    return cantidad > 0; //true si existe y está libre
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(string codigo, int idArticulo, int idCliente, DateTime fecha)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Vouchers SET IdArticulo = @IdArticulo, FechaCanje = @Fecha, IdCliente = @IdCliente WHERE CodigoVoucher = @Codigo;");
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.setearParametro("@Fecha", fecha);
                datos.setearParametro("@IdCliente", idCliente);
                datos.setearParametro("@Codigo", codigo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}


