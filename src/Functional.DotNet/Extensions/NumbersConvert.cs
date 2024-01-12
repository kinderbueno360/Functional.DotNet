using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.Extensions
{
    using static F;
    public static class NumbersConvert
    {

        public const float MMUnityInPoints = 2.834645669291339f;

        public const float MMUnityInInch = 2.54f;

        public static int RoundOff(this int value) =>
            (int)Math.Round(value / 100000.0) * 100000;



        public static int ToIntMinus(this string value)
           => value
               .ToOption()
               .Map(ToInt)
               .Match(
                   Some: outcome => outcome.GetOrElse(-1),
                   None: () => -1
               );




        /// <summary>
        /// Converts a string to an int. Returns 0 if the string is null or cannot be converted.
        /// </summary>
        /// <param name="value">The string to be converted.</param>
        /// <returns>The converted int value, or 0 if the conversion is unsuccessful.</returns>
        public static int ToInt32(this string value)
            => value
                .ToOption()
                .Map(ToInt)
                .Match(
                    Some: outcome => outcome.GetOrElse(0),
                    None: () => 0
                );

        /// <summary>
        ///  Save way to convert to Float , if it fails the result will be 0
        /// </summary>
        /// <param name="floatValue"></param>
        /// <returns>The converted number or 0</returns>
        public static float ToFloat(this double floatValue) =>
             floatValue
                .ToOption()
                .Map(ConvertToFloat)
                .Match(
                    Some: outcome => outcome,
                    None: () => 0
                );

        /// <summary>
        /// Convert mm to point (PDF)
        /// </summary>
        /// <param name="mm">valeur float en mm</param>
        public static float MMToInch10(this int mm) =>
            mm.ConvertToFloat() / MMUnityInInch * 10;


        /// <summary>
        /// Convert mm to point (PDF)
        /// </summary>
        /// <param name="mm">valeur float en mm</param>
        public static float MMToInch10(this double mm) =>
            mm.ConvertToFloat() / MMUnityInInch * 10;


        /// <summary>
        /// Converts a string to an int. Returns 0 if the string cannot be converted.
        /// </summary>
        /// <param name="value">The string to be converted.</param>
        /// <returns>The converted int value, or 0 if the conversion is unsuccessful.</returns>
        static Option<int> ToInt(string value) =>
            int.TryParse(value, out int result)
                ? result
                : decimal.TryParse(value, out decimal resultDecimal)
                    ? Convert.ToInt32(resultDecimal)
                    : None;


        /// <summary>
        /// Converts a string to an int. Returns 0 if the string cannot be converted.
        /// </summary>
        /// <param name="value">The string to be converted.</param>
        /// <returns>The converted int value, or 0 if the conversion is unsuccessful.</returns>
        static Option<double> ConvertToDouble(string value) =>
            double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double result)
                ? result
                : None;


        /// <summary>
        /// Convert mm to inch 10
        /// </summary>
        /// <param name="mm">valeur float en mm</param>
        public static float MMToInch10(this float mm) =>
            mm / MMUnityInInch * 10;

        // 72 points = 1 inch = 25.4 mm
        // 1mm = 2.834645669291339 points
        /// <summary>
        /// Convert mm to point (PDF)
        /// </summary>
        /// <param name="mm">valeur float en mm</param>
        public static float MMToPoint(this float mm) =>
            mm * MMUnityInPoints;

        public static Option<float> Apply(this int value, Func<int, float> convertionToApplyFunc) =>
                    Some(value)
                        .Map(convertionToApplyFunc)
                        .Match(
                            Some: result => result,
                            None: () => 0
                         );

        public static int Sum(this Option<float> value, float numToAdd) =>
            value
                .Map(MathFunctions.Add)
                .Apply(numToAdd)
                .Match(
                    Some: result => result,
                    None: () => 0
                 );

        private static float ConvertToFloat(this double value) =>
            Convert.ToSingle(value);

        private static float ConvertToFloat(this int value) =>
            Convert.ToSingle(value);
    }
}
