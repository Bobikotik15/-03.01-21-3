using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp129
{
    /// <summary>
    /// Класс работы с файлом
    /// </summary>
    internal class File
    {
        /// <summary>
        /// Метод записи результата в файл
        /// </summary>
        /// <param name="totalPoints"></param>
        public static void WriteResultsToFile(int totalPoints)
        {
            string path = @"D:\практика уп 03.01\задача\ПП для практики 2\raiting.txt";

            using (StreamWriter sw = System.IO.File.AppendText(path))
            {
                sw.WriteLine($"Total points: {totalPoints}");
            }
        }
        /// <summary>
        /// Метод чтения максимального результата из файл
        /// </summary>
        public static void ReadMaxPointsFromFile()
        {
            string path = @"D:\практика уп 03.01\задача\ПП для практики 2\raiting.txt";
            string[] lines = System.IO.File.ReadAllLines(path);
            int maxPoints = 0;

            foreach (string line in lines)
            {
                if (line.Contains("Total points:"))
                {
                    int points = int.Parse(line.Split(':')[1].Trim());
                    if (points > maxPoints)
                    {
                        maxPoints = points;
                    }
                }
            }
            Console.WriteLine($"Максимальное количество баллов: {maxPoints}");
        }
    }
}
