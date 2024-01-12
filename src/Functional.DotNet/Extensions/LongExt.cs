using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.Extensions
{
    using static F;

    public static class Long
    {
        public static Option<long> Parse(string s) =>
             long.TryParse(s, out long result)
               ? Some(result)
               : None;

    }
}
