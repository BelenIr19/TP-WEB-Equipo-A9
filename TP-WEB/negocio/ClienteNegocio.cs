using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dominio;

namespace negocio
{
    public class ClienteNegocio
    {
        AccesoDatos  datos = new AccesoDatos();

        public void agregar (Cliente nuevo)
        {
            try
            {
            datos.setearConsulta("INSERT INTO clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) VALUES (@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP)");
            datos.setearParametro("@Documento", nuevo.Documento);
            datos.setearParametro("@Nombre", nuevo.Nombre);
            datos.setearParametro("@Apellido", nuevo.Apellido);
            datos.setearParametro("@Email", nuevo.Email);
            datos.setearParametro("@Direccion", nuevo.Direccion); 
            datos.setearParametro("@Ciudad", nuevo.Ciudad);
            datos.setearParametro("@CP", nuevo.Cp);

            datos.ejecutarAccion(); 
            datos.cerrarConexion();
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

        // Metodo para obtener por dni
        public bool ObtenerPorDNI(Cliente cliente)
        {
            bool encontrado = false;

            try
            {
                AccesoDatos datos = new AccesoDatos();
                {
                    // Consulta para buscar al cliente por DNI
                    datos.setearConsulta("SELECT ID, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP " +
                                      "FROM Clientes WHERE Documento = @Documento");
                    datos.setearParametro("@Documento", cliente.Documento);

                    datos.ejecutarLectura();

                    if (datos.Lector.Read()) // si encontró un registro
                    {
                        // Llenamos el objeto cliente con los datos de la DB
                        cliente.Id = (int)datos.Lector["Id"];
                        cliente.Nombre = datos.Lector["Nombre"].ToString();
                        cliente.Apellido = datos.Lector["Apellido"].ToString();
                        cliente.Email = datos.Lector["Email"].ToString();
                        cliente.Direccion = datos.Lector["Direccion"].ToString();
                        cliente.Ciudad = datos.Lector["Ciudad"].ToString();
                        cliente.Cp = (int)datos.Lector["Cp"];

                        encontrado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return encontrado;
        }


    }
    }
