using System;
using Xunit;

namespace wimm.Guards.Types.Tests
{
    public class VisibleString_Test
    {
        [Fact]
        public void Construct_NullValue_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                VisibleString _ = null;
            });
        }

        [Fact]
        public void AccessValue_DefaultConstructed_ThrowsOnAccess()
        {
            var arr = new VisibleString[1];

            Assert.Throws<InvalidOperationException>(() =>
            {
                string _ = arr[0];
            });
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("\t")]
        [InlineData("\n")]
        [InlineData("\r\n")]
        public void Construct_WhiteSpaceCombinations_Throws(string value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                VisibleString _ = value;
            });
        }
    }
}
