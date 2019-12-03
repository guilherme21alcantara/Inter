using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ECommerce.Models;
using Newtonsoft.Json;
using ECommerce.Data;
using System.Linq;
using System;

namespace ECommerce.Controllers
{
    public class CarrinhoController : Controller
    {
        public IActionResult Comprar(int id)
        {
            Pedido pedido;
            try
            {
                pedido = JsonConvert
                .DeserializeObject<Pedido>(HttpContext.Session
                    .GetString("carrinho"));
            }
            catch
            {
                pedido = new Pedido();
            }

            //  Consulta em BD e lógica de programação
            using(var data = new ProdutoData())
            {
                Produto produto = data.Read(id);

                Item item = pedido.Itens
                    .SingleOrDefault(i => i.Produto.IdProduto == id);

                if(item == null)
                {
                    pedido.Itens.Add(new Item{
                        Produto = produto,
                        Quantidade = 1,
                        Valor = produto.Valor
                    });
                }
                else
                {
                    item.Quantidade++;
                }
            }

            //
            
            HttpContext.Session.SetString("carrinho",
                 JsonConvert.SerializeObject(pedido));
            

            return RedirectToAction("Index", "Produto");
        }

        public IActionResult Index()
        {
            Pedido pedido;
            try
            {
                pedido = JsonConvert
                .DeserializeObject<Pedido>(HttpContext.Session
                    .GetString("carrinho"));
            }
            catch
            {
                pedido = new Pedido();
            }

            return View(pedido);
        }
    }
}