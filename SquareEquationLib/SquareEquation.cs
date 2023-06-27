namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double[] Result;
        double epsilon=1e-9;

        if ((-epsilon < a && a < epsilon))
        {
            throw new System.ArgumentException();
        }

        if ((Double.IsNaN(a)) || (Double.IsNegativeInfinity(a)) 
        || (Double.IsPositiveInfinity(a)) || (Double.IsNaN(b)) || (Double.IsNegativeInfinity(b)) || Double.IsPositiveInfinity(b)
        || (Double.IsNaN(c)) || (Double.IsNegativeInfinity(c)) || Double.IsPositiveInfinity(c)) 
        {
            throw new System.ArgumentException();
        }
                  
        double D = (b*b)-(4*a*c);

        if (D>=epsilon)
        {
            Result = new double[2];
            Result[0] = (-(b + Math.Sign(b) * Math.Sqrt(D)) / 2);
            Result[1] = c / Result[0];
            return Result;
        }

        else if (Math.Abs(D)<epsilon)
        {
            Result = new double[1];
            Result[0] = (-b/(2*a));
            return Result;
           
        }
        else 
        {
           Result = new double[0];
           return Result;
        }
       
        throw new NotImplementedException();
    }
}