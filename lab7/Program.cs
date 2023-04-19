public interface PointQuadrilateral
{
    public double Square();
    public double Perimetr();
    public String TypeOf();
    public void setSides();

}
public interface SideQuadrilateral
{
    public double Square();
    public double Perimetr();
    public String TypeOf();

}
public class Quadrilateral : PointQuadrilateral, SideQuadrilateral
{
    double a;
    double b;
    double c;
    double d;

    Point p1;
    Point p2;
    Point p3;
    Point p4;

    public Quadrilateral(double a, double b, double c, double d)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        this.d = d;
    }
    public Quadrilateral(Point p1, Point p2, Point p3, Point p4)
    {
        this.p1 = p1;
        this.p2 = p2;
        this.p3 = p3;
        this.p4 = p4;
    }

    static double findSide(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow(p2.x - p1.x, 2) + Math.Pow(p2.y - p1.y, 2));
    }
    void PointQuadrilateral.setSides()
    {
        a = findSide(p1, p2);
        b = findSide(p2, p3);
        c = findSide(p3, p4);
        d = findSide(p4, p1);
    }
    static double geronSquare(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
    double PointQuadrilateral.Perimetr()
    {
        ((PointQuadrilateral)this).setSides();
        return ((SideQuadrilateral)this).Perimetr();

    }
    double SideQuadrilateral.Perimetr()
    {
        return a + b + c + d;
    }
    double PointQuadrilateral.Square()
    {
        ((PointQuadrilateral)this).setSides();
        double diagonal = findSide(p1, p3);
        return geronSquare(a, b, diagonal) + geronSquare(c, d, diagonal);
    }
    double squateForCyclicQuadrilateral()
    {
        double p = (a + b + c + d) / 2;
        return Math.Sqrt((p - a) * (p - b) * (p - c) * (p - d));
    }
    double squareUsingTwoDiagonals()
    {
        Console.WriteLine("Enter 1st diagonal");
        double diagonal1 = Double.Parse(Console.ReadLine());
        Console.WriteLine("Enter 2nd diagonal");
        double diagonal2 = Double.Parse(Console.ReadLine());
        Console.WriteLine("Enter angle");
        double angle = Double.Parse(Console.ReadLine());
        if (angle < 180 && angle > 0
            &&((Math.Min(a + b, c + d) > diagonal1&& Math.Min(b + c, d + a) > diagonal2)
            ||(Math.Min(a + b, c + d) > diagonal2&& Math.Min(b + c, d + a) > diagonal1)))
        {
            
                    return (0.5 * diagonal1 * diagonal2 * Math.Sin(angle * Math.PI / 180));

            
        }
        Console.WriteLine("Wrong input");
        return 0;
    }
    double paralelSquare()
    {
        if (question("Do you know about the length of height?"))
        {
            Console.WriteLine("Enter heigth");
            double h = Double.Parse(Console.ReadLine());
            Console.WriteLine("Choose side to which height is drawn");
            string side = Console.ReadLine();
            if (h < a&&(side=="b"|| side == "d"))
                return (d * h);
            else if ((h < b)&& (side == "a" || side == "c"))
            {
                return (a * h);
            }
            else Console.WriteLine("Wrong hieght");
            return 0;
        }
        else if (question("Do you know about the angle between two sides?"))
        {
            Console.WriteLine("Enter angle");
            double angle = Double.Parse(Console.ReadLine());
            if (angle < 180&&angle>0)
            {
                return (a * b * Math.Sin(angle * Math.PI / 180));
            }
            Console.WriteLine("Wrong angle");
            return 0;
        }
        return -1;
    }
    double rombusSquare()
    {
        double square = this.paralelSquare();
        if (square != -1)
        {
            return square;
        }
        else if (question("Do you know the length of two diagonals?")) 
        {
            Console.WriteLine("Enter 1st diagonal");
            double diagonal1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter 2nd diagonal");
            double diagonal2 = Double.Parse(Console.ReadLine());
            if( ((Math.Min(a + b, c + d) > diagonal1 && Math.Min(b + c, d + a) > diagonal2)
            || (Math.Min(a + b, c + d) > diagonal2 && Math.Min(b + c, d + a) > diagonal1)))
            return (diagonal1 * diagonal2 / 2); 
           
        }
        Console.WriteLine("Wrong input");
         return 0;
    }
    double SideQuadrilateral.Square()
    {
        double square = 0;
        switch (((SideQuadrilateral)this).TypeOf())
        {
            case "Square":
                return (a * a);
            case "Rectangle":
                return (a * b);
            case "Cyclic quadrilateral":
                return this.squateForCyclicQuadrilateral();
            case "Trapezium":  
                double h = Math.Sqrt(a*a-Math.Pow((Math.Pow(b - d, 2) + a * a - c * c) / (2 * (b - d)), 2 ));
                return h * (b + d) / 2;
                break;
            case "Isosceles trapezium":
                return this.squateForCyclicQuadrilateral();
            case "Parallelogram":
               square = this.paralelSquare();
                if (square == -1)
                    goto default;
                else 
                    return square;
            case"Rombus":
                return rombusSquare();
            default:
                if(question("Do you know the length of two diagonals and angle between them?"))
                    return this.squareUsingTwoDiagonals();
                Console.WriteLine("Not enough infromatoin to determine square");
                return 0;
        }
    }
    static double findKoef(Point p1, Point p2)
    {
        if(p2.x == p1.x)
        {
            return 0;
        }
        else
        return (p2.y - p1.y) / (p2.x - p1.x);
    }
    public static bool question (string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("1.Yes");
        Console.WriteLine("2.No");
        string choice = Console.ReadLine();
        if (choice == "1")
        {
            return true;
        }
        return false;

    }
    string SideQuadrilateral.TypeOf()
    {
        string s = "Irregular quadrilateral";
        bool rombus, paralel;
        if (a == b && b == c && c == d && d == a)
        {
            s = "Rombus";
            if (question("Are all four angles right?"))
            {
                s = "Square";
            }
        }
        else if(a == c && b == d)
        {
            s = "Parallelogram";
            if (question("Are all four angles right "))
                s = "Rectangle";
        }
        else  if (question("Is only one pair of the opposite sides parallel?"))
        { 
            s = "Trapezium";
        if (a == c || b == d)
                s = "Isosceles trapezium";
        }
        else if (question("Is the sum of the opposite angles equals to 180 degrees?"))
            s = "Cyclic quadrilateral";
        return s;
    }
    static double checkKoef(double k)
    {
        if (k == 0)
        {
            return 0;
        }
        else 
            return -1 / k;
    }
    string PointQuadrilateral.TypeOf()
    {
        string s = "";
        ((PointQuadrilateral)this).setSides();
        double diagonal1 = findSide(p1, p3);
        double diagonal2 = findSide(p2, p4);
        double k1 = findKoef(p1, p2);
        double k2 = findKoef(p2, p3);
        double k3 = findKoef(p3, p4);
        double k4 = findKoef(p4, p1);
        if (k1==k3 || k2==k4)
        {
            if ((k1 == k3 && k2 != k4) || (k2 == k4 && k1 != k3))
            {
                s = (diagonal1 == diagonal2) ? "Isosceles trapezium" : "Trapezium";
            }
            else if (k1 == k3 && k2 == k4)
            {
                s = "Parallelogram";
                if (a == b && b == c & c == d && d == a)
                {
                    s = (diagonal1 == diagonal2
                        && findKoef(p1, p3) == checkKoef(findKoef(p2, p4))) ?
                     "Square" : "Rombus";
                }
                else if (k1 == checkKoef(k2) && k2 == checkKoef(k3)
                    && k3 == checkKoef(k4) && k4 == checkKoef(k1))
                    s = "Rectangle";
            }
        }
        else
            s = "Irregular quadrilateral";
        return s;
    }
}
    public class Point
    {
        public double x;
        public double y;
        public Point()
        {
            x = 0;
            y = 0;
        }
        public Point(double x,double y)
        {
            this.x = x;
            this.y = y;
        }
    }
class Program
{
    public static void Main(string[] args)
    {
        Quadrilateral q;
        string choice = "1";
        while (choice != "0")
        {
            Console.WriteLine("Choose enter type\n1.Quadrilateral by points\n2.Quadrilateral by sides\n0.Exit");
            choice = Console.ReadLine();
            if (choice == "1")
            {
                List<Point> points = new List<Point>();
                double x;
                double y;
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("Please enter " + i + " point");
                    x = Double.Parse(Console.ReadLine());
                    y = Double.Parse(Console.ReadLine());
                    points.Add(new Point(x, y));
                }
                q = new Quadrilateral(points[0], points[1], points[2], points[3]);
                Console.WriteLine("Type is " + ((PointQuadrilateral)q).TypeOf());
                Console.WriteLine("Square is " + Math.Round(((PointQuadrilateral)q).Square(), 3));
                Console.WriteLine("Perimetr is " + Math.Round(((PointQuadrilateral)q).Perimetr(), 3));

            }
            else if (choice == "2")
            {
                List<double> sides = new List<double>();

                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("Please enter " + (i + 1) + " side");
                    sides.Add(Double.Parse(Console.ReadLine()));
                }
                q = new Quadrilateral(sides[0], sides[1], sides[2], sides[3]);
                Console.WriteLine("Type is " + ((SideQuadrilateral)q).TypeOf());
                double square = Math.Round(((SideQuadrilateral)q).Square(), 3);
                Console.WriteLine("Square is " + square);
                Console.WriteLine("Perimetr is " + Math.Round(((SideQuadrilateral)q).Perimetr(), 3));

            }
        }
    } 
}
