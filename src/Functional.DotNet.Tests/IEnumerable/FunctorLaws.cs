using FsCheck.Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.Tests.MonadStacks
{
    using static F;
    using static Assert;

    public class IEnumerable_FunctorLaws
    {
        [Property]
        public void FirstFunctorLawHolds(string s)
        {
            var a = List(s);
            var b = a.Map(x => x);
            Equal(a, b);
        }

        [Property]
        public void SecondFunctorLawHolds(int input)
        {
            Func<int, int> f = i => i - 2;
            Func<int, int> g = i => i * 50;

            var a = List(input).Map(f).Map(g);
            var b = List(input).Map(x => g(f(x)));

            Equal(a, b);
        }
    }
}
