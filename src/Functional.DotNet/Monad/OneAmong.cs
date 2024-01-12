using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.Monad
{
    /// <summary>
    /// Represents a discriminated union that can hold a value of one among two possible types.
    /// </summary>
    /// <typeparam name="T0">The type of the first possible value.</typeparam>
    /// <typeparam name="T1">The type of the second possible value.</typeparam>
    public class OneAmong<T0, T1>
    {
        private object _value;
        private int _index;

        /// <summary>
        /// Creates an instance of OneAmong holding a value of type T0.
        /// </summary>
        /// <param name="value">The value of type T0.</param>
        public OneAmong(T0 value) { _value = value; _index = 0; }

        /// <summary>
        /// Creates an instance of OneAmong holding a value of type T1.
        /// </summary>
        /// <param name="value">The value of type T1.</param>
        public OneAmong(T1 value) { _value = value; _index = 1; }

        /// <summary>
        /// Performs a pattern matching operation on the OneAmong instance.
        /// </summary>
        /// <typeparam name="TResult">The return type of the match functions.</typeparam>
        /// <param name="matchFunc0">The function to execute if the value is of type T0.</param>
        /// <param name="matchFunc1">The function to execute if the value is of type T1.</param>
        /// <returns>The result of the executed function.</returns>
        public TResult Match<TResult>(
            Func<T0, TResult> matchFunc0,
            Func<T1, TResult> matchFunc1)
        {
            return _index switch
            {
                0 => matchFunc0((T0)_value),
                1 => matchFunc1((T1)_value),
                _ => throw new InvalidOperationException("Invalid OneAmong type")
            };
        }

        /// <summary>
        /// Transforms the value in OneAmong instance if it is of type T0.
        /// </summary>
        /// <typeparam name="TResult">The type to which to transform the value.</typeparam>
        /// <param name="mapFunc">The transform function.</param>
        /// <returns>A new OneAmong instance with the transformed value.</returns>
        public OneAmong<TResult, T1> Map<TResult>(Func<T0, TResult> mapFunc)
        {
            return _index == 0 ? new OneAmong<TResult, T1>(mapFunc((T0)_value)) : new OneAmong<TResult, T1>((T1)_value);
        }

        /// <summary>
        /// Applies a function that returns a OneAmong to the value if it is of type T0.
        /// </summary>
        /// <typeparam name="TResult">The type of the value in the returned OneAmong.</typeparam>
        /// <param name="bindFunc">The function to apply.</param>
        /// <returns>The result of applying the function.</returns>
        public OneAmong<TResult, T1> Bind<TResult>(Func<T0, OneAmong<TResult, T1>> bindFunc)
        {
            return _index == 0 ? bindFunc((T0)_value) : new OneAmong<TResult, T1>((T1)_value);
        }

        /// <summary>
        /// Filters the OneAmong instance based on a predicate if the value is of type T0.
        /// </summary>
        /// <param name="predicate">The predicate to apply.</param>
        /// <returns>The original OneAmong if the predicate is true, otherwise a default value.</returns>
        public OneAmong<T0, T1> Where(Func<T0, bool> predicate)
        {
            return _index == 0 && predicate((T0)_value) ? this : new OneAmong<T0, T1>((T1)_value);
        }

        /// <summary>
        /// Transforms the value in the OneAmong instance using a selector function if the value is of type T0.
        /// </summary>
        /// <typeparam name="TSelectResult">The type of the result after applying the selector function.</typeparam>
        /// <param name="selectFunc">The selector function to apply.</param>
        /// <returns>A new OneAmong instance with the selected value.</returns>
        public OneAmong<TSelectResult, T1> Select<TSelectResult>(Func<T0, TSelectResult> selectFunc)
        {
            return Map(selectFunc);
        }

        /// <summary>
        /// Projects each element of a OneAmong into a new form.
        /// </summary>
        /// <typeparam name="TBindResult">The type of the intermediate result.</typeparam>
        /// <typeparam name="TSelectManyResult">The type of the final result.</typeparam>
        /// <param name="bindFunc">A function to apply to each element.</param>
        /// <param name="selectManyFunc">A function to transform the final result.</param>
        /// <returns>A new OneAmong instance with the final selected value.</returns>
        public OneAmong<TSelectManyResult, T1> SelectMany<TBindResult, TSelectManyResult>(
            Func<T0, OneAmong<TBindResult, T1>> bindFunc,
            Func<T0, TBindResult, TSelectManyResult> selectManyFunc)
        {
            return _index == 0 ? bindFunc((T0)_value).Map(b => selectManyFunc((T0)_value, b)) : new OneAmong<TSelectManyResult, T1>((T1)_value);
        }
    }


    public class OneAmong<T0, T1, T2>
    {
        private object _value;
        private int _index;

        public OneAmong(T0 value) { _value = value; _index = 0; }
        public OneAmong(T1 value) { _value = value; _index = 1; }
        public OneAmong(T2 value) { _value = value; _index = 2; }

        public TResult Match<TResult>(
            Func<T0, TResult> matchFunc0,
            Func<T1, TResult> matchFunc1,
            Func<T2, TResult> matchFunc2)
        {
            return _index switch
            {
                0 => matchFunc0((T0)_value),
                1 => matchFunc1((T1)_value),
                2 => matchFunc2((T2)_value),
                _ => throw new InvalidOperationException("Invalid OneAmong type")
            };
        }

        public OneAmong<TResult, T1, T2> Map<TResult>(Func<T0, TResult> mapFunc)
        {
            return _index switch
            {
                0 => new OneAmong<TResult, T1, T2>(mapFunc((T0)_value)),
                1 => new OneAmong<TResult, T1, T2>((T1)_value),
                2 => new OneAmong<TResult, T1, T2>((T2)_value),
                _ => throw new InvalidOperationException("Invalid OneAmong type")
            };
        }

        public OneAmong<TResult, T1, T2> Bind<TResult>(Func<T0, OneAmong<TResult, T1, T2>> bindFunc)
        {
            return _index switch
            {
                0 => bindFunc((T0)_value),
                1 => new OneAmong<TResult, T1, T2>((T1)_value),
                2 => new OneAmong<TResult, T1, T2>((T2)_value),
                _ => throw new InvalidOperationException("Invalid OneAmong type")
            };
        }

        public OneAmong<TResult, T1, T2> Select<TResult>(Func<T0, TResult> mapFunc)
        {
            return _index switch
            {
                0 => new OneAmong<TResult, T1, T2>(mapFunc((T0)_value)),
                1 => new OneAmong<TResult, T1, T2>((T1)_value),
                2 => new OneAmong<TResult, T1, T2>((T2)_value),
                _ => throw new InvalidOperationException("Invalid OneAmong type")
            };
        }

        public OneAmong<TResult, T1, T2> SelectMany<TResult>(Func<T0, OneAmong<TResult, T1, T2>> mapFunc)
        {
            return Bind(mapFunc);
        }
    }

    public class OneAmong<T0, T1, T2, T3>
    {
        private object _value;
        private int _index;

        public OneAmong(T0 value) { _value = value; _index = 0; }
        public OneAmong(T1 value) { _value = value; _index = 1; }
        public OneAmong(T2 value) { _value = value; _index = 2; }
        public OneAmong(T3 value) { _value = value; _index = 3; }

        public TResult Match<TResult>(
            Func<T0, TResult> matchFunc0,
            Func<T1, TResult> matchFunc1,
            Func<T2, TResult> matchFunc2,
            Func<T3, TResult> matchFunc3)
        {
            return _index switch
            {
                0 => matchFunc0((T0)_value),
                1 => matchFunc1((T1)_value),
                2 => matchFunc2((T2)_value),
                3 => matchFunc3((T3)_value),
                _ => throw new InvalidOperationException("Invalid OneAmong type")
            };
        }

        public OneAmong<TResult, T1, T2, T3> Map<TResult>(Func<T0, TResult> mapFunc)
        {
            return _index switch
            {
                0 => new OneAmong<TResult, T1, T2, T3>(mapFunc((T0)_value)),
                1 => new OneAmong<TResult, T1, T2, T3>((T1)_value),
                2 => new OneAmong<TResult, T1, T2, T3>((T2)_value),
                3 => new OneAmong<TResult, T1, T2, T3>((T3)_value),
                _ => throw new InvalidOperationException("Invalid OneAmong type")
            };
        }

        public OneAmong<TResult, T1, T2, T3> Bind<TResult>(Func<T0, OneAmong<TResult, T1, T2, T3>> bindFunc)
        {
            return _index switch
            {
                0 => bindFunc((T0)_value),
                1 => new OneAmong<TResult, T1, T2, T3>((T1)_value),
                2 => new OneAmong<TResult, T1, T2, T3>((T2)_value),
                3 => new OneAmong<TResult, T1, T2, T3>((T3)_value),
                _ => throw new InvalidOperationException("Invalid OneAmong type")
            };
        }

        public OneAmong<TResult, T1, T2, T3> Select<TResult>(Func<T0, TResult> mapFunc)
        {
            return _index switch
            {
                0 => new OneAmong<TResult, T1, T2, T3>(mapFunc((T0)_value)),
                1 => new OneAmong<TResult, T1, T2, T3>((T1)_value),
                2 => new OneAmong<TResult, T1, T2, T3>((T2)_value),
                3 => new OneAmong<TResult, T1, T2, T3>((T3)_value),
                _ => throw new InvalidOperationException("Invalid OneAmong type")
            };
        }

        public OneAmong<TResult, T1, T2, T3> SelectMany<TResult>(Func<T0, OneAmong<TResult, T1, T2, T3>> mapFunc)
        {
            return Bind(mapFunc);
        }
    }

    public class OneAmong<T0, T1, T2, T3, T4>
    {
        private object _value;
        private int _index;

        public OneAmong(T0 value) { _value = value; _index = 0; }
        public OneAmong(T1 value) { _value = value; _index = 1; }
        public OneAmong(T2 value) { _value = value; _index = 2; }
        public OneAmong(T3 value) { _value = value; _index = 3; }
        public OneAmong(T4 value) { _value = value; _index = 4; }

        public TResult Match<TResult>(
            Func<T0, TResult> matchFunc0,
            Func<T1, TResult> matchFunc1,
            Func<T2, TResult> matchFunc2,
            Func<T3, TResult> matchFunc3,
            Func<T4, TResult> matchFunc4)
        {
            return _index switch
            {
                0 => matchFunc0((T0)_value),
                1 => matchFunc1((T1)_value),
                2 => matchFunc2((T2)_value),
                3 => matchFunc3((T3)_value),
                4 => matchFunc4((T4)_value),
                _ => throw new InvalidOperationException("Invalid OneAmong type")
            };
        }

        public OneAmong<TResult, T1, T2, T3, T4> Map<TResult>(Func<T0, TResult> mapFunc)
        {
            return _index switch
            {
                0 => new OneAmong<TResult, T1, T2, T3, T4>(mapFunc((T0)_value)),
                1 => new OneAmong<TResult, T1, T2, T3, T4>((T1)_value),
                2 => new OneAmong<TResult, T1, T2, T3, T4>((T2)_value),
                3 => new OneAmong<TResult, T1, T2, T3, T4>((T3)_value),
                4 => new OneAmong<TResult, T1, T2, T3, T4>((T4)_value),
                _ => throw new InvalidOperationException("Invalid OneAmong type")
            };
        }

        public OneAmong<TResult, T1, T2, T3, T4> Bind<TResult>(Func<T0, OneAmong<TResult, T1, T2, T3, T4>> bindFunc)
        {
            return _index switch
            {
                0 => bindFunc((T0)_value),
                1 => new OneAmong<TResult, T1, T2, T3, T4>((T1)_value),
                2 => new OneAmong<TResult, T1, T2, T3, T4>((T2)_value),
                3 => new OneAmong<TResult, T1, T2, T3, T4>((T3)_value),
                4 => new OneAmong<TResult, T1, T2, T3, T4>((T4)_value),
                _ => throw new InvalidOperationException("Invalid OneAmong type")
            };
        }

        public OneAmong<TResult, T1, T2, T3, T4> Select<TResult>(Func<T0, TResult> mapFunc)
        {
            return _index switch
            {
                0 => new OneAmong<TResult, T1, T2, T3, T4>(mapFunc((T0)_value)),
                1 => new OneAmong<TResult, T1, T2, T3, T4>((T1)_value),
                2 => new OneAmong<TResult, T1, T2, T3, T4>((T2)_value),
                3 => new OneAmong<TResult, T1, T2, T3, T4>((T3)_value),
                4 => new OneAmong<TResult, T1, T2, T3, T4>((T4)_value),
                _ => throw new InvalidOperationException("Invalid OneAmong type")
            };
        }

        public OneAmong<TResult, T1, T2, T3, T4> SelectMany<TResult>(Func<T0, OneAmong<TResult, T1, T2, T3, T4>> mapFunc)
        {
            return Bind(mapFunc);
        }
    }

}
