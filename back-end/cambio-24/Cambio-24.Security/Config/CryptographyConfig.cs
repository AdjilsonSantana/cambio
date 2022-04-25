using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Security.Config
{
    public static class CryptographyConfig
    {
        public static int Interations = 2;
        public static int KeySize = 256;
        public static string Hash = "SHA1";
        public static string Salt = "aselrias38490a32";
        public static string Vector = "8947az34awl34kjq";
        public static string Password = "secret";
       
    }
}
