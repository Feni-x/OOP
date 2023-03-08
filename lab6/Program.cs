using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

class Program
{
    public static int[] initialize(int n)
    {
        return new int[n];
    }
    public static int[,] initialize(int n,int m)
    {
        return new int[n,m];
    }
    public static int[] randomFilling( int[] arr,int low=-40,int high=40)
    {
        Random r = new Random();
        for(int i = 0; i < arr.Length; i++)
        {
            arr[i] = r.Next(low,high);
        }
        return arr;
    }
    public static double avgArithmetic(int[] arr)
    {
        double sum = 0;
        foreach(int d in arr)
        {
            sum += d;
        }
        return sum/arr.Length;
    }
    public static int[,] randomFilling(int[,] arr, int low = -50, int high = 50)
    {
        Random r = new Random();
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for(int j=0;j<arr.GetLength(1);j++)
                arr[i,j] = r.Next(low,high);
        }
        return arr;
    }
    public static void print(int[] arr)
    {
        foreach (var v in arr)
            Console.Write(v+"\t");
        Console.WriteLine();
    }
    public static void print(int[,] arr)
    {
        for(int i =0; i < arr.GetLength(0); i++)
        {
           for(int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write(arr[i,j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    public static int[] sum(int[] arr1, int[] arr2)
    {
        if (arr1.Length != arr2.Length)
        {
            Console.WriteLine("Arrays have different lengthes");
            return null;
        }
        int[] arr = new int[arr1.Length];
        for (int i = 0; i < arr1.Length; i++)
        {
            arr[i] = arr1[i] + arr2[i];
        }
        return arr;
    }
    public static void sort(int[] arr,int low, int high)
    {
        if (low < high)
        {
            int pi = partition(arr,low,high);
            sort(arr, low, pi-1);
            sort(arr, pi+1, high);
        }
        else
        {
            return;
        }
        
    }
    private static int partition(int[] arr,int low, int high)
    {
        int temp;
        int pivot = arr[high];
        int i = (low - 1);
        for(int j = low; j <= high - 1; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
        }
        }
        temp = arr[i+1];
        arr[i+1] = arr[high];
        arr[high] = temp;
        return(i + 1);
    }
    static public int amountNonZeroEl(int[,] arr)
    {
        bool flag;
        int sum = 0;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            flag = true;
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] == 0)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                sum++;
            }
        }
        return sum;
    }
    static public int findMaxMoreThanOnce(int[,] arr)
    {
        int max = arr[0,0];
        bool indicator = true;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                bool flag = false;
                for (int k = 0; k < arr.GetLength(0); k++)
                {
                    for (int z = 0; z < arr.GetLength(1); z++)
                    {
                        if ((i != k || j != z) && arr[i, j] == arr[k, z])
                        {
                           
                           flag=true;
                        }
                    }
                }
                if (flag) {
                    if (i == 0 && j == 0)
                        continue;
                    else
                    {
                        if (indicator)
                        {
                            indicator = false;
                         
                        }
                        if (arr[i, j] > max)
                        {
                            max = arr[i, j];
                           
                        }
                    }
                }
            
            }     
        }
        if (indicator)
        {
            Console.WriteLine("No same elements");
            max = 0;
        }
        return max;
    }
    public static int[,] sort2DArrOdd(int[,] arr)
    {
        int min = 0;
        int temp = 0;
        for(int i=0; i<arr.GetLength(0); i+=2)
        {
            for (int j=0; j < arr.GetLength(1)-1; j++)
            {
                min = j;
                for (int k=j+1; k< arr.GetLength(1); k++)
                {
                    if(arr[i, k] < arr[i,min])
                    {
                        min = k;
                    }
                }
                temp = arr[i, min];
                arr[i, min] = arr[i, j];
                arr[i, j] = temp;
            }
        }
        return arr;
    }
    static void printMenu()
    {
        Console.WriteLine("Choose action"
            + "\n1.Create array of size"
            + "\n2.Create 2D array of size"
            + "\n3.Fill array with random values"
            + "\n4.Fill 2D array with random values"
            + "\n5.Print array"
            + "\n6.Print 2D array"
            + "\n7 (1.1).Average arithmetic value"
            + "\n8 (1.2) Sum of vectors"
            + "\n9.(1.3) Sort elements of array in ascending order"
            + "\n10.(2.1) Sort elements in odd raws of 2D array in ascending order"
            + "\n11.(2.2) Find amount of rows without zero elements in 2D array"
            + "\n12.(2.3) Find max value that occurs more than once in 2D array "
        );
    }
    static void Main(string[] args)
    {
        int[] arr1=new int[0];
        int[] arr2 = new int[0];
        int[,] arr3 = new int[0,0];
        int choice = 5;
        while (choice != 0)
        {
            printMenu();
            choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("Enter size");
                    int l = Int32.Parse(Console.ReadLine());
                    arr1 = initialize(l);
                    break;
                case 2:
                    Console.WriteLine("Enter 1st dimension");
                    int m = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter 2nd dimension");
                    int n = Int32.Parse(Console.ReadLine());
                    arr3 = initialize(m,n);
                    break;
                case 3:
                    randomFilling(arr1);
                    print(arr1);
                    break;
                case 4:
                    randomFilling(arr3);
                    print(arr3);
                    break;
                case 5:
                    print(arr1);
                    break;
                case 6:
                    print(arr3);
                    break;
                case 7:
                    Console.WriteLine("Average arithmetic is "+ avgArithmetic(arr1));
                    break;
                case 8:
                    arr2 = initialize(arr1.Length);
                    arr2 = randomFilling(arr2);
                    Console.WriteLine("Randomly generated array that will be added to array");
                    print(arr2);
                    Console.WriteLine("Sum");
                    print(sum(arr1, arr2));
                    break;
                case 9:
                    sort(arr1, 0, arr1.Length-1);
                    print(arr1);
                    break;
                case 10:
                    sort2DArrOdd(arr3);

                    print(arr3);
                    break;
                case 11:
                    Console.WriteLine("Amount of rows without zero elements "+amountNonZeroEl(arr3));
                    break;
                case 12:
                    Console.WriteLine("Max element that occurs more than once "+findMaxMoreThanOnce(arr3));
                    break;
            }
        }
    }
}