using AccesoDatos.Repositorio.IRepositorio;
using RopaTilin.AccesoDatos;
using RopaTilin.AccesoDatos.Repositorio;
using RopaTilin.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public IRopaRepositorio Bodegas { get; set; }
        public ICategoriaRepositorio Categorias { get; set; }

        public IMarcaRepositorio Marca {  get; set; }
        public IProductoRepositorio Producto { get; set; }
        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Bodegas = new RopaRepositorio(_db);
            Categorias = new CategoriaRepositorio(_db);
            Marca = new MarcaRepositorio(_db);
            Producto = new ProductoRepositorio(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}
