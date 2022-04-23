
using SSCASPEL.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    public static class Verificador
    {

        public static bool EsValido(AppDBContext context)
        {


           // FileStream filestream = new FileStream("out.txt", FileMode.Create);
        //    var streamwriter = new StreamWriter(filestream);
         //   streamwriter.AutoFlush = true;
         //   Console.SetOut(streamwriter);
         //   Console.SetError(streamwriter);


            var param = context.Parametros.FirstOrDefault(e => e.Id == 1);

            var encode = EncDecPass.EncryptString(param.Modo + param.Dispositivos + param.Fechaexp.ToString("s"));

            // System.Diagnostics.Debug.WriteLine("fecha exp " + param.Fechaexp);
            //  System.Diagnostics.Debug.WriteLine("ahorita " + DateTime.Now);

            // var encode = EncDecPass.PEncrypt(param.Modo + param.Dispositivos + param.Fechaexp);

            // declaring key
            //    var key = "b14ca5898a4e4133bbce2ea2315a1916";

            //   var encode = HelperClass.EncryptString(key,param.Modo + param.Dispositivos + param.Fechaexp);


            //   var decript = HelperClass.DecryptString(key,param.Serial);

            // Console.WriteLine("entexto");
            //   Console.WriteLine(encode);
            //  Console.WriteLine("descriptado");
            //  Console.WriteLine(decript);

         //   System.Diagnostics.Debug.WriteLine("encriptado :" + encode);

         //   System.Diagnostics.Debug.WriteLine("descr :" + decript);

            //   var encode = EncDecPass.NEncrypt(param.Modo + param.Dispositivos + param.Fechaexp);

            // var encode = EncDecPass.ZEncrypt(param.Modo + param.Dispositivos + param.Fechaexp);

            // var encode = EncDecPass.XEncrypt(param.Modo + param.Dispositivos + param.Fechaexp);

            // var encode = EncDecPass.AEncryptString(param.Modo + param.Dispositivos + param.Fechaexp, "aXb2uy4z");

            if (param.Serial == encode)
            {

                if (param.Modo.Equals("C"))
                {
                    return true;
                }
                else if (param.Fechaexp >= DateTime.Now)
                {
                    return true;
                }
                else
                {
                   // return true;
                    return false;
                }
            }
            else
            {
               // return true;
                return false;  //se deben cambiar a esto al corregir lo de utf
            }
        }


    }
}
