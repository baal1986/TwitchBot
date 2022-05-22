using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace cs_TwitchBot {
    public static class LoginsPasswords {

        //*********************************************************************************
        /// <summary>
        /// Загрузка из файла в список
        /// </summary>
        public static async void UploadAllData(string fileNameLoginsPasswords) {

            listLoginsPasswords = new ConcurrentBag<string>(
                                            new SortedSet<string>(
                                                File.ReadAllLines(fileNameLoginsPasswords).ToList()));
        }
        //*********************************************************************************

        //*********************************************************************************
        public static ConcurrentBag<string> listLoginsPasswords;
        //*********************************************************************************
    }
}
