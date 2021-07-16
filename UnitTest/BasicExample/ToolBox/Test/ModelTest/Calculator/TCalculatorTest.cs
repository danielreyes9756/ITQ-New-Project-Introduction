using System;
using NSubstitute;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Calculator;
using Model.Calculator.Add;
using Model.Calculator.Substract;
using Model.Calculator.Multiply;
using Model.Calculator.Divide;
using Model.Calculator.Rest;
using Model.Calculator.Even;
using Model.Calculator.Squart;

namespace ModelTest.Calculator
{
    [TestClass]
    public sealed class TCalculatorTest
    {
        private ICalculator calculatorTest;
        //Solo se mockea las clases que tienen referencias vía constructor de otra interfaz
        IAdd mockAdd;
        ISubstract mockSub;
        IMultiply mockMul;
        IDivide mockDiv;
        IRest mockRest;
        IEven mockEven;
        ISquart mockSqrt;

        [TestInitialize]
        public void OnInit()
        {
            mockAdd = Substitute.For<IAdd>();
            mockSub = Substitute.For<ISubstract>();
            mockMul = Substitute.For<IMultiply>();
            mockDiv = Substitute.For<IDivide>();
            mockRest = Substitute.For<IRest>();
            mockEven = Substitute.For<IEven>();
            mockSqrt = Substitute.For<ISquart>();
            calculatorTest = new CCalculator("prueba", mockAdd, mockSub, mockMul, mockDiv, mockRest, mockSqrt, mockEven);
            
        }

        [TestMethod]
        public void WhenTheConstructorIsCalledWithNullArguments_ThenAnArgumentNullExceptionIsThrown()
        {
            // Asserts.
            Assert.ThrowsException<ArgumentNullException>(
                () => new CCalculator(null, mockAdd, mockSub, mockMul, mockDiv, mockRest, mockSqrt, mockEven), 
                "You can create a calculator without specific Model", "Model");

            Assert.ThrowsException<ArgumentNullException>(
                () => new CCalculator("prueba", null, mockSub, mockMul, mockDiv, mockRest, mockSqrt, mockEven), 
                "You can create a calculator without Add propertie", "mockAdd");

            Assert.ThrowsException<ArgumentNullException>(
                () => new CCalculator("prueba", mockAdd, null, mockMul, mockDiv, mockRest, mockSqrt, mockEven),
                "You can create a calculator without Substract propertie", "mockSub");

            Assert.ThrowsException<ArgumentNullException>(
                () => new CCalculator("prueba", mockAdd, mockSub, null, mockDiv, mockRest, mockSqrt, mockEven),
                "You can create a calculator without Multiply propertie", "mockMul");

            Assert.ThrowsException<ArgumentNullException>(
                () => new CCalculator("prueba", mockAdd, mockSub, mockMul, null, mockRest, mockSqrt, mockEven),
                "You can create a calculator without Divide propertie", "mockDiv");

            Assert.ThrowsException<ArgumentNullException>(
                () => new CCalculator("prueba", mockAdd, mockSub, mockMul, mockDiv, null, mockSqrt, mockEven),
                "You can create a calculator without Rest propertie", "mockRest");

            Assert.ThrowsException<ArgumentNullException>(
                () => new CCalculator("prueba", mockAdd, mockSub, mockMul, mockDiv, mockRest, null, mockEven),
                "You can create a calculator without Squart propertie", "mockSqrt");

            Assert.ThrowsException<ArgumentNullException>(
                () => new CCalculator("prueba", mockAdd, mockSub, mockMul, mockDiv, mockRest, mockSqrt, null),
                "You can create a calculator without Even propertie", "mockEven");
        }

        [TestMethod]
        public void WhenTheConstructorIsCalledWithInvalidRangeArguments_ThenAnArgumentOutOfRangeExceptionIsThrown()
        {
            // Asserts.
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new CCalculator("a", mockAdd, mockSub, mockMul, mockDiv, mockRest, mockSqrt, mockEven), "Invalid length, at least you need 4 letters", "Model");

            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new CCalculator("estomidemasdedoce", mockAdd, mockSub, mockMul, mockDiv, mockRest, mockSqrt, mockEven), "Invalid length, max length 12", "Model");
        }

        [TestMethod]
        public void WhenTheConstructorIsCalledWithValidArgument_ThenAnCalculatorIsGenerated()
        {
            // Act.
            ICalculator constructorTestEquals = new CCalculator("prueba", mockAdd, mockSub, mockMul, mockDiv, mockRest, mockSqrt, mockEven);
            // Assert.
            Assert.IsTrue(constructorTestEquals.Equals(calculatorTest));

            // Act.
            ICalculator constructorTestNoneEquals = new CCalculator("mensaje", mockAdd, mockSub, mockMul, mockDiv, mockRest, mockSqrt, mockEven);
            
            // Assert.
            Assert.IsFalse(constructorTestNoneEquals.Equals(calculatorTest));
            
            // or
            
            // Assert.
            Assert.AreEqual(constructorTestEquals.Model, calculatorTest.Model);
            Assert.AreEqual(constructorTestEquals.Mode, calculatorTest.Mode);

            Assert.AreNotEqual(constructorTestNoneEquals.Model, calculatorTest.Model);
            Assert.AreEqual(constructorTestNoneEquals.Mode, calculatorTest.Mode);
        }

        [TestMethod]
        public void WhenSetModeIsCalledWithInvalidArgument_ThenAnArgumentNullExceptionIsThrown()
        {
            // Assert.
            Assert.ThrowsException<ArgumentNullException>(() => calculatorTest.Mode = null, "You can chage to null Mode", "value");
        }

        [TestMethod]
        public void WhenSetModeIsCalledWithInvalidArgument_ThenAnArgumentOutOfRangeExceptionIsThrown()
        {
            // Assert.
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => calculatorTest.Mode = "prueba", "This calculator had two modes (decimal or hexadecimal)", "value");
        }

        [TestMethod]
        public void WhenSetModeIsCalledWithValidArgument_ThenAnGetModeIsThrown()
        {
            // Act.
            calculatorTest.Mode = "hexadecimal";

            // Assert.
            Assert.AreEqual(calculatorTest.Mode, "hexadecimal");

            // Act
            calculatorTest.Mode = "DecImaL";

            // Assert.
            Assert.AreEqual(calculatorTest.Mode, "decimal");
        }

        [TestMethod]
        public void WhenSetModelIsCalledWithInvalidArgument_ThenAnArgumentNullExceptionIsThrown()
        {
            // Assert.
            Assert.ThrowsException<ArgumentNullException>(() => calculatorTest.Model = null, "Model can't be null", "value");
        }

        [TestMethod]
        public void WhenSetModelIsCalledWithInvalidArgument_ThenAnArgumentOutOfRangeExceptionIsThrown()
        {
            // Assert.
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => calculatorTest.Model = "3", "Incompatible Model length, less than 4", "value");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => calculatorTest.Model = "estomidemasdedoce", "Incompatible Model length, greater than 12", "value");
        }

        [TestMethod]
        public void WhenSetModelIsCalledWithValidArgument_ThenAnGetModelIsThrown()
        {
            // Act.
            calculatorTest.Model = "tested";

            // Assert.
            Assert.AreEqual(calculatorTest.Model, "tested");
        }

        [TestMethod]
        public void WhenAddFunctionIsCalled_ThenReturnAPlusB()
        {
            // Act.
            mockAdd.Add(1,2).Returns(3);
            int actualValue = calculatorTest.AddFunction(1, 2);
            mockAdd.Received(1).Add(1, 2);

            // Assert.
            Assert.AreEqual(actualValue, 3);

            // or using class CAdd
            Assert.AreEqual(actualValue, new CAdd().Add(1,2));
        }

        [TestMethod]
        public void WhenSubstractFunctionIsCalled_ThenReturnAMinusB()
        {
            // Act.
            mockSub.Substract(2, 1).Returns(1);
            int actualValue = calculatorTest.SubstractFunction(2, 1);
            mockSub.Received(1).Substract(2, 1);

            // Assert.
            Assert.AreEqual(actualValue, 1);

            // or using class CSubstact
            Assert.AreEqual(actualValue, new CSubstract().Substract(2, 1));
        }

        [TestMethod]
        public void WhenMultiplyFunctionIsCalled_ThenReturnAMultipliedByB()
        {
            // Act.
            mockMul.Multiply(2, 2).Returns(4);
            int actualValue = calculatorTest.MultiplyFunction(2, 2);
            mockMul.Received(1).Multiply(2, 2);

            // Assert.
            Assert.AreEqual(actualValue, 4);

            // or using class CSubstact
            Assert.AreEqual(actualValue, new CMultiply().Multiply(2, 2));
        }
        
        [TestMethod]
        public void WhenDivideFunctionIsCalledWithInvalidYArgument_ThenAnArgumentOutOfRangeExceptionIsThrown()
        {
            // Act/Assert.
            mockDiv.When(x=> x.Divide(Arg.Any<int>(), Arg.Is(0))).Do(x => throw new ArgumentOutOfRangeException("Argument Y can't be zero", "Y"));

            // or using the class

            // Assert.
            mockDiv.When(x => x.Divide(7, 29)).Do(x => throw new ArgumentOutOfRangeException("Y"));
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => mockDiv.Divide(7, 29), "Argument Y can't be greater than X in this calculator", "Y");
        }
        

        [TestMethod]
        public void WhenDivideFunctionIsCalledWithValidArguments_ThenReturnsXDividedByY()
        {
            // Act.
            mockDiv.Divide(10, 2).Returns(5);
            int actualValue = calculatorTest.DivideFunction(10, 2);
            mockDiv.Received(1).Divide(10, 2);

            // Assert.
            Assert.AreEqual(actualValue, 5);

            // or using class CSubstact
            Assert.AreEqual(actualValue, new CDivide().Divide(10, 2));
        }

        [TestMethod]
        public void WhenEvenFunctionIsCalledWithValidArguments_ThenReturnsTrueIfEvenFalseIfNot()
        {
            // Act.
            mockEven.Even(3).Returns(true);
            bool actualValue = calculatorTest.EvenFunction(3);
            mockEven.Received(1).Even(3);

            // Assert.
            Assert.IsTrue(actualValue);

            // Act.
            mockEven.Even(6).Returns(false);
            actualValue = calculatorTest.EvenFunction(6);
            mockEven.Received(2).Even(Arg.Any<int>());

            // Assert.
            Assert.IsFalse(actualValue);

        }
        
        [TestMethod]
        public void WhenRestFunctionIsCalledWithInvalidYArgument_ThenAnArgumentOutOfRangeExceptionIsThrown()
        {
            // Act/Assert.
            mockRest.When(x => x.Rest(Arg.Any<int>(), Arg.Is(0))).Do(x => throw new ArgumentOutOfRangeException("Argument Y can't be zero", "Y"));

            // mockRest.When(x => x.Rest(Arg.Any<int>(), Arg.Any<int>())).Do(x => throw new ArgumentOutOfRangeException("Argument Y can't be zero", "Y"));
            mockRest.When(x => x.Rest(7, 29)).Do(x => throw new ArgumentOutOfRangeException("Y"));
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => mockRest.Rest(7, 29), "Argument Y can't be greater than X in this calculator", "Y");
        }
        

        [TestMethod]
        public void WhenRestFunctionIsCalledWithValidArguments_ThenReturnsRestOfXAndY()
        {
            // Act.
            mockRest.Rest(10, 2).Returns(0);
            int actualValue = calculatorTest.RestFunction(10, 2);
            mockRest.Received(1).Rest(10, 2);

            // Assert.
            Assert.AreEqual(actualValue, 0);


            // Act.
            mockRest.Rest(9, 2).Returns(1);
            actualValue = calculatorTest.RestFunction(9,2);
            mockRest.Received(1).Rest(9, 2);

            // Assert.
            Assert.AreEqual(actualValue, 1);

        }

        [TestMethod]
        public void WhenSquartFunctionIsCalled_ThenReturnsSquartOfX()
        {
            // Act.
            mockSqrt.Squart(4).Returns(2);
            double actualValue = calculatorTest.SquartFunction(4);
            mockSqrt.Received(1).Squart(4);

            // Assert.
            Assert.AreEqual(actualValue, 2);
        }

    }
}
