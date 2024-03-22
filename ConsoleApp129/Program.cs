using System;
using System.Collections.Generic;
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

            do
            {
                Menu.DisplayOption();
                Map map = new Map();
                map.Map_generation();
                ConsoleKeyInfo key = Console.ReadKey();

                while (key.Key != ConsoleKey.Escape)
                {
                    map.Drawing_the_map();
                    key = Console.ReadKey();
                    map.MovePersons(key.Key);
                    map.MovePersons();
                    Console.Clear();
                }
            }
            while (true);
        }
    }
}  