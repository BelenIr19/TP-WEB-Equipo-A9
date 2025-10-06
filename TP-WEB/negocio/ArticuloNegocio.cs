using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace negocio
{
    public class ArticuloNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();

            try
            {
                datos.setearConsulta("SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.IdMarca, A.IdCategoria, A.Precio FROM ARTICULOS A, MARCAS M, CATEGORIAS C WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.IdMarca = new Marca();
                    aux.IdMarca.Id = (int)datos.Lector["IdMarca"];
                    aux.IdMarca.Descripcion = (string)datos.Lector["Marca"];

                    aux.IdCategoria = new Categoria();
                    aux.IdCategoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.IdCategoria.Descripcion = (string)datos.Lector["Categoria"];

                    aux.Imagenes = ImgArticulos(aux.Id);

                    lista.Add(aux);
                }

                lista = lista
                .GroupBy(a => new
                {
                    a.Codigo,
                    a.Nombre,
                    a.Descripcion,
                    Marca = a.IdMarca?.Descripcion,
                    Categoria = a.IdCategoria?.Descripcion,
                    a.Precio
                })
                .Select(g => g.First())
                .ToList();

                return lista;
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

        public string nombreArticulo(int idArticulo)
        {
            string nombre = null;
            datos.setearConsulta("SELECT Nombre FROM ARTICULOS WHERE Id = @idArticulo");
            datos.setearParametro("@idArticulo", idArticulo);
            datos.ejecutarLectura();
            if(datos.Lector.Read())
            {
                nombre = (string)datos.Lector["Nombre"];
            }
            return nombre;
        }

        public List<Imagen> ImgArticulos(int idArticulo)
        {
            List<Imagen> imagenes = new List<Imagen>();
            AccesoDatos datosImg = new AccesoDatos();

            try
            {
                datosImg.setearConsulta("SELECT IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo = @id");
                datosImg.setearParametro("@id", idArticulo);
                datosImg.ejecutarLectura();

                while (datosImg.Lector.Read())
                {
                    Imagen img = new Imagen();
                    img.IdArticulo = (int)datosImg.Lector["IdArticulo"];
                    img.Url = datosImg.Lector["ImagenUrl"].ToString();

                    if (!string.IsNullOrWhiteSpace(img.Url))
                    {
                        imagenes.Add(img);
                    }
                }

                imagenes = imagenes
                .GroupBy(i => i.Url.Trim().ToLower())
                .Select(g => g.First())
                .ToList();

                return imagenes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosImg.cerrarConexion();
            }
        }


        
    }
}
