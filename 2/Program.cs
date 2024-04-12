using System.Runtime;
using System.Text;

namespace _2
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
                "1 - Создать директории\n2 - Удалить директории\n" +
                "0 - Инструкция\nESC - выход";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Guide);
            Console.ResetColor();
        }


        static void Main(string[] args)
        {
            string? path = Environment.CurrentDirectory;

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            ConsoleKeyInfo key = new ConsoleKeyInfo();


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Задание 2\n" +
                "Создайте в своей папке 20 дочерних директорий с именами MyTestFolder0 - MyTestFolder19.\n" +
                "Удалите их программо.");
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
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Текущая директория: " + path);
                Console.ResetColor();

                for (int i = 0; i < 20; i++)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(path + "\\MyTestFolder" + i);
                    if (!dirInfo.Exists)
                    {
                        dirInfo.Create();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Директория \"MyTestFolder\"" + i + " создана");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Директория \"MyTestFolder\"" + i + " уже существует!");
                        Console.ResetColor();
                    }
                }

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Сделайте дальнейший выбор...");
                Console.ResetColor();
                Console.WriteLine();
            }


            void Press2()
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Текущая директория: " + path);
                Console.ResetColor();

                for (int i = 0; i < 20; i++)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(path + "\\MyTestFolder" + i);
                    if (dirInfo.Exists)
                    {
                        dirInfo.Delete(true);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Директория \"MyTestFolder\"" + i + " удалена");
                        Console.ResetColor();

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Директория \"MyTestFolder\"" + i + " не существует!");
                        Console.ResetColor();
                    }
                }

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Сделайте дальнейший выбор...");
                Console.ResetColor();
                Console.WriteLine();
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
