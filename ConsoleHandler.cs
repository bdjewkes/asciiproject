using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIGame
{
    class ConsoleHandler
    {
        public static void Initialize()
        {
            Console.CursorVisible=false ;
        }
        public static void Draw(int x, int y, MapObject.Icon icon)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(icon.character);
        }
    }
}
