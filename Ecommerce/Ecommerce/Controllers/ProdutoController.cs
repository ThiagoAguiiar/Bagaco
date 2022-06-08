using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpPost]
        public IActionResult CadastroProduto(string nome, double preco, string descricao, int codigo, int qtd)
        {
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

        public IActionResult Carrinho()
        {
            return View(Produto.MostrarCarrinho());
        }

        [HttpPost]
        public IActionResult Carrinho(int aux)
        {
            List<int> qtds = new List<int>();

            for(int i = 0; i < aux; i++)
            {
                string input = i.ToString();

                string quantidadeProduto = Request.Form[input].ToString();
                qtds.Add(int.Parse(quantidadeProduto));
            }

            Produto.AlterarCarrinho(qtds);

            return RedirectToAction("Carrinho");
        }

        [HttpGet]
        public IActionResult AtualizarDados(int comprados)
        {
            return View("Carrinho");
        }

        //método que vai salvar na tabela Pedidos
        public IActionResult Salvar()
        {
            return View("ProdutosCliente");
        }

        [HttpPost]
        public IActionResult AddCarrinho(int aux)
        {
            string input = aux.ToString();

            string quantidadeProduto = Request.Form[input].ToString();
            string codigo = Request.Form[input + input].ToString();

            Produto p = new Produto(null, 0, null, int.Parse(codigo), 0, null); 
            TempData["msg"] = p.AddCarrinho(int.Parse(quantidadeProduto));

            return RedirectToAction("ProdutosCliente");
        }

        public IActionResult ProdutosAdm()
        {

            return View(Produto.Listar());
        }

        public IActionResult ProdutosCliente()
        {
            return View(Produto.Listar());
        }
        public IActionResult AlterarProduto(int codigo)
        {
            ViewData["dados"] = Produto.RetornarDados(codigo);

            return View();

        }
        [HttpPost]
        public IActionResult AlterarProduto(string nome, double preco, string descricao, int codigo, int qtd)
        {
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

                    TempData["msg"] = p.AlterarProduto(codigo);
                }
            }

            return RedirectToAction("AlterarProduto");
        }

        //exclui um produto (Adm)
        public IActionResult Excluir(int codigo)
        {
            Produto p = new Produto(null, 0, null, codigo, 0, null);
            TempData["msg"] = p.Excluir();
            return RedirectToAction("ProdutosAdm");
        }


        public IActionResult FinalizarCompra()
        {
            Usuario u = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("user").ToString());

            Produto.FinalizarCompra(u.Cpf);
            return RedirectToAction("ProdutosCliente");
        }

        public IActionResult Deletar(int id)
        {

            TempData["msg"] = Produto.Deletar(id);

            return RedirectToAction("Carrinho");
        }

        public IActionResult ListarPedidos()
        {
            Usuario u = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("user").ToString());

            return View(Produto.ListarPedidos(u.Cpf));
        }
    }

} 