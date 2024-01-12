using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.Tests
{
    public class IdentityTests
    {
        
        // Test for IdentityExt.Map
        [Fact]
        public void IdentityExt_Map_AppliesFunctionToValue()
        {
            Identity<int> identity = F.Identity(10);
            Func<int, string> intToString = x => x.ToString();

            var result = identity.Map(intToString);

            Assert.Equal("10", result());
        }

        // Test for IdentityExt.Bind
        [Fact]
        public void IdentityExt_Bind_BindsFunctionToValue()
        {
            Identity<int> identity = F.Identity(10);
            Func<int, Identity<string>> intToString = x => () => x.ToString();

            var result = identity.Bind(intToString);

            Assert.Equal("10", result());
        }
    }
}
