using cs_DllTwitch;
using System;
using System.Collections.Generic;
using System.IO;

namespace cs_TwitchConsole {
    class Program {
        static void Main(string[] args) {
            string proxyListNamae = @"socket4Proxy.txt";
            string typeProxy = @"socket4";


            DllTwitch lib = new DllTwitch();
            
            var res = lib.CheckProxys(lib.LoadProxysList(proxyListNamae), typeProxy);
            string file= string.Empty;
            foreach (var r in res)
                file += (r +"\r\n");
            File.WriteAllText("socket4Proxy.txt", file);
            Console.WriteLine("END");
            Console.ReadLine();

            var resStep1 = lib.Step1("51.38.227.203:80");
            var resStep4 = lib.Step4(resStep1, "login", "password", "chanalName", "Message");
            Console.WriteLine($"WSS");
            lib.Wss();

            Console.ReadLine();
        }
    }
}
