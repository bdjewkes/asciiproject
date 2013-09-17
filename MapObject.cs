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
       public Position position { get; private set; }
       
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
        public Display display { get; private set; }
     
    
/* 
 *  MOEntityFramework - tbd
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
      public static MapObject Player()
      {
          MapObject m = new MapObject();
          m.display = new Display('@');
          return m;
      }
       
/*
 *  MapObject Position methods:  
 *  
 *   Move(MapObject,Position) sets the position of a MapObject to the position entered as the second argument, and returns
 *      the new position.  Move queues an update so that the change in position will show on the map without a full
 *      refresh. 
 *      
 *  Place(MapObject,Position) sets the position of a MapObject, but DOES NOT queue an update.  ONLY use Place
 *      if it is followed by a refresh, such as during initialization.
 *      
 *  Left(MO), Right(MO), Up(MO), and Down(MO) returns the position one step in the respective direction of the MO 
 */
 
      public Position Move(Position newpos)
      {
          if (CheckEntry(newpos)) 
          {
              Position oldpos = this.position;
              this.position = newpos;
              return this.position;
          }
          else { return this.position; }
      }  
      public static void Place(MapObject obj,Position pos)
      {
          obj.position = pos;
      }
      public static bool CheckEntry(Position newpos)  // Returns true if it is okay to enter, and false if not
      {
          if (newpos.x < 0 ||  newpos.y < 0 || 
              newpos.x > MapHandler.Map.ActiveMap.sizex || newpos.y > MapHandler.Map.ActiveMap.sizey) { return false; }
          else { return true; }
      }

      public Position Left()
      {
          Position newpos = new Position(position.x-1, position.y);
          return newpos;
      }
      public Position Right()
      {
          Position newpos = new Position(position.x+1, position.y);
          return newpos;
      }
      public Position Up()
      {
          Position newpos = new Position(position.x,position.y-1);
          return newpos;
      }
      public Position Down()
      {
          Position newpos = new Position(position.x, position.y+1);
          return newpos;
      }
    } 
}
