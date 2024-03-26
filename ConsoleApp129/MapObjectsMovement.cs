using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp129
{
    /// <summary>
    /// Класс перемещений объектов на карте
    /// </summary>
    internal class MapObjectsMovement
    {
        private Random rand = new Random();

        /// <summary>
        /// Обновляет положение объектов на карте
        /// </summary>
        public void MovePersons(MapObject[,] map)
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

                    if (map[i, j] is Enemy2)
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
                                newY = (j + 1) % map.GetLength(0);
                                break;
                            case 4:
                                newY = (j + 0) % map.GetLength(0);
                                break;
                            case 5:
                                newX = (j + 5) % map.GetLength(0);
                                break;
                            case 6:
                                newY = (j + 5) % map.GetLength(0);
                                break;
                        }

                        if (newMap[newX, newY] is Field)
                        {
                            newMap[newX, newY] = map[i, j];
                            newMap[i, j] = new Field();
                        }
                    }
                    if (map[i, j] is Enemy3)
                    {
                        int direction = rand.Next(4);

                        int newX = i, newY = j;

                        switch (direction)
                        {
                            case 0: // Движение вверх-влево
                                newX = (i - 1 + map.GetLength(0)) % map.GetLength(0);
                                newY = (i - 1 + map.GetLength(1)) % map.GetLength(1);
                                break;
                            case 1: // Движение вверх-вправо
                                newX = (i - 1 + map.GetLength(0)) % map.GetLength(0);
                                newX = (i + 1) % map.GetLength(1);
                                break;
                            case 2: // Движение вниз-влево
                                newX = (i + 1) % map.GetLength(0);
                                newY = (j - 1 + map.GetLength(1)) % map.GetLength(1);
                                break;
                            case 3: // Движение вниз-вправо
                                newX = (j + 1) % map.GetLength(0);
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
        /// Перемещает объекты на карте в соответствии с нажатой клавишей на клавиатуре
        /// </summary>
        /// <param name="key"></param>
        public void MovePersons(ConsoleKey key, MapObject[,] map, ref int enemyCount, ref int enemyCount2, ref int enemyCount3,ref int totalPoints)
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
                                    catch (ButtonException ex)
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
                                    totalPoints += 100;
                                }
                                else if (EnemyMenu.EnemyMenuChoice == 0) ; // Проверка выбора побега, чтобы враг не исчезал в последовательности атака - сбежать
                            }
                            if (newMap[newX, newY] is Enemy2)
                            {
                                EnemyMenu.ShowEnemyInteractionMenu();
                                if (EnemyMenu.EnemyMenuChoice == 1)
                                {
                                    newMap[newX, newY] = new Field(); // После атаки вражеский объект исчезает с поля
                                    enemyCount2--; // Уменьшение счетчика количества врагов
                                    totalPoints += 200;
                                }
                                else if (EnemyMenu.EnemyMenuChoice == 0) ; // Проверка выбора побега, чтобы враг не исчезал в последовательности атака - сбежать
                            }
                            if (newMap[newX, newY] is Enemy3)
                            {
                                EnemyMenu.ShowEnemyInteractionMenu();
                                if (EnemyMenu.EnemyMenuChoice == 1)
                                {
                                    newMap[newX, newY] = new Field(); // После атаки вражеский объект исчезает с поля
                                    enemyCount3--; // Уменьшение счетчика количества врагов
                                    totalPoints += 300;
                                }
                                else if (EnemyMenu.EnemyMenuChoice == 0); // Проверка выбора побега, чтобы враг не исчезал в последовательности атака - сбежать
                            }
                        }
                    }
                }
            }
            Array.Copy(newMap, map, map.Length);
        }
    }
}
