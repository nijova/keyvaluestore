using System;

namespace KeyValueStore
{
    public static class Helpers
    {
        public static string GetDir(string Key)
        {
            var subdirs = Tuple.Create(Key.Substring(0, 2), Key.Substring(2, 2));
            return string.Format("./keyvaluestore/{0}/{1}/", subdirs.Item1, subdirs.Item2);
        }
    }
}
