using Functional.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.MonadStacks
{
    using static Functional.DotNet.F;
    using Functional.DotNet;

    public static class TaskResultMonad
    {
        public static Task<Result<R>> TraverseBind<T, R>(this Result<T> @this
         , Func<T, Task<Result<R>>> func)
         => @this.Match(
               Fail: error => Async(Result.Error<R>(error.Message)),
               Success: t => func(t.Data)
            );
    }
}
