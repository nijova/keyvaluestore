using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace KeyValueStore
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            while(true)
            {
                var x = Console.ReadLine();
                var mx = CreateMD5(x);
                Save(mx, mx);
                Console.WriteLine(mx);
            }
        }

        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static void Save(string key, string value)
        {
            string dir = string.Format("./keyvaluestore/{0}/{1}/", key.Substring(0,2), key.Substring(2,2));
            string fileName = key;
            string fullPath = dir + fileName;
            try
            {
                File.WriteAllText(fullPath, value + Environment.NewLine);
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(dir);
                File.WriteAllText(fullPath, value + Environment.NewLine);
            }
        }
    }
}
