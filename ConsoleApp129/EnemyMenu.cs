using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp129
{
    internal class EnemyMenu
    {
        public static void ShowEnemyInteractionMenu()
        {
            Console.WriteLine("1. Атака");
            Console.WriteLine("2. Убежать");
            Console.WriteLine("3. Сдаться");
            Console.Write("Выберите действие: ");

            int choice = GetMenuChoice(1, 3);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Вы атаковали врага!");
                    break;
                case 2:
                    Console.WriteLine("Вы убежали!");
                    break;
                case 3:
                    Console.WriteLine("Вы сдались врагу! Игра закончена");
                    break;
                default:
                    Console.WriteLine("Неправильный выбор!");
                    break;
            }
        }
        private static int GetMenuChoice(int min, int max)
        {
            int choice;
            while (true)
            {
                Console.Write("Сделайте выбор: ");
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max)
                {
                    Console.WriteLine("Введите число от 1 до 3");
                }
                else
                {
                    return choice;
                }
            }
        }
    }
}
