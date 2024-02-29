using AccesoDatos.Repositorio.IRepositorio;
using RopaTilin.Modelos;

namespace RopaTilin.AccesoDatos.Repositorio.IRepositorio
{
    public interface IRopaRepositorio : IRepositorio<Bodega>
    {
        void actualizar(Bodega bodegas);
    }
}