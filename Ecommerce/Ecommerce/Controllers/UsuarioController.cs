using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string cpf, string senha)
        {
            Usuario u = Usuario.Entra(cpf, senha);

            //verifica se tem algo no objeto
            if (u != null)
            {
                //guarda o usuario
                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(u));
                //criar um cookie
                Response.Cookies.Append("obj", JsonConvert.SerializeObject(u));

                //verifica se é adm ou não
                if (u.Tipo == "Adm")
                {
                    return RedirectToAction("ProdutosAdm", "Produto");
                }
                else
                {
                    return RedirectToAction("ProdutosCliente", "Produto");
                }
            }
            //retorna para a tela cadastro
            else
            {
                return RedirectToAction("Cadastro");
            }
        }
        //alterar a parte de cadastro
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(string cpf, string nome, string telefone, string senha, string endereco)
        {
            Usuario u = new Usuario(cpf, nome, telefone, senha, null, endereco);
            u.Cadastro();
            return View("Login");
        }

        public IActionResult PromoveAdm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PromoveAdm(string cpf)
        {
            Usuario u = new Usuario(cpf, null, null, null, null, null);
            u.Promove();
            return View("PromoveAdm");
        }

        public IActionResult ListarClientes()
        {
            return View();
        }

        public IActionResult AlterarDados()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AlterarDados(string cpf, string nome, string telefone, string senha, string endereco)
        {
            Usuario u = new Usuario(cpf, nome, telefone, senha, null, endereco);
            u.Alterar(cpf, nome, telefone, senha, endereco);
            return View("AlterarDados");
        }

        public IActionResult Adm_clientes()
        {
            return View();
        }

        public IActionResult Carrinho()
        {
            return View();
        }

        public IActionResult Cliente()
        {
            return View();
        }


    }
}


