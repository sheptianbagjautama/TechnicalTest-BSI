class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Masukkan string:");
        string input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Input kosong.");
            return;
        }

        char currentChar = input[0];
        int count = 1;

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == currentChar)
            {
                count++;
            }
            else
            {
                Console.WriteLine($"{currentChar} = {count}");
                currentChar = input[i];
                count = 1;
            }
        }

        Console.WriteLine($"{currentChar} = {count}");
    }
}
