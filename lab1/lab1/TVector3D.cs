using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

public class TVector3D : TVector2D
{
    private double z;

    public TVector3D(double x, double y, double z) : base(x, y)
    {
        this.z = z;
    }
    public TVector3D() : base()
    {
        this.z = 0;
    }

    public TVector3D(TVector3D vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }

    public override void input()
    {
        base.input();
        Console.WriteLine("Please, enter z");
        z = Double.Parse(Console.ReadLine());
    }

    public override void print()
    {
        base.print();
        Console.Write(";" + z + "\n");
    }

    public override double length()
    {
        
        return Math.Sqrt(x * x +y * y  + z * z);
    }
    public override void normalize()
    {
        double length = this.length();
        base.normalize();
        z = z / length;
    }
    public bool equals(TVector3D vector)
    {
        return x==vector.x && y==vector.y && z==vector.z;   
    }
    public static TVector3D operator +(TVector3D vector1, TVector3D vector2)
    {
        return new TVector3D(vector1.x + vector2.x, vector1.y + vector2.y,vector1.z+vector2.z);
    }
    public static TVector3D operator -(TVector3D vector1, TVector3D vector2)
    {
        return new TVector3D(vector1.x - vector2.x, vector1.y - vector2.y, vector1.z - vector2.z);
    }
    public static double operator *(TVector3D vector1, TVector3D vector2)
    {
        return (vector1.x * vector2.x + vector1.y * vector2.y+vector1.z*vector2.z);
    }


}
