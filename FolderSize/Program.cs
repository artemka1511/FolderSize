using System;
using System.IO;

namespace FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите путь до папки: ");
            string path = Console.ReadLine();
            Console.WriteLine();
            try
            {
                if (Directory.Exists(path))
                {
                    Console.WriteLine($"Размер директории составляет: {GetSize(path, default)} байт");
                }
                else
                {
                    Console.WriteLine("Ошибка: директория не найдена");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Ошибка: " + exception);
            }
        }

        static double GetSize(string path, double size)
        {
            string[] dirs = Directory.GetDirectories(path);

            if (dirs.Length != 0)
            {
                foreach (var item in dirs)
                {
                    GetSize(item, size);
                }
            }

            var files = Directory.GetFiles(path);

            Console.WriteLine($"Директория: {path} содержит {files.Length} файлов");

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                size += fileInfo.Length;
                Console.WriteLine($"Размер файла {fileInfo.Name} составляет {fileInfo.Length} байт");
            }

            Console.WriteLine();

            return size;
        }
    }
}
