
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using dominio;
using negocio;

namespace Negocio
{
    public class ClienteNegocio
    {
        public void Agregar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) values (@documento,@nombre,@apellido,@email,@direccion,@ciudad,@cp)");
                datos.setearParametro("@documento", cliente.Documento);
                datos.setearParametro("@nombre", cliente.Nombre);
                datos.setearParametro("@apellido", cliente.Apellido);
                datos.setearParametro("@email", cliente.Email);
                datos.setearParametro("@direccion", cliente.Direccion);
                datos.setearParametro("@ciudad", cliente.Ciudad);
                datos.setearParametro("@cp", cliente.CP);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }



        public bool ObtenerPorDNI(Cliente cliente)
        {
            //cliente cliente = new cliente();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP from Clientes\r\n where Documento = @dni");
                datos.setearParametro("@dni", cliente.Documento);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    cliente.Id = int.Parse(datos.Lector["id"].ToString());
                    cliente.Documento = datos.Lector["Documento"].ToString();
                    cliente.Nombre = datos.Lector["Nombre"].ToString();
                    cliente.Apellido = datos.Lector["Apellido"].ToString();
                    cliente.Email = datos.Lector["Email"].ToString();
                    cliente.Direccion = datos.Lector["Direccion"].ToString();
                    cliente.Ciudad = datos.Lector["Ciudad"].ToString();
                    cliente.CP = int.Parse(datos.Lector["CP"].ToString());

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}