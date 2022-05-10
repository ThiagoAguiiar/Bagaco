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
            if (HttpContext.Session.GetString("user") == null)
            {
                Usuario u = new Usuario(null, null, null, cpf, senha, null);

                TempData["msg"] = JsonConvert.SerializeObject(u.Entra(cpf, senha));
                //guarda o usuario
                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(u));
                //criar um cookie
                Response.Cookies.Append("obj", JsonConvert.SerializeObject(u));

                if (TempData["msg"].ToString() == "True")
                {
                    return View("Adm");
                }
                else
                {
                    return View("Cliente");
                }
            }
            else
            {
                Usuario u = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("user"));

                if(u.Tipo == "sim")
                {
                    return View("Adm");
                }
                else
                {
                    return View("Cliente");
                }
            }
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
