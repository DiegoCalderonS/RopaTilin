using Microsoft.AspNetCore.Mvc;

using AccesoDatos.Repositorio.IRepositorio;
using RopaTilin.Modelos;
using RopaTilin.Utilidades;

namespace CueritosChapaChapa.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RopaController : Controller
    {
        
        private readonly IUnidadTrabajo _unidadTrabajo;

        public RopaController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;   
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            Bodega bodega = new Bodega();
            if (id == null) { 
            bodega.Estado= true;
                return View(bodega);
            }
            bodega = await _unidadTrabajo.Bodegas.Obtener(id.GetValueOrDefault());
            if (bodega == null)
            {
                return NotFound();
            }
            return View(bodega);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Bodega bodega)
        {
            if (ModelState.IsValid)
            {
                if (bodega.id == 0)
                {
                    await _unidadTrabajo.Bodegas.Agregar(bodega);
                    TempData[RP.Exitosa] = "La Bodega Se Creo Con Exito";
                }
                else
                {
                    _unidadTrabajo.Bodegas.actualizar(bodega);
                    TempData[RP.Exitosa] = "La Bodega Se Actualizo Con Exito";

                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[RP.Error] = "Error al Grabar la Bodega";
            return View(bodega);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var bodegaDB = await _unidadTrabajo.Bodegas.Obtener(id);
            if (bodegaDB == null)
            {
                return Json(new { success = false, message = " Error al borrar el registro en la base de datos " });
            }
            _unidadTrabajo.Bodegas.Remover(bodegaDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = " Ropa eliminada con exito " });
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Bodegas.ObtenerTodos();
            return Json(new { data = todos});

        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Bodegas.ObtenerTodos();

            if (id == 0)
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim()
                        == nombre.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim()
                        == nombre.ToLower().Trim() && b.id != id);
            }
            if (valor)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });
        }

        #endregion

    }
}
