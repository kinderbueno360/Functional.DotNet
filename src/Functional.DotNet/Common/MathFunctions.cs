using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.DotNet.Extensions;

namespace Functional.DotNet
{
    public static class MathFunctions
    {

        public static Func<float, float, int> Add = (a, b) => Convert.ToInt32(a + b);

        public static Func<float, float, int> Subtract = (a, b) => Convert.ToInt32(a - b);

        public static Func<float, float, int> Multiply = (a, b) => Convert.ToInt32(a * b);

        public static Func<float, float, int> Divide = (a, b) => Convert.ToInt32(a / b);

        public static double ToDouble(this string value)
        {
            return value.ToOption().Map(RemoveEuroFormatting).Map(ConvertToDouble)
                .Match(() => 0.0, (Option<double> outcome) => outcome.GetOrElse(0.0));
        }

        private static Option<double> ConvertToDouble(string value) => 
            double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double result) ? ((Option<double>)result) : ((Option<double>)F.None);


        public static Func<string, string> RemoveEuroFormatting =
            (string value) =>
                value
                    .Replace(" ", "")
                    .Replace("€", "")
                    .Replace(",", ".")
                    .Trim();
    }
}
