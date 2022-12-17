using System;
using System.Runtime.ConstrainedExecution;

namespace Converter
{
    public class MainProgramm
    {
        internal static bool exitFlag;

        public MainProgramm(String filePath)
        {
            Console.Clear();
            Console.WriteLine("Для сохранения файла в формате json, txt или xml - нажмите F1. Для завершения программы нажмите ESC");

            FileReader fileReader = new FileReader(filePath);
            foreach (Car car in fileReader.getCars()) { 
                Console.WriteLine(car.ToString());
            }
            
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey();

                if (key.Key.Equals(ConsoleKey.F1))
                {
                    Console.Clear();
                    Console.WriteLine("Введите путь до сохраняемого файла, включая имя и тип");
                    
                    filePath = Console.ReadLine();
                    if (filePath != null && !File.Exists(filePath) && !filePath.Equals(""))
                    {
                        new FileSaver(filePath, fileReader.getCars());
                    }
                    else
                        Console.WriteLine("Вы ничего не ввели или такой файл уже существует. Попробуйте снова");
                }

            } while (!key.Key.Equals(ConsoleKey.Escape) && !exitFlag);
        }
    }
}