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
        public static MapObject.Position MovePlayer(MapObject obj, string direction)
        {
            MapObject.Position origin = MapObject.GetPosition(obj);
            MapObject.Position newpos;
            switch (direction)
            {
                case "Up":
                    newpos = MapObject.Up(obj);
                    break;
                case "Down":
                    newpos = MapObject.Down(obj);
                    break;
                case "Left":
                    newpos = MapObject.Left(obj);
                    break;
                case "Right":
                    newpos = MapObject.Right(obj);
                    break;
                default:
                    newpos = origin;
                    break;
            }
            MapObject.Move(obj, newpos);
            return newpos;
        }
    }
}
