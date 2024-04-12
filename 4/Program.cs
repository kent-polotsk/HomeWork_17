using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace _4
{
    internal class Program
    {
        public static ConsoleKeyInfo PressKey()
        {
            int cursorLeft = Console.CursorLeft;
            ConsoleKeyInfo key = Console.ReadKey();
            Console.SetCursorPosition(cursorLeft, Console.CursorTop);
            Console.Write(" ");
            Console.SetCursorPosition(cursorLeft, Console.CursorTop);
            return key;
        }

        public static void PrintGuide()
        {
            const string Guide =
                "1 - Сериализация\n2 - Десериализация\n" +
                "0 - Инструкция\nESC - выход";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Guide);
            Console.ResetColor();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            List<MyItem> list = new List<MyItem>() { new(2, "Дмитрий"), new(35, "Алексей"), new(15, "Виктор"), new(12, "Олег"), new(27, "Сергей") };

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            ConsoleKeyInfo key = new ConsoleKeyInfo();


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Задание 4\n" +
                "Создайте класс MyItem c 2мя public свойствами: Age и Name.\n" +
                "Создайте объект данного типа. Сериализуйте этот обект в JSON используя Newtonsoft.Json\n" +
                "так, чтобы поле Name не попадало в JSON, а значение Age было в поле JSON с именем MyAge");
            Console.ResetColor();

            PrintGuide();


            do
            {
                key = PressKey();

                switch (key.Key)
                {
                    case ConsoleKey.NumPad1:
                        {
                            Press1();
                            break;
                        }
                    case ConsoleKey.D1:
                        {
                            Press1();
                            break;
                        }

                    case ConsoleKey.NumPad2:
                        {
                            Press2();
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            Press2();
                            break;
                        }

                    case ConsoleKey.Escape:
                        {
                            PressEsc();
                            break;
                        }

                    default: break;
                }
            } while (true);


            void Press1()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Original list:");
                Console.ResetColor();

                foreach (MyItem myitem in list)
                {
                    Console.WriteLine($"Age: {myitem.Age}, Name: {myitem.Name}");
                }
                

                FileStream fs = new FileStream("Serialization.json", FileMode.Create, FileAccess.Write, FileShare.Read);
                StreamWriter sw = new StreamWriter(fs);

                string serialized = JsonConvert.SerializeObject(list);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Serialized:");
                Console.ResetColor();
                Console.WriteLine(serialized);

                sw.WriteLine(serialized);

                sw.Close();
                fs.Close();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Сделайте дальнейший выбор...");
                Console.ResetColor();
                Console.WriteLine();
            }


            void Press2()
            {
                if (File.Exists("Serialization.json"))
                {
                    FileStream fs = new FileStream("Serialization.json", FileMode.Open, FileAccess.Read, FileShare.Read);
                    StreamReader sr = new StreamReader(fs);

                    var json = sr.ReadToEnd();

                    List<MyItem> deserializedList = JsonConvert.DeserializeObject<List<MyItem>>(json);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Deserialized:");
                    Console.ResetColor();

                    foreach (MyItem myitem in deserializedList)
                    {
                        Console.WriteLine($"Age: {myitem.Age}, Name: {myitem.Name}");
                    }

                    sr.Close();
                    fs.Close();

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Сделайте дальнейший выбор...");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Файл json не найден!");
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }


            void PressEsc()
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.WriteLine("1");
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string bye = "Работа приложения завершена...";
                for (int i = 0; i < bye.Length; i++)
                {
                    Console.Write(bye[i]);
                    Thread.Sleep(15);
                }
                Console.ResetColor();
                Thread.Sleep(200);
                Console.WriteLine();
                Environment.Exit(0);
            }

        }
    }
}
