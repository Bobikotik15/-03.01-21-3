using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp129
{
    /// <summary>
    /// Класс для работы с меню
    /// </summary>
    internal class Menu
    {
        /// <summary>
        /// Отображает опции меню
        /// </summary>
        public static void DisplayOption()
        {
            MainMenu.DisplayMenu();
        }
    }
    /// <summary>
    /// Класс для работы с главным меню. Наследуется от класса Menu
    /// </summary>
    internal class MainMenu : Menu
    {
        private static int currentChoice = 1; ////Объявление переменной для хранения текущего выбранного пункта меню
        /// <summary>
        /// Отображает главное меню
        /// </summary>
        public static void DisplayMenu()
        {
            Console.WriteLine("Главное меню");

            string[] menuItems = { "Играть", "Помощь", "Выход" }; //

            for (int i = 1; i <= menuItems.Length; i++)
            {
                if (i == currentChoice)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Установка зеленого цвета для текущего выбранного пункта
                    Console.WriteLine($"* {i}. {menuItems[i - 1]}"); // Вывод текущего пункта с маркером *
                    Console.ResetColor(); 
                }
                else
                {
                    Console.ResetColor(); // Сброс цвета перед выводом других пунктов меню
                    Console.WriteLine($"  {i}. {menuItems[i - 1]}"); //Остальные пункты без маркера
                }
            }

            ConsoleKey key = Console.ReadKey().Key; 

            if (key == ConsoleKey.UpArrow) 
            {
                currentChoice = Math.Max(1, currentChoice - 1); // Обработка нажатия клавиши вверх
            }
            else if (key == ConsoleKey.DownArrow)
            {
                currentChoice = Math.Min(menuItems.Length, currentChoice + 1); // Обработка нажатия клавиши вниз
            }

            if (key == ConsoleKey.Enter)
            {
                switch (currentChoice)
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
                        Console.WriteLine("☺ - враг, может двигаться только по одной клетке за ход. При убийстве дает 100 баллов");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("☺ - враг, может двигаться прыжками. При убийстве дает 200 баллов");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("☺ - враг, может двигаеться по диагонали и прыжками. При убийстве дает 300 баллов");
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
            else 
            {
                Console.Clear();
                DisplayMenu();
            }
        }
        /// <summary>
        /// Метод возвращения в главное меню
        /// </summary>
            public static void ReturnToMainMenu()
            {
            DisplayMenu();
            }
    }
    /// <summary>
    /// Абстрактный класс для работы с меню взаимодействия с врагом. Наследуется от класса Menu
    /// </summary>
    internal abstract class EnemyMenu : Menu 
    {
        private static int currentChoice = 1; //Объявление переменной для хранения текущего выбранного пункта меню

        public static int EnemyMenuChoice; // Переменная для хранения выбора пользователя

        /// <summary>
        /// Отображение меню взаимодействия с врагом
        /// </summary>
        public static void ShowEnemyInteractionMenu()
        {

            Console.Clear();
            Console.Write("\n Столкновение с врагом! Выберите действие: \n");

            string[] menuItems = { "Атака", "Убежать", "Сдаться" };

            for (int i = 1; i <= menuItems.Length; i++)
            {
                if (i == currentChoice)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"* {menuItems[i - 1]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine($"  {menuItems[i - 1]}");
                }
            }

            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.UpArrow)
            {
                currentChoice = Math.Max(1, currentChoice - 1);
            }
            else if (key == ConsoleKey.DownArrow)
            {
                currentChoice = Math.Min(menuItems.Length, currentChoice + 1);
            }

            if (key == ConsoleKey.Enter)
            {
                switch (currentChoice)
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
            else
            {
                Console.Clear();
                ShowEnemyInteractionMenu();
            }
        }
    }
}
