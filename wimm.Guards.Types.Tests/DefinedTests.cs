using System;
using Xunit;

namespace wimm.Guards.Types.Tests
{
    public class DefinedTests
    {
        [Fact]
        public void Construct_ValueUndefined_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Defined<TestValues> _ = (TestValues)int.MaxValue;
            });
        }

        [Fact]
        public void Construct_ValueDefined_Constructs()
        {
            Defined<TestValues> _ = TestValues.First;
        }

        [Fact]
        public void AccessValue_DefaultConstructed_Throws()
        {
            var arr = new Defined<TestValues>[1];

            Assert.Throws<InvalidOperationException>(() =>
            {
                TestValues a = arr[0];
            });
        }

        [Fact]
        public void AccessValue_ValueConstructed_GetsValue()
        {
            Defined<TestValues> val = TestValues.First;
        }

        private enum TestValues
        {
            First
        }

    }
}
