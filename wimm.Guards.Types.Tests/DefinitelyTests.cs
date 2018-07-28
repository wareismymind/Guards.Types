using System;
using Xunit;

namespace wimm.Guards.Types.Tests
{
    public class DefinitelyTests
    {
        [Fact]
        public void Construct_NullValue_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Definitely<string> unused = null;
            });
        }

        [Fact]
        public void Construct_NonNullValue_Constructs()
        {
            Definitely<string> underTest = "Test";
        }

        [Fact]
        public void AccessValue_ValueConstructed_ReturnsValue()
        {
            var val = "Test";
            Definitely<string> underTest = val;

            Assert.Equal(val, (string)underTest);
        }

        [Fact]
        public void AccessValue_DefaultConstructed_Throws()
        {
            var arr = new Definitely<string>[1];

            Assert.Throws<InvalidOperationException>(() =>
            {
                var _ = arr[0].Value;
            });

        }

    }
}
