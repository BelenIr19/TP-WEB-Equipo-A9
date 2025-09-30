using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    AccesoDatos datosImagenes = new AccesoDatos();
                    datosImagenes.setearConsulta("SELECT Id, ImagenUrl, IdArticulo FROM IMAGENES WHERE IdArticulo = @articuloId");
                    datosImagenes.setearParametro("@articuloId", aux.Id);
                    datosImagenes.ejecutarLectura();

                    aux.Imagenes = new List<Imagen>();
                    while (datosImagenes.Lector.Read())
                    {
                        Imagen img = new Imagen();
                        img.Id = (int)datosImagenes.Lector["id"];
                        img.Url = (string)datosImagenes.Lector["ImagenUrl"];
                        img.ArticuloId = (int)datosImagenes.Lector["IdArticulo"];
                        aux.Imagenes.Add(img);
                    }

                    datosImagenes.cerrarConexion();
                    lista.Add(aux);
                }
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

        public int agregar(Articulo nuevo)
        {
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca.Id);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@Precio", nuevo.Precio);

                datos.ejecutarAccion();
                datos.cerrarConexion();

                //Consultar el Id del artículo recién agregado para agregar las imágenes
                datos = new AccesoDatos();
                datos.setearConsulta("SELECT Id FROM ARTICULOS WHERE Codigo = @Codigo");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.ejecutarLectura();
                datos.Lector.Read();
                int idArticulo = (int)datos.Lector["Id"];

                return idArticulo;
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

        public void modificar(Articulo articulo)
        {
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio WHERE Id = @Id");
                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@IdMarca", articulo.Marca.Id);
                datos.setearParametro("@IdCategoria", articulo.Categoria.Id);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("@Id", articulo.Id);
                datos.ejecutarAccion();

                datos.cerrarConexion();
                datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @Id");
                datos.setearParametro("@Id", articulo.Id);
                datos.ejecutarAccion();

                datos.cerrarConexion();

                datos = new AccesoDatos();

                foreach (Imagen img in articulo.Imagenes)
                {
                    agregarImagen(img);
                }

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

        public void agregarImagen(Imagen img)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                datos.setearParametro("@IdArticulo", img.ArticuloId);
                datos.setearParametro("@ImagenUrl", img.Url);
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

        public void eliminar(int id)
        {
            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS Where Id = @id; DELETE FROM IMAGENES WHERE IdArticulo = @id");
                datos.setearParametro("@id", id);

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

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> listaFiltrada = new List<Articulo>();
            listaFiltrada = listar();

            switch (campo)
            {
                case "Codigo":
                    listaFiltrada = listaFiltrada.FindAll(a => a.Codigo.ToUpper() == filtro.ToUpper());
                    break;

                case "Nombre":
                    switch (criterio)
                    {
                        case "Comienza con":
                            listaFiltrada = listaFiltrada.FindAll(a => a.Nombre.ToUpper().StartsWith(filtro.ToUpper()));
                            break;
                        case "Termina con":
                            listaFiltrada = listaFiltrada.FindAll(a => a.Nombre.ToUpper().EndsWith(filtro.ToUpper()));
                            break;
                        case "Contiene":
                            listaFiltrada = listaFiltrada.FindAll(a => a.Nombre.ToUpper().Contains(filtro.ToUpper()));
                            break;
                    }
                    break;

                case "Descripcion":
                    switch (criterio)
                    {
                        case "Comienza con":
                            listaFiltrada = listaFiltrada.FindAll(a => a.Descripcion.ToUpper().StartsWith(filtro.ToUpper()));
                            break;
                        case "Termina con":
                            listaFiltrada = listaFiltrada.FindAll(a => a.Descripcion.ToUpper().EndsWith(filtro.ToUpper()));
                            break;
                        case "Contiene":
                            listaFiltrada = listaFiltrada.FindAll(a => a.Descripcion.ToUpper().Contains(filtro.ToUpper()));
                            break;
                    }
                    break;

                case "Marca":
                    listaFiltrada = listaFiltrada.FindAll(a => a.Marca.Descripcion == criterio);
                    break;

                case "Categoria":
                    listaFiltrada = listaFiltrada.FindAll(a => a.Categoria.Descripcion == criterio);
                    break;

                case "Precio":
                    switch (criterio)
                    {
                        case "Mayor a":
                            listaFiltrada = listaFiltrada.FindAll(a => a.Precio >= decimal.Parse(criterio));
                            break;
                        case "Menor a":
                            listaFiltrada = listaFiltrada.FindAll(a => a.Precio <= decimal.Parse(criterio));
                            break;
                        case "Igual a":
                            listaFiltrada = listaFiltrada.FindAll(a => a.Precio == decimal.Parse(criterio));
                            break;
                    }
                    break;
            }
            return listaFiltrada;
        }
    }
}