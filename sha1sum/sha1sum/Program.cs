using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace sha1sum
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() != 1)
            {
                Console.WriteLine("Usage: sha1sum path-to-file");
                Environment.Exit(1);
            }
            else
            {
                var path = args.First();
                var fileInfo = new FileInfo(path);
                using (var stream = fileInfo.OpenRead())
                {
                    var sha1provider = new SHA1CryptoServiceProvider();
                    var hash = sha1provider.ComputeHash(stream);
                    var sb = new StringBuilder();
                    foreach (var hashByte in hash)
                    {
                        sb.AppendFormat("{0:X2}", hashByte);
                    }
                    Console.WriteLine(sb.ToString());
                    Environment.Exit(0);
                }
            }

        }
    }
}
