namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
{
    double epsilon = 1e-6;

    if (Math.Abs(a) < epsilon)
    {
        throw new ArgumentException();
    }

    if (double.IsNaN(a) || double.IsInfinity(a) || double.IsNaN(b) || double.IsInfinity(b) ||
        double.IsNaN(c) || double.IsInfinity(c))
    {
        throw new ArgumentException();
    }

    double D = (b * b) - (4 * a * c);

    if (D >= epsilon)
    {
        double[] Result = new double[2];
        Result[0] = (-b + Math.Sqrt(D)) / (2 * a);
        Result[1] = (-b - Math.Sqrt(D)) / (2 * a);
        return Result;
    }
    else if (Math.Abs(D) < epsilon)
    {
        double[] Result = new double[1];
        Result[0] = -b / (2 * a);
        return Result;
    }
    else
    {
        double[] Result = new double[0];
        return Result;
    }
}
}