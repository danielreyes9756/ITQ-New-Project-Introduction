namespace ModLib.CalculatorModule
{
    public interface ICalculator
    {
        int Add(int a, int b);
        string mode { get; set; }
        
    }
}
