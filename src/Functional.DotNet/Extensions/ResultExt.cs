using Functional.DotNet.Monad;
using Functional.DotNet.MonadStacks;

namespace Functional.DotNet
{
    public static class ResultExt
    {

        public static Task<Result<U>> Select<T, U>
         (this Task<Result<T>> self
         , Func<T, U> mapper)
         => self.Map(x => x.Map(mapper));

        

        public static Task<Result<R>> SelectMany<T, R>
           (this Task<Result<T>> task       
           , Func<T, Task<Result<R>>> bind) 
           => task.Bind(vt => vt.TraverseBind(bind));

        public static Task<Result<RR>> SelectMany<T, R, RR>
           (this Task<Result<T>> task       
           , Func<T, Task<Result<R>>> bind  
           , Func<T, R, RR> project)
           => task
              .Map(vt => vt.TraverseBind(t => bind(t).Map(vr => vr.Map(r => project(t, r)))))
              .Unwrap();

        public static Result<R> Map<T, R>
          (this Result<T> @this, Func<T, R> f)
          => @this.Match
          (
             Success: t => Result.Success(f(t.Data)),
             Fail: errs => Result.Error<R>(errs.Message)
          );

        public static R Match<T, R>
              (this Result<T> @this, Func<Result<T>, R> Fail, Func<Result<T>, R> Success)
              => @this.Success ? Success(@this) : Fail(@this);
    }
}
