using System;
using LVirt.Models;
using Microsoft.AspNetCore.Mvc;

namespace LVirt.Controllers
{
    public class ProdutoController : Controller
     {
        public ActionResult Visualizar()
        {
            Produto produto = GetProduto();
            return View(produto);
            //return new ContentResult() { Content = "<h3>Produto --> Visualizar</h3>", ContentType = "text/html" };
        }

        private Produto GetProduto()
        {
            return new Produto()
            {
                Id = 1,
                Nome = "Xbox One",
                Descricao = "Jogue em 4K",
                Valor = 2000.00M
            };
        }
    }
}
