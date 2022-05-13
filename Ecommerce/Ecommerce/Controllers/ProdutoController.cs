using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        public IActionResult CadastroProduto(string nome, double preco, string descricao, int cod, int qtd, string img)
        {
            IFormFile arquivo = Request.Form.Files[0];
            string tipoArquivo = arquivo.ContentType;
            if (tipoArquivo.Contains("png") ||
                    tipoArquivo.Contains("jpeg"))
            {
                MemoryStream s = new MemoryStream();
                arquivo.CopyToAsync(s);
                byte[] bytesArquivo = s.ToArray();
                Produto p = new Produto(nome, preco, descricao, cod, qtd, bytesArquivo);
                p.Cadastro(nome, preco, descricao, cod, qtd, bytesArquivo);

            }



                //retorna a view principal
                return RedirectToAction("CadastroProduto");
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

