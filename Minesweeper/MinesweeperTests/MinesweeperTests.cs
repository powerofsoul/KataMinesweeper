using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;
using System.Collections.Generic;

namespace MinesweeperTests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        [ExpectedException (typeof(ArgumentException),"Invalid size")]
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
        [DeploymentItem(@"myfile.txt", "out")]
        public void MapFromFileIsValid() {
            Map m = Map.LoadMapFromFile(@"targetFolder\source");
        }

        [TestMethod]
        public void ParseMapReturnNoExceptions() {
            Map.ParseMap(new string[] { "2 2","..",".." });
        }
    }
}
