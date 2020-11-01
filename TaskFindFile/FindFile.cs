using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace HomeWork_3.TaskFindFile
{
    class FindFile
    {
        public static void MethodFindFile()
        {
            string _path = @"D:";

            string _fileName = "file.txt";

            foreach (var file in Directory.EnumerateFiles(_path, _fileName,
                SearchOption.AllDirectories))
            {
                FileInfo fi;
                try
                {
                    
                    fi = new FileInfo(file);
                 
                    Console.WriteLine(fi.Name + " " + fi.FullName + " " + fi.Length + " байт" +
                        " Создан: " + fi.CreationTime);

                    Console.WriteLine(ReadAllText(@"D:\file.txt"));

                    Compress(@"D:\file.txt");

                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        public static string ReadAllText(string value)
        {
            using (FileStream stream = File.OpenRead(value))
            {
                var encoding = new UTF8Encoding(true);
                var reader = new StreamReader(stream, encoding);
                return reader.ReadToEnd();
            }
        }

        public static void Compress(string path)
        {
            string sourceFolder = path; // исходная папка
            string zipFile = Path.Combine(path, "file.zip"); // сжатый файл
            string targetFolder = Path.Combine(path, "Unpacked"); // папка, куда распаковывается файл

            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
            Console.WriteLine($"Папка {sourceFolder} архивирована в файл {zipFile}");
            ZipFile.ExtractToDirectory(zipFile, targetFolder);

            Console.WriteLine($"Файл {zipFile} распакован в папку {targetFolder}");
            Console.ReadLine();
        }
    }
       


    
}
