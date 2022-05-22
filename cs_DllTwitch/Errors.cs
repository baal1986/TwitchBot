using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_DllTwitch {
    public static class Errors {
        public static ConcurrentBag<string> errors = new ConcurrentBag<string>();
    }
}
