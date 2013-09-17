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
        public static void Draw(MapObject obj)
        {
            MapObject.Position pos = obj.position;
            MapObject.Display display = MapObject.GetDisplay(obj);
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write(display.character);
        }
        public static void ClearObj(MapObject obj, MapObject.Position pos)
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write(' ');
        }
    }
}
