using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIGame
{

/*
 *  MapHandler keeps track of where shit is at.
 * 
 * Initialize(Map) populates the ActiveMap list based on the properties defined for that map.
 *     
 * 
 */
    class MapHandler
    {
        public class Map
        {
           public string name="Default Map";
           public int sizex=10;
           public int sizey = 10;
        }
        public static List<MapObject> ActiveMap; // The Active Map is the map is the array that is viewed by the ConsoleHandler
        
/*
 *     Initialize(themap) creates an instance of the map class, and initializes ActiveMap with a list of MapObjects.
 *         Initialize looks at each possible x,y position up to sizex,sizey, and creates MapObjects with 
 *         that Position 
  
 */
        public static void Initialize(Map themap)
        {
            ActiveMap = new List<MapObject>(); // Initializes a list of MapObjects
            Console.Title = themap.name;                        
            for (int posx = 0; posx < themap.sizex; posx++) // Iterates through each position (posx,posy) in the map
            {
                for (int posy = 0; posy < themap.sizey; posy++)
                {
                    // Instructions for each (posx,posy) go HERE:
                    List<MapObject> here=GetMapObjects(posx,posy,themap);
                    foreach (MapObject obj in here)
                    {                  
                        obj.position = new MapObject.Position(posx,posy);
                        ActiveMap.Add(obj);
                    }
                }           
            }   
        }
        public static void Update()
        {
            foreach (MapObject obj in ActiveMap)
            {
              ConsoleHandler.Draw(obj.position, obj.icon);
            }
        }
        public static List<MapObject> GetMapObjects(int x,int y, Map themap)
        {
                List<MapObject> here = new List<MapObject>();
                if (CheckEdge(x, y, themap)){ here.Add(new Wall()); }
                else { here.Add(new Floor()); }
                return here;

        }
        public static bool CheckEdge(int x, int y, Map themap)
        {
            if(x==0 || y==0 || x==themap.sizex-1 || y==themap.sizey-1) { return true; }
            else { return false; }
        }
   
    }
}

