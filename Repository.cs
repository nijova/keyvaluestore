using System;
using System.IO;

namespace KeyValueStore
{
    public static class Repository
    {

        public static void GetByKey(string key)
        {

        }

        public static void Put(string keyHash, string value)
        {
            string dir = Helpers.GetDir(keyHash);
            string fileName = keyHash;
            string fullPath = dir + fileName;
            string fullValue = value + Environment.NewLine;
            try
            {
                File.WriteAllText(fullPath, fullValue);
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(dir);
                File.WriteAllText(fullPath, fullValue);
            }
        }

        public static void Delete(string key)
        {

        }
    }
}
