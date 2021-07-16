namespace Model.Calculator.Even
{
    public class CEven : IEven
    {
        public CEven() { }
        public bool Even(int X)
        {
            return X % 2 != 0;
        }
    }
}
