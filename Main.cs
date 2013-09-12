using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleHandler;
using MapHandler;

namespace Main
{
    class Program
    {
        public static void Main(string[] args)
        {
            ConsoleHandler.ConsoleHandler.Initialize();
            MapHandler.MapHandler.Map amap = new MapHandler.MapHandler.Map();
            amap.name = "Test Map";
            MapHandler.MapHandler.Initialize(amap);
           
            
            
            
           
        }
    }
}
