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
       public string type;
       
/*
 * The GameObject's display information.  Currently includes 'character', the ASCII character that will display on 
 * the console, and layer.  Layers are checked by the ConsoleHandler in the event of multiple objects in the same
 * coordinates.  Currently a layer value of 1 will overwrite anything of 0, but not vice versa
 * 
 * Add color or any other display information to this struc
 */
        public struct Display 
        {
            public char character;
            public int layer;
            public Display(char newcharacter, int Layer)
            {
                this.character = newcharacter;
                this.layer = Layer;
            }
          }
        public Display display { get; private set; }
     
   
        public static void Update(List<MapObject> activeobjects)
        {
            foreach(MapObject obj in activeobjects)
            {
                if (obj.type == "wall")
                {
                    obj.display = obj.Wall_Behaviour();
                }
            }
        }



/* 
 *  MOEntityFramework - tbd
 */
/*
 *  MapObject Properties
 */
        public bool density; //MapObjects can not enter positions occupied by dense mapobjects
        public static MapObject Wall()
        {
            MapObject m = new MapObject();
            m.type = "wall";
            m.display = new Display('#', 0);
            m.density = true;
            return m;
        }
        public static MapObject Floor()
        {
            MapObject m = new MapObject();
            m.display = new  Display('X',0);
            m.density = false;
            return m;
        }
        public static MapObject Player()
        {
            MapObject m = new MapObject();
            m.display = new Display(Convert.ToChar(1),1);
            m.density = false;
            return m;
        }
       
/*
 *  MapObject Position methods:  
 *  
 *   mobj.Move(Position) sets the position of a MapObject to the position entered as the second argument, and returns
 *      the new position.  Move queues an update so that the change in position will show on the map without a full
 *      refresh. 
 *      
 *  Place(MapObject,Position) sets the position of a MapObject, but does not require a positive CheckEntry.  Consider 
 *      getting rid of it.
 *      
 *  mobj.Left(), mobj.Right(), mobj.Up(), and mobj.Down() returns the position one step in the respective direction 
 *  of the mobj 
 */
 
        public Position Move(Position newpos)
        {
            if (CheckEntry(newpos)) 
            {
                this.position = newpos;
                return this.position;
            }
            else { return this.position; }
        }  
        public static void Place(MapObject obj,Position pos)  //######## slated for removal, make sure that won't break everything
        {
            obj.position = pos;
        }
        public static bool CheckEntry(Position newpos)  // Returns true if it is okay to enter, and false if not
        {
            if (newpos.x < 0 || newpos.y < 0 ||
                newpos.x > MapHandler.Map.ActiveMap.sizex || newpos.y > MapHandler.Map.ActiveMap.sizey) { return false; }
            else
            {
                List<MapObject> here = MapHandler.Map.ActiveMap.GetPositionContents(newpos);
                foreach (MapObject obj in here)
                {
                    if (obj.density) { return false; }
                }
            }
            return true;
           
         
          
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

    public Display Wall_Behaviour()
    {
        Display disp;
        bool left = MapHandler.Map.ActiveMap.CheckForObject(this.Left(), this);
        bool right = MapHandler.Map.ActiveMap.CheckForObject(this.Right(), this);
        bool up = MapHandler.Map.ActiveMap.CheckForObject(this.Up(), this);
        bool down = MapHandler.Map.ActiveMap.CheckForObject(this.Down(), this);
       
        //cross
        if (down && right && left && up)
        {
            disp = new Display((char)206, 1);
            return disp;
        }
        //T
        if (down && right && left)
        {
            disp = new Display((char)203, 1);
            return disp;
        }
        //upside down T
        if (up && right && left)
        {
            disp = new Display((char)206, 1);
            return disp;
        }
        // --|
        if (up && down && left)
        {
            disp = new Display((char)185, 1);
            return disp;
        }
        // |--
        if (up && down && left)
        {
            disp = new Display((char)204, 1);
            return disp;
        }
        if (down && right)
        {
            disp = new Display((char)201, 1);
            return disp;
        }
        if (down && left)
        {
            disp = new Display((char)187, 1);
            return disp;
        }
        if (up && right)
        {
            disp = new Display((char)200, 1);
            return disp;
        }
        if (up && left)
        {
            disp = new Display((char)188, 1);
            return disp;
        }
        if (down || up)
        {
            disp = new Display((char) 186,1);
            return disp;
        }
        if (left || right)
        {
            disp = new Display((char) 205, 1);
            return disp;
        }
        else
        {
            disp = new Display('#', 0);
        }
        return disp;
    }

   


    } 
}
