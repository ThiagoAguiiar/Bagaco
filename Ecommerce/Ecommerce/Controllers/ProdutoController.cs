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
            return View();
        }

        public IActionResult Carrinho()
        {
            //retorna para a view principal do Adm
            return View();
        }


        [HttpPost]
        public IActionResult CadastroProduto(string nome, double preco, string descricao, int codigo, int qtd)
        {
            //IFormFile arquivo = Request.Form.Files[0];
            foreach (IFormFile arquivo in Request.Form.Files)
            {
                string tipoArquivo = arquivo.ContentType;
                if (tipoArquivo.Contains("png") ||
                        tipoArquivo.Contains("jpeg"))
                {
                    MemoryStream s = new MemoryStream();
                    arquivo.CopyToAsync(s);
                    byte[] bytesArquivo = s.ToArray();
                    Produto p = new Produto(nome, preco, descricao, codigo, qtd, bytesArquivo);
                    
                    TempData["msg"] = p.Cadastro();
                }
            }
                return RedirectToAction("CadastroProduto");  
        }

        public IActionResult ProdutosAdm()
        {

            return View(Produto.Listar());
        }

        public IActionResult ProdutosCliente()
        {
            return View(Produto.Listar());
        }

        

    }
} 

    

