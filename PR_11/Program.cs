/************************************************************************************************/
/* Практическая работа №11                                                                      */
/* Выполнила: Корнеева В.Е., 2-ИСП                                                              */
/* Задание: Cоставить программу вывода текста на английском языке в порядке латинского алфавита */
/************************************************************************************************/
using System;

namespace PR_11
{
    internal class Program
    {
        static void Errors(Exception exception)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Упс.. ошибочка вышла: {exception.Message}");
        }
        static void Main(string[] args)
        {
            for (; ;)
            {
                try
                {
                    Console.Title = "Практическая работа №11";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Здравствуйте!");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Введите строку текста на английском языке:");
                    string text = Console.ReadLine();
                    char[] chars = text.ToCharArray();
                    bool hasDigits = false;
                    text = text.TrimStart(' '); //удаляет ведущие пробелы
                    if (text == String.Empty) 
                    {
                        throw new Exception("Вы ничего не ввели или текст указан некорректно");
                    }
                    foreach (char c in chars)
                    {
                        if ((c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я'))   //Проверка символа на введение букв кириллицы 
                        {
                            throw new Exception("Текст должен быть на английском языке");
                        }
                        if (Char.IsDigit(c)) //Проверка символа на то что он является десятичной цифрой
                        {
                            hasDigits = true;
                        }
                    }
                    if (hasDigits)
                    {
                        throw new Exception("Вы ввели число...");
                    }
                    string[] Mass = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Array.Sort(Mass); //Сортировка слов по алфавиту
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Слова в порядке алфавита: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (string word in Mass)
                    {
                        Console.WriteLine(word);
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Errors(ex);
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Хотите выполнить команду еще раз? \nНажмите Y для продолжение программы, иначе любую другую кнопку для завершения!");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    continue;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Программа завершена. \tДо свидания!");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
    


