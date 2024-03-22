using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp129
{
    /// <summary>
    /// Класс обработки исключения, возникающее при попытке обработать нажатие кнопки без соответствующего метода обработки
    /// </summary>
    internal class ButtonException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса ButtonException с указанным сообщением
        /// </summary>
        /// <param name="message"></param>
        public ButtonException(string message) : base("Отсутствует метод обработки нажатой клавиши")
        {
        }
    }
}
