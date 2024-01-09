using Functional.DotNet.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet
{
    public static class NumberEx
    {

        public static Number Where
            (this Number number, Func<Number, bool> predicate) =>
                number.Match(
                    () => Number.None,
                    (t) => predicate(t) ? number : Number.None)
                        .GetOrElse(Number.None);

        public static Number Select(this Number @this, Func<decimal, Number> func)
            => @this.Match(
                    () => Number.None,
                    (t) => func(t))
                        .GetOrElse(Number.None);

    }
}
