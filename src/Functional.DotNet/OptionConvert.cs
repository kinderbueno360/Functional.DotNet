using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet
{
    public static class OptionConvert
    {
        /// <summary>
        /// Wraps an object in an Option monad.
        /// </summary>
        /// <param name="value">The object to be wrapped.</param>
        /// <returns>An Option monad with the given object value.</returns>
        public static Option<object> ToOption(this object? value) => value!;

        /// <summary>
        /// Wraps an object in an Option monad.
        /// </summary>
        /// <param name="value">The object to be wrapped.</param>
        /// <returns>An Option monad with the given object value.</returns>
        public static Option<PropertyInfo> ToOption(this PropertyInfo? value) => value!;



        /// <summary>
        /// Wraps a string in an Option monad.
        /// </summary>
        /// <param name="value">The string to be wrapped.</param>
        /// <returns>An Option monad with the given string value.</returns>
        public static Option<string> ToOption(this string value) => value;

        /// <summary>
        /// Wraps a double in an Option monad.
        /// </summary>
        /// <param name="value">The string to be wrapped.</param>
        /// <returns>An Option monad with the given string value.</returns>
        public static Option<double> ToOption(this double value) => value;


        /// <summary>
        /// Wraps a TimeSpan in an Option monad.
        /// </summary>
        /// <param name="value">The string to be wrapped.</param>
        /// <returns>An Option monad with the given string value.</returns>
        public static Option<TimeSpan> ToOption(this TimeSpan value) => value;


        /// <summary>
        /// Wraps a TimeSpan in an Option monad.
        /// </summary>
        /// <param name="value">The string to be wrapped.</param>
        /// <returns>An Option monad with the given string value.</returns>
        public static Option<byte[]> ToOption(this byte[] value) => value;


    }
}
