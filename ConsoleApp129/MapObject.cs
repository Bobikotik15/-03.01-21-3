using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp129
 {   
    /// <summary>
    /// Это абстрактный класс с методом Rendering_on_the_map(), который возвращает символ, представляющий объект на карте
    /// </summary>
    internal abstract class MapObject
    {
        /// <summary>
        /// Метод возращения символа
        /// </summary>
        /// <returns></returns>
        public abstract char Rendering_on_the_map();
    }
    /// <summary>
    /// Представляет объект стены на картеля наследуемый от MapObject
    /// </summary>
    internal class Wall : MapObject
    {
        public override char Rendering_on_the_map()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            return '+';
        }
    }
    /// <summary>
    /// Представляет объект поля на карте, наследуемый от MapObject
    /// </summary>
    internal class Field : MapObject
    {
        public override char Rendering_on_the_map()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            return '.';
        }
    }
    /// <summary>
    /// Представляет объект дерева на карте, наследуемый от MapObject
    /// </summary>
    internal class Tree : MapObject
    {
        public override char Rendering_on_the_map()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return 'T';
        }
    }


}
