using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASCIIGame;
using System.Linq;
namespace ASCIIGameTests
{
    [TestClass]
    public class MapTests
    {
        [TestMethod]
        public void TestMapList()
        {
            MapHandler.Map.ActiveMap = new MapHandler.Map();
            MapHandler.Map.ActiveMap.Initialize();
            Assert.AreEqual(MapHandler.Map.ActiveMap.sizex, 10);
            Assert.AreEqual(MapHandler.Map.ActiveMap.sizey, 10);
            Assert.IsNotNull(MapHandler.Map.ActiveMap.MapObjectList);
            foreach (var obj in MapHandler.Map.ActiveMap.MapObjectList)
            {
                Assert.IsNotNull(obj.position);
            }
            MapHandler.Map.ActiveMap.Refresh();
         
           
            
        }

        
        
        
        
        /*public void TestWall()
        {
            var map = new MapHandler.Map();
            MapHandler.Initialize(map);
            var leftWalls = MapHandler.ActiveMap.Where(x=>{
                var pos = MapObject.GetPosition(x);
                return pos.x==0;
            });
            foreach (var maybeWall in leftWalls){
                Assert.AreEqual(MapObject.GetPosition(maybeWall),
                    MapObject.Left(maybeWall));
            }*/
        
    }
}
