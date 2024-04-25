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
    public class MarcaRepositorio : Repositorio<Marca>, IMarcaRepositorio
    {
        private readonly ApplicationDbContext _db;
        public MarcaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void actualizar(Marca marca)
        {
            var marcaBD = _db.Bodegas.FirstOrDefault(b => b.id == marca.id);
            if (marcaBD != null)
            {

                marcaBD.Nombre = marca.Nombre;
                marcaBD.Descripcion = marca.Descripcion;
                marcaBD.Estado = marca.Estado;
                _db.SaveChanges();
            }
        }
    }
}
