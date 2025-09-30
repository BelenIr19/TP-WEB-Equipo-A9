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
    }
}