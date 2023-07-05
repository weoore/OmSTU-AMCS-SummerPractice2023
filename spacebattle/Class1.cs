﻿namespace spacebattle;
public class SpaceShip
{
    public static double[] RectilinearMovement(double[] start, double[] speed, bool canMove)
    {
        double[] empty = new double[] { };
        double[] finish = new double[2];
        if (start == empty || Double.IsNaN(start[0]) || Double.IsNaN(start[1]) ||
            Double.IsInfinity(start[0]) || Double.IsInfinity(start[1]))
        {
            throw new System.ArgumentException();
        }
        else if (speed == empty || Double.IsNaN(speed[0]) || Double.IsNaN(speed[1]) ||
            Double.IsInfinity(speed[0]) || Double.IsInfinity(speed[1]))
        {
            throw new System.ArgumentException();
        }
        else
        {
            finish[0] = start[0] + speed[0];
            finish[1] = start[1] + speed[1];
        }
        if (!canMove)
        {
            throw new System.ArgumentException();
        }
        else
        {
            return finish;
        }
    }

    public static double Fuel(double FuelConsumption, double FuelReserve)
    {
        if (FuelReserve <= FuelConsumption)
        {
            throw new System.ArgumentException();
        }
        else
        {
            return FuelReserve - FuelConsumption;
        }
    }

    public static double Rotation(double angle, double change, bool canRotate)
    {
        double newAngle;
        if (Double.IsNaN(angle) || Double.IsInfinity(angle))
        {
            throw new System.ArgumentException();
        }
        else if (Double.IsNaN(change) || Double.IsInfinity(change))
        {
            throw new System.ArgumentException();
        }
        else 
        {
            newAngle = angle + change;
        }
        
        if (!canRotate)
        {
            throw new System.ArgumentException();
        }
        else
        {
            return newAngle;
        }
    }
}