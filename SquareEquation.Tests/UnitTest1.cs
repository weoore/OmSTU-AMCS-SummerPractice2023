using Xunit;
using SquareEquationLib;

namespace SquareEquationLib.Tests;

public class SquareEquationLib_isUnite
{   
    private const double epsilon = 1e-9;
    [Fact]
    public void TwoBases()
    {
        double[] expected = new double[] { 2, 1 };
        double[] actual = SquareEquation.Solve(1, -3, 2);

        Assert.True(Math.Abs(expected[0] - actual[0]) < epsilon);
        Assert.True(Math.Abs(expected[1] - actual[1]) < epsilon);
    }

    [Fact]
    public void OneBase()
    {
        double[] expected = new double[] { 3 };
        double[] actual = SquareEquation.Solve(3, -18, 27);

        Assert.True(Math.Abs(expected[0] - actual[0]) < epsilon);
    }

    [Fact]
    public void Nothing()
    {
        double[] expected = new double[] { };
        double[] actual = SquareEquation.Solve(1, -2, 10);

        Assert.Equal(expected, actual);
    }



    [Fact]
    public void ThrowsArgumentException()
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(0, 2, 3));
    }

    [Theory]
    [InlineData(double.NaN, 2, 3)]
    [InlineData(1, double.PositiveInfinity, 3)]
    [InlineData(1, 2, double.NegativeInfinity)]
    public void Wrong(double a, double b, double c)
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(a, b, c));
    }
}