using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//1.Написать класс для работы с директориями:
//Класс должен содержать методы принимающие путь к папке и возвращающий:


//FileInfo[] файлов из папки,

//Класс должен содержать метод принимающие путь к папке и расширение файлов(txt например):
//Количество файлов в каталоге,
//FileInfo[] файлов из папки.
namespace _1
{
    internal static class FileClass
    {
        /// <summary>
        /// Метод подсчета и вывода файлов в каталоге
        /// </summary>
        /// <param name="path">Путь к каталогу</param>
        /// <returns>Возвращает количество файлов в каталоге и массив FileInfo файлов в нем</returns>
        public static (int, FileInfo[]?) FilesCountAndInfo(string? path)
        {
            try
            {
                if (path is null || path == string.Empty || path == "")
                {
                    throw new ArgumentException();
                }

                else
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    if (!dirInfo.Exists)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный путь или директории не существует!");
                        Console.WriteLine();
                        Console.ResetColor();
                        return (-1, null);
                    }
                    else
                    {
                        return (dirInfo.EnumerateFiles().ToArray().Length, dirInfo.EnumerateFiles().ToArray());
                    }
                }
            }

            catch (ArgumentException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректно указан путь. " + e.Message);
                Console.WriteLine();
                return (-1, null);
            }
            finally
            {
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Метод подсчета и вывода файлов с заданным расширением в каталоге
        /// </summary>
        /// <param name="path">Путь к каталогу</param>
        /// <returns>Возвращает количество файлов с заданным расширением и массив FileInfo файлов в каталоге</returns>
        public static (int, FileInfo[]?) FilesExtCountAndInfo(string? path, string? ext)
        {
            try
            {
                if (path is null || path == string.Empty || path == "" || ext is null || ext == string.Empty || ext == "")
                {
                    throw new ArgumentException();
                }

                else
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    if (!dirInfo.Exists)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный путь или директории не существует!");
                        Console.WriteLine();
                        Console.ResetColor();
                        return (-1, null);
                    }
                    else
                    {
                        return (dirInfo.EnumerateFiles().Where(x=>x.Extension.ToLower() == "."+ext.ToLower() || x.Extension.ToLower() == ext.ToLower()).ToArray().Length, 
                            dirInfo.EnumerateFiles().Where(x => x.Extension.ToLower() == "." + ext.ToLower() || x.Extension.ToLower() == ext.ToLower()).ToArray());
                    }
                }
            }
            catch (ArgumentException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректно указаны путь или расширение. " + e.Message);
                Console.WriteLine();
                return (-1, null);
            }
            finally
            {
                Console.ResetColor();
            }
        }
    }
}
