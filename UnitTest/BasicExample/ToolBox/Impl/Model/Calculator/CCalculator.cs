using Model.Calculator.Add;
using Model.Calculator.Substract;
using Model.Calculator.Divide;
using Model.Calculator.Multiply;
using Model.Calculator.Rest;
using Model.Calculator.Squart;
using Model.Calculator.Even;
using System;

namespace Model.Calculator
{
    public class CCalculator : ICalculator
    {
        private readonly IAdd Add;
        private readonly ISubstract Sub;
        private readonly IMultiply Mul;
        private readonly IDivide Div;
        private readonly IRest Rest;
        private readonly ISquart Sqrt;
        private readonly IEven Even;
        private string _Model;
        private string _Mode;
        public CCalculator(string Model, IAdd Add, ISubstract Sub, IMultiply Mul, IDivide Div, IRest Rest, ISquart Sqrt, IEven Even)
        {
            // Also we can use function NameOf to take the variable name
            if (Model == null) throw new ArgumentNullException("Model");
            if (Model.Length < 4) throw new ArgumentOutOfRangeException("Model");
            if (Model.Length > 12) throw new ArgumentOutOfRangeException("Model");
            this.Add = Add ?? throw new ArgumentNullException("Add");
            this.Sub = Sub ?? throw new ArgumentNullException("Sub");
            this.Mul = Mul ?? throw new ArgumentNullException("Mul");
            this.Div = Div ?? throw new ArgumentNullException("Div");
            this.Rest = Rest ?? throw new ArgumentNullException("Rest");
            this.Sqrt = Sqrt ?? throw new ArgumentNullException("Sqrt");
            this.Even = Even ?? throw new ArgumentNullException("Even");
            _Model = Model;
            _Mode = "decimal"; //default value
            
        }
        public string Mode 
        { 
            get => _Mode;
            set 
            {
                if (value == null) throw new ArgumentNullException("value");
                if (value.ToLower() != "decimal" && value.ToLower() != "hexadecimal") throw new ArgumentOutOfRangeException("value");
                _Mode = value.ToLower();
            } 
        }
        public string Model 
        { 
            get =>  _Model;
            set
            {
                if (value == null) throw new ArgumentNullException("Value");
                if (value.Length < 4) throw new ArgumentOutOfRangeException("Value");
                if (value.Length > 12) throw new ArgumentOutOfRangeException("Value");
                _Model = value;
            }
        }

        public int AddFunction(int X, int Y)
        {
            return Add.Add(X, Y);
        }

        public int DivideFunction(int X, int Y)
        {
            //IDivide divide;
            return Div.Divide(X,Y);
        }

        public bool Equals(ICalculator calculator)
        {
            return (Model == calculator.Model && calculator.Mode == Mode);
        }

        public bool EvenFunction(int X)
        {
            return Even.Even(X);
        }

        public int MultiplyFunction(int X, int Y)
        {
            return Mul.Multiply(X, Y);
        }

        public int RestFunction(int X, int Y)
        {
            return Rest.Rest(X, Y);
        }

        public double SquartFunction(int X)
        {
            return Sqrt.Squart(X);
        }

        public int SubstractFunction(int X, int Y)
        {
            return Sub.Substract(X, Y);
        }
    }
}