using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult CadastroProduto()
        {
            //retorna para a view principal do Adm
            return View("CadastroProduto");
        }

        [HttpPost]
        public IActionResult CadastroProduto(string nome, double preco, int cod, int qtd)
        {
            Produto prod = new Produto(nome, preco, null, cod, qtd);
            ViewBag["msg"] = prod.Cadastro(nome, preco, null, cod, qtd);

            //retorna a view principal
            return View();
        }

        /* public IActionResult Lista()
        {
            return View("Produtos");
        }

        */

        

        // [HttpPost]
        /* public IActionResult Lista()
         {
             return View(Produto.Listar());
         }
        */
    }

}

