using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace ECommerce.Controllers
{
    public class ClienteController : Controller
    {
        // campo (Field)
        private static List<Cliente> clientes = new List<Cliente>();
        private static int contador = 1;

        [HttpGet]
        public ActionResult Index()
        {
            return View(clientes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //using Microsoft.AspNetCore.Http;
        [HttpPost]
        public ActionResult Create(IFormCollection form)
        {
            string endereco = form["endereco"];
            string razao_social = form["razao_social"];
            string nome_fantasia = form["nome_fantasia"];

            if(razao_social.Length < 6) {
                ViewBag.Mensagem = "Razao Social deve conter 6 ou mais caracteres";
                return View();
            }      

            var novoCliente = new Cliente();
            novoCliente.Endereco = form["endereco"]; 
            novoCliente.Razao_Social = form["razao_social"]; 
            novoCliente.Nome_Fantasia = form["nome_fantasia"]; 
            novoCliente.Cod_Cliente = contador++;

            clientes.Add(novoCliente);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            // foreach(var c in clientes)
            // {
            //     if(c.IdCliente == id)
            //     {
            //         clientes.Remove(c);
            //         break;
            //     }
            // }

            var cliente = clientes.Single(c => c.Cod_Cliente == id);
            clientes.Remove(cliente);

            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            // SELECT * FROM Cliente WHERE id = 1
            Cliente cliente = (from c in clientes
                                where c.Cod_Cliente == id
                                select c).First();

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Update(int id, IFormCollection form)
        {
            var cliente = clientes.Single(c => c.Cod_Cliente == id);

            string endereco = form["endereco"];
            string razao_social = form["razao_social"];
            string nome_fantasia = form["nome_fantasia"];

            if(razao_social.Length < 6) {
                ViewBag.Mensagem = "Nome deve conter 6 ou mais caracteres";
                return View(cliente);
            }

            cliente.Endereco = form["endereco"];
            cliente.Razao_Social = form["razao_social"];
            cliente.Nome_Fantasia = form["nome_fantasia"];

            return RedirectToAction("Index");
        }
    }
}