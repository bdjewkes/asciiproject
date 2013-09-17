using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIGame
{
    class PlayerController
    {
        public static MapObject theplayer;
        public static MapObject.Position startpos = new MapObject.Position(4,4);
        public static MapObject.Position MovePlayer(MapObject theplayer, string direction)
        {
            MapObject.Position origin = theplayer.position;
            MapObject.Position newpos;
            switch (direction)
            {
                case "Up":
                    newpos = theplayer.Up();
                    break;
                case "Down":
                    newpos = theplayer.Down();
                    break;
                case "Left":
                    newpos = theplayer.Left();
                    break;
                case "Right":
                    newpos = theplayer.Right();
                    break;
                default:
                    newpos = origin;
                    break;
            }
            theplayer.Move(newpos);
            return newpos;
        }
    }
}
