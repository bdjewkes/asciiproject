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

/*
 *  Console updating and buffer behavior:
 *  
 *  ConsoleHandler.Refresh(Map) loads the display.character of every MapObject in the map's object list into the 
 *  char[,] buffer.  The buffer is then compared the char[,] last_frame.  If last_state is empty, the buffer is written
 *  to the screen.  Otherwise, a comparison is made between buffer and last_frame, and any changes are written.
 */

        public static char[,] last_frame;
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
                    if (ConsoleHandler.last_frame == null)
                    {
                        Console.SetCursorPosition(posx, posy);
                        Console.Write(buffer[posx, posy]);
                    }
                    else
                    {
                        if (ConsoleHandler.last_frame[posx, posy] != buffer[posx, posy])
                        {
                            Console.SetCursorPosition(posx, posy);
                            Console.Write(buffer[posx, posy]);
                        }
                    }   
                }
            }
            ConsoleHandler.last_frame = buffer;
            
            
               

        }
    }
}
