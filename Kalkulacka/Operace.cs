using System;

namespace Kalkulacka;

public class Operace
{
    public double Add(double a, double b)
    {
        return a + b;
    }
    
    public double Minus(double a, double b)
    {
        return a - b;
    }
    
    public double Multiply(double a, double b)
    {
        return a * b;
    }
    
    public double Divide(double a, double b)
    {
        if (b == 0) throw new ArgumentException("Dělit nulou nelze");
        
        return a / b;
    }
}