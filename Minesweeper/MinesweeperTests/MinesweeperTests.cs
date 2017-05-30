using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;
using System;

namespace MinesweeperTests {

    [TestClass]
    public class UnitTest1 {

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"Invalid size")]
        public void SizeOfGridIsIncorrect() {
            string input = "***";
            Map m = new Map(input,5,5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"Invalid map")]
        public void InvalidCharactersInInput() {
            string input = "*.*.*#...";
            Map m = new Map(input,3,3);
        }

        [TestMethod]
        public void MapIsValid() {
            string input = ".*..*.***";
            Map m = new Map(input,3,3);
        }

        [TestMethod]
        public void MapFromFileIsValid() {
            var m = Map.LoadMapFromFile(@"Resources\map1.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"Invalid size")]
        public void MapFromFileHasInvalidSize() {
            var m = Map.LoadMapFromFile(@"Resources\map2.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"Invalid map")]
        public void MapFromFileHasInvalidCharacters() {
            var m = Map.LoadMapFromFile(@"Resources\map3.txt");
        }

        [TestMethod]
        public void FilesHasTwoMaps() {
            var maps = Map.LoadMapFromFile(@"Resources\map4.txt");
            Assert.AreEqual(maps.Count,2);
        }

        [TestMethod]
        public void ParseMapReturnNoExceptions() {
            Map.ParseMap(new string[] { "2 2","..",".." });
        }
    }
}