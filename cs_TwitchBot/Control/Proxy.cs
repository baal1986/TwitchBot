using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace cs_TwitchBot {
    public static class Proxy {

        //*********************************************************************************
        /// <summary>
        /// Загрузка из файла в список
        /// </summary>
        public static void UploadAllData(string fileProxies) {
            proxies = new ConcurrentBag<string>(
                                           new SortedSet<string>(
                                               File.ReadAllLines(fileProxies).ToList()));
        }
        //*********************************************************************************

        //*********************************************************************************
        public static ConcurrentBag<string> proxies;
        //*********************************************************************************
    }
}
