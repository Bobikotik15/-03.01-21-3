using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp129
{
    /// <summary>
    /// Класс для работы с картой и объектами на ней
    /// </summary>
    internal class Map
    {
        private MapObjectsMovement objectsMovement = new MapObjectsMovement();

        private int enemyCount; //Переменная для отслеживания количества врагов
        private int enemyCount2; //Переменная для отслеживания количества врагов
        private int enemyCount3; //Переменная для отслеживания количества врагов

        Random rand = new Random();
        MapObject[,] map = new MapObject[25, 25]; // создание поля с размером 25 на 25

        /// <summary>
        /// Метод генерации карты
        /// </summary>
        public void Map_generation()
        {
            enemyCount = 0;
            enemyCount2 = 0;
            enemyCount3 = 0;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    int A = rand.Next(100);
                    int B = rand.Next(100);
                    int C = rand.Next(100);

                    map[i, j] = new Field();

                    if (A > 1 && A < 6)
                    {
                        map[i, j] = new Wall();
                    }

                    if (A > 5 && A < 10)
                    {
                        map[i, j] = new Tree();
                    }

                    if (i == map.GetLength(0) / 2 && j == map.GetLength(1) / 2)
                    {
                        map[i, j] = new Hero(i, j);
                    }

                    if (A < 1)
                    {
                        map[i, j] = new Enemy(i, j);
                        enemyCount++;// Увеличение счетчика врагов
                    }
                    if (B < 1)
                    {
                           map[i, j] = new Enemy2(i, j);

                        enemyCount2++;// Увеличение счетчика врагов
                    }
                    if (C < 1)
                    {
                        map[i, j] = new Enemy3(i, j);

                        enemyCount3++;// Увеличение счетчика врагов
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
            objectsMovement.MovePersons(map);
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
            MapObjectsMovement objectsMovement = new MapObjectsMovement();
            objectsMovement.MovePersons(key, map, ref enemyCount, ref enemyCount2, ref enemyCount3);
            if (enemyCount == 0 && enemyCount2 == 0 && enemyCount3 == 0)// Генерация новой карты
            {
                Console.WriteLine("Все противники побеждены! Переход на следующий уровень...");
                Map_generation();
            }
        }
    }
}

