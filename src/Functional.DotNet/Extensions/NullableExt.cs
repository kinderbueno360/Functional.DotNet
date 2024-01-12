using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.Extensions
{
    using static F;

    public static class NullableExt
    {
        public static Option<T> ToOption<T>(this Nullable<T> @this) where T : struct
           => @this.HasValue 
                ? Some(@this.Value) 
                : None;
    }
}
