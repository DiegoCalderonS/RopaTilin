using AccesoDatos.Repositorio.IRepositorio;
using RopaTilin.Modelos;

namespace RopaTilin.AccesoDatos.Repositorio.IRepositorio
{
    public interface ICategoriaRepositorio : IRepositorio<Categoria>
    {
        void actualizar(Categoria categoria);
    }
}