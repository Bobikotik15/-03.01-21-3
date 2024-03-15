using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp129
{
    class Program
{
    static void Main(string[] args)
    {
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
    }
}
            