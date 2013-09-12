using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapHandler
{

/*
 *  MapHandler keeps track of where shit is at.
 * 
 * Initialize(Map) takes a Map struct and populates the ActiveMap array
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
        public static List<MapObjects.MapObjects>[,] ActiveMap; // The Active Map is the map is the array that is viewed by the ConsoleHandler
        
/*
 *     Initialize(themap) takes an instance of the Map class, and loads it into an array.
 *     The array is sized to Map.themap.sizex and Map.themap.sizey, and assigns each position a char.
 */
        public static void Initialize(Map themap)
        {
            ActiveMap = new List<MapObjects.MapObjects>[themap.sizex, themap.sizey];  // initialize the array, at size specified by themap
            Console.Title = themap.name;                        
            for (int posx = 0; posx < themap.sizex; posx++) // Iterates through each position (posx,posy) in the map
            {
                for (int posy = 0; posy < themap.sizey; posy++)
                {
                    // Instructions for each (posx,posy) go HERE:
                    List<MapObjects.MapObjects> here=GetMapObjects(posx,posy,themap);
                    ActiveMap[posx, posy] = here;
                    Console.SetCursorPosition(posx, posy);
                    Console.WriteLine(here[0].icon.character);
                }           
            }   
            Console.ReadKey(true);
            
   
        } 
        public static List<MapObjects.MapObjects> GetMapObjects(int x,int y, Map themap)
        {
                List<MapObjects.MapObjects> here = new List<MapObjects.MapObjects>();
                if (CheckEdge(x, y, themap)){ here.Add(new MapObjects.Wall()); }
                else { here.Add(new MapObjects.Floor()); }
                return here;

        }
        public static bool CheckEdge(int x, int y, Map themap)
        {
            if(x==0 || y==0 || x==themap.sizex-1 || y==themap.sizey-1) { return true; }
            else { return false; }
        }
   
    }
 


    class ConsoleHandler
/*      The ConsoleHandler takes the information from the map, and draws what is in the player's view
 */
    
    
    {
        public static bool quit = false;
        public static int cursx; //  cursx and cursy represent the position of the CursorPosition
        public static int cursy; //
       
        public static void Update()
        {
            Console.Title = "The ASCII GAME!";
            while (quit == false)
            {
                Console.Clear();
                Console.SetCursorPosition(cursx, cursy);
                Console.Write("@");
                Console.SetCursorPosition(1,1);
                ConsoleKeyInfo keypress = Console.ReadKey(true);
                KeyInput(keypress);
                Console.Clear();
            }

        }
       
        static void KeyInput(ConsoleKeyInfo keypress)
        {
            switch (keypress.Key)
                {
                    case ConsoleKey.Escape:           
                        quit = true;    
                        break;
                    case ConsoleKey.UpArrow:
                        if(cursy>0)
                            cursy--;
                        break;
                    case ConsoleKey.DownArrow:
                        if(cursy<24)
                           cursy++;
                           break;
                    case ConsoleKey.LeftArrow:
                        if(cursy>0)
                            cursy--;
                            break;
                    case ConsoleKey.RightArrow:
                        if(cursy<78)
                            cursy++;
                            break;
                    default:
                        break;
                }
            }

        }
}

