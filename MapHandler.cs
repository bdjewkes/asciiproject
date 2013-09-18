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
            public string name = "Default";
            public int sizex = 10;
            public int sizey = 10;
            public List<MapObject> MapObjectList = new List<MapObject>();

            /*
             *     Map.Initialize() takes an instance of the map class, and initializes it with a list of
             * MapObjects.  Initialize looks at each possible x,y position up to sizex,sizey.  For each x,y position, 
             * Initialize creates a a list of MapObjects 'here' with CreateMapObject, sets the position of each MapObject
             *         to x,y, and adds the contents of 'here' to actmap's MapList.
             */

            public void Initialize()
            {
                for (int posx = 0; posx <= this.sizex; posx++) // Iterates through each position (posx,posy) in the map
                {
                    for (int posy = 0; posy <= this.sizey; posy++)
                    {
                        // Instructions for each (posx,posy) go HERE:
                        List<MapObject> here = this.CreateMapObject(posx, posy);
                        foreach (MapObject obj in here)
                        {
                            MapObject.Position pos = new MapObject.Position(posx, posy);
                            MapObject.Place(obj, pos);
                            this.MapObjectList.Add(obj);
                        }
                    }
                }
            }

            /*  
             * Refresh does a complete redraw of the map.  This is a fast but visually distracting method, and should be 
             * avoided when possible
             */
            public static Map ActiveMap;
            public List<MapObject> CreateMapObject(int x, int y)
            {
                List<MapObject> here = new List<MapObject>();
                if (CheckEdge(x, y, this))
                {
                    MapObject obj = MapObject.Wall();
                    here.Add(obj);
                }
                else
                {
                    MapObject obj = MapObject.Floor();
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

            public List<MapObject> GetPositionContents(MapObject.Position pos)
            {
                List<MapObject> here = new List<MapObject>();
                foreach(MapObject obj in this.MapObjectList)
                {
                    if (obj.position.x == pos.x && pos.y == obj.position.y) { here.Add(obj); }
                    else { continue; }
                }
                return here;
            }

        }

       

        public static bool CheckEdge(int x, int y, Map themap)
        {
            if(x==0 || y==0 || x==themap.sizex || y==themap.sizey) { return true; }
            else { return false; }
        }
   
    }
}

