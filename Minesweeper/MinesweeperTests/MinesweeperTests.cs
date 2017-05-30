using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;

namespace MinesweeperTests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        [ExpectedException (typeof(ArgumentException),"Invalid input")]
        public void SizeOfGridIsIncorrect() {
            string input = "***";
            Map m = new Map(input);
        }
    }
}
