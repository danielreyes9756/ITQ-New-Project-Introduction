using System;
using ModLib.CalculatorModule;
using NUnit.Framework;

namespace Testing.CalculatorTest
{
    public sealed class TCalculator
    {
        private CCalculator calculatorTest;
        public void OnInit()
        {
            calculatorTest = new CCalculator("prueba");
        }

        public void WhenTheConstructorIsCalledWithNullArgument_ThenAnArgumentNullExceptionIsThrown()
        {
            // Act/Assert.
            Assert.Throws<ArgumentNullException>(() => new CCalculator(null), "You can create a calculator without specific model", "model");
        }

        public void WhenTheConstructorIsCalledWithInvalidArgument_ThenAnArgumentOutOfRangeExceptionIsThrown()
        {
            // Act/Assert.
            Assert.Throws<ArgumentOutOfRangeException>(() => new CCalculator("a"), "Invalid length, at least you need 4 letters", "model");
            Assert.Throws<ArgumentOutOfRangeException>(() => new CCalculator("estomidemasdedoce"), "Invalid length, max length 12", "model");
        }

        public void WhenSetModeIsCalledWithInvalidArgument_ThenAnArgumentExceptionIsThrown()
        {
            // Act/Assert.
            Assert.Throws<ArgumentException>(() => calculatorTest.mode="a" , "This calculator had two modes (decimal or hexadecimal)", "mode");
        }
        /**
         * siguiente avance con NSubstitute
         * public void WhenGetModeIsCalledWith_ThenReturnTheMode()
         * {
         * // Act/Assert.
         * Assert.AreEqual<ArgumentException>(calculatorTest.getMode(), "This calculator had two mdoes (decimal or hexadecimal)", "mode");
         * }
        */
        public void WhenSetModeIsCalledWithValidArgument_ThenGetModeIsCalled()
        {
            // Arrange/Act/Assert.
            if (calculatorTest.mode == "decimal")
            {
                calculatorTest.mode = "hexadecimal";
                Assert.AreEqual(calculatorTest.mode, "hexadecimal", "Set and Get works", "mode");
            } else
            {
                calculatorTest.mode = "decimal";
                Assert.AreEqual(calculatorTest.mode, "decimal", "Set and Get works", "mode");
            }            
        }
        public void WhenAddIsCalled_ThenReturnAPlusB()
        {
            Assert.AreEqual(calculatorTest.Add(20, 20), 40);
            Assert.AreEqual(calculatorTest.Add(15, 1), 16);
        }
    }
}
