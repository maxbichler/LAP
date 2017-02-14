using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace innovation4austria.logic
{
    public class Helper
    {

        public static byte[] ComputeHash(string value)
        {
            var encodePasswort = System.Security.Cryptography.SHA512.Create();
            var encoder = new System.Text.ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return encodePasswort.ComputeHash(combined);
        }


    }
}
