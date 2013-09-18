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
  
        }
        [TestMethod]
        public void WallBehaviourTest()
        {
            MapHandler.Map.ActiveMap = new MapHandler.Map();
            MapObject topleft = MapObject.Wall();
            MapObject topright = MapObject.Wall();
            MapObject botleft = MapObject.Wall();
            MapObject botright = MapObject.Wall();
            MapHandler.Map.ActiveMap.MapObjectList.Add(topleft);
            MapHandler.Map.ActiveMap.MapObjectList.Add(topright);
            MapHandler.Map.ActiveMap.MapObjectList.Add(botleft);
            MapHandler.Map.ActiveMap.MapObjectList.Add(botright);
            topleft.Move(new MapObject.Position(0,0));
            Assert.AreEqual(topleft.position.x, 0);
            Assert.AreEqual(topleft.position.y, 0);
            topright.Move(new MapObject.Position(1,0));
            MapObject.Position tlr = topleft.Right();
            MapObject.Position tll = topright.Left();
            Assert.AreEqual(tlr.x, topright.position.x);
            Assert.AreEqual(tll.x, topleft.position.x);

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
