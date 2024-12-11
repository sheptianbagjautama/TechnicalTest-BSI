class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Masukkan angka-angka dipisahkan oleh koma (contoh: 2,4,6,5,3,1,7,9,10,8):");
        int[] result = Console.ReadLine()
                              .Split(',')
                              .Select(int.Parse)
                              .Where(n => n % 2 != 0)
                              .OrderByDescending(n => n)
                              .ToArray();

        Console.WriteLine($"Output: [{string.Join(",", result)}]"); //output
    }
}
