using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp129
{
    internal class ButtonException : Exception
    {
        public ButtonException(string message) : base("Отсутствует метод обработки нажатой клавиши")
        {
        }
    }
}
