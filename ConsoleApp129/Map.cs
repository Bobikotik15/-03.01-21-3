using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp129
{
    internal class Map
    {
        private int enemyCount; //Переменная для отслеживания количества врагов

        Random rand = new Random();
        MapObject[,] map = new MapObject[25, 25]; // создание поля с размером 25 на 25

        /// <summary>
        /// Метод генерации карты
        /// </summary>
        public void Map_generation()
        {
            enemyCount = 0;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    int A = rand.Next(100);
                    map[i, j] = new Field();

                    if (A > 1 && A < 6)
                    {
                        map[i, j] = new Wall();
                    }
                    if (A < 1)
                    {
                        map[i, j] = new Enemy(i, j);
                        enemyCount++;// Увеличение счетчика врагов
                    }
                    if (A > 5 && A < 10)
                    {
                        map[i, j] = new Tree();
                    }
                    if (i == map.GetLength(0) / 2 && j == map.GetLength(1) / 2)
                    {
                        map[i, j] = new Hero(i, j);
                    }
                }
            }
        }
        /// <summary>
        /// Выводит карту на экран
        /// </summary>
        public void Drawing_the_map()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j].Rendering_on_the_map() + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Обновляет положение объектов на карте
        /// </summary>
        public void MovePersons()
        {
            MapObject[,] newMap = new MapObject[map.GetLength(0), map.GetLength(1)];

            Array.Copy(map, newMap, map.Length);

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] is Enemy)
                    {
                        int direction = rand.Next(4);

                        int newX = i, newY = j;
                        switch (direction)
                        {
                            case 0:
                                newX = (i - 1 + map.GetLength(0)) % map.GetLength(0);
                                break;
                            case 1:
                                newX = (i + 1) % map.GetLength(0);
                                break;
                            case 2:
                                newY = (j - 1 + map.GetLength(1)) % map.GetLength(1);
                                break;
                            case 3:
                                newY = (j + 1) % map.GetLength(1);
                                break;
                        }

                        if (newMap[newX, newY] is Field)
                        {
                            newMap[newX, newY] = map[i, j];
                            newMap[i, j] = new Field();
                        }
                    }
                }
            }

            Array.Copy(newMap, map, map.Length);
        }
        /// <summary>
        /// логика для получения выбора пользователя в меню
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public static void GetMenuChoice(int min, int max)
        {
            Menu menu = new Menu();
        }
        /// <summary>
        /// Перемещает объекты на карте в соответствии с нажатой клавишей на клавиатуре
        /// </summary>
        /// <param name="key"></param>
        public void MovePersons(ConsoleKey key)
        {
           
            MapObject[,] newMap = new MapObject[map.GetLength(0), map.GetLength(1)];
            Array.Copy(map, newMap, map.Length);
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (key != ConsoleKey.Escape) // при нажатии на Escape выход в главное меню без затрагивания обработкой исключений
                    {
                        if (map[i, j] is Hero)
                        {
                            int newX = i, newY = j;
                            switch (key)
                            {
                                case ConsoleKey.UpArrow:
                                    newX = (i - 1 + map.GetLength(0)) % map.GetLength(0);
                                    break;
                                case ConsoleKey.DownArrow:
                                    newX = (i + 1) % map.GetLength(0);
                                    break;
                                case ConsoleKey.LeftArrow:
                                    newY = (j - 1 + map.GetLength(1)) % map.GetLength(1);
                                    break;
                                case ConsoleKey.RightArrow:
                                    newY = (j + 1) % map.GetLength(1);
                                break;
                                default:
                                    try
                                    {
                                        throw new ButtonException("");
                                    }
                                    catch(ButtonException ex)
                                    {
                                        Console.Clear();
                                        Console.WriteLine(ex.Message); // Вывод сообщения об ошибке в исключении  
                                        Console.ReadLine();
                                    }
                                break;
                            }

                            if (newMap[newX, newY] is Field) // проверка типа объекта
                            {
                                newMap[newX, newY] = map[i, j];
                                newMap[i, j] = new Field();
                            }
                            if (newMap[newX, newY] is Enemy)
                            {
                                EnemyMenu.ShowEnemyInteractionMenu();
                                if (EnemyMenu.EnemyMenuChoice == 1)
                                {
                                    newMap[newX, newY] = new Field(); // После атаки вражеский объект исчезает с поля
                                    enemyCount--; // Уменьшение счетчика количества врагов
                                }
                                else if (EnemyMenu.EnemyMenuChoice == 0) ; // Проверка выбора побега, чтобы враг не исчезал в последовательности атака - сбежать
                            }
                        }
                    }
                }
            }
            Array.Copy(newMap, map, map.Length);
            if (enemyCount == 0)// Генерация новой карты
            {
                Map_generation();
            }
        }
    }
}

