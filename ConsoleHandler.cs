﻿using System;
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
            MapObject.Position pos = MapObject.GetPosition(obj);
            MapObject.Display display = MapObject.GetDisplay(obj);
            Console.SetCursorPosition(pos.x, pos.y);
            Console.WriteLine(display.character);
        }
    }
}
