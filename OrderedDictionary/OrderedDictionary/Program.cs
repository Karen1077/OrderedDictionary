using OrderedDictionary;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderedDictionary = new OrderedDictionary<string, int>
            {
                // Добавляем элементы в OrderedDictionary
                { "One", 1 },
                { "Two", 2 },
                { "Three", 3 },
                { "Four", 4 },
                { "Five", 5 },
                { "Six", 6 },
                { "Seven", 7 }
              };

            // Используем ключи для доступа к значениям
            Console.WriteLine(orderedDictionary["One"]); // Выводит 1
            Console.WriteLine(orderedDictionary["Three"]); // Выводит 3
            Console.WriteLine(orderedDictionary["Five"]); // Выводит 5
            Console.WriteLine(orderedDictionary["Seven"]); // Выводит 7
            Console.WriteLine();

            // Итерация по OrderedDictionary
            foreach (var kvp in orderedDictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            // Выводит:
            // One: 1
            // Two: 2
            // Three: 3
            // Four: 4
            // Five: 5
            // Six: 6
            // Seven: 7
            Console.WriteLine();

            // Проверка наличия ключа
            Console.WriteLine(orderedDictionary.ContainsKey("Three")); // Выводит True
            Console.WriteLine(orderedDictionary.ContainsKey("Eleven")); // Выводит False
            Console.WriteLine();

            // Удаление элемента из OrderedDictionary
            orderedDictionary.Remove("Six");

            // Проверка изменений
            foreach (var kvp in orderedDictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            // Выводит:
            // One: 1
            // Two: 2
            // Three: 3
            // Four: 4
            // Five: 5
            // Seven: 7
            Console.WriteLine();

            // Очистка OrderedDictionary
            orderedDictionary.Clear();

            Console.ReadLine();
        }
    }
}
