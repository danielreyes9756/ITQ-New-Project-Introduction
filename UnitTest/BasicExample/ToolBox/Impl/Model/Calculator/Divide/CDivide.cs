using System;

namespace Model.Calculator.Divide
{
    public class CDivide : IDivide
    {
        public CDivide() { }
        public int Divide(int X, int Y)
        {
            if (Y == 0) throw new ArgumentOutOfRangeException("Y");
            if (Y > X) throw new ArgumentOutOfRangeException("Y");
            return X / Y;
        }
    }
}
