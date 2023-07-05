namespace spacebattletests;
using TechTalk.SpecFlow;
using spacebattle;

[Binding]
public class StraightMoveTest
{
    private double[] pos = new double[2];
    private double[] start = new double[2];
    private double[] speed = new double[2];
    private double[] badstart = new double[2];
    private double[] badspeed = new double[2];
    public bool canMove = true;
    public bool ErrorTypeMove, ErrorTypeRotate;
    private double FuelReserve, FuelConsumption, res;
    private Exception excep = new Exception();
    private Exception excep_ = new Exception();
    public bool canRotate = true;
    private double angle, change_angle, res_angle;

    [When(@"происходит вращение вокруг собственной оси")]
    public void ShipRotation()
    {
        try
        {
            res_angle = SpaceShip.Rotation(angle, change_angle, canRotate);
        }
        catch (Exception e)
        {
            excep_ = e;
        }
    }

    [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
    public void hasAngle(double a)
    {
        angle = a;
    }
    
    [Given(@"космический корабль, угол наклона которого невозможно определить")]
    public void AngleUndefined()
    {
        angle = Double.NaN;
        ErrorTypeRotate = true;
    }

    [Given(@"имеет мгновенную угловую скорость (.*) град")]
    public void hasAngVelocity(double a)
    {
        change_angle = a;
    }

    [Given(@"мгновенную угловую скорость невозможно определить")]
    public void AngVelocityUndefined()
    {
        change_angle = Double.NaN;
        ErrorTypeRotate = true;
    }
    
    [Given(@"невозможно изменить уголд наклона к оси OX космического корабля")]
    public void AngleUnchangeable()
    {      
        canRotate = false;
        ErrorTypeRotate = true;
    }

    [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
    public void ShipAngle(double p)
    {
        double excepted = p;
        Assert.Equal(excepted, res_angle);
    }
    
    [When("происходит прямолинейное равномерное движение без деформации")]
    public void RectilinearMoving()
    {
        try
        {
            pos = SpaceShip.RectilinearMovement(start, speed, canMove);
            res = SpaceShip.Fuel(FuelConsumption, FuelReserve);
        }
        catch (Exception e)
        {
            excep = e;
        }
    }

    [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
    public void hasFuel(double f)
    {
        FuelReserve = f;
    }

    [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
    public void FuelСonsumption(double a)
    {
        FuelConsumption = a;
    }

    [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
    public void LocatedAtThePoint(double x, double y)
    {
        start[0] = x;
        start[1] = y;
    }

    [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
    public void hasSpeed(double v1, double v2)
    {
        speed[0] = v1;
        speed[1] = v2;
    }

    [Given(@"космический корабль, положение в пространстве которого невозможно определить")]
    public void PositionUndefined()
    {
        badstart[0] = Double.NaN;
        badstart[1] = Double.NaN;
        ErrorTypeMove = true;
    }
    
    [Given(@"скорость корабля определить невозможно")]
    public void SpeedUndefined()
    {
        badspeed[0] = Double.NaN;
        badspeed[1] = Double.NaN;
        ErrorTypeMove = true;
    }
    
    [Given(@"изменить положение в пространстве космического корабля невозможно")]
    public void PositionUnchangeable()
    {
        canMove = false;
        ErrorTypeMove = true;
    }
    
    [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
    public void MovesTo(double f0, double f1)
    {
        double[] expected = new double[]{f0, f1};
        Assert.Equal(expected, pos);
    }

    [Then(@"новый объем топлива космического корабля равен (.*) ед")]
    public void newFuelTank(double e)
    {
        double excepted = e;
        Assert.Equal(excepted, res);
    }

    [Then(@"возникает ошибка Exception")]
    public void throwedException()
    {
        if (ErrorTypeMove)
        {
            Assert.Throws<ArgumentException>(() => SpaceShip.RectilinearMovement(badstart, badspeed, canMove));
        }
        else if (ErrorTypeRotate)
        {
            Assert.Throws<ArgumentException>(() => SpaceShip.Rotation(angle, change_angle, canRotate));
        }
        else if (FuelReserve <= FuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => SpaceShip.Fuel(FuelConsumption, FuelReserve));
        }
    }
}