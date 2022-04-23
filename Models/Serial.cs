using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    public static class Serial
    {
        public static string Codigo { get; set; }
        public static int Dispositivos { get; set; }
        public static string apiBaseUrl { get; set; }
        public static bool EnviarMail { get; set; }
        public static string CorreoDestino { get; set; }
    }
}
