using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_TwitchBot {
    public static class Accounts {
        public static ConcurrentBag<string> accounts = new ConcurrentBag<string>();
    }
}
