using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Entrar()
        {
            return View();
        }

        [HttpPost]

        public string Entrar(string cpf, string senha)
        {
            Usuario u = new Usuario(cpf, senha);
            TempData["msg"] = u.Entra(cpf, senha);

            return 
         

        }
    }
}
