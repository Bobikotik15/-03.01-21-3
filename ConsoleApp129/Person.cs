using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp129
{
    /// <summary>
    /// Класс персонажа с координатами X и Y наследуемый от MapObject
    /// </summary>
    internal class Person : MapObject
    {
        int pointX;
        int pointY;

        public Person(int X,int Y)
        {
            pointX = X; pointY = Y; 
        }
        /// <summary>
        /// Метод возращения символа
        /// </summary>
        /// <returns></returns>
        public override char Rendering_on_the_map()
        {
            return '☺';
        }
    }
    /// <summary>
    /// Представляет объект героя на карте
    /// </summary>
    internal class Hero : Person
    {
        /// <summary>
        /// Метод инициализирует новый экземпляр класса Hero с указанными координатами X и Y
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public Hero(int X, int Y) : base(X, Y)
        {

        }
        public override char Rendering_on_the_map()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return '☻';
        }
    }
    /// <summary>
    /// Представляет объект врага на карте
    /// </summary>
    internal class Enemy : Person
    {
        /// <summary>
        /// Метод инициализирует новый экземпляр класса Enemy с указанными координатами X и Y
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public Enemy(int X, int Y) : base(X, Y)
        {
        }
        public override char Rendering_on_the_map()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return base.Rendering_on_the_map();
        }
    }
    /// <summary>
    /// Представляет объект врага второго типа на карте
    /// </summary>
    internal class Enemy2 : Person
    {
        /// <summary>
        /// Метод инициализирует новый экземпляр класса Enemy с указанными координатами X и Y
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public Enemy2(int X, int Y) : base(X, Y)
        {
        }
        public override char Rendering_on_the_map()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            return base.Rendering_on_the_map();
        }
    }
    /// <summary>
    /// Представляет объект врага третьего типа на карте
    /// </summary>
    internal class Enemy3 : Person
    {
        /// <summary>
        /// Метод инициализирует новый экземпляр класса Enemy с указанными координатами X и Y
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public Enemy3(int X, int Y) : base(X, Y)
        {
        }
        public override char Rendering_on_the_map()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            return base.Rendering_on_the_map();
        }
    }
}
