using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SSCASPEL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
//using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SSCASPEL.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {

        public AppDBContext _context;

        private readonly IConfiguration _configuration;

        private readonly ILogger<AuthController> _logger;

        public AuthController(IConfiguration configuration, ILogger<AuthController> logger, AppDBContext master)
        {
            _logger = logger;
            _context = master;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login(string username, string password,string source)
        {
            // Tu código para validar que el usuario ingresado es válido



            // Asumamos que tenemos un usuario válido
          //  var user = new User
          //  {
            //    Name = "Eduardo",
            //    Email = "admin@kodoti.com",
            //    UserId = "a79b2e64-a4de-4f3a-8cf6-a68ba400db24"
            //};


            System.Diagnostics.Debug.WriteLine("usuario:  " + username);

            System.Diagnostics.Debug.WriteLine("source:  " + source);

            
            try
            {
                

                var usuario = _context.Usuario.Where(s => s.Username == username && s.Password == password);

                if (usuario.Any())
                {
                    if (usuario.Where(s => s.Username == username && s.Password == password).Any())
                    {
                        //var userf = _context.Usuario.Find(1);
                        var userf  = _context.Usuario.FirstOrDefault(e => e.Username == username && e.Password == password);
                        /* HttpContext.Session.SetString("usuario", userf.Nombre);

                         HttpContext.Session.SetString("tema", userf.Tema);

                         ViewBag.usuario = userf.Nombre;

                         */

                        System.Diagnostics.Debug.WriteLine("usuario:  " + userf.Nombre);


                        // Leemos el secret_key desde nuestro appseting
                        var secretKey = _configuration.GetValue<string>("SecretKey");
                        var key = Encoding.ASCII.GetBytes(secretKey);

                        // Creamos los claims (pertenencias, características) del usuario
                   //     var claims = new[]
                   //     {
                       //new Claim(ClaimTypes.NameIdentifier, user.UserId),
                         //  new Claim(ClaimTypes.Email, user.Email)
                        // new Claim("UserData", JsonConvert.SerializeObject(user))
                   //       };

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                        {
              //  new Claim(ClaimTypes.NameIdentifier, user.UserId),
             //   new Claim(ClaimTypes.Email, user.Email)

                        }),
                            // Subject =  claims,
                            // Nuestro token va a durar un día
                            Expires = DateTime.UtcNow.AddDays(1),
                            // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        };

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                        // return Ok(tokenHandler.WriteToken(createdToken));
                        if (source == "web") {
                            // return RedirectToPage("/Home/Index");
                            // return Redirect("/Home/Index");
                            SessionHelper.SetObjectAsJson(HttpContext.Session, "usuario", userf);
                            return RedirectToAction("Index","Home");
                        } else {
                            return new JsonResult(tokenHandler.WriteToken(createdToken));
                        }
                        
                    }

                }


            }
            catch (IOException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                string message = "Usuario no valido";
                return new JsonResult(message);
            }

            return new JsonResult("Sin datos");

        }
    }
}
