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
                Save(mx);
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

        public static void Save(string s)
        {
            string folder = @"./level1/level2/";
            string fileName = "filehausen";
            string fullPath = folder + fileName;
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            File.WriteAllLines(fullPath, new List<string> { s });
        }
    }
}
