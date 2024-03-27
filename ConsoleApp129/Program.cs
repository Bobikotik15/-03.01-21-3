using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp129
{
    /// <summary>
    /// Класс представляющий программу
    /// </summary>
    class Program
    {
        /// <summary>
        /// Точка входа в программу. Основной метод программы, запускающий игровой цикл
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Map map = new Map();
            ConsoleKeyInfo key;
            do
            {
                Menu.DisplayOption();
                map.Map_generation();
                key = Console.ReadKey(true);

                while (key.Key != ConsoleKey.Escape)
                {
                    map.Drawing_the_map();
                    key = Console.ReadKey();
                    map.MovePersons(key.Key);
                    map.MovePersons();
                    Console.Clear();

                    if (key.Key == ConsoleKey.F5)  // Обрабатка нажатия клавиши F5
                    {
                        int totalPoints = map.TotalPoints;
                        File.WriteResultsToFile(totalPoints);
                        File.ReadMaxPointsFromFile();
                    }
                    if (key.Key == ConsoleKey.F6) // Обрабатка нажатия клавиши F6
                    {
                        File.ReadMaxPointsFromFile();
                    }
                }
            }
            while (true);
        }
    }
}  