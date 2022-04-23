using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SSCASPEL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace SSCASPEL.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public AppDBContext _context;

        public SSCApiController api;

        public AspelDBContext _Aspelcontext;

        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(ILogger<HomeController> logger, AspelDBContext master2, AppDBContext master, IWebHostEnvironment hostEnvironment)
        {
            _context = master;
            _Aspelcontext = master2;
            _logger = logger;
            this._hostEnvironment = hostEnvironment;

        }

        public IActionResult Index()
        {

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            var empresa = _context.Parametros.FirstOrDefault();

            ViewData["usuario"] = user;
            ViewBag.Empresa = empresa.Empresa;

            if (user == null)
            {

                return RedirectToAction("Index", "Login");
            }

            //   List<Inventario> inve = _Aspelcontext.Inventario.ToList();

            return View(user);
        }

        public IActionResult UpdateSerials(string tipo, string message)
        {
            ViewData["message"] = message;
            ViewData["tipo"] = tipo;

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;
            return View();
        }


        public IActionResult Politicas()
        {

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;

            var politicas = _context.Sustitutiva.ToList();
            return View(politicas);
        }

        public IActionResult Series()
        {

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;

            var series = _context.Serie.ToList();
            return View(series);
        }

        public IActionResult Rutas()
        {
            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;

            var rutas = _context.Ruta.ToList();
            return View(rutas);
        }

        public IActionResult Ruta(int id)
        {

            System.Diagnostics.Debug.WriteLine("ruta id " + id);

            Ruta rut = _context.Ruta.Where(x => x.id == id).FirstOrDefault();

            System.Diagnostics.Debug.WriteLine("ruta id " + rut.nombre);
            RutaDetail rt = new RutaDetail();

            try {
                rt.ruta = rut;
            }
            catch (Exception ex) { 
            }
           

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;

            return View(rt);
        }

            public IActionResult UpdateDataSerial(UpdateSerial upd)
        {
            string mensaje = "";
            try
            {

                UpdateSerial updata = new UpdateSerial();

                updata = upd;

                updata.Fechaexp = upd.Fechaexp.AddHours(23.0).AddMinutes(59.0).AddSeconds(59.0);

                //  var conc = EncDecPass.EncryptString(updata.Modo + updata.Dispositivos + updata.Fechaexp);
                var ser = updata.Serial;
                System.Diagnostics.Debug.WriteLine("Modo: " + updata.Modo);
                System.Diagnostics.Debug.WriteLine("Fecha: " + updata.Fechaexp.ToString("s"));
                System.Diagnostics.Debug.WriteLine("Dispositivos: " + updata.Dispositivos);
                System.Diagnostics.Debug.WriteLine("Serial ingresado: " + updata.Serial);

                //  var conc = EncDecPass.PEncrypt(updata.Modo + updata.Dispositivos + updata.Fechaexp);

                //  var decr = EncDecPass.PDecrypt(updata.Serial);

                //estos son los que siempre he usado

                //  var conc = EncDecPass.EncryptString(updata.Modo + updata.Dispositivos + updata.Fechaexp);

                //  string decr = EncDecPass.DecryptString(updata.Serial);
                // declaring key
                //  var key = "b14ca5898a4e4133bbce2ea2315a1916";

                //  var conc = HelperClass.EncryptString(key,updata.Modo + updata.Dispositivos + updata.Fechaexp);

                //  var decr = HelperClass.DecryptString(key,updata.Serial);

                //  var conc = EncDecPass.NEncrypt(updata.Modo + updata.Dispositivos + updata.Fechaexp);

                // var conc = EncDecPass.ZEncrypt(updata.Modo + updata.Dispositivos + updata.Fechaexp);

                //  var conc = EncDecPass.XEncrypt(updata.Modo + updata.Dispositivos + updata.Fechaexp);

                //    var conc = EncDecPass.AEncryptString(updata.Modo + updata.Dispositivos + updata.Fechaexp, "aXb2uy4z");

                //     FileStream filestream = new FileStream("out.txt", FileMode.Create);
                //      var streamwriter = new StreamWriter(filestream);
                //      streamwriter.AutoFlush = true;
                //      Console.SetOut(streamwriter);
                //      Console.SetError(streamwriter);

                var conc = EncDecPass.EncryptString(updata.Modo + updata.Dispositivos + updata.Fechaexp.ToString("s"));
                var nseria = "jB6jvTUrvkJZ2Jb/CenioEucAO2FgICe";

                var decr = "";
                if (ser != null)
                {
                    decr = EncDecPass.DecryptString(ser);
                }
                else
                {
                    decr = EncDecPass.DecryptString(nseria);

                }
                System.Diagnostics.Debug.WriteLine("Nuevo Encriptado '" + conc + "'");


                System.Diagnostics.Debug.WriteLine("Serial decriptado " + decr);


                //   Console.WriteLine("entexto");
                //     Console.WriteLine(conc);
                ////    Console.WriteLine("descriptado");
                //    Console.WriteLine(decr);

                // string mensaje = "";

                if (conc == ser)
                {
                    var std = _context.Parametros.FirstOrDefault(e => e.Id == 1);

                    mensaje = "Su serial se ha actualizado exitosamente";
                    System.Diagnostics.Debug.WriteLine("El serial es correcto");

                    std.Mostrexist = std.Mostrexist;
                    std.Cliexvend = std.Cliexvend;
                    std.Modo = updata.Modo;
                    std.Dispositivos = updata.Dispositivos;

                    std.Fechaexp = updata.Fechaexp;
                    std.Serial = conc;
                    //  System.Diagnostics.Debug.WriteLine(updata.Fechaexp);
                    _context.SaveChanges();


                    return Redirect("/Home/UpdateSerials?tipo=succ&message=" + mensaje.Replace(" ", "%20"));
                }
                else
                {
                    mensaje = "Su serial no es valido con esta informacion ";// +updata.Modo+updata.Dispositivos+updata.Fechaexp+" serial creado :"+conc;
                    System.Diagnostics.Debug.WriteLine("El serial NO es correcto");
                    return Redirect("/Home/UpdateSerials?tipo=error&message=" + mensaje.Replace(" ", "%20"));
                }
            }
            catch (Exception)
            {
                mensaje = "Su serial no es valido con esta informacion";
                return Redirect("/Home/UpdateSerials?tipo=error&message=" + mensaje.Replace(" ", "%20"));
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreaProducto()
        {
            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");


            ViewData["usuario"] = user;
            return View();

        }

        public IActionResult AgregaSerie()
        {
            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");


            ViewData["usuario"] = user;
            return View();
        }

        public IActionResult Pedidos(string fecha, string fecha2)
        {

            DateTime startf;
            DateTime endf;
            if (!String.IsNullOrEmpty(fecha))
            {
                startf = Convert.ToDateTime(fecha);

            }
            else
            {
                startf = DateTime.Now.Date;

            }
            if (!String.IsNullOrEmpty(fecha2))
            {
                endf = Convert.ToDateTime(fecha2).AddHours(23.0).AddMinutes(59.0).AddSeconds(59.0);
            }
            else
            {
                endf = DateTime.Now;

            }

            System.Diagnostics.Debug.WriteLine("in " + startf + "end " + endf);
            var pedidos = _context.Documento.Where(x => x.Tipo == "P" && x.Fecha >= startf && x.Fecha <= endf).OrderByDescending(x => x.Id).ToList();

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;

            //   Response.Headers.Add("Refresh", "5");

            return View(pedidos);
        }

        public IActionResult Cobros(string fecha, string fecha2)
        {

            DateTime startf;
            DateTime endf;
            if (!String.IsNullOrEmpty(fecha))
            {
                startf = Convert.ToDateTime(fecha);

            }
            else
            {
                startf = DateTime.Now.Date;

            }
            if (!String.IsNullOrEmpty(fecha2))
            {
                endf = Convert.ToDateTime(fecha2).AddHours(23.0).AddMinutes(59.0).AddSeconds(59.0);
            }
            else
            {
                endf = DateTime.Now;

            }

            System.Diagnostics.Debug.WriteLine("in " + startf + "end " + endf);
            
            var pedidos = _context.Cobro.Where(x => x.Fecha >= startf && x.Fecha <= endf).OrderByDescending(x => x.Id).ToList();

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;

            //   Response.Headers.Add("Refresh", "5");

            return View(pedidos);

            //   var cobros = _context.Cobro.OrderByDescending(x => x.Id).ToList();

            //   Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            //    ViewData["usuario"] = user;

            //   Response.Headers.Add("Refresh", "5");

            //    return View(cobros);
        }

        public IActionResult Facturas(string fecha, string fecha2)
        {

            DateTime startf;
            DateTime endf;
            if (!String.IsNullOrEmpty(fecha))
            {
                startf = Convert.ToDateTime(fecha);

            }
            else
            {
                startf = DateTime.Now.Date;

            }
            if (!String.IsNullOrEmpty(fecha2))
            {
                endf = Convert.ToDateTime(fecha2).AddHours(23.0).AddMinutes(59.0).AddSeconds(59.0);
            }
            else
            {
                endf = DateTime.Now;

            }

            System.Diagnostics.Debug.WriteLine("in " + startf + "end " + endf);
            var facturas = _context.Documento.Where(x => x.Tipo == "F" && x.Fecha >= startf && x.Fecha <= endf).OrderByDescending(x => x.Id).ToList();

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;

            //   Response.Headers.Add("Refresh", "5");

            return View(facturas);
        }

        public IActionResult Cotizaciones(string fecha, string fecha2)
        {

            DateTime startf;
            DateTime endf;
            if (!String.IsNullOrEmpty(fecha))
            {
                startf = Convert.ToDateTime(fecha);

            }
            else
            {
                startf = DateTime.Now.Date;

            }
            if (!String.IsNullOrEmpty(fecha2))
            {
                endf = Convert.ToDateTime(fecha2).AddHours(23.0).AddMinutes(59.0).AddSeconds(59.0);
            }
            else
            {
                endf = DateTime.Now;

            }

            System.Diagnostics.Debug.WriteLine("in " + startf + "end " + endf);
            var pedidos = _context.Documento.Where(x => x.Tipo == "C" && x.Fecha >= startf && x.Fecha <= endf).OrderByDescending(x => x.Id).ToList();

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;

            //   Response.Headers.Add("Refresh", "5");

            return View(pedidos);
        }

        public async Task<IActionResult> Documento(int id)
        {
            DocumentoRev doctoRev = new DocumentoRev();



            var docto = await _context.Documento.Where(x => x.Id == id).FirstOrDefaultAsync();

            var doctodet = await _context.DocumentoDet.Where(x => x.Iddoc == id).ToListAsync();

            doctoRev.Encabezado = docto;
            doctoRev.Detalle = doctodet;

            List<DocSeguimiento> seguim = new List<DocSeguimiento>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(Serial.apiBaseUrl + "/seguimiento/" + docto.Tipo + "/" + docto.Id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        //  System.Diagnostics.Debug.WriteLine("respuesta " + apiResponse);

                        seguim = JsonConvert.DeserializeObject<List<DocSeguimiento>>(apiResponse);
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + e.Message);
            }

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");
            ViewData["seguimiento"] = seguim;
            ViewData["usuario"] = user;

            return View(doctoRev);
        }

        public IActionResult Info()
        {

            var param = _context.Parametros.FirstOrDefault(b => b.Id == 1);

            ViewData["parametros"] = param;

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;

            // var userf  = _context.Usuario.FirstOrDefault(
            return View();
        }

        public async Task<IActionResult> Recibo(int id)
        {

            ReciboRev doctoRev = new ReciboRev();

            var docto = await _context.Cobro.Where(x => x.Id == id).FirstOrDefaultAsync();

            var doctodet = await _context.CobroDet.Where(x => x.Idr == id).ToListAsync();

            doctoRev.Encabezado = docto;
            doctoRev.Detalle = doctodet;


            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");
            ViewData["usuario"] = user;
            return View(doctoRev);
        }

        public IActionResult Productos(string search)
        {

            List<Producto> listaprod = new List<Producto>();

            if (!String.IsNullOrEmpty(search))
            {

                listaprod = _context.Producto.Where(x => x.Descripcion.Contains(search) && x.Almacen == 0).ToList();
            }
            else
            {
                listaprod = _context.Producto.Where(x => x.Almacen == 0).ToList();
            }


            // List<Producto> listaprod =  _context.Producto.ToList();

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;



            return View(listaprod);

        }

        public IActionResult Clientes(string fecha, string fecha2,string nombre)
        {

            List<Cliente> cliente;


            if (!string.IsNullOrEmpty(nombre))
            {
                cliente = _context.Cliente.Where(x => x.Nombre.Contains(nombre)).Take(100).ToList();
            }
            else
            {
                cliente = _context.Cliente.Take(100).ToList();
            }
            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;

            return View(cliente);
        }

        public IActionResult Cliente(int id)
        {
            var cliente = _context.Cliente.Find(id);

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;

            return View(cliente);
        }


        public IActionResult Dispositivos()
        {

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;


            var disposi = _context.Dispositivo.ToList();

            return View(disposi);
        }
        public IActionResult Usuarios()
        {

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;

            var users = _context.Usuario.ToList();

            return View(users);
        }

        public async Task<IActionResult> Usuario(int id)
        {
            //  System.Diagnostics.Debug.WriteLine("selcionado: " + id);

            var vendor = _Aspelcontext.Vendedor.ToList();

            Vendedor nw = new Vendedor();

            ViewData["vendedor"] = vendor;
            Usuario usuariosel = new Usuario();

            usuariosel = await _context.Usuario.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (usuariosel.Cvevend == "     ")
            {
                usuariosel.Cvevend = "0";
            }
            //  System.Diagnostics.Debug.WriteLine("selcionado: " + usuariosel.Nombre);

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;
            return View(usuariosel);
        }

        public async Task<IActionResult> UpUsuario(Usuario usuario)
        {
            //  System.Diagnostics.Debug.WriteLine("selcionado: " + id);
            if (usuario.Cvevend == "0")
            {
                usuario.Cvevend = "     ";
            }
            _context.Usuario.Update(usuario);
            _context.SaveChanges();

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;
            return Redirect("/Home/Usuarios");
        }

        public IActionResult DelDevice(int id)
        {
            Dispositivo dispo = new Dispositivo();
            dispo = _context.Dispositivo.Find(id);
            _context.Remove(dispo);
            _context.SaveChanges();

            return Redirect("/Home/Dispositivos");

        }

        public IActionResult DelSerie(int id)
        {
            Series dispo = new Series();
            dispo = _context.Serie.Find(id);
            _context.Remove(dispo);
            _context.SaveChanges();

            return Redirect("/Home/Series");

        }

        public IActionResult NuevoUsuario()
        {
            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            var vendor = _Aspelcontext.Vendedor.ToList();

            ViewData["vendedor"] = vendor;

            ViewData["usuario"] = user;
            return View();
        }

        public IActionResult CreaPolitica()
        {
            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;
            return View();
        }

        public IActionResult CreaPoliticaS(Sustitutiva sust)
        {
            _context.Sustitutiva.Add(sust);
            _context.SaveChanges();
            return Redirect("/Home/Politicas");
        }

        public IActionResult Parametros()
        {
            var param = _context.Parametros.Find(1);
            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;
            return View(param);
        }


        public IActionResult NuevaMedida()
        {

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;
            return View();
        }
        public IActionResult NuevaMedidaN(UMed unidad)
        {
            _context.UnidadMedida.Add(unidad);

            _context.SaveChanges();

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;
            return Redirect("/Home/Unidades");
        }

        public IActionResult Producto(string id)
        {

            var producto = _context.Producto.Find(id);

            double impu = 0, preciof = 0;

            var esquema = _context.Impuesto.Where(x => x.Esquema == producto.Esquema).FirstOrDefault();

            if (esquema.Impu4 != 0)
            {
                impu = esquema.Impu4;
            }
            else if (esquema.Impu3 != 0)
            {
                impu = esquema.Impu3;
            }
            else if (esquema.Impu2 != 0)
            {
                impu = esquema.Impu2;
            }
            else if (esquema.Impu1 != 0)
            {
                impu = esquema.Impu1;
            }

            preciof = producto.Precio * (1 + (impu / 100));

            //   System.Diagnostics.Debug.WriteLine("impuesto " + impu);

            producto.Precio = preciof;

            var unidades = _context.UnidadesMedida.FromSqlRaw("SELECT a.id,a.codigo,b.nivel,b.unmed,a.univenta FROM inventariopres a INNER JOIN inventariounmed b on b.id = a.unmed WHERE a.codigo='" + id.Replace("'", "''") + "' ORDER BY a.codigo, b.nivel").ToList();

            var imagen = _context.Images.Where(x => x.CveArt == id).ToList();

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;


            ProductoModel prdmod = new ProductoModel();

            prdmod.prod = producto;
            prdmod.user = user;
            prdmod.unmd = unidades;
            prdmod.imgn = imagen;


            return View(prdmod);
        }

        public IActionResult Unidades()
        {

            var unidades = _context.UnidadMedida.OrderBy(x => x.Nivel).ToList();

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;


            return View(unidades);
        }

        public IActionResult CreateImag(string id)
        {
            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;

            ImageModel img = new ImageModel();
            img.CveArt = id;

            return View(img);
        }

        public IActionResult DeleImag(int id)
        {
            //  Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            //    ViewData["usuario"] = user;

            System.Diagnostics.Debug.WriteLine("codigo de imagen: " + id);

            ImageModel img = new ImageModel();
            img = _context.Images.Where(a => a.ImageId == id).FirstOrDefault();

            _context.Images.Remove(img);
            _context.SaveChanges();

            return Redirect("/Home/Producto/" + img.CveArt);
        }

        public async Task<IActionResult> Create([Bind("ImageId,Title,ImageFile,CveArt")] ImageModel imageModel)
        {

            System.Diagnostics.Debug.WriteLine("cveart: " + imageModel.CveArt);

            if (ModelState.IsValid)
            {
                //Save image to wwwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                string extension = Path.GetExtension(imageModel.ImageFile.FileName);
                imageModel.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imageModel.ImageFile.CopyToAsync(fileStream);
                }
                //Insert record
                _context.Add(imageModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Producto", new { id = imageModel.CveArt });
                //return RedirectToAction(nameof(Producto));
            }
            return View(imageModel);
        }

        public IActionResult EditProd(string id)
        {

            var producto = _context.Producto.Find(id);

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;

            return View(producto);
        }

        public IActionResult EditaSerie(int id)
        {

            var seriex = _context.Serie.Find(id);

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;

            return View(seriex);
        }

        public IActionResult CreateClie()
        {
            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;

            return View();
        }

        public IActionResult CreaCliente(Cliente cliente)
        {

            _context.Cliente.Add(cliente);
            _context.SaveChanges();
            return Redirect("/Home/Clientes");
        }

        public IActionResult CreaSerie(Series seriex)
        {

            //  System.Diagnostics.Debug.WriteLine(seriex.Serie);
            //  System.Diagnostics.Debug.WriteLine(seriex.Concai);

            _context.Serie.Add(seriex);
            _context.SaveChanges();
            return Redirect("/Home/Series");
        }


        public IActionResult EditarProducto(Producto producto)
        {

            _context.Producto.Update(producto);
            _context.SaveChanges();

            return Redirect("/Home/Productos");
        }

        public IActionResult EditarSerieN(Series seriex)
        {

            _context.Serie.Update(seriex);
            _context.SaveChanges();
            return Redirect("/Home/Series");
        }

        public IActionResult UpdParametros(Parametros param)
        {
            _context.Parametros.Update(param); //requires using System.Data.Entity.Migrations;
            _context.SaveChanges();
            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;
            return Redirect("/Home/Parametros");
        }

        public IActionResult NewUsuario(Usuario user)
        {

            if (user.Cvevend == "0")
            {
                user.Cvevend = "     ";
            }

            _context.Usuario.Add(user);

            _context.SaveChangesAsync();

            return Redirect("/Home/Usuarios");
        }

        public IActionResult NuevoProducto(Producto producto)
        {


            _context.Producto.Add(producto);

            UnidadesMedida um = new UnidadesMedida();
            um.Codigo = producto.Codigo;
            um.Nivel = 1;
            um.Unidades = 1;

            _context.UnidadesMedida.Add(um);
                

            _context.SaveChangesAsync();

            return Redirect("/Home/Productos");
        }

        public IActionResult AgreUnMed(string codigo)
        {

            Usuario user = SessionHelper.GetObjectFromJson<Usuario>(HttpContext.Session, "usuario");

            ViewData["usuario"] = user;

            InvePresentacion umd = new InvePresentacion();

            umd.Codigo = codigo;

            var unidades = _context.UnidadMedida.ToList();

            ViewData["unidades"] = unidades;

            return View(umd);
        }
        /*
               // [Route("getpdf")]
                public IActionResult GetPdf(string url)
                {
                    if (string.IsNullOrEmpty(url))
                        return new NotFoundResult();

                    //Initialize HTML to PDF converter 
                    HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
                    WebKitConverterSettings settings = new WebKitConverterSettings();

                    //Set WebKit path
                    settings.WebKitPath = Path.Combine(_hostEnvironment.ContentRootPath, "QtBinariesWindows");
                    //Assign WebKit settings to HTML converter
                    htmlConverter.ConverterSettings = settings;

                    //Convert URL to PDF
                    PdfDocument document = htmlConverter.Convert(url);

                    MemoryStream stream = new MemoryStream();
                    document.Save(stream);

                    return File(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, "azureacademynopcommerce.pdf");
                }*/

        public IActionResult AgregaUMN(InvePresentacion umna)
        {

            InvePresentacion inp = new InvePresentacion();
            inp.Id = 0;
            inp.Codigo = umna.Codigo;
            inp.Unmed = umna.Unmed;
            inp.Univenta = umna.Univenta;

            // System.Diagnostics.Debug.WriteLine("id: " + inp.Id);
            // System.Diagnostics.Debug.WriteLine("codigo: " + inp.Codigo);
            // System.Diagnostics.Debug.WriteLine("unidad: " + inp.Unmed);
            // System.Diagnostics.Debug.WriteLine("cantidad: " + inp.Univenta);

            _context.Presentaciones.Add(inp);
            _context.SaveChanges();

            ViewBag.ShouldClose = true;

            return Redirect("AgreUnMed");
        }

        public IActionResult CrearNuevaFactura()
        {

            return View();
        }

        public IActionResult CloseSession()
        {
            HttpContext.Session.Clear();
            HttpContext.SignOutAsync();
            return Redirect("/Login/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
