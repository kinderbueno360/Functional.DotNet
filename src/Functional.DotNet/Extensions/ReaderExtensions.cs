using Functional.DotNet.Monad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.Extensions
{
    public static class ReaderExtensions
    {
        public static Reader<Env, (T, U)> Zip<Env, T, U>(
            this Reader<Env, T> first, Reader<Env, U> second)
            => env => (first(env), second(env));

        public static Reader<Env, List<T>> Sequence<Env, T>(
            this IEnumerable<Reader<Env, T>> readers)
            => env => readers.Select(reader => reader(env)).ToList();
    }
}
