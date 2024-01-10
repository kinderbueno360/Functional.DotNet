using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.Tests.IEnumerable
{
    public class Partition
    {
        [Fact]
        public void Test_Partition()
        {
            var nums = Enumerable.Range(0, 10);
            var (even, odd) = nums.Partition(i => i % 2 == 0);

            Assert.Equal(new int[] { 0, 2, 4, 6, 8 }, even);
            Assert.Equal(new int[] { 1, 3, 5, 7, 9 }, odd);
        }
    }
}
