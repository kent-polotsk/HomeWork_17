using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace _1
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
                "1 - Метод без учета расширений\n2 - Метод с учетом расширений\n" +
                "0 - Инструкция\nESC - выход";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Guide);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {

            string? path = "", ext = "";

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            ConsoleKeyInfo key = new ConsoleKeyInfo();


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Задание 1\n" +
                "Написать класс для работы с директориями: \n" +
                "Класс должен содержать методы принимающие путь к папке и возвращающий:\n" +
                "Количество файлов в каталоге, FileInfo[] файлов из папки\n" +
                "Класс должен содержать метод принимающие путь к папке и расширение файлов(txt например):\n" +
                "Количество файлов в каталоге, FileInfo[] файлов из папки.");
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


            //Методы для обработки нажатия кнопок

            void Press1()
            {
                Console.WriteLine("Введите путь к директории: ");
                path = Console.ReadLine();

                var item1 = FileClass.FilesCountAndInfo(path).Item1;

                if (item1 > 0)
                {
                    var item2 = FileClass.FilesCountAndInfo(path).Item2;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Количество файлов в каталоге: {item1}. Список файлов:");
                    Console.ResetColor();

                    foreach (var f in item2)
                    {
                        Console.WriteLine("--------Имя: " + f.Name);
                        Console.WriteLine("\tРазмер: " + f.Length + " байт");
                        Console.WriteLine("\tДата создания: " + f.CreationTime.Date.ToShortDateString()); 
                    }
                    Console.WriteLine();
                }
                else if (item1 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Файлы в директории отсутствуют!");
                    Console.WriteLine();
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Сделайте дальнейший выбор...");
                Console.ResetColor();
            }


            void Press2()
            {
                Console.WriteLine("Введите путь к директории: ");
                path = Console.ReadLine();
                Console.WriteLine("Введите расширение файлов: ");
                ext = Console.ReadLine();

                var item1 = FileClass.FilesExtCountAndInfo(path, ext).Item1;


                if (item1 > 0)
                {
                    var item2 = FileClass.FilesExtCountAndInfo(path, ext).Item2;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Количество файлов с расширением {ext} в каталоге: {item1}. Список файлов:");
                    Console.ResetColor();

                    foreach (var f in item2)
                    {
                        Console.WriteLine("--------Имя: " + f.Name);
                        Console.WriteLine("\tРазмер: " + f.Length + " байт");
                        Console.WriteLine("\tДата создания: " + f.CreationTime.Date.ToShortDateString());
                    }
                    Console.WriteLine();
                }
                else if (item1 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Файлы с расширением .{ext} в директории отсутствуют!");
                    Console.WriteLine();
                    Console.ResetColor();
                }
                Console.ForegroundColor= ConsoleColor.DarkYellow;
                Console.WriteLine("Сделайте дальнейший выбор...");
                Console.ResetColor();
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
