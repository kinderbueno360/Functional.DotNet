using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.Monad
{
    public delegate (T, S) State<S, T>(S state);
    public static class StateMonad
    {
        // Return a state monad from a value
        public static State<S, T> Return<S, T>(T value)
            => s => (value, s);

        // Bind (Monad)
        public static State<S, U> Bind<S, T, U>(this State<S, T> stateFunc, Func<T, State<S, U>> func)
            => initialState =>
            {
                var (value, newState) = stateFunc(initialState);
                return func(value)(newState);
            };

        // Map (Functor)
        public static State<S, U> Map<S, T, U>(this State<S, T> stateFunc, Func<T, U> mapper)
            => Bind(stateFunc, t => Return<S, U>(mapper(t)));



        // LINQ 

        public static State<S, U> Select<S, T, U>(this State<S, T> stateFunc, Func<T, U> selector)
            => stateFunc.Map(selector);


        public static State<S, V> SelectMany<S, T, U, V>(
            this State<S, T> stateFunc,
            Func<T, State<S, U>> selector,
            Func<T, U, V> resultSelector)
            => s =>
            {
                var (value, newState) = stateFunc(s);
                var (newValue, newNewState) = selector(value)(newState);
                return (resultSelector(value, newValue), newNewState);
            };

    }
}
