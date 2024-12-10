class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Masukkan angka-angka dipisahkan oleh koma (contoh: 2,4,6,5,3,1,7,9,10,8):");
        int[] result = Console.ReadLine()
                              .Split(',') //Split by comma
                              .Select(int.Parse) //Konversi menjadi bilangan bulat
                              .Where(n => n % 2 != 0) //Filter hanya mencari angka ganjil
                              .OrderByDescending(n => n) //Urutkan dari yang terbesar ke terkecil
                              .ToArray(); //Konversi ke array

        Console.WriteLine($"Output: [{string.Join(",", result)}]"); //output
    }
}
