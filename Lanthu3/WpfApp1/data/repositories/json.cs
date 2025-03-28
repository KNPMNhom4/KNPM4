using System;
using System.IO;


class Program
{
    static void Main()
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "users.json");

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "[]");
            Console.WriteLine("File users.json đã được tạo thành công.");
        }
        else
        {
            Console.WriteLine("File users.json đã tồn tại.");
        }
    }
}
