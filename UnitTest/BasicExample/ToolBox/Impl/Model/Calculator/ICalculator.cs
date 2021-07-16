namespace Model.Calculator
{
    public interface ICalculator
    {
        int AddFunction(int X, int Y);
        int SubstractFunction(int X, int Y);
        int MultiplyFunction(int X, int Y);
        int DivideFunction(int X, int Y);
        int RestFunction(int X, int Y);
        bool EvenFunction(int X);
        double SquartFunction(int X);
        string Mode { get; set; }
        string Model { get; set; }

        bool Equals(ICalculator calculator);
    }
}
