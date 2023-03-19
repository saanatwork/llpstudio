using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace llpstudio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //string data = "0x4173a363cBAE216285A4E0447d8757623b8eDC3d";
            //string keys = "g0M1/LeqBj9B9WqI2kTCg80eyzCQyPgPWeuICYnbXoU=";
            //string ss=Encrypt(data,keys);
            //string dd=Decrypt(ss,keys);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public string Decrypt(string cipherText, string key)
        //{
        //    byte[] initializationVector = Encoding.ASCII.GetBytes("abcede0123456789");
        //    byte[] buffer = Convert.FromBase64String(cipherText);
        //    using (Aes aes = Aes.Create())
        //    {
        //        //aes.Key = Encoding.UTF8.GetBytes(key);
        //        //aes.IV = initializationVector;
        //        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        //        using (var memoryStream = new MemoryStream(buffer))
        //        {
        //            using (var cryptoStream = new CryptoStream(memoryStream as Stream, decryptor, CryptoStreamMode.Read))
        //            {
        //                using (var streamReader = new StreamReader(cryptoStream as Stream))
        //                {
        //                    return streamReader.ReadToEnd();
        //                }
        //            }
        //        }
        //    }
        //}

        //public string Encrypt(string data, string key)
        //{
        //    byte[] initializationVector = Encoding.ASCII.GetBytes("abcede0123456789");
            
        //    using (Aes aes = Aes.Create())
        //    {
        //       // aes.Key = Encoding.UTF8.GetBytes(key);
        //       // aes.IV = initializationVector;
        //        var symmetricEncryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            using (var cryptoStream = new CryptoStream(memoryStream as Stream,symmetricEncryptor, CryptoStreamMode.Write))
        //            {
        //                using (var streamWriter = new StreamWriter(cryptoStream as Stream))
        //                {
        //                    streamWriter.Write(data);
        //                }
        //                return Convert.ToBase64String(memoryStream.ToArray());
        //            }
        //        }
        //    }
        //}
    }
}