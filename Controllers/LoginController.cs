using Microsoft.AspNetCore.Mvc;
using SSCASPEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            if (user != null) {

                return RedirectToAction("Index", "Home");
            }
            // System.Diagnostics.Debug.WriteLine(Models.Serial.Codigo);

            return View();
        }
    }
}
