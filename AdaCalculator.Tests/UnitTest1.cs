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

        [Theory]
        [InlineData("sum", 44, 46, 100)]
        [InlineData("sum", 12.4, 2.1, 14.5)]
        [InlineData("sum", -2, 3, 1)]
        public void CalculatorMachine_SummingTwoNumbers_ShouldBeResult(string sum, double numb1, double numb2, double result)
        {
           _calculatorMock.Setup(x => x.Calculate(sum, numb1, numb2)).Returns((sum, result));
           var sutResult = _sutCalculator.Calculate(sum, numb1, numb2);
           _calculatorMock.Verify(x => x.Calculate(sum, numb1, numb2), Times.Once);
        }

        [Theory]
        [InlineData("subtract", 21, 3, 18)]
        [InlineData("subtract", 24, -24, 48)]
        [InlineData("subtract", 2, 0, 2)]
        public void CalculatorMachine_SubtractingTwoNumbers_ShouldBeResult(string subtract, double numb1, double numb2, double result)
        {
            var sut = new CalculatorMachine();
            var resultSut = sut.Calculate(subtract, numb1, numb2);
            resultSut.ShouldBe((subtract, result));
        }

        [Theory]
        [InlineData("divide", 15, 3, 5)]
        [InlineData("divide", 5, 2, 2.5)]
        [InlineData("divide", 12, 1, 12)]
        public void CalculatorMachine_DivingTwoNumbers_ShouldBeResult(string divide, double numb1, double numb2, double result)
        {
            _calculatorMock.Setup(x => x.Calculate(divide, numb1, numb2)).Returns((divide, result));
            var sutResult = _sutCalculator.Calculate(divide, numb1, numb2);
            _calculatorMock.Verify(x => x.Calculate(divide, numb1, numb2), Times.Once);
        }

        [Theory]
        [InlineData("multiply", 12, 0, 0)]
        [InlineData("multiply", 3.5, 2, 7)]
        [InlineData("multiply", 2, 8, 16)]
        public void CalculatorMachine_MultiplyingTwoNumbers_ShouldBeResult(string multiply, double numb1, double numb2, double result)
        {
            var sut = new CalculatorMachine();
            var resultSut = sut.Calculate(multiply, numb1, numb2);
            resultSut.ShouldBe((multiply, result));
        }
    }
}