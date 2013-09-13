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
            MapHandler.Map amap = new MapHandler.Map();
            amap.name = "Test Map";
            MapHandler.Initialize(amap);
            Console.ReadKey(true);
        }
    }
}
