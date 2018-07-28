using System;
using System.Collections.Generic;
using Xunit;

namespace wimm.Guards.Types.Tests
{
    public class ExtensionTests
    {
        [Fact]
        public void ToDefinitely_NullObject_Throws()
        {
            var input = null as IEnumerable<string>;
            Assert.Throws<ArgumentNullException>(() => input.ToDefinitely());
        }

        [Fact]
        public void ToDefinitely_ValidInterface_ReturnValueRefEqualsInput()
        {
            var input = new List<string> { "Doot" } as IEnumerable<string>;
            var res = input.ToDefinitely();

            Assert.Same(input, res.Value);
        }

        [Fact]
        public void ToDefinitely_ValidClass_ReturnValueRefEqualsInput()
        {
            var input = new List<string> { "DootDoot " };
            var res = input.ToDefinitely();

            Assert.Same(input, res.Value);
        }

    }


}
