using AccesoDatos.Repositorio.IRepositorio;

using RopaTilin.AccesoDatos;
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

       
        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Bodegas = new RopaRepositorio(_db);
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
