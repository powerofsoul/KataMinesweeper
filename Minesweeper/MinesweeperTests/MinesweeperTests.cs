using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;
using System;

namespace MinesweeperTests {

    [TestClass]
    public class UnitTest1 {

        [TestCategory("MapCreation")]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"Invalid size")]
        public void SizeOfGridIsIncorrect() {
            string input = "***";
            Map m = new Map(input,5,5);
        }

        [TestCategory("MapCreation")]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"Invalid map")]
        public void InvalidCharactersInInput() {
            string input = "*.*.*#...";
            Map m = new Map(input,3,3);
        }

        [TestCategory("MapCreation")]
        [TestMethod]
        public void MapIsValid() {
            string input = ".*..*.***";
            Map m = new Map(input,3,3);
        }

        [TestCategory("LoadFromFile")]
        [TestMethod]
        public void MapFromFileIsValid() {
            var m = Map.LoadMapFromFile(@"Resources\map1.txt");
        }

        [TestCategory("LoadFromFile")]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"Invalid size")]
        public void MapFromFileHasInvalidSize() {
            var m = Map.LoadMapFromFile(@"Resources\map2.txt");
        }

        [TestCategory("LoadFromFile")]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"Invalid map")]
        public void MapFromFileHasInvalidCharacters() {
            var m = Map.LoadMapFromFile(@"Resources\map3.txt");
        }

        [TestCategory("LoadFromFile")]
        [TestMethod]
        public void FilesHasTwoMaps() {
            var maps = Map.LoadMapFromFile(@"Resources\map4.txt");
            Assert.AreEqual(maps.Count,2);
        }

        [TestCategory("LoadFromFile")]
        [TestMethod]
        public void ZeroMapIsSkipedFromLoadMapFromFile() {
            var maps = Map.LoadMapFromFile(@"Resources\map5.txt");
            Assert.AreEqual(1,maps.Count);
        }

        [TestCategory("MapCreation")]
        [TestMethod]
        public void ParseMapReturnNoExceptions() {
            Map.ParseMap(new string[] { "2 2","..",".." });
        }

        [TestCategory("MapCreation")]
        [TestMethod]
        public void MapHaveCorrectWidth() {
            var map = Map.ParseMap(new string[] { "3 2","...","..." });
            Assert.AreEqual(3,map.Width);
        }

        [TestCategory("MapCreation")]
        [TestMethod]
        public void MapHaveCorrectHeight() {
            var map = Map.ParseMap(new string[] { "3 1","..." });
            Assert.AreEqual(1,map.Height);
        }

        [TestCategory("MapCreation")]
        [TestMethod]
        public void MapHaveCorrectMapLayout() {
            var map = Map.ParseMap(new string[] { "2 2",".*","**" });
            Assert.AreEqual(".***",map.MapLayout);
        }

        [TestMethod]
        public void GetFiledReturnCorrectAnswer() {
            var map = new Map("..*...**.",3,3);

            Assert.AreEqual('.',map.GetField(1,1));
            Assert.AreEqual('*',map.GetField(0,2));
            Assert.AreEqual('.',map.GetField(2,2));
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentException),"Invalid position")]
        public void GetFieldReturnExceptionForInvalidPosition() {
            var map = new Map("....",2,2);
            map.GetField(3,2);
        }
        
        [TestMethod]
        public void SetFieldSetTheCorrectPosition()
        {
            var map = new Map("....",2,2);
            map.SetField('*',0,0);
            Assert.AreEqual('*',map.GetField(0,0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"Invalid position")]
        public void SetFieldSetTheCorrectPosition()
        {
            var map = new Map("....",2,4);
        }
    }
}