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
        public static void Draw(MapObject.Position pos, MapObject.Icon icon)
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.WriteLine(icon.character);
        }
    }
}
