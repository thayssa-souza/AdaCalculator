using AdaCalculator;
using Moq;
using Shouldly;

namespace AdaCalculator.Tests
{
    public class UnitTest1
    {
        private CalculatorMachine _sutCalculator;
        private readonly MockRepository _mockRepository;
        private readonly Mock<ICalculator> _calculatorMock;

        public UnitTest1()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);

            _calculatorMock = _mockRepository.Create<ICalculator>();

            _sutCalculator = new CalculatorMachine(_calculatorMock.Object);
        }

        [Fact]
        public void CalculatorMachine_SummingTwoNumbersWithMocks_ShouldBeResultCorrect()
        {
            _calculatorMock.Setup(x => x.Calculate("sum", 27, -2)).Returns(("sum", 25));
            var sutResult = _sutCalculator.Calculate("sum", 27, -2);
            _calculatorMock.Verify(x => x.Calculate("sum", 27, -2), Times.Once);

            Assert.Equal(("sum", 25), sutResult);
        }

        [Theory]
        [InlineData("subtract", 21, 3, 18)]
        [InlineData("subtract", 24, -24, 48)]
        [InlineData("subtract", 2, 0, 2)]
        public void CalculatorMachine_SubtractingTwoNumbers_ShouldBeResultCorrect(string subtract, double numb1, double numb2, double result)
        {
            var sut = new CalculatorMachine();
            var resultSut = sut.Calculate(subtract, numb1, numb2);
            resultSut.ShouldBe((subtract, result));
        }

        [Fact]
        public void CalculatorMachine_DivingTwoNumbersWithMocks_ShouldBeResultCorrect()
        {
            _calculatorMock.Setup(x => x.Calculate("divide", 8, 2)).Returns(("divide", 4));
            var sutResult = _sutCalculator.Calculate("divide", 8, 2);
            _calculatorMock.Verify(x => x.Calculate("divide", 8, 2), Times.Once);
            Assert.Equal(("divide", 4), sutResult);
        }

        [Theory]
        [InlineData("multiply", 12, 0, 0)]
        [InlineData("multiply", 3.5, 2, 7)]
        [InlineData("multiply", 2, 8, 16)]
        public void CalculatorMachine_MultiplyingTwoNumbers_ShouldBeResultCorrect(string multiply, double numb1, double numb2, double result)
        {
            var sut = new CalculatorMachine();
            var resultSut = sut.Calculate(multiply, numb1, numb2);
            resultSut.ShouldBe((multiply, result));
        }
    }
}