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
        public IActionResult CadastroProduto(string nome, double preco, string descricao, int cod, int qtd)
        {
            Produto prod = new Produto(nome, preco, descricao, cod, qtd);
            ViewBag.msg = prod.Cadastro(nome, preco, descricao, cod, qtd);

            //retorna a view principal
            return View();
        }

        public IActionResult Adm()
         {
            
             return View(Produto.Listar());
         }
        
    }

}

