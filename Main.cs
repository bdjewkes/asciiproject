using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIGame
{
    class Program
    {
        public static void Main(string[] args)
        {
            ConsoleHandler.Initialize();
            MapHandler.Map.ActiveMap = new MapHandler.Map();
            MapHandler.Map.ActiveMap.name = "Test Map";
            MapHandler.Map.ActiveMap.sizex = 10;
            MapHandler.Map.ActiveMap.sizey = 10;
            MapHandler.Map.ActiveMap.Initialize();
            MapHandler.Map.ActiveMap.Refresh();
            bool quit = false;
            while (!quit)
            {
                ConsoleKeyInfo keyinput = Console.ReadKey(true);
                bool cont = KeyInput(keyinput);
                if (!cont) { quit = true; }
                MapHandler.Update();
            }
        }
        public static bool KeyInput(ConsoleKeyInfo keyinput)
        {
            switch (keyinput.Key)
            {
                case ConsoleKey.Escape:
                    return false;
                case ConsoleKey.UpArrow:
                    PlayerController.MovePlayer(PlayerController.theplayer, "Up");
                    break;
                case ConsoleKey.DownArrow:
                    PlayerController.MovePlayer(PlayerController.theplayer, "Down");
                    break;
                case ConsoleKey.LeftArrow:
                    PlayerController.MovePlayer(PlayerController.theplayer, "Left");
                    break;
                case ConsoleKey.RightArrow:
                    PlayerController.MovePlayer(PlayerController.theplayer, "Right");
                    break;
                default:
                    break;     
            }
            return true;

        }
    }
}
