using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    public class TVector2D
    {
    protected double x;
    protected double y;

    public TVector2D(double x, double y)
    {
        this.x = x;
        this.y = y;
    }
    public TVector2D()
    {
        this.x = 0;
        this.y = 0;
    }

    public TVector2D( TVector2D vector)
    {
        this.x = vector.x;
        this.y = vector.y;
    }

    public virtual void input()
    {
        Console.WriteLine("Please, enter x");
        x=Int32.Parse(Console.ReadLine());
        Console.WriteLine("Please, enter y");
        y =Int32.Parse(Console.ReadLine());
    }

    public virtual void print()
    {
        Console.Write(x + "; " + y + " ");
    }

    public virtual double length()
    {
        return (Math.Sqrt(x * x + y * y));
    }

    public virtual void normalize()
    {
        double length = this.length();
        x = x / length;
        y = y / length;

    }
    //ToDo чи треба додавати протилежність?
    public bool equals(TVector2D vector) 
    {
        return x == vector.x && y == vector.y;
    }

    public static TVector2D operator + (TVector2D vector1, TVector2D vector2)
    {
        return new TVector2D(vector1.x + vector2.x, vector1.y + vector2.y);
    }
    public static TVector2D operator -(TVector2D vector1, TVector2D vector2)
    {
        return new TVector2D(vector1.x - vector2.x, vector1.y - vector2.y);
    }
    public static double operator *(TVector2D vector1, TVector2D vector2)
    {
        return (vector1.x * vector2.x + vector1.y * vector2.y);
    }

}

