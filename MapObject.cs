using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIGame
{
    public class MapObject 
    {
        static MapObject() {  }
        
/*
 *  All MapObjects have a position(x,y).  
 *  Position is accessed with MapObject.GetPosition(obj)
 *  Position is modified with MapObject.Move(obj,position)
 */ 
        public struct Position 
        {
            public int x;
            public int y;
            public Position(int locx, int locy)
            {
                this.x = locx;
                this.y = locy;
            }
       }
       protected Position position;
       public static Position GetPosition(MapObject obj)
       {
          return obj.position;
       }

/*
 * The GameObject's display information.  Currently only includes 'character', the ASCII character that will display on 
 * the console.  Add color or any other display information to this struc
 */
        public struct Display 
        {
            public char character;
            public Display(char newcharacter)
            {
                this.character = newcharacter;
            }
          }
        protected Display display;
        public static Display GetDisplay(MapObject obj)
        {
            return obj.display;
        }
/* 
 *  MOEntityFramework
 */
      public static MapObject Wall()
      {
          MapObject m = new MapObject();
          m.display = new Display('#');
          return m;
      }
      public static MapObject Floor()
      {
          MapObject m = new MapObject();
          m.display = new  Display('X');
          return m;
      }
/*
 *  MapObject Position methods:  
 *  
 *   Move(MapObject,Position) sets the position of a MapObject to the position entered as the second argument, and returns
 *      the new position
 *      
 *  Left(MO), Right(MO), Up(MO), and Down(MO) returns the position one step in the respective direction of the MO 
 */
 
      public static Position Move(MapObject obj, Position newpos)
      {
          obj.position = newpos;
          return obj.position;
      }
      public static Position Left(MapObject obj)
      {
          Position newpos = new Position(obj.position.x--, obj.position.y);
          return newpos;
      }
      public static Position Right(MapObject obj)
      {
          Position newpos = new Position(obj.position.x++, obj.position.y);
          return newpos;
      }
      public static Position Up(MapObject obj)
      {
          Position newpos = new Position(obj.position.x, obj.position.y--);
          return newpos;
      }
      public static Position Down(MapObject obj)
      {
          Position newpos = new Position(obj.position.x, obj.position.y++);
          return newpos;
      }
    } 
}
