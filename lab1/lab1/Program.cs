
public class Program
{
    public static void printMenu()
    {
        Console.WriteLine("\nPlease, choose action\n0. Exit\n1. Empty constuctor" +
            "\n2. Constructor with parameters\n3. Copy constuctor"+ 
            "\n4. Input object\n5. Print object\n6.Print coppied object\n7. Length\n8.Normalize\n9.Compare to coppied" +
            "\n10. Addition\n11. Subtraction\n12. Multiplication");
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Choose dimension");
        int choice = int.Parse(Console.ReadLine());
        TVector2D v21 = new TVector2D();
        TVector2D v22 = new TVector2D();
        TVector3D v31 = new TVector3D();
        TVector3D v32 = new TVector3D();
        switch (choice)
        {
            case 2:
                while (choice != 0)
                {
                    printMenu();
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 0: break;
                        case 1:
                            v21 = new TVector2D();
                            Console.WriteLine("First vector");
                            v21.print();
                            break;
                        case 2:
                            Console.WriteLine("Please enter x and y");
                            v21 = new TVector2D(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                            Console.WriteLine("First vector");
                            v21.print();
                            break;
                        case 3:
                            Console.WriteLine("Coppied vector");
                            v22 = new TVector2D(v21);
                            v22.print();
                            break;
                        case 4:
                            v21.input();
                            Console.WriteLine("First vector");
                            v21.print();
                            break;
                        case 5:
                            Console.WriteLine("First vector");
                            v21.print();
                            break;
                        case 6:
                            Console.WriteLine("Coppied vector");
                            v22.print();
                            break;
                        case 7:
                           Console.WriteLine("Length");
                           Console.WriteLine(v21.length());
                            break;
                        case 8:
                            Console.WriteLine("Normalized first vector");
                            v21.normalize();
                            v21.print();
                            break;
                        case 9:
                            Console.WriteLine("Are first and second vectors same?");
                            Console.WriteLine(v21.equals(v22));
                            break;
                        case 10:
                            Console.WriteLine("first vector + second");
                            v22 = v21 + v22;
                            v22.print();
                            break;
                        case 11:
                            Console.WriteLine("first vector - second");
                            v22 = v21 - v22;
                            v22.print();
                            break;
                        case 12:
                            Console.WriteLine("scalar multiplication");
                            Console.WriteLine(v21 * v22);
                            break;


                    }
                }
                break;
            case 3:
                while (choice != 0)
                {
                    printMenu();
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 0: break;
                        case 1:
                            v31 = new TVector3D();
                            Console.WriteLine("First vector");
                            v31.print();
                            break;
                        case 2:
                            Console.WriteLine("Please enter x, y and z");
                            v31 = new TVector3D(int.Parse(Console.ReadLine()),
                                int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                            Console.WriteLine("First vector");
                            v31.print();
                            break;
                        case 3:
                            Console.WriteLine("Coppied vector");
                            v32 = new TVector3D(v31);
                            v32.print();
                            break;
                        case 4:
                            v31.input();
                            Console.WriteLine("First vector");
                            v31.print();
                            break;
                        case 5:
                            Console.WriteLine("First vector");
                            v31.print();
                            break;
                        case 6:
                            Console.WriteLine("Coppied vector");
                            v32.print();
                            break;
                        case 7:
                            Console.WriteLine("Length");
                            Console.WriteLine(v31.length());
                            break;
                        case 8:
                            Console.WriteLine("Normalized first vector");
                            v31.normalize();
                            v31.print();
                            break;
                        case 9:
                            Console.WriteLine("Are first and second vectors same?");
                            Console.WriteLine(v31.equals(v32));
                            break;
                        case 10:
                            Console.WriteLine("First vector + second");
                            v32 = v31 + v32;
                            v32.print();
                            break;
                        case 11:
                            Console.WriteLine("First vector - second");
                            v32 = v31 - v32;
                            v32.print();
                            break;
                        case 12:
                            Console.WriteLine("Scalar multiplication");
                            Console.WriteLine(v31 * v32);
                            break;


                    }
                }
                break;
        }
    }
}