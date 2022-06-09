using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSCASPEL.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using conectorfelv2;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using Microsoft.Data.SqlClient;

namespace SSCASPEL.Controllers
{
    [Route("api/[controller]")]
    // [Authorize]
    [ApiController]
    public class SSCApiController : ControllerBase
    {

        public AppDBContext _context;
        public AspelDBContext _aspelcontext;
        //  private readonly IHostingEnvironment _hostingEnvironment2;

        public conectorfelv2.RequestCertificacionFel _request = new RequestCertificacionFel();

        private readonly IWebHostEnvironment _hostEnvironment;

        private readonly IEmailConfiguration _emailConfiguration;

        public SSCApiController(AppDBContext master, AspelDBContext master2, IWebHostEnvironment hostEnvironment, IEmailConfiguration emailConfiguration)
        {

            this._context = master;
            this._aspelcontext = master2;
            this._hostEnvironment = hostEnvironment;
            this._emailConfiguration = emailConfiguration;
            //    _hostingEnvironment2 = hostingEnvironment2;

        }

        [Produces("application/json")]
        [HttpGet("clientes")]
        public IActionResult Clientes()
        {
            if (Verificador.EsValido(_context))
            {

                try
                {

                    var Clientes = _context.Cliente.Where(x => x.Estado == "A" || x.Estado == "M").OrderBy(a => a.Id).ToList();

                    return Ok(Clientes);
                }
                catch
                {

                    return BadRequest();

                }
            }
            else
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized);
            }
        }

        [Produces("application/json")]
        [HttpGet("usuarios")]
        public IActionResult Usuarios()
        {
            try
            {

                var Usuarios = _context.Usuario.OrderBy(a => a.Id).ToList();

                return Ok(Usuarios);
            }
            catch
            {

                return BadRequest();

            }
        }

        [Produces("application/json")]
        [HttpGet("series")]
        public IActionResult Series()
        {
            try
            {

                var Series = _context.Serie.OrderBy(a => a.Serie).ToList();

                return Ok(Series);
            }
            catch
            {

                return BadRequest();

            }
        }

        [Produces("application/json")]
        [HttpGet("bancos")]
        public IActionResult Bancos()
        {
            try
            {

                var bancos = _context.Banco.OrderBy(a => a.Nombre).ToList();

                return Ok(bancos);
            }
            catch
            {

                return BadRequest();

            }
        }


        [Produces("application/json")]
        //[HttpGet("stock/{almacen?}/{codigo?}")]
        [HttpGet("productos/{almacen?}")]
        public IActionResult Productos(int almacen)
        {
            if (Verificador.EsValido(_context))
            {
                try
                {
                    if (almacen != 0 || almacen != null)
                    {
                        var Productos = _context.Producto.Where(b => b.Almacen == almacen).OrderBy(a => a.Codigo).ToList();

                        return Ok(Productos);
                    }
                    else
                    {
                        var Productos = _context.Producto.Where(b => b.Almacen == 0).OrderBy(a => a.Codigo).ToList();

                        return Ok(Productos);
                    }
                }
                catch
                {

                    return BadRequest();

                }
            }
            else
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized);
            }
        }


        [Produces("application/json")]
        [HttpGet("precios")]
        public IActionResult Precios()
        {
            if (Verificador.EsValido(_context))
            {
                try
                {

                    var Precios = _context.Precio.Where(x => x.Preciou != 0).OrderBy(a => a.Codigo).ThenBy(b => b.Lista).ToList();

                    return Ok(Precios);
                }
                catch
                {

                    return BadRequest();

                }
            }
            else
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized);
            }
        }

        [Produces("application/json")]
        [HttpGet("impuestos")]
        public IActionResult Impuestos()
        {
            if (Verificador.EsValido(_context))
            {
                try
                {

                    var Impuestos = _context.Impuesto.OrderBy(a => a.Esquema).ToList();

                    return Ok(Impuestos);
                }
                catch
                {

                    return BadRequest();

                }
            }
            else
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized);
            }
        }

        [Produces("application/json")]
        [HttpGet("condiciones")]
        public IActionResult Condiciones()
        {
            if (Verificador.EsValido(_context))
            {
                try
                {

                    var Condiciones = _context.Condicion.ToList();
                    //  var Impuestos = _context.Impuesto.OrderBy(a => a.Esquema).ToList();

                    return Ok(Condiciones);
                }
                catch
                {

                    return BadRequest();

                }
            }
            else
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized);
            }
        }

        [Produces("application/json")]
        [HttpGet("parametros")]
        public IActionResult Parametros()
        {
            try
            {

                var Parametros = _context.Parametros.ToList();
                //  var Impuestos = _context.Impuesto.OrderBy(a => a.Esquema).ToList();

                return Ok(Parametros);
            }
            catch
            {

                return BadRequest();

            }
        }

        [Produces("application/json")]
        [HttpGet("sustitutivas")]
        public IActionResult Sustitutivas()
        {
            if (Verificador.EsValido(_context))
            {
                try
                {

                    var Sustitutivas = _context.Sustitutiva.Where(a => a.St == "A").OrderBy(a => a.Politica).ToList();

                    return Ok(Sustitutivas);
                }
                catch
                {

                    return BadRequest();

                }
            }
            else
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized);
            }
        }

        [Produces("application/json")]
        [HttpGet("acumulativas")]
        public IActionResult Acumulativas()
        {
            if (Verificador.EsValido(_context))
            {
                try
                {

                    var Acumulativas = _context.Acumulativa.Where(a => a.St == "A").OrderBy(a => a.Politica).ToList();

                    return Ok(Acumulativas);
                }
                catch
                {

                    return BadRequest();

                }
            }
            else
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized);
            }
        }

        [Produces("application/json")]
        [HttpGet("seguimiento/{tipo}/{id}")]
        public async Task<ActionResult> Seguimiento(String tipo, int id)
        //  public IActionResult Seguimiento(String tipo, int id)
        {
            tipo = tipo.ToUpper();
            //  System.Diagnostics.Debug.WriteLine("tipo" + tipo);
            //   System.Diagnostics.Debug.WriteLine("numero" + id);

            List<DocSeguimiento> seguimientod = new List<DocSeguimiento>();

            try
            {
                var doc0 = _context.Documento.Where(x => x.Id == id).FirstOrDefault();

                if (doc0 != null)
                {
                    //    System.Diagnostics.Debug.WriteLine("cvedoc del id : " + doc0.Cvedoc);

                    string query1 = "SELECT CVE_DOC AS cve_doc,ISNULL(DOC_SIG,'') AS docsig,FECHA_DOC AS fecha,TIP_DOC AS tdoc,ISNULL(TIP_DOC_SIG,'') as tdocs,STATUS AS estado  FROM FACT" + doc0.Tipo + "01 WHERE CVE_DOC = '" + doc0.Cvedoc + "'";

                    DocSeguimiento doc1 = await _aspelcontext.DocSeguimientos.FromSqlRaw(query1).FirstOrDefaultAsync();

                    if (doc1 != null)
                    {
                        //      System.Diagnostics.Debug.WriteLine("pedido" + doc1.docsig);
                        seguimientod.Add(doc1);
                        if (!doc1.tdocs.Equals(""))
                        {
                            string query2 = "SELECT CVE_DOC AS cve_doc,ISNULL(DOC_SIG,'') AS docsig,FECHA_DOC AS fecha,TIP_DOC AS tdoc,ISNULL(TIP_DOC_SIG,'') as tdocs,STATUS AS estado  FROM FACT" + doc1.tdocs + "01 WHERE CVE_DOC = '" + doc1.docsig + "'";

                            DocSeguimiento doc2 = await _aspelcontext.DocSeguimientos.FromSqlRaw(query2).FirstOrDefaultAsync();

                            if (doc2 != null)
                            {
                                //       System.Diagnostics.Debug.WriteLine("pedido" + doc2.tdocs);
                                seguimientod.Add(doc2);
                                if (!doc2.tdocs.Equals(""))
                                {
                                    string query3 = "SELECT CVE_DOC AS cve_doc,ISNULL(DOC_SIG,'') AS docsig,FECHA_DOC AS fecha,TIP_DOC AS tdoc,ISNULL(TIP_DOC_SIG,'') as tdocs,STATUS AS estado  FROM FACT" + doc2.tdocs + "01 WHERE CVE_DOC = '" + doc2.docsig + "'";

                                    DocSeguimiento doc3 = await _aspelcontext.DocSeguimientos.FromSqlRaw(query3).FirstOrDefaultAsync();

                                    if (doc3 != null)
                                    {
                                        //           System.Diagnostics.Debug.WriteLine("pedido" + doc3.tdocs);
                                        seguimientod.Add(doc3);
                                        if (!doc3.tdocs.Equals(""))
                                        {
                                            string query4 = "SELECT CVE_DOC AS cve_doc,ISNULL(DOC_SIG,'') AS docsig,FECHA_DOC AS fecha,TIP_DOC AS tdoc,ISNULL(TIP_DOC_SIG,'') as tdocs,STATUS AS estado  FROM FACT" + doc3.tdocs + "01 WHERE CVE_DOC = '" + doc3.docsig + "'";

                                            DocSeguimiento doc4 = await _aspelcontext.DocSeguimientos.FromSqlRaw(query4).FirstOrDefaultAsync();

                                            if (doc4 != null)
                                            {
                                                //       System.Diagnostics.Debug.WriteLine("pedido" + doc4.tdocs);
                                                seguimientod.Add(doc4);
                                                if (!doc4.tdocs.Equals(""))
                                                {
                                                    string query5 = "SELECT CVE_DOC AS cve_doc,ISNULL(DOC_SIG,'') AS docsig,FECHA_DOC AS fecha,TIP_DOC AS tdoc,ISNULL(TIP_DOC_SIG,'') as tdocs,STATUS AS estado  FROM FACT" + doc4.tdocs + "01 WHERE CVE_DOC = '" + doc4.docsig + "'";

                                                    DocSeguimiento doc5 = await _aspelcontext.DocSeguimientos.FromSqlRaw(query5).FirstOrDefaultAsync();

                                                    if (doc5 != null)
                                                    {
                                                        //      System.Diagnostics.Debug.WriteLine("pedido" + doc5.tdocs);
                                                        seguimientod.Add(doc5);
                                                        if (!doc5.tdocs.Equals(""))
                                                        {
                                                            string query6 = "SELECT CVE_DOC AS cve_doc,ISNULL(DOC_SIG,'') AS docsig,FECHA_DOC AS fecha,TIP_DOC AS tdoc,ISNULL(TIP_DOC_SIG,'') as tdocs,STATUS AS estado  FROM FACT" + doc5.tdocs + "01 WHERE CVE_DOC = '" + doc5.docsig + "'";

                                                            DocSeguimiento doc6 = await _aspelcontext.DocSeguimientos.FromSqlRaw(query6).FirstOrDefaultAsync();

                                                            if (doc6 != null)
                                                            {
                                                                //       System.Diagnostics.Debug.WriteLine("pedido" + doc6.tdocs);
                                                                seguimientod.Add(doc5);
                                                            }
                                                            else
                                                            {
                                                                return Ok(seguimientod);
                                                            }

                                                        }
                                                        else
                                                        {
                                                            return Ok(seguimientod);
                                                        }

                                                    }
                                                    else
                                                    {

                                                        return Ok(seguimientod);
                                                    }

                                                }
                                                else
                                                {
                                                    return Ok(seguimientod);
                                                }

                                            }
                                            else
                                            {

                                                return Ok(seguimientod);
                                            }
                                        }
                                        else
                                        {
                                            return Ok(seguimientod);
                                        }

                                    }
                                    else
                                    {

                                        return Ok(seguimientod);
                                    }
                                }
                                else
                                {
                                    return Ok(seguimientod);
                                }

                            }
                            else
                            {

                                return Ok(seguimientod);
                            }

                        }
                        else
                        {
                            return Ok(seguimientod);
                        }

                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("no encontro nada con el idws: " + doc0.Id);
                        return BadRequest();
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("no encontro nada con el id: " + id);
                    return BadRequest();
                }

                return Ok();
            }
            catch
            {

                return BadRequest();

            }

        }


        [Produces("application/json")]
        [HttpGet("unidadesventa")]
        public IActionResult UnidadesVenta()
        {
            if (Verificador.EsValido(_context))
            {
                try
                {

                    var UnidaddeVenta = _context.UnidadesMedida.FromSqlRaw("SELECT a.id,a.codigo,b.nivel,b.unmed,a.univenta FROM inventariopres a INNER JOIN inventariounmed b on b.id = a.unmed ORDER BY a.codigo, b.nivel").ToList();



                    return Ok(UnidaddeVenta);
                }
                catch
                {

                    return BadRequest();

                }
            }
            else
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized);
            }
        }

        [Produces("application/json")]
        [HttpGet("getdocto/{id}")]
        public IActionResult GetDocto(int id)
        {


            try
            {

                var doc = _context.Documento.FirstOrDefault(e => e.Id == id);

                System.Diagnostics.Debug.WriteLine("id encontrado: " + doc.Cvedoc);

                var docdet = _context.DocumentoDet.Where(e => e.Iddoc == id);

                foreach (DoctoDet det in docdet)
                {

                    System.Diagnostics.Debug.WriteLine("detalle: " + det.Descr);
                }

                return Ok(doc);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getcvedoc/{id}")]
        public IActionResult GetCveDoc(int id)
        {
            CveDoc cvd = new CveDoc();
            try
            {

                System.Diagnostics.Debug.WriteLine("id a busar: " + id);

                var doc = _context.Documento.FirstOrDefault(e => e.Id == id);

                System.Diagnostics.Debug.WriteLine("cvedoc encontrado: " + doc.Cvedoc);

                cvd.docto = doc.Cvedoc;

                return Ok(cvd);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getdocumento/{id}")]
        public async Task<ActionResult> GetDocumento(int id)
        {
            DocumentoRev doctoRev = new DocumentoRev();

            var docto = await _context.Documento.Where(x => x.Id == id).FirstOrDefaultAsync();

            var doctodet = await _context.DocumentoDet.Where(x => x.Iddoc == id).ToListAsync();

            doctoRev.Encabezado = docto;
            doctoRev.Detalle = doctodet;

            return Ok(doctoRev);
        }

        [HttpPost("[action]"), ActionName("subePedido")]
        [Obsolete]
        public async Task<ActionResult<Docto>> SubePedido(Pedido pedido)
        {

            if (Verificador.EsValido(_context))
            {
                try
                {

                    string jsonString = JsonSerializer.Serialize(pedido);

                    System.Diagnostics.Debug.WriteLine("Json recibido en pedido:  " + jsonString);

                    System.Diagnostics.Debug.WriteLine("El UIDEV recibido es: " + pedido.Uidev);

                    using (StreamWriter writer = System.IO.File.AppendText("logfile.txt"))
                    {
                        writer.WriteLine(DateTime.Now);
                        writer.WriteLine("ID del usuario: " + pedido.Iduser);
                        writer.WriteLine("UI del documento: " + pedido.Uidev);
                        writer.WriteLine("Desde : " + pedido.Enviadesde);
                        writer.WriteLine("FechaDoc : " + pedido.Fecha);
                        writer.WriteLine("Json Recibido: " + jsonString);
                        writer.WriteLine("");
                    }

                    Docto enc = new Docto();
                    enc.Cvedoc = "";
                    enc.Tipo = pedido.Tipdoc;
                    enc.Idclie = pedido.Idclie;
                    enc.Cliente = pedido.Cliente;
                    enc.Serie = pedido.Serie;
                    enc.Nombreclie = pedido.Nombreclie;
                    enc.Rfc = pedido.Rfc;
                    enc.Fecha = Convert.ToDateTime(pedido.Fecha);
                    if (pedido.Fechaen != null)
                    {
                        enc.Fechaen = Convert.ToDateTime(pedido.Fechaen);
                    }
                    else
                    {
                        enc.Fechaen = Convert.ToDateTime(pedido.Fecha);
                    }
                    enc.Fechaws = DateTime.Now;
                    enc.Vendedor = pedido.Vendedor;
                    enc.Esquema = pedido.Esquema;
                    enc.Supedido = pedido.Supedido;
                    enc.Condicion = pedido.Condicion;
                    enc.Observacion = pedido.Observacion;
                    enc.Transporte = pedido.Transporte;
                    enc.Direntrega = pedido.Direntrega;
                    enc.Clocation = pedido.Clocation;
                    enc.Iduser = pedido.Iduser;
                    enc.Noalmacen = pedido.Noalmacen;
                    enc.Uidev = pedido.Uidev;

                    enc.Total = pedido.Total;
                    enc.Canttot = pedido.Canttot;
                    if (pedido.Descuento < 0)
                    {
                        enc.Descuento = 0;
                    }
                    else
                    {
                        enc.Descuento = pedido.Descuento;
                    }
                    enc.Impuesto1 = pedido.Impuesto1;
                    enc.Impuesto2 = pedido.Impuesto2;
                    enc.Impuesto3 = pedido.Impuesto3;
                    enc.Impuesto4 = pedido.Impuesto4;

                    var idfind = _context.Documento.Where(b => b.Uidev == enc.Uidev).FirstOrDefault();

                    // var idfind = _context.Documento.Where(b => b.Uidev == enc.Uidev).Single();

                    if (idfind is not null)
                    {

                        using (StreamWriter writer = System.IO.File.AppendText("logfile.txt"))
                        {

                            writer.WriteLine("Documento encontrado y devuelto: " + idfind.Id);
                            writer.WriteLine("");
                        }
                        return CreatedAtAction(nameof(Docto), new { id = idfind.Id });
                    }
                    else if (pedido.Idws != 0)
                    {
                        using (StreamWriter writer = System.IO.File.AppendText("logfile.txt"))
                        {

                            writer.WriteLine("Documento ya registrado se devuelve el id: " + pedido.Idws);
                            writer.WriteLine("");
                        }
                        return CreatedAtAction(nameof(Docto), new { id = pedido.Idws });
                    }
                    else
                    {
                        _context.Documento.Add(enc);

                        await _context.SaveChangesAsync();

                        int idc = enc.Id;

                        var ordenStrita = pedido.Detalles.ToList();

                        //  System.Diagnostics.Debug.WriteLine("se creo el id " + idc);
                        int part = 1;
                        foreach (var det in ordenStrita)
                        {

                            DoctoDet deta = new DoctoDet();

                            deta.Iddoc = idc;
                            deta.Partida = part;
                            deta.Cantidad = det.Cantidad;
                            deta.Cantxuv = det.Cantxuv;
                            deta.Cveart = det.Cveart;
                            deta.Descr = det.Descr;
                            deta.Precio = det.Precio;
                            deta.Totalpartida = det.Totalpartida;
                            deta.Preciou = det.Preciou;
                            deta.Apartado = det.Apartado;
                            deta.Serie = det.Serie;
                            deta.Esquema = det.Esquema;
                            deta.Univen = det.Univen;
                            deta.Tipprod = det.Tipprod;
                            deta.Tipcam = det.Tipcam;
                            deta.Desc1 = det.Desc1;
                            deta.Desc2 = det.Desc2;
                            deta.Impuesto1 = det.Impuesto1;
                            deta.Impuesto2 = det.Impuesto2;
                            deta.Impuesto3 = det.Impuesto3;
                            deta.Impuesto4 = det.Impuesto4;
                            deta.Observacion = det.Observacion;

                            _context.DocumentoDet.Add(deta);
                            await _context.SaveChangesAsync();

                            part++;

                        }
                        try
                        {
                            await _context.Database.ExecuteSqlRawAsync($"EXECUTE TRASLADO_ASAE");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("ocurrio un error al correr el procedimiento almacenado" + ex.Message);
                            using (StreamWriter writer = System.IO.File.AppendText("logfile.txt"))
                            {
                                writer.WriteLine(DateTime.Now);
                                writer.WriteLine("Error al correr procedimiento SQL: " + ex.Message);
                                writer.WriteLine("");
                            }

                            System.Diagnostics.Debug.WriteLine("Ocurrio un error " + ex.Message);
                        }
                        var param = _context.Parametros.FirstOrDefault(e => e.Id == 1);

                        if (param.Intfel != 0)
                        {

                            DatoFEL dfel = new DatoFEL();
                            dfel.Id = enc.Id;
                            dfel.Serie = GenerateRandomString(8);
                            dfel.Numero = GenerateRandomNumber(10);
                            string uuid = System.Guid.NewGuid().ToString();
                            dfel.Numeroaut = uuid.ToUpper();
                            dfel.Tipofel = "FACTURA CAMBIARIA";
                            dfel.Fechacreado = DateTime.Now;
                            dfel.Fechaaut = DateTime.Now;
                            dfel.Estado = 1;
                            dfel.Moneda = "GTQ";
                            dfel.Certificador = "INFILE";
                            dfel.Nitcert = "125200";
                            System.Diagnostics.Debug.WriteLine("Serie:: " + dfel.Serie);
                            System.Diagnostics.Debug.WriteLine("Numero:: " + dfel.Numero);

                            _context.DatoFel.Add(dfel);
                            await _context.SaveChangesAsync();
                        }
                        if (enc.Id != 0 && Serial.EnviarMail)
                        {
                            System.Diagnostics.Debug.WriteLine("Si envia el mail");
                            try
                            {
                                var registro = await _context.Documento.FindAsync(enc.Id);
                                var vendedor = await _context.Usuario.FindAsync(registro.Iduser);

                                var tipodoc = "";

                                switch (registro.Tipo)
                                {

                                    case "P":
                                        tipodoc = "PEDIDO";
                                        break;
                                    case "F":
                                        tipodoc = "FACTURA";
                                        break;
                                    case "C":
                                        tipodoc = "COTIZACION";
                                        break;
                                    default: break;
                                }

                                EmailMessage mensaje = new EmailMessage();

                                EmailAddress tomail = new EmailAddress();
                                tomail.Name = "Destino";
                                tomail.Address = Serial.CorreoDestino;

                                EmailAddress frommail = new EmailAddress();
                                frommail.Name = vendedor.Nombre;
                                frommail.Address = vendedor.Email;

                                mensaje.ToAddresses.Add(tomail);
                                mensaje.FromAddresses.Add(frommail);

                                mensaje.Subject = "Documento creado";

                                mensaje.Content = "<!DOCTYPE html><html><head>" +
                                                    "<meta charset = \"utf-8\">" +
                                                    "<title> Documento Creado </title>" +
                                                    "<link rel = \"stylesheet\" href = \"\">" +
                                                    "</head>" +
                                                    "<body>" +
                                                    "<h1 style = \"color: #5e9ca0;\"><span style = \"color: #333333;\"> Documento creado </span></h1>" +
                                                    "<h2 style = \"color: #2e6c80;\" ><span style = \"color: #333333;\" > El usuario: " + vendedor.Nombre + ", creo el siguiente documento</span></h2>" +
                                                    "<h2 style = \"color: #001a33;\" > Tipo: " + tipodoc + "</h2>" +
                                                    // "           <br>" +
                                                    "<h2 style = \"color: #001a33;\" > Registro: " + registro.Id + "</h2>" +
                                                    // "           <br>" +
                                                    "<h2 style = \"color: #001a33;\" > NIT: " + registro.Rfc + "</h2>   " +
                                                    "<h2 style = \"color: #001a33;\" > Cliente: " + registro.Nombreclie + "</h2>   " +
                                                    //             <br>" +
                                                    "<h2 style = \"color: #001a33;\" > Fecha: " + registro.Fecha + "</h2>" +
                                                    //      "      <br>" +
                                                    "<h2 style = \"color: #001a33;\" > Valor: " + registro.Total.ToString("###,###,##0.00") + " </h2>" +
                                                    "</body>" +
                                                    "</html> ";

                                Send(mensaje, vendedor.Email);
                            }
                            catch (Exception ex)
                            {
                                using (StreamWriter writer = System.IO.File.AppendText("logfile.txt"))
                                {

                                    writer.WriteLine("Ocurrio un error con el correo: " + ex.Message);
                                    writer.WriteLine("");
                                }
                                Console.WriteLine("ocurrio un error" + ex.Message);
                                System.Diagnostics.Debug.WriteLine("Ocurrio un error " + ex.Message);
                            }

                        }
                        using (StreamWriter writer = System.IO.File.AppendText("logfile.txt"))
                        {

                            writer.WriteLine("Documento creado: " + enc.Id);
                            writer.WriteLine("");
                        }
                        return CreatedAtAction(nameof(Docto), new { id = enc.Id });
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("ocurrio un error al subir un pedido: " + ex.Message);
                    using (StreamWriter writer = System.IO.File.AppendText("logfile.txt"))
                    {
                        writer.WriteLine(DateTime.Now);
                        writer.WriteLine("Error al subir un pedido: " + ex.Message);
                        writer.WriteLine("");
                    }

                    System.Diagnostics.Debug.WriteLine("Ocurrio un error " + ex.Message);
                    return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);

                }
            }
            else
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized);
            }
        }

        [HttpPost("[action]"), ActionName("subeRecibo")]
        [Obsolete]
        public async Task<ActionResult<Docto>> SubeRecibo(Recibo recibo)
        {

            var param = _context.Parametros.FirstOrDefault();
            string jsonString = JsonSerializer.Serialize(recibo);

            System.Diagnostics.Debug.WriteLine("Json recibido en recibo:  " + jsonString);

            Cobro enc = new Cobro();

            enc.Idclie = recibo.idclie;
            enc.Cliente = recibo.cliente;
            enc.Fecha = Convert.ToDateTime(recibo.fecha);
            enc.Forma = recibo.forma;
            enc.Referencia = recibo.referencia;
            enc.Forma2 = recibo.forma2;
            enc.Referencia2 = recibo.referencia2;
            enc.Bancocq = recibo.bancocq;
            enc.Bancoin = recibo.bancoin;
            enc.Total = recibo.total;
            enc.Fechaws = DateTime.Now;

            /*   Docto enc = new Docto();
               enc.Cvedoc = "";
               enc.Tipo = pedido.Tipdoc;
               enc.Idclie = pedido.Idclie;
               enc.Cliente = pedido.Cliente;
               enc.Nombreclie = pedido.Nombreclie;
               enc.Rfc = pedido.Rfc;
               enc.Fecha = Convert.ToDateTime(pedido.Fecha);
               if (pedido.Fechaen != null)
               {
                   enc.Fechaen = Convert.ToDateTime(pedido.Fechaen);
               }
               else
               {
                   enc.Fechaen = Convert.ToDateTime(pedido.Fecha);
               }
               enc.Fechaws = DateTime.Now;
               enc.Vendedor = pedido.Vendedor;
               enc.Esquema = pedido.Esquema;
               enc.Supedido = pedido.Supedido;
               enc.Condicion = pedido.Condicion;
               enc.Observacion = pedido.Observacion;
               enc.Transporte = pedido.Transporte;
               enc.Direntrega = pedido.Direntrega;
               enc.Clocation = pedido.Clocation;
               enc.Iduser = pedido.Iduser;

               enc.Total = pedido.Total;
               enc.Canttot = pedido.Canttot;
               enc.Descuento = pedido.Descuento;
               enc.Impuesto1 = pedido.Impuesto1;
               enc.Impuesto2 = pedido.Impuesto2;
               enc.Impuesto3 = pedido.Impuesto3;
               enc.Impuesto4 = pedido.Impuesto4;
            */
            _context.Cobro.Add(enc);

            await _context.SaveChangesAsync();

            int idc = enc.Id;

            var ordenStrita = recibo.detalle;

            //  System.Diagnostics.Debug.WriteLine("se creo el id " + idc);
            int part = 1;
            foreach (var det in ordenStrita)
            {

                CobroDet deta = new CobroDet();

                deta.Idr = idc;
                deta.Partida = part;
                deta.Refer = det.refer;
                deta.Fecha = Convert.ToDateTime(det.fecha);
                deta.Saldo = det.saldo;
                deta.Abono = det.abono;
                deta.Mar = det.mar;



                _context.CobroDet.Add(deta);
                await _context.SaveChangesAsync();

                part++;

            }

            try
            {
                if (param.Cintegradoa == "S")
                {
                    await _context.Database.ExecuteSqlRawAsync($"EXECUTE COBROS_ASAE");
                }
                else
                {

                    await _context.Database.ExecuteSqlRawAsync($"EXECUTE COBROS_ABANCOS");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ocurrio un error al correr el procedimiento almacenado" + ex.Message);
                using (StreamWriter writer = System.IO.File.AppendText("logfile.txt"))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.WriteLine("Error al correr procedimiento SQL: " + ex.Message);
                    writer.WriteLine("");
                }

                System.Diagnostics.Debug.WriteLine("Ocurrio un error " + ex.Message);
            }

            //   await _context.Database.ExecuteSqlRawAsync($"EXECUTE TRASLADO_ASAE");

            return CreatedAtAction(nameof(Docto), new { id = enc.Id });



        }
        [Produces("application/json")]
        [HttpGet("existencia/{id}")]
        public async Task<IActionResult> Existencia(string id)
        {
            ExistProd ep = new ExistProd();
            try
            {
                //int exist = await _context.Database.ExecuteSqlRawAsync($"EXECUTE CHECKEXIST {0}", id);
                var pId = new SqlParameter("@Id", id);
                //   var pName = new SqlParameter("@Name", name);
                var dato = await _context.Set<ExistProd>()
                         .FromSqlRaw("Execute CHECKEXIST  @Id", parameters: new[] { pId })
                        .ToArrayAsync();
                //
                //   System.Diagnostics.Debug.WriteLine("Valor: " + dato);

                //  ep.cveart = id;
                //    ep.exist = users;

                return Ok(dato);

                // await _context.Database.ExecuteSqlRawAsync($"EXECUTE COBROS_ASAE");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Ocurrio un error: " + ex.Message);

                return BadRequest();
            }
        }
        [HttpPost("[action]"), ActionName("regDispositivo")]
        public async Task<ActionResult<Dispositivo>> NuevoDispositivo(Dispositivo disp)
        {
            Dispositivo dipu = disp;

            bool hasData = _context.Dispositivo.Any(a => a.Device == dipu.Device);

            if (hasData)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status202Accepted);
            }
            else
            {

                if (Verificador.EsValido(_context))
                {

                    var param = _context.Parametros.FirstOrDefault(e => e.Id == 1);

                    Serial.Dispositivos = param.Dispositivos;

                    if (_context.Dispositivo.Count() < Serial.Dispositivos)
                    {

                        _context.Dispositivo.Add(disp);

                        await _context.SaveChangesAsync();

                        return CreatedAtAction(nameof(Cliente), new { id = disp.ID }, disp);
                    }
                    else
                    {
                        return this.StatusCode(StatusCodes.Status409Conflict, "Se llego al limite de dispositivos");

                    }

                }
                else
                {
                    return this.StatusCode(StatusCodes.Status409Conflict, "El serial ha sido alterado");
                }
            }
        }

        [HttpPost("[action]"), ActionName("nuevoCliente")]
        public async Task<ActionResult<Cliente>> NuevoCliente(Cliente cliente)
        {
            _context.Cliente.Add(cliente);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Cliente), new { id = cliente.Id }, cliente);
        }


        [HttpPost("[action]"), ActionName("fromSAE")]
        public ActionResult FromSAE(List<CxCSAE> movimientos)
        {
            string jsonString = JsonSerializer.Serialize(movimientos);

            System.Diagnostics.Debug.WriteLine("Json recibido:  " + jsonString);

            int reg = 0;
            //  CxCSAE cxxc = movimientos;
            foreach (var movs in movimientos)
            {

                System.Diagnostics.Debug.WriteLine("Desde SAE el movimiento: " + movs.Documento);
                reg++;
            }
            return Ok("Recibi " + reg + " registros");
        }

        [HttpGet("pedido/{id}")]
        public IActionResult Pedido(int id)
        {

            //  System.Diagnostics.Debug.WriteLine("si llego a la api con el numero: " + id);

            DocumentoRev doctoRev = new DocumentoRev();

            var docto = _context.Documento.Where(x => x.Id == id).FirstOrDefault();
            var doctodet = _context.DocumentoDet.Where(x => x.Iddoc == id).ToList();

            doctoRev.Encabezado = docto;
            doctoRev.Detalle = doctodet;

            var MyEntity = doctoRev;
            return Ok(MyEntity);

        }

        [HttpGet("fel/{id}")]
        public IActionResult getDataFel(int id)
        {

            //  System.Diagnostics.Debug.WriteLine("si llego a la api con el numero: " + id);

            var doctoRev = _context.DatoFel.Find(id);

            var MyEntity = doctoRev;
            return Ok(MyEntity);

        }

        [HttpGet("saldos/{id}")]
        public async Task<IActionResult> Saldos(String id)
        {

            //  System.Diagnostics.Debug.WriteLine("si llego a la api con el numero: " + id);

            string query = "SELECT * FROM (SELECT A.CVE_CLIE AS cliente,A.REFER AS refer,A.FECHA_VENC as fechav,ROUND((A.IMPORTE*A.SIGNO)+ISNULL(B.IMPORTE,0),2) AS saldo  FROM CUEN_M01 A LEFT JOIN (SELECT CVE_CLIE,REFER,ID_MOV,NUM_CARGO,ROUND(SUM(IMPORTE*SIGNO),2) AS IMPORTE " +
                           "FROM CUEN_DET01 GROUP BY CVE_CLIE,REFER,ID_MOV,NUM_CARGO) B ON B.CVE_CLIE = A.CVE_CLIE AND B.REFER = A.REFER AND B.ID_MOV = A.NUM_CPTO AND B.NUM_CARGO = A.NUM_CARGO AND A.NUM_CPTO = 1) C WHERE C.cliente != 'MOSTR' AND C.saldo > 0 AND LTRIM(RTRIM(C.cliente))=LTRIM(RTRIM('" + id + "'))";

            System.Diagnostics.Debug.WriteLine("query: " + query);
            var docto = await _aspelcontext.FactPendientes.FromSqlRaw(query).OrderBy(x => x.fechav).ToListAsync();


            return Ok(docto);

        }

        /* [HttpGet("getpdf/{id}")]
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
         }/*/


        [HttpGet("test/{id?}")]
        public IActionResult Test(int id)
        {
            if (id == 1)
            {
                try
                {
                    if (_context.Database.CanConnect())
                    {
                        return Ok("El servicio esta funcionando con normalidad");
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status503ServiceUnavailable);
                }
            }
            else
            {
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpGet("xmltest/{id?}")]
        public IActionResult XmlTest(int id)
        {
            XMLGEN xmld = new XMLGEN();

            xmld.creaEnc();

            System.Diagnostics.Debug.WriteLine("ver doct " + xmld.AsString());
            return Ok();
        }


        // GET api/values  
        [HttpGet("getimag")]
        public IActionResult getImage(string type)
        {
            Byte[] b;
            if (type == null)
            {
                return Content("Hi there is no type value given. Please enter picturefromtext or hostedimagefile in type parameter in url");
            }
            if (type.Equals("picturefromtext"))
            {
                Image image = DrawText("IMAGEN NO ENCONTRADA", new Font(FontFamily.GenericSansSerif, 15), Color.DarkBlue, Color.Cornsilk);
                b = ImageToByteArray(image);
            }
            else if (type.Equals("hostedimagefile"))
            {
                b = System.IO.File.ReadAllBytes("images\\alicate.jpg");
            }
            else
            {
                return Content("No action is defined for this type value");
            }
            return File(b, "image/jpeg");
        }

        [Produces("application/json")]
        [HttpGet("getimagelist/{codigo}")]
        public IActionResult getProdImageList(string codigo)
        {


            try
            {

                var list = _context.Images.Where(x => x.CveArt == codigo).ToList();

                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("[action]"), ActionName("crearFactura")]
        public ActionResult crearFactura(Pedido pedido)
        {
            // bool DatosGenerales = _request.Datos_generales();


            return Ok();
        }
        /*
                [HttpGet("pdf")]
                public IActionResult ExportToPDF()
                {
                    //Initialize HTML to PDF converter 
                    HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
                    WebKitConverterSettings settings = new WebKitConverterSettings();
                    //Set WebKit path
                    settings.WebKitPath = Path.Combine(_hostingEnvironment2.ContentRootPath, "QtBinariesWindows");
                    //Assign WebKit settings to HTML converter
                    htmlConverter.ConverterSettings = settings;
                    //Convert URL to PDF
                    PdfDocument document = htmlConverter.Convert("https://www.google.com");
                    MemoryStream stream = new MemoryStream();
                    document.Save(stream);
                    return File(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, "Sample.pdf");
                }*/
        /* public static Byte[] PdfSharpConvert(String html)
         {
             Byte[] res = null;
             using (MemoryStream ms = new MemoryStream())
             {
                 var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                 pdf.Save(ms);
                 res = ms.ToArray();
             }
             return res;
         }*/

        // GET api/values  
        [HttpGet("getimage/{type}")]
        public IActionResult getImagenProd(string type)
        {

            string wwwRootPath = _hostEnvironment.WebRootPath;
            Byte[] b;
            if (type == null)
            {
                return Content("No hay imagen a mostrar");
            }
            if (type.Equals("error"))
            {
                Image image = DrawText("IMAGEN NO ENCONTRADA", new Font(FontFamily.GenericSansSerif, 15), Color.DarkBlue, Color.Cornsilk);
                b = ImageToByteArray(image);
            }
            else
            {
                try
                {
                    b = System.IO.File.ReadAllBytes(wwwRootPath + "\\image\\" + type);
                }
                catch (Exception ex)
                {
                    b = System.IO.File.ReadAllBytes(wwwRootPath + "\\image\\" + "notfound.png");
                }
            }
            /*   else
               {
                   return Content("No action is defined for this type value");
               }*/
            return File(b, "image/jpeg");
        }

        public Image DrawText(String text, Font font, Color textColor, Color backColor)
        {
            //first, create a dummy bitmap just to get a graphics object  
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            //measure the string to see how big the image needs to be  
            SizeF textSize = drawing.MeasureString(text, font);

            //free up the dummy image and old graphics object  
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size  
            img = new Bitmap((int)textSize.Width, (int)textSize.Height);

            drawing = Graphics.FromImage(img);

            //paint the background  
            drawing.Clear(backColor);

            //create a brush for the text  
            Brush textBrush = new SolidBrush(textColor);

            drawing.DrawString(text, font, textBrush, 0, 0);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            return img;

        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public void Send(EmailMessage emailMessage, string correode)
        {
            var message = new MimeMessage();

            message.To.AddRange(emailMessage.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
            message.From.Add(MailboxAddress.Parse(correode));

            // System.Diagnostics.Debug.WriteLine("correo de " + correode);
            message.From.AddRange(emailMessage.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));

            message.Subject = emailMessage.Subject;
            //We will say we are sending HTML. But there are options for plaintext etc. 
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = emailMessage.Content
            };

            //Be careful that the SmtpClient class is the one from Mailkit not the framework!
            using (var emailClient = new SmtpClient())
            {

                //The last parameter here is to use SSL (Which you should!)
                emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);

                //Remove any OAuth functionality as we won't be using it. 
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                emailClient.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);

                emailClient.Send(message);

                emailClient.Disconnect(true);
            }

        }

        //[Produces("application/json")]
        [HttpGet("getjson")]
        public IActionResult getJson()
        {
            try
            {
                string text = "";
                FileStream fileStream = new FileStream("C:\\Temp\\MogiJson.txt", FileMode.Open);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line = reader.ReadLine();
                    text += line;
                }

                return Ok(text);
            }
            catch
            {

                return BadRequest();

            }
        }
        [Produces("application/json")]
        [HttpGet("cxc/{id}/{fecha?}")]
        public IActionResult getCxc(string id, string fecha)
        {
            try
            {
                if (string.IsNullOrEmpty(fecha))

                    fecha = DateTime.Now.ToString("dd/MM/yyyy");
                {
                    //
                }
                /*  using (var context = new AppDBContext())
                  {
                      var clientIdParameter = new SqlParameter("@ClientId", 4);

                      var result = context.Database
                          .SqlQuery<CxcDet>("GetResultsForCampaign @ClientId", clientIdParameter)
                          .ToList();
                  }*/
                var CXCS = _context.CXCdet.FromSqlRaw("CHECKCXC @CVE_CLIE, @FECHAC ",
              new SqlParameter("CVE_CLIE", id),
              new SqlParameter("FECHAC", fecha))
                .IgnoreQueryFilters();
                return Ok(CXCS);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("error en cxc: " + e.Message);
                return BadRequest();

            }



        }

        public String GenerateRandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var list = Enumerable.Repeat(0, length).Select(x => chars[random.Next(chars.Length)]);
            return string.Join("", list);
        }
        public String GenerateRandomNumber(int length)
        {
            var chars = "0123456789";
            var random = new Random();
            var list = Enumerable.Repeat(0, length).Select(x => chars[random.Next(chars.Length)]);
            return string.Join("", list);
        }
    }

}

