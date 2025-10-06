using System;
using System.Collections.Generic;
using System.Configuration;
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
				datos.setearConsulta("SELECT Id, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @documento");
                datos.setearParametro("@documento", dni);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    cliente = new Cliente();
                    cliente.Id = (int)datos.Lector["Id"];
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

        public void Agregar(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) VALUES (@documento, @nombre, @apellido, @email, @direccion, @ciudad, @cp)");
                datos.setearParametro("@documento", nuevo.Documento);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@direccion", nuevo.Direccion);
                datos.setearParametro("@ciudad", nuevo.Ciudad);
                datos.setearParametro("@cp", nuevo.CP);
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

        public void Modificar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Clientes SET Documento = @Documento, Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Direccion = @Direccion, Ciudad = @Ciudad, CP = @CP WHERE Id = @IdCliente");
                datos.setearParametro("@Documento", cliente.Documento);
                datos.setearParametro("@Nombre", cliente.Nombre);
                datos.setearParametro("@Apellido", cliente.Apellido);
                datos.setearParametro("@Email", cliente.Email);
                datos.setearParametro("@Direccion", cliente.Direccion);
                datos.setearParametro("@Ciudad", cliente.Ciudad);
                datos.setearParametro("@CP", cliente.CP);
                datos.setearParametro("@IdCliente", cliente.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
