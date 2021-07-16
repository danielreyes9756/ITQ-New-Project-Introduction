using System;

namespace Model.Calculator.Rest
{
    public class CRest : IRest
    {
        public CRest() { }
        public int Rest(int X, int Y)
        {
            if (Y == 0) throw new ArgumentOutOfRangeException("Y");
            if (Y > X) throw new ArgumentOutOfRangeException("Y");
            return X % Y;
        }
    }
}
