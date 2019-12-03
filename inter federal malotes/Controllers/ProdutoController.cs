using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ECommerce.Models;
using ECommerce.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            using(var data = new ProdutoData())
                return View(data.Read());            
        }

        public IActionResult Create()
        {
            /*
            using(var data = new CategoriaData())
                ViewBag.Categorias = data.Read();
                
            */
            return View();
        }

        [HttpPost]
        public IActionResult Create(Produto e)
        {
            if(!ModelState.IsValid)
            {
                return View(e);
            }

            using(var data = new ProdutoData())
                data.Create(e);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            using(var data = new ProdutoData())
                data.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            /*
            using(var data = new CategoriaData())
            {
                var lista = data.Read();
                //using Microsoft.AspNetCore.Mvc.Rendering;
                var items = new SelectList(lista, "IdCategoria", "Nome");
                ViewBag.Categorias = items;
            }
            */

            using(var data = new ProdutoData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Produto e)
        {
            e.IdProduto = id;

            if(!ModelState.IsValid)
                return View(e);
        
            using(var data = new ProdutoData())
                data.Update(e);

            return RedirectToAction("Index");
        }
    }
}