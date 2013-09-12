using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapObjects
/*
 *   MapObjects are any object on the map, including terrain.  
 *   All MapObjects have a Location, set with Location(x,y), and an Icon, set with Icon(ASCII character).
 */

{
    public class MapObjects 
    {
        public struct Position // A MapObject's x,y coordinates
        {
            public int x;
            public int y;
            public Position(int locx, int locy)
            {
                this.x = locx;
                this.y = locy;
            }
        }
        public struct Icon
        {
            public char character;
            public Icon(char newcharacter)
            {
                this.character = newcharacter;
            }
        }
      public Position position;
      public Icon icon;
      public void Move(MapObjects obj,Position newpos)
      {
          MapHandler.MapHandler.ActiveMap[obj.position.x, obj.position.y].Remove(obj);
          MapHandler.MapHandler.ActiveMap[newpos.x, newpos.y].Add(obj);
      }
      public void Left(MapObjects obj)
      { 
          obj.position.x--;
          
      }
      public void Right(MapObjects obj)
      { 
          obj.position.x++; 
      }
      public void Up(MapObjects obj) 
      { 
          obj.position.y--; 
      }
      public void Down(MapObjects obj)
      { 
          obj.position.y++;
      }
     
    }
    public class Wall : MapObjects
    {
        public Wall()
        {
            this.icon = new Icon('#');
        }
    }
    public class Floor : MapObjects
    {
        public Floor()
        {
            this.icon = new Icon('X');
        }
    }
}
