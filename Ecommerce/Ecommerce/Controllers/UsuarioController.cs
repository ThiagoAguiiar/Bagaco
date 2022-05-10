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

            //if (HttpContext.Session.GetString("user") != null)
            //{
            //    Usuario u = new Usuario(null, null, null, cpf, senha, null);
            //    TempData["msg"] = u.Entra(cpf, senha);
            //    Usuario user = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("user"));

            //    if (TempData["msg"].ToString() == "Adm")
            //    {
            //        return View("Adm");
            //    }
            //    else {
            //        return View("Cliente");
            //    }


            //}
            //else
            //{                 
                Usuario u = Usuario.Entra(cpf, senha);
                if (u != null)
                {
                    //TempData["msg"] = JsonConvert.SerializeObject(u.Entra(cpf, senha));
                    //guarda o usuario
                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(u));
                    //criar um cookie
                    Response.Cookies.Append("obj", JsonConvert.SerializeObject(u));

                    if (u.Tipo.ToUpper() == "SIM")
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
                    return RedirectToAction("login");
                }

            //}
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(string nome, string cpf, string senha)
        {
            Usuario u = new Usuario(nome, null, null, cpf, senha, null);
            ViewBag["msg"] = u.Cadastro(nome, cpf, senha);

            //retorna a view login após fazer o cadastro
            return View("Login");
        }
    }   
    
}
