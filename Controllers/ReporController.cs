using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SSCASPEL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace SSCASPEL.Controllers
{
    public class ReporController : Controller
    {

        private readonly IWebHostEnvironment _hostEnvironment;
        readonly IGeneratePdf _generatePdf;

        public AppDBContext _context;

        public ReporController(IWebHostEnvironment hostEnvironment, AppDBContext master, IGeneratePdf generatePdf)
        {
            _context = master;
            this._hostEnvironment = hostEnvironment;
            _generatePdf = generatePdf;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DoctoPDF(int id)
        {
            DocumentoRev doctoRev = new DocumentoRev();

            var docto = _context.Documento.Where(x => x.Id == id).FirstOrDefault();

            var doctodet = _context.DocumentoDet.Where(x => x.Iddoc == id).ToList();

            List<DoctoDet2> doctodet2 = new List<DoctoDet2>();

            var param = _context.Parametros.Where(x => x.Id == 1).FirstOrDefault();

            string pathd = Request.GetDisplayUrl();

            int indexof = pathd.IndexOf("repor");

            pathd = pathd.Substring(0, indexof) + "image/";

            System.Diagnostics.Debug.WriteLine("direccion: " + pathd);

            foreach (var it in doctodet)
            {
                DoctoDet2 dt2 = new DoctoDet2();
                var imagg = _context.Images.FirstOrDefault(x => x.CveArt == it.Cveart);
                dt2.Apartado = it.Apartado;
                dt2.Cantidad = it.Cantidad;
                dt2.Cantxuv = it.Cantxuv;
                dt2.Cveart = it.Cveart;
                dt2.Desc1 = it.Desc1;
                dt2.Desc2 = it.Desc2;
                dt2.Descr = it.Descr;
                dt2.Esquema = it.Esquema;
                dt2.Id = it.Id;
                dt2.Iddoc = it.Iddoc;
                if (imagg != null)
                {
                    dt2.Imagename = pathd + imagg.ImageName;
                }
                else
                {
                    dt2.Imagename = "";
                }
                dt2.Impuesto1 = it.Impuesto1;
                dt2.Impuesto2 = it.Impuesto2;
                dt2.Impuesto3 = it.Impuesto3;
                dt2.Impuesto4 = it.Impuesto4;
                dt2.Lote = it.Lote;
                dt2.Observacion = it.Observacion;
                dt2.Partida = it.Partida;
                dt2.Politica = it.Politica;
                dt2.Precio = it.Precio;
                dt2.Preciou = it.Preciou;
                dt2.Serie = it.Serie;
                dt2.Tipcam = it.Tipcam;
                dt2.Tipprod = it.Tipprod;
                dt2.Totalpartida = it.Totalpartida;
                dt2.Univen = it.Univen;
                doctodet2.Add(dt2);
            }
            doctoRev.imagepath = pathd + "logo.png";
            doctoRev.Param = param;
            doctoRev.Encabezado = docto;
            doctoRev.Detalle2 = doctodet2;

            return View(doctoRev);
        }

        public async Task<IActionResult> DoctoToPDF(int id)
        {
            DocumentoRev doctoRev = new DocumentoRev();

            var docto = _context.Documento.Where(x => x.Id == id).FirstOrDefault();

            var doctodet = _context.DocumentoDet.Where(x => x.Iddoc == id).ToList();

            var param = _context.Parametros.Where(x => x.Id == 1).FirstOrDefault();

            List<DoctoDet2> doctodet2 = new List<DoctoDet2>();

            string pathd = Request.GetDisplayUrl();

            int indexof = pathd.IndexOf("repor");

            pathd = pathd.Substring(0, indexof) + "image/";

            System.Diagnostics.Debug.WriteLine("direccion: " + pathd);

            foreach (var it in doctodet)
            {
                DoctoDet2 dt2 = new DoctoDet2();
                var imagg = _context.Images.FirstOrDefault(x => x.CveArt == it.Cveart);
                dt2.Apartado = it.Apartado;
                dt2.Cantidad = it.Cantidad;
                dt2.Cantxuv = it.Cantxuv;
                dt2.Cveart = it.Cveart;
                dt2.Desc1 = it.Desc1;
                dt2.Desc2 = it.Desc2;
                dt2.Descr = it.Descr;
                dt2.Esquema = it.Esquema;
                dt2.Id = it.Id;
                dt2.Iddoc = it.Iddoc;
                if (imagg != null)
                {
                    dt2.Imagename = pathd + imagg.ImageName;
                }
                else
                {
                    dt2.Imagename = "";
                }
                dt2.Impuesto1 = it.Impuesto1;
                dt2.Impuesto2 = it.Impuesto2;
                dt2.Impuesto3 = it.Impuesto3;
                dt2.Impuesto4 = it.Impuesto4;
                dt2.Lote = it.Lote;
                dt2.Observacion = it.Observacion;
                dt2.Partida = it.Partida;
                dt2.Politica = it.Politica;
                dt2.Precio = it.Precio;
                dt2.Preciou = it.Preciou;
                dt2.Serie = it.Serie;
                dt2.Tipcam = it.Tipcam;
                dt2.Tipprod = it.Tipprod;
                dt2.Totalpartida = it.Totalpartida;
                dt2.Univen = it.Univen;
                doctodet2.Add(dt2);
            }
            doctoRev.imagepath = pathd + "logo.png";
            doctoRev.Param = param;
            doctoRev.Encabezado = docto;
            doctoRev.Detalle2 = doctodet2;


            //return View(docto);
            return await _generatePdf.GetPdf("Views/Repor/DoctoPDF.cshtml", doctoRev);
        }



        public IActionResult EstadoCuentaV(int id, string fechaf)
        {
            ClieCXC cxc = new ClieCXC();

            cxc = retDataCxc(id, fechaf);
            return View(cxc);
        }
        public async Task<IActionResult> EstadoCuenta(int id, string fechaf)
        {

            ClieCXC cxc = new ClieCXC();

            cxc = retDataCxc(id, fechaf);
            // return View(cxc);

            return await _generatePdf.GetPdf("Views/Repor/EstadoCuentaV.cshtml", cxc);

            // System.IO.File.WriteAllBytes("testHard.pdf",await _generatePdf.GetPdf("Views/Repor/EstadoCuentaV.cshtml", cxc));
            //  return Ok();

        }

        public ClieCXC retDataCxc(int id, string fechaf)
        {

            ClieCXC cxc = new ClieCXC();

            var cliente = _context.Cliente.Where(x => x.Id == id).FirstOrDefault();
            var param = _context.Parametros.Where(x => x.Id == 1).FirstOrDefault();

            if (cliente == null)
            {
                cliente.Nombre = "CLIENTE NO ENCONTRADO";
            }


            System.Diagnostics.Debug.WriteLine("Hola: " + fechaf);

            System.Diagnostics.Debug.WriteLine("id sae: " + cliente.Idsae);

            string pathd = Request.GetDisplayUrl();

            int indexof = pathd.IndexOf("repor");

            pathd = pathd.Substring(0, indexof) + "image/";

            cxc.imagepath = pathd + "logo.png";
            cxc.Param = param;
            cxc.cliente = cliente;
            // cxc.fechac = fechaf;
            try
            {
                if (string.IsNullOrEmpty(fechaf))
                {
                    fechaf = DateTime.Now.ToString("dd/MM/yyyy");

                    //
                }
                else
                {

                    DateTime myDate = DateTime.ParseExact(fechaf, "yyyy-MM-dd",
                                        System.Globalization.CultureInfo.InvariantCulture);
                    fechaf = myDate.ToString();
                }
                /*  using (var context = new AppDBContext())
                  {
                      var clientIdParameter = new SqlParameter("@ClientId", 4);

                      var result = context.Database
                          .SqlQuery<CxcDet>("GetResultsForCampaign @ClientId", clientIdParameter)
                          .ToList();
                  }*/
                var CXCS = _context.CXCdet.FromSqlRaw("CHECKCXC @CVE_CLIE, @FECHAC",
              new SqlParameter("CVE_CLIE", cliente.Idsae),
              new SqlParameter("FECHAC", fechaf))
                .IgnoreQueryFilters();

                double saldo = 0;
                //   if (CXCS.Any() == true)
                //   {
                foreach (CxcDet c in CXCS)
                {
                    cxc.detalle.Add(c);
                    saldo += c.saldo;
                }
                //    }
                //   else {
                if (cxc.detalle.Count == 0)
                {
                    CxcDet d1 = new CxcDet();
                    d1.refer = "NO TIENE DOCUMENTOS PENDIENTES DE SALDO";
                    cxc.detalle.Add(d1);
                }

                cxc.cliente.Saldo = saldo;
                cxc.fechac = fechaf;
                //     }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ocurrio un error:" + e.Message);
            }
            return cxc;
        }

        public IActionResult UltVentas(int id, string fechai, string fechaf)
        {
            ClieMovsInve cmvi = new ClieMovsInve();
             cmvi = retDataMovs(id, fechai,fechaf);
            return View(cmvi);
        }

        public async Task<IActionResult> UltimasVentas(int id, string fechai, string fechaf)
        {

            ClieMovsInve cmi = new ClieMovsInve();

            cmi = retDataMovs(id, fechai, fechaf);
            // return View(cxc);

            return await _generatePdf.GetPdf("Views/Repor/UltVentas.cshtml", cmi);

            // System.IO.File.WriteAllBytes("testHard.pdf",await _generatePdf.GetPdf("Views/Repor/EstadoCuentaV.cshtml", cxc));
            //  return Ok();

        }

        public ClieMovsInve retDataMovs(int id, string fechai, string fechaf)
        {
            ClieMovsInve cmvi = new ClieMovsInve();

            var cliente = _context.Cliente.Where(x => x.Id == id).FirstOrDefault();
            var param = _context.Parametros.Where(x => x.Id == 1).FirstOrDefault();

            if (cliente == null)
            {
                cliente.Nombre = "CLIENTE NO ENCONTRADO";
            }


            System.Diagnostics.Debug.WriteLine("fechai: " + fechai);
            System.Diagnostics.Debug.WriteLine("fechaf: " + fechaf);

            System.Diagnostics.Debug.WriteLine("id sae: " + cliente.Idsae);

            string pathd = Request.GetDisplayUrl();

            int indexof = pathd.IndexOf("repor");

            pathd = pathd.Substring(0, indexof) + "image/";

            cmvi.imagepath = pathd + "logo.png";
            cmvi.Param = param;
            cmvi.cliente = cliente;
            // cxc.fechac = fechaf;
            try
            {
                if (string.IsNullOrEmpty(fechai))
                {
                    int year = DateTime.Now.Year;
                    DateTime firstDay = new DateTime(year, 1, 1);
                    fechai = firstDay.ToString("dd/MM/yyyy");

                    //
                }
                else
                {

                    DateTime myDate = DateTime.ParseExact(fechai, "yyyy-MM-dd",
                                        System.Globalization.CultureInfo.InvariantCulture);
                    fechai = myDate.ToString();
                }
                if (string.IsNullOrEmpty(fechaf))
                {
                    fechaf = DateTime.Now.ToString("dd/MM/yyyy");

                    //
                }
                else
                {

                    DateTime myDate = DateTime.ParseExact(fechaf, "yyyy-MM-dd",
                                        System.Globalization.CultureInfo.InvariantCulture);
                    fechaf = myDate.ToString();
                }

                var CMovs = _context.MovsDet.FromSqlRaw("CHECKVENTAS @CVE_CLIE, @FECHA1, @FECHA2",
              new SqlParameter("CVE_CLIE", cliente.Idsae),
              new SqlParameter("FECHA1", fechai),
              new SqlParameter("FECHA2", fechaf))
                .IgnoreQueryFilters();

                //  double saldo = 0;
                //   if (CXCS.Any() == true)
                //   {
                foreach (MovsDet c in CMovs)
                {
                    System.Diagnostics.Debug.WriteLine("producto: " + c.descr);
                    cmvi.detalle.Add(c);
                }
                //    }
                //   else {
                if (cmvi.detalle.Count == 0)
                {
                    MovsDet d1 = new MovsDet();
                    d1.descr = "NO HAY VENTAS NO REGISTRADAS";
                    cmvi.detalle.Add(d1);
                }
                cmvi.fechai = fechai;
                cmvi.fechac = fechaf;
                //     }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ocurrio un error:" + e.Message);
            }
            return cmvi;
        }

    }


}
