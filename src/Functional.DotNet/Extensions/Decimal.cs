using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Functional.DotNet.F;

namespace Functional.DotNet.Extensions
{
    public static class Decimal
    {
        public static Option<decimal> Parse(string s)
        {
            decimal result;
            return decimal.TryParse(s, out result)
               ? Some(result) : None;
        }

        public static bool IsOdd(decimal i) => i % 2 == 1;

        public static bool IsEven(decimal i) => i % 2 == 0;

        public static new Func<decimal, string> ToString = d => d.ToString();
    }
}
