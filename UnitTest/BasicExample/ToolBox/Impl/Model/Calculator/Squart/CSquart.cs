using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Calculator.Squart
{
    public class CSquart : ISquart
    {
        public CSquart() { }
        public double Squart(int X) 
        {
            return Math.Sqrt(X);
        }
    }
}
