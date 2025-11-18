
using System.Globalization;

namespace IHaveArgument
{
    // Суть этого задания - научиться работать с аргументами командной строки.
    // Программа принимает параметры: --name <имя>, --sum <число>, --currency <код>.
    // Если аргумент отсутствует - используем значение по умолчанию.
    // Для чисел используем TryParse, чтобы не было ошибок.
    // Для валюты используем CultureInfo - чтобы число выводилось в формате выбранной страны.
    class Program
    {
        static void Main(string[] args)
        {
            string name = "User";
            decimal sum = 100m;
            string currencyCode = "USD";

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "--name":
                        if (i + 1 < args.Length) name = args[i + 1];
                        break;
                    case "--sum":
                        if (i + 1 < args.Length && decimal.TryParse(args[i + 1], out decimal parsedSum))
                            sum = parsedSum;
                        break;
                    case "--currency":
                        if (i + 1 < args.Length) currencyCode = args[i + 1];
                        break;
                }
            }

            CultureInfo culture;
            try
            {
                culture = new CultureInfo(currencyCode);
            }
            catch
            {
                Console.WriteLine("Некорректный код культуры. Используем en-US.");
                culture = new CultureInfo("en-US");
            }

            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Сумма: {sum.ToString("C", culture)}");
        }
    }
}