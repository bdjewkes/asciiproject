using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIGame
/*
 *   MapObjects are any object on the map, including terrain.  
 *   All MapObjects have a Location, set with Location(x,y), and an Icon, set with Icon(ASCII character).
 */

{
    public class MapObject 
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
      public void Move(MapObject obj,Position newpos)
      {
          obj.position = newpos;
      }
      public void Left(MapObject obj)
      { 
          Move(obj,new Position(obj.position.x--,obj.position.y));
      }
      public void Right(MapObject obj)
      {
          Move(obj, new Position(obj.position.x++, obj.position.y));
      }
      public void Up(MapObject obj) 
      {
          Move(obj, new Position(obj.position.x, obj.position.y--));
      }
      public void Down(MapObject obj)
      {
          Move(obj, new Position(obj.position.x, obj.position.y++));
      }
     
    }
    public class Wall : MapObject
    {
        public Wall()
        {
            this.icon = new Icon('#');
        }
    }
    public class Floor : MapObject
    {
        public Floor()
        {
            this.icon = new Icon('X');
        }
    }
}
