using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ClienteNegocio
    {
        public Cliente BuscarCliente(string dni)
        {
			AccesoDatos datos = new AccesoDatos();
            Cliente cliente = new Cliente();
            cliente = null;

            try
			{
				datos.setearConsulta("SELECT Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @documento");
                datos.setearParametro("@documento", dni);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    cliente = new Cliente();
                    cliente.Nombre = (string)datos.Lector["Nombre"];
                    cliente.Apellido = (string)datos.Lector["Apellido"];
                    cliente.Email = (string)datos.Lector["Email"];
                    cliente.Direccion = (string)datos.Lector["Direccion"];
                    cliente.Ciudad = (string)datos.Lector["Ciudad"];
                    cliente.CP = (int)datos.Lector["CP"];
                }

                return cliente;
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }
    }
}
