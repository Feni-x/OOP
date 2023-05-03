using System.Diagnostics.Metrics;
using System.Text;

class Program
{
    public static (int,int) countLetters(char[]letters, 
        char[]vowels, char[] Сonsonants)
    {
        (int vowelsCount, int consonantsCount) t1 = (0, 0);
        t1.vowelsCount=countBlock(letters,vowels);
        t1.consonantsCount = countBlock(letters, Сonsonants);
        return t1;
    }
    public static int countLetter(char letter, char[] block)
    {
        int count = 0;
        foreach (char el in block)
        {
            if (Char.ToLower(letter) == el)
            {
                count++;
                return count;
            }
        }
        return count;
    }
    public static int countBlock(char[] letters, char[] block)
    {
        int count = 0;
        foreach (char letter in letters)
        {
            count += countLetter(letter, block);
           
        }
        return count;
    }
    public static int countBlock(List<char> letters, char[] block)
    {
        int count = 0;
        foreach(char letter in letters)
        {
            count += countLetter(letter, block);
        }
        return count;
    }
    public static (int, int) countLetters(List<char> letters,
       char[] vowels, char[] Сonsonants)
    {
        (int vowelsCount, int consonantsCount) t1 = (0, 0);
        List<char> lettersTemp=new List<char>(letters);
        int[] count = new int[20];
        t1.vowelsCount = countBlock(lettersTemp,vowels);
        t1.consonantsCount = countBlock(lettersTemp, Сonsonants);

        return t1;
    }
  
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.InputEncoding = System.Text.Encoding.Unicode;

        string file = "source.txt";
        string text;
       Start:
        try
        {
            StreamReader sr = new StreamReader(file);
            text = sr.ReadToEnd();
            Console.WriteLine(text);
        }
        catch (Exception e)
        {
            Console.WriteLine("File dosen`t etist");
            Console.WriteLine(e.ToString());
            Console.WriteLine("Please write name og the file");
            file = Console.ReadLine();
            goto Start;
        }
         char[] ukrVowels = new char[] { 'а', 'е', 'є', 'и', 'і', 'ї', 'о', 'у', 'ю', 'я' };
         char[] ukrСonsonants = new char[] { 'б', 'в', 'г', 'ґ',
        'д', 'ж','й','з','к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф',
        'х', 'ц', 'ч', 'ш', 'щ' };
        
        char[] textArr = text.ToCharArray();
        List<char> list = new List<char>(text);
        (int vowels, int consonants) t1=countLetters(textArr, ukrVowels, ukrСonsonants);
        Console.WriteLine("There are "+ t1.vowels + " vowels and " + t1.consonants+ " consonants");
         t1 = countLetters(list, ukrVowels, ukrСonsonants);
        Console.WriteLine("When using list");
       Console.WriteLine("There are " + t1.vowels + " vowels and " + t1.consonants + " consonants");


    }
}