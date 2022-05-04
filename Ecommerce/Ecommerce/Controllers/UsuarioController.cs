using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
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
            Usuario u = new Usuario(null, null, null, cpf, senha, null);
            TempData["msg"] = u.Login(cpf, senha);

            return RedirectToAction("Login");
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(string nome, string cpf, string senha)
        {
            Usuario u = new Usuario(nome, null, null, cpf, senha, null);
            TempData["msg"] = u.Cadastro(nome, cpf, senha);

            return RedirectToAction("Cadastro");
        }
    }   
    
}
