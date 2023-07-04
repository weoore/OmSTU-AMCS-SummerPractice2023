namespace BDD.Tests;

using TechTalk.SpecFlow;
using System;
using System.Linq;
using SquareEquationLib;

[Binding]
public class StepDefinitions
{
    
    private double eps = 1e-6;
    private double[] result;
    private double a, b, c;
    private Exception excep = new Exception();
    
    [When("вычисляются корни квадратного уравнения")]
    public void AddTheRoots()
    { 
        try 
        {
            result = SquareEquation.Solve(a, b, c);
        }
        catch (Exception e)
        {
            excep =  e;
        }
    }
    
    [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
    public void TwoRoots(double r0, double r1)
    {
        double[] expected = {r0, r1};
        Assert.Equal(expected, result);
    }
    
    [Then(@"квадратное уравнение имеет один корень (.*) кратности два")]
    public void OneRoot(double r0)
    {
        double[] expected = {r0};
        Assert.Equal(expected, result);
    }

    [Then(@"множество корней квадратного уравнения пустое")]
    public void NoRoots()
    {
        double[] expected = {};
        Assert.Equal(expected, result);
    }
    
    [Given(@"Квадратное уравнение с коэффициентами \(Double\.PositiveInfinity, (.*), (.*)\)")]
    public void AIsPositiveInfinity(int r0, int r1)
    {
        a = double.PositiveInfinity;
        b = r0;
        c = r1;
    }

    [Given(@"Квадратное уравнение с коэффициентами \(Double\.NegativeInfinity, (.*), (.*)\)")]
    public void AIsNegativeInfinity(int r0, int r1)
    {
        a = double.NegativeInfinity;
        b = r0;
        c = r1;
    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.PositiveInfinity, (.*)\)")]
    public void BIsPositiveInfinity(int r0, int r1)
    {
        a = r0;
        b = double.PositiveInfinity;
        c = r1;
    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.NegativeInfinity, (.*)\)")]
    public void BIsNegativeInfinity(int r0, int r1)
    {
        a = r0;
        b = double.NegativeInfinity;
        c = r1;
    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.PositiveInfinity\)")]
    public void CIsPositiveInfinity(int r0, int r1)
    {
        a = r0;
        b = r1;
        c = double.PositiveInfinity;
    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.NegativeInfinity\)")]
    public void CIsNegativeInfinity(int r0, int r1)
    {
        a = r0;
        b = r1;
        c = double.NegativeInfinity;
    }

    [Given(@"Квадратное уравнение с коэффициентами \(NaN, (.*), (.*)\)")]
    public void AIsNaN(double r0, double r1)
    {
        a = double.NaN;
        b = r0;
        c = r1;
    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), NaN, (.*)\)")]
    public void BIsNaN(double r0, double r1)
    {
        a = r0;
        b = double.NaN;
        c = r1;
    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), NaN\)")]
    public void CIsNaN(double r0, double r1)
    {
        a = r0;
        b = r1;
        c = double.NaN;
    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
    public void GoodCoef(double r0, double r1, double r2 )
    {
        a = r0;
        b = r1;
        c = r2;
    }

    [Then("выбрасывается исключение ArgumentException")]
    public void ThrowException()
    {
        Assert.Throws<ArgumentException>(() => SquareEquation.Solve(a, b, c));
    }
}