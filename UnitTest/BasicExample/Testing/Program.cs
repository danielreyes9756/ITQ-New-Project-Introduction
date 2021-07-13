using System;
using Testing.CalculatorTest;
namespace Testing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TCalculator testCalculator = new TCalculator();
            testCalculator.OnInit();
            testCalculator.WhenAddIsCalled_ThenReturnAPlusB();
            testCalculator.WhenSetModeIsCalledWithInvalidArgument_ThenAnArgumentExceptionIsThrown();
            testCalculator.WhenSetModeIsCalledWithValidArgument_ThenGetModeIsCalled();
            testCalculator.WhenTheConstructorIsCalledWithInvalidArgument_ThenAnArgumentOutOfRangeExceptionIsThrown();
            testCalculator.WhenTheConstructorIsCalledWithNullArgument_ThenAnArgumentNullExceptionIsThrown();
        }
    }
}
