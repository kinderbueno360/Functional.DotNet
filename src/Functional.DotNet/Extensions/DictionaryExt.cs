using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.Extensions
{
    using static F;

    public static class DictionaryExt
    {
        public static Option<T> Lookup<K, T>(this IDictionary<K, T> dict, K key)
           => dict.TryGetValue(key, out T? value) 
                    ? Some(value) 
                    : None;
    }
}
