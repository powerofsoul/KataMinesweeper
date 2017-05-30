using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;

namespace MinesweeperTests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        [ExpectedException (typeof(ArgumentException),"Invalid size")]
        public void SizeOfGridIsIncorrect() {
            string input = "***";
            int size = 10;
            Map m = new Map(input,10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"Invalid map")]
        public void InvalidCharactersInInput() {
            string input = "*.*.*#...";
            int size = 3;
            Map m = new Map(input,3);
        }

        [TestMethod]
        public void MapIsValid() {
            string input = ".*..*.***";
            int size = 3;
            Map m = new Map(input,3);
        }
    }
}
