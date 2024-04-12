using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace _5
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Задание 5\n" +
            "Создать строковую переменную \"HI, my name is tist file”.\n" +
            "Сохранить ее в файл. Изменить tist на test не перезаписывая сам файл(просто изменить).\n");
            Console.ResetColor();

            string s = "HI, my name is tist file";

            Thread.Sleep(1000);
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                FileStream stream = new FileStream("Test.txt", FileMode.Create, FileAccess.ReadWrite);

                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine(s);
                Console.WriteLine("Файл создан, текст записан\n");
                writer.Close();
                stream.Close();
                Thread.Sleep(2000);

                stream = new FileStream("Test.txt", FileMode.Open, FileAccess.ReadWrite);

                string textToInsert = "e";
                var utf8 = new UTF8Encoding();
                byte[] pass = utf8.GetBytes(textToInsert);
                stream.Position = 16;

                stream.Write(pass, 0, textToInsert.Length);
                stream.Close();
                Console.WriteLine("Текст изменен\n");
                Console.ResetColor();

            } 
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Error: {e.Message}\n");
                Console.ResetColor();
            }
        }
    }
}
