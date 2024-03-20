using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp129

{
    internal  class Menu
    {
        public static void DisplayOption()
        {
            MainMenu.DisplayMenu();
        }

        public static int GetMenuChoice(int min, int max)
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

    internal class MainMenu : Menu
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("Главное меню");
            Console.WriteLine("1. Играть");
            Console.WriteLine("2. Помощь");
            Console.WriteLine("3. Выход");

            int choice = GetMenuChoice(1, 3);

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Начало игры");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Помощь по игре:");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("☺ - игрок");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("☺ - враг");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("+ - стены");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(". - поле");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("T - деревья");
                    Console.ResetColor();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
        public static void ReturnToMainMenu()
        {
            DisplayMenu();
        }
    }
    internal abstract class EnemyMenu : Menu 
    {
        public static int EnemyMenuChoice; // Переменная для хранения выбора пользователя

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
                    EnemyMenu.EnemyMenuChoice = 1;
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Вы убежали!");
                    EnemyMenu.EnemyMenuChoice = 0;
                    Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Вы сдались врагу! Игра закончена");
                    Console.ReadLine();
                    MainMenu mainMenu = new MainMenu();
                    Console.Clear();
                    MainMenu.ReturnToMainMenu();
                    MainMenu.DisplayMenu();
                    break;
                default:
                    Console.WriteLine("Неправильный выбор!");
                    break;
            }
        }
    }
}
