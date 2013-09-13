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
 * Initialize(Map) takes a  Map and populates the ActiveMap array
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
        public static List<MapObject>[,] ActiveMap; // The Active Map is the map is the array that is viewed by the ConsoleHandler
        
/*
 *     Initialize(themap) takes an instance of the Map class, and loads it into an array.
 *     The array is sized to Map.themap.sizex and Map.themap.sizey
 */
        public static void Initialize(Map themap)
        {
            ActiveMap = new List<MapObject>[themap.sizex, themap.sizey];  // initialize the array, at size specified by themap
            Console.Title = themap.name;                        
            for (int posx = 0; posx < themap.sizex; posx++) // Iterates through each position (posx,posy) in the map
            {
                for (int posy = 0; posy < themap.sizey; posy++)
                {
                    // Instructions for each (posx,posy) go HERE:
                    List<MapObject> here=GetMapObjects(posx,posy,themap);
                    ActiveMap[posx, posy] = here;
                    ConsoleHandler.Draw(posx,posy,here[0].icon);
                }           
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

