using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.MonadStacks
{
    using static F;

    public static class TaskValidationMonad
    {


        public static Task<Validation<U>> Select<T, U>
           (this Task<Validation<T>> self
           , Func<T, U> mapper)
           => self.Map(x => x.Map(mapper));

        // Task<Validation<T>> `bind` T -> Task<Validation<R>>

        public static Task<Validation<R>> SelectMany<T, R>
           (this Task<Validation<T>> task       // Task<Validation<T>> 
           , Func<T, Task<Validation<R>>> bind) // -> (T -> Task<Validation<R>>)
           => task.Bind(vt => vt.TraverseBind(bind));

        public static Task<Validation<RR>> SelectMany<T, R, RR>
           (this Task<Validation<T>> task       // Task<Validation<T>> 
           , Func<T, Task<Validation<R>>> bind  // -> (T -> Task<Validation<R>>)
           , Func<T, R, RR> project)
           => task
              .Map(vt => vt.TraverseBind(t => bind(t).Map(vr => vr.Map(r => project(t, r)))))
              .Unwrap();
    }
}
