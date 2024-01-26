using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.Extensions
{
    using static F;

    public static class EnumExt
    {
        public static Option<T> Parse<T>(this string s) where T : struct
           => Enum.TryParse(s, out T t)
                ? Some(t)
                : None;
    }
}
