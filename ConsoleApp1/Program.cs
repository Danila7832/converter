using Converter;

class Programm
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите путь до файла, включая имя и тип");

        var filePath = Console.ReadLine();
        if (filePath != null && File.Exists(filePath) && !filePath.Equals(""))
        {
            new MainProgramm(filePath);
        }
        else
            Console.WriteLine("Вы ничего не ввели или файла по заданному пути не существует, программа завершена");
    }
}