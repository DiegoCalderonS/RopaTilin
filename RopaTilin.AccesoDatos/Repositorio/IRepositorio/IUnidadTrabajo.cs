using RopaTilin.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        IRopaRepositorio Bodegas { get; }

        ICategoriaRepositorio Categorias { get; }
        IMarcaRepositorio Marca { get; }
        IProductoRepositorio Producto { get; }
        Task Guardar();
    }
}
