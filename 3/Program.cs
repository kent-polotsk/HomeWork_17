using System.Text;

namespace _3
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
                "1 - Создать файл и записать в него текст\n2 - Вывести текст из файла\n3 - Удалить файл\n" +
                "0 - Инструкция\nESC - выход";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Guide);
            Console.ResetColor();
        }


        static void Main(string[] args)
        {
            string? directory = Environment.CurrentDirectory,
                fileName = "MyFirstFile.txt",
                path = Path.Combine(directory, fileName),
                text = "Привет с первой строки\n\nПривет с 3й строки";

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            ConsoleKeyInfo key = new ConsoleKeyInfo();


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Задание 3\n" +
                "Создайте любой файл, запишите в него текст\n" +
                "“Привет с первой строки\n" +
                "\n" +
                "Привет с 3й строки”, закройте файл.\n" +
                "Прочитайте файл и покажите на консоль.");
            Console.ResetColor();

            PrintGuide();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Путь к файлу: " + path + "\n");
            Console.ResetColor();

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

                    case ConsoleKey.NumPad3:
                        {
                            Press3();
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            Press3();
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
                if (File.Exists(path))
                {
                    using (StreamWriter sw = new StreamWriter(path,false,Encoding.UTF8))
                    {
                        sw.Write(text);
                        sw.Close();
                    }
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Файл перезаписан.");
                }
                else
                {
                    File.Create(path).Close();
                    using (StreamWriter sw = new StreamWriter(path,false, Encoding.UTF8))
                    {
                        sw.Write(text);
                        sw.Close();
                    }
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Файл создан.");
                }
                Console.ResetColor();
                Console.WriteLine();
            }


            void Press2()
            {
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
                    {
                        Console.WriteLine(sr.ReadToEnd() + "\n");
                        sr.Close();
                    }
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Файл считан.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Файл не найден.");
                }
                Console.ResetColor();
                Console.WriteLine();
            }

            void Press3()
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                if (File.Exists(path))
                {
                    File.Delete(path);
                    Console.WriteLine("Файл удален.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Файл не найден.");
                }

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
