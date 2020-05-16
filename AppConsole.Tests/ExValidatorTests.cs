using System;
using Xunit;
using AppConsole;

namespace AppConsole.Tests
{
    public class ExValidatorTests
    {
        [Theory]
        [InlineData("([])(){}")]
        [InlineData("()")]
        public void TestValidExpressions(String inputExpression)
        {
            Assert.True(ExValidator.Valid(inputExpression), "Should be Valid Expression");
            Assert.True(ExValidator.Valid(inputExpression), "Should be Valid Expression");
        }

        [Theory]
        [InlineData("([)(){}")]
        [InlineData("([){}")]
        [InlineData("()()(}{}")]
        public void TestInvalidExpressions(String inputExpression)
        {
            Assert.False(ExValidator.Valid(inputExpression), "Should be Invalid Expression");
            Assert.False(ExValidator.Valid(inputExpression), "Should be Invalid Expression");
        }
    }
}
