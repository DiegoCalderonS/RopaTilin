using AccesoDatos.Repositorio.IRepositorio;

using RopaTilin.AccesoDatos;
using RopaTilin.AccesoDatos.Repositorio.IRepositorio;
using RopaTilin.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorio
{
    public class RopaRepositorio : Repositorio<Bodega>, IRopaRepositorio
    {
        private readonly ApplicationDbContext _db;
        public RopaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void actualizar(Bodega bodega)
        {
            var bodegaBD = _db.Bodegas.FirstOrDefault(b => b.id == bodega.id);
            if (bodegaBD != null)
            {

                bodegaBD.Nombre = bodega.Nombre;
                bodegaBD.Descripcion = bodega.Descripcion;
                bodegaBD.Estado = bodega.Estado;
                _db.SaveChanges();
            }
        }
    }
}
