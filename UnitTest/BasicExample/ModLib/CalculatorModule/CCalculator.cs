using System;

namespace ModLib.CalculatorModule
{
    public class CCalculator : ICalculator
    {
        public string model { get; set; } 
        private string _mode;
        public CCalculator(string model) 
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            if (model.Length < 4)
            {
                throw new ArgumentOutOfRangeException("model");
            }
            if (model.Length > 12)
            {
                throw new ArgumentOutOfRangeException("model");
            }
            this.model = model;
            _mode = "decimal";
        }

        public string mode
        {

            get
            {
                return _mode;
            }
            set
            {
                if (value.ToLower() != "decimal" && value.ToLower() != "hexadecimal")
                {
                    throw new ArgumentException("mode");
                }
                _mode = value;
            }
        }

        public int Add(int a, int b)
        {
            return a+b;
        }
    }
}
