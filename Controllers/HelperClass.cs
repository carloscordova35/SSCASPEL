using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SSCASPEL.Controllers
{
    public class HelperClass
    {

        public static char Mid(string param, int startIndex, int length)
        {
            Char result = Convert.ToChar(param.Substring(startIndex, length));
            return result;
        }
        public static string Decrypt(string icText)
        {
            int icLen;
            string icNewText = "";
            char icChar;
            //icChar = '' ;
            icLen = icText.Length;
            for (int i = 0; i <= icLen - 1; i++)
            {
                icChar = Mid(icText, i, 1);
                switch (Strings.AscW(icChar))
                {
                    case object _ when 192 <= Strings.AscW(icChar) && Strings.AscW(icChar) <= 217:
                        {
                            icChar = Strings.ChrW(Strings.AscW(icChar) - 127);
                            break;
                        }

                    case object _ when 218 <= Strings.AscW(icChar) && Strings.AscW(icChar) <= 243:
                        {
                            icChar = Strings.ChrW(Strings.AscW(icChar) - 121);
                            break;
                        }

                    case object _ when 244 <= Strings.AscW(icChar) && Strings.AscW(icChar) <= 253:
                        {
                            icChar = Strings.ChrW(Strings.AscW(icChar) - 196);
                            break;
                        }

                    case 32:
                        {
                            icChar = Strings.ChrW(32);
                            break;
                        }
                }
                icNewText = icNewText + icChar;
            }
            // icNewText = Microsoft.VisualBasic.StrReverse(icNewText);
            return (icNewText);
        }
        public static string Encrypt(string icText)
        {
            int icLen;
            string icNewText = "";
            char icChar;
            icLen = icText.Length;
            for (int i = 1; i <= icLen; i++)
            {
                icChar = Mid(icText, i, 1);
                switch (Strings.AscW(icChar))
                {
                    case object _ when 65 <= Strings.AscW(icChar) && Strings.AscW(icChar) <= 90:
                        {
                            icChar = Strings.ChrW(Strings.AscW(icChar) + 127);
                            break;
                        }

                    case object _ when 97 <= Strings.AscW(icChar) && Strings.AscW(icChar) <= 122:
                        {
                            icChar = Strings.ChrW(Strings.AscW(icChar) + 121);
                            break;
                        }

                    case object _ when 48 <= Strings.AscW(icChar) && Strings.AscW(icChar) <= 57:
                        {
                            icChar = Strings.ChrW(Strings.AscW(icChar) + 196);
                            break;
                        }

                    case 32:
                        {
                            icChar = Strings.ChrW(32);
                            break;
                        }
                }
                icNewText = icNewText + icChar;
            }
            return (icNewText);
        }

        public static string ReplaceFirstOccurrence(string Source, string Find, string Replace)
        {
            string result = "";
            int Place = Source.IndexOf(Find);
            if (Place != -1)
            {
                result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            }
            else
            {
                result = Source;
            }
            return result;
        }

        public static string SQLString(string sStrings, Boolean Trim = true)
        {
            //Get
            //{

            if (Trim)
            {
                if (sStrings != null && sStrings.Trim() != "")
                    return ReplaceFirstOccurrence(sStrings.Trim(), "'", "''");
                else
                    return "";
            }
            else if (sStrings.Trim() != "")
                return ReplaceFirstOccurrence(sStrings, "'", "''");
            else
                return "";
            //}
        }

        public static string EncryptString(string key, string plainInput)
        {
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainInput);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

    }
}
