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
            MapObject.Display display = obj.display;
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write(display.character);
        }
        public static void ClearObj(MapObject obj, MapObject.Position pos)
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write(' ');
        }
        public static void Refresh(MapHandler.Map themap)
        {
            char[,] buffer = new char[themap.sizex+1,themap.sizey+1];
            foreach (MapObject obj in themap.MapObjectList)
            {
                buffer[obj.position.x,obj.position.y] = obj.display.character;
            }
            for (int posx = 0; posx <= themap.sizex; posx++) // Iterates through each position (posx,posy) in the map
            {
                for (int posy = 0; posy <= themap.sizey; posy++)
                {              
                    Console.SetCursorPosition(posx, posy);
                    Console.Write(buffer[posx, posy]);
                    
          
                }
            }

            
               

        }
    }
}
