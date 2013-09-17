using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIGame
{

/*
 *
 * 
 * Initialize(Map) populates the ActiveMap list based on the properties defined for that map.
 *     
 * 
 */
    public class MapHandler
    {
        public class Map
        {
           public string name;
           public int sizex;
           public int sizey;
           public List<MapObject> MapObjectList;
        }
       
        public static Map ActiveMap;
        
/*
 *     Initialize(themap) takes an instance of the map class, and initializes the ActiveMap actmap with a list of
 *         MapObjects.  Initialize looks at each possible x,y position up to sizex,sizey.  For each x,y position, 
 *         Initialize creates a a list of MapObjects 'here' with CreateMapObject, sets the position of each MapObject
 *         to x,y, and adds the contents of 'here' to actmap's MapList.
 */
        public static void Initialize(Map themap)
        {
            Console.Title = themap.name;
            List<MapObject> MOList = new List<MapObject>();
            for (int posx = 0; posx <= themap.sizex; posx++) // Iterates through each position (posx,posy) in the map
            {
                for (int posy = 0; posy <= themap.sizey; posy++)
                {
                    // Instructions for each (posx,posy) go HERE:
                    List<MapObject> here=CreateMapObject(posx,posy,themap);
                    foreach (MapObject obj in here)
                    {                  
                        MapObject.Position pos = new MapObject.Position(posx,posy);
                        MapObject.Place(obj,pos);
                        MOList.Add(obj);
                    }
                }           
            }
            themap.MapObjectList = MOList;
        }

/*  
 * Refresh does a complete redraw of the map.  This is a fast but visually distracting method, and should be 
 * avoided when possible
 */ 

        public static void Refresh()
        {
            Console.Clear();
            foreach (MapObject obj in ActiveMap.MapObjectList)
            {
                ConsoleHandler.Draw(obj);
            }
        }
/*  
 *  Whenever an object moves, it adds a MapUpdate to the MapHandler.update list.  Every frame, the
 *  updates are run through the ConsoleHandler.
 *  
 *  a MapUpdate references a MapObject, and its former position.  
 *  the updatelist is filled with the updates to be made each frame, using QueueUpdate(obj,formerposition)
 *  Each frame Update() is called.  For each update in queue it: 1) Clears the old display from the console and
 *  2) draws the new display.  ########TO IMPLEMENT: check to see if there is another mapobject at that location,
 *  and draw that instead of simply clearing.  #### ALSO SOME KIND OF LAYER MANAGEMENT?
 */
        public struct MapUpdate
        {
            public MapObject obj;
            public MapObject.Position oldposition;
            public MapUpdate(MapObject Obj, MapObject.Position OldPosition)
            {
                obj = Obj;
                oldposition = OldPosition;
            }
        }
        protected static List<MapUpdate> updatelist = new List<MapUpdate>();
        public static void QueueUpdate(MapObject obj, MapObject.Position pos)
        {
            MapUpdate theupdate = new MapUpdate(obj,pos);
            updatelist.Add(theupdate);
        }
        public static void Update()
        {
            if (updatelist.Count() == 0) { return; } 
            else 
            {
                foreach (MapUpdate theupdate in updatelist)
                {
                ConsoleHandler.ClearObj(theupdate.obj,theupdate.oldposition);
                ConsoleHandler.Draw(theupdate.obj);
                }
                updatelist.Clear();
            }
        }
        


        public static List<MapObject> CreateMapObject(int x,int y, Map themap)
        {
                List<MapObject> here = new List<MapObject>();
                if (CheckEdge(x, y, themap))
                {
                    MapObject obj = MapObject.Wall();
                    here.Add(obj); 
                }
                if (x == PlayerController.startpos.x && y == PlayerController.startpos.y)
                {
                    MapObject obj = MapObject.Player();
                    PlayerController.theplayer = obj;
                    here.Add(obj);       
                }
                return here;
        }
        public static bool CheckEdge(int x, int y, Map themap)
        {
            if(x==0 || y==0 || x==themap.sizex || y==themap.sizey) { return true; }
            else { return false; }
        }
   
    }
}

