using AccesoDatos.Repositorio.IRepositorio;
using RopaTilin.Modelos;

namespace RopaTilin.AccesoDatos.Repositorio.IRepositorio
{
    public interface IMarcaRepositorio : IRepositorio<Marca>
    {
        void actualizar(Marca marca);
    }
}