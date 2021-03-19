using System.IO;

namespace KeyValueStore
{
    public static class Repository
    {
        public static string GetByKey(string keyHash)
        {
            string dir = Helpers.GetDir(keyHash);
            string fileName = keyHash;
            string fullPath = dir + fileName;
            try
            {
                return File.ReadAllText(fullPath);
            }
            catch
            {
                return null;
            }
        }

        public static bool Put(string keyHash, string value)
        {
            string dir = Helpers.GetDir(keyHash);
            string fileName = keyHash;
            string fullPath = dir + fileName;
            try
            {
                File.WriteAllText(fullPath, value);
                return true;
            }
            catch (DirectoryNotFoundException)
            {
                try
                {
                    Directory.CreateDirectory(dir);
                    File.WriteAllText(fullPath, value);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool Delete(string keyHash)
        {
            string dir = Helpers.GetDir(keyHash);
            string fileName = keyHash;
            string fullPath = dir + fileName;
            try
            {
                File.Delete(fullPath);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
