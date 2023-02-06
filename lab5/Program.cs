
class Program
{
    public static void printMenu()
    {

    }
    static void Main(string[] args)
    {
        TVector2D vector = new TVector2D(3, 4);
        vector.print();
        vector.input();
        Console.WriteLine(vector.lenght());
        vector.normalize();
        vector.print();
        Console.WriteLine("Choose dimension");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 2: 
                TVector2D v21 = new TVector2D();
               TVector2D v22 = new TVector2D();
                break;
                v21.print();
                v21.input();
                Console.WriteLine(v21.lenght());
                v21.normalize();
                v21.print();
            case 3:
                TVector3D v31 = new TVector3D();
                TVector3D v32 = new TVector3D();
                break;
        }
    }
}