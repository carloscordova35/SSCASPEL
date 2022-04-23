using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    public class Pedido
    {

        public int Id { get; set; }
        public int Idws { get; set; }
        public string Cvedoc { get; set; }
        public string Tipdoc { get; set; }
        public string Serie { get; set; }
        public string Cliente { get; set; }
        public int Idclie { get; set; }
        public string Fecha { get; set; }
        public string Fechaen { get; set; }
        public string Vendedor { get; set; }
        public int Esquema { get; set; }
        public string Supedido { get; set; }
        public string Condicion { get; set; }
        public double Canttot { get; set; }
        public double Impuesto1 { get; set; }
        public double Impuesto2 { get; set; }
        public double Impuesto3 { get; set; }
        public double Impuesto4 { get; set; }
        public double Descuento { get; set; }
        public double Total { get; set; }
        public string Rfc { get; set; }
        public string Ensistema { get; set; }
        public string Fechasub { get; set; }
        public string Observacion { get; set; }
        public string Nombreclie { get; set; }
        public string Dirclie { get; set; }
        public string Clocation { get; set; }
        public string Transporte { get; set; }
        public string Direntrega { get; set; }
        public int Iduser { get; set; }
        public int Noalmacen { get; set; }
        public string Uidev { get; set; }
        public string Enviadesde { get; set; }
        public List<PedidoDet> Detalles { get; set; }

        public double getTotal()
        {
            return Math.Round(Total);
        }

        public Pedido()
        {
            Detalles = new List<PedidoDet>();
        }

        public bool EsCorrecto()
        {
            if (Cliente != null && Fecha != null)
            {
                return true;
            }
            return false;
        }

    }
}
