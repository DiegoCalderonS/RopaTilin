﻿using Microsoft.AspNetCore.Mvc;
using AccesoDatos.Repositorio.IRepositorio;
using RopaTilin.Modelos;
using RopaTilin.Utilidades;

namespace CueritosChapaChapa.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriaController : Controller
    {
        
        private readonly IUnidadTrabajo _unidadTrabajo;

        public CategoriaController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;   
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            Categoria categoria = new Categoria();
            if (id == null) {
                categoria.Estado= true;
                return View(categoria);
            }
            categoria = await _unidadTrabajo.Categorias.Obtener(id.GetValueOrDefault());
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoria.id == 0)
                {
                    await _unidadTrabajo.Categorias.Agregar(categoria);
                    TempData[RP.Exitosa] = "La categoria Se Creo Con Exito";
                }
                else
                {
                    _unidadTrabajo.Categorias.actualizar(categoria);
                    TempData[RP.Exitosa] = "La categoria Se Actualizo Con Exito";

                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[RP.Error] = "Error al Grabar la categoria";
            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var categoriaDB = await _unidadTrabajo.Categorias.Obtener(id);
            if (categoriaDB == null)
            {
                return Json(new { success = false, message = " Error al borrar el registro en la base de datos " });
            }
            _unidadTrabajo.Categorias.Remover(categoriaDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = " Categoria eliminada con exito " });
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Categorias.ObtenerTodos();
            return Json(new { data = todos});

        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Categorias.ObtenerTodos();

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
