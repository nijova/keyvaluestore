using System;
using System.Text;

namespace KeyValueStore
{
    public static class Helpers
    {
        public static string GetDir(string Key)
        {
            var subdirs = Tuple.Create(Key.Substring(0, 2), Key.Substring(2, 2));
            return string.Format("./keyvaluestore/{0}/{1}/", subdirs.Item1, subdirs.Item2);
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
    }
}
