using AccesoDatos.Repositorio;
using Microsoft.AspNetCore.Mvc.Rendering;
using RopaTilin.AccesoDatos.Repositorio.IRepositorio;
using RopaTilin.Modelos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RopaTilin.AccesoDatos.Repositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        private readonly ApplicationDbContext _db;
        public ProductoRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
        public void actualizar(Producto producto)
        {
            var productoBD = _db.Productos.FirstOrDefault(b => b.Id == producto.Id);
        if(productoBD != null)
            {
                if(producto.ImagenUrl!=null)
                {
                    productoBD.ImagenUrl= producto.ImagenUrl;
                }

                productoBD.NumeroSerie = producto.NumeroSerie;
                productoBD.Descripcion = producto.Descripcion;
                productoBD.Precio= producto.Precio;
                productoBD.Costo= producto.Costo;
                productoBD.CategoriaId= producto.CategoriaId;
                productoBD.MarcaId= producto.MarcaId;
                productoBD.PadreId= producto.PadreId;
                productoBD.Estado = producto.Estado;
                _db.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj)
        {
            if(obj == "Categoria")
            {
                return _db.Categorias.Where(c => c.Estado == true).Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.id.ToString()
                }) ;
            }
            if(obj =="Marca")
            {
                return _db.Marca.Where(c => c.Estado == true).Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.id.ToString()
                });
            }
            return null;
        }
    }
}
