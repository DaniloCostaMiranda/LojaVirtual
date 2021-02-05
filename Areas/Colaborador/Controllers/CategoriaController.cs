using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LVirt.Libraries.Filtro;
using LVirt.Libraries.Lang;
using LVirt.Models;
using LVirt.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LVirt.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao]
    public class CategoriaController : Controller
    {
        private ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        // GET: /<controller>/
        public IActionResult Index(int? pagina)
        {
            var categorias = _categoriaRepository.ObterTodasCategorias(pagina);
           
            return View(categorias);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Select(a=>new SelectListItem(a.Nome, a.Id.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm]Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepository.Cadastrar(categoria);

                TempData["MSG_S"] = Mensagem.MSG_S001;

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Select(a => new SelectListItem(a.Nome, a.Id.ToString()));
            return View();
        }

        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            var catego = _categoriaRepository.ObterCategoria(id);
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Where(a=>a.Id != id).Select(a => new SelectListItem(a.Nome, a.Id.ToString()));
            return View(catego);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm]Categoria categoria, int id)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepository.Atualizar(categoria);
                TempData["MSG_S"] = Mensagem.MSG_S001;

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Where(a => a.Id != id).Select(a => new SelectListItem(a.Nome, a.Id.ToString()));
            return View();
        }

        [HttpGet]
        [ValidateHttpReferer]
        public IActionResult Excluir(int id)
        {
            _categoriaRepository.Excluir(id);
            TempData["MSG_S"] = Mensagem.MSG_S002;
            return RedirectToAction(nameof(Index));
        }
    }
}
