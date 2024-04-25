using AccesoDatos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc.Rendering;
using RopaTilin.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RopaTilin.AccesoDatos.Repositorio.IRepositorio
{
    public interface IProductoRepositorio : IRepositorio<Producto>  
    {
        void actualizar(Producto producto);
        IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj);
    }
}
