//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp129
//{
//    internal class MainMenu
//    {
//        public void DisplayMenu()
//        {
//            Console.WriteLine("Главное меню");
//            Console.WriteLine("1. Играть");
//            Console.WriteLine("2. Помощь");
//            Console.WriteLine("3. Выход");

//            int choice = GetMenuChoice(1, 3);
//            switch (choice)
//            {
//                case 1:
//                    Console.WriteLine("Начало игры");
//                    break;
//                case 2:
//                    Console.WriteLine("Помощь по игре");
//                    break;
//                case 3:
//                    Environment.Exit(0);
//                    break;
//            }
//        }
//        private int GetMenuChoice(int min, int max)
//        {
//            int choice;
//            while (true)
//            {
//                Console.Write("Сделайте выбор: ");
//                if (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max)
//                {
//                    Console.WriteLine("Введите число от 1 до 3");
//                }
//                else
//                {
//                    return choice;
//                }
//            }
//        }
//    }
//}
