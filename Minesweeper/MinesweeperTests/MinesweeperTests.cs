using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
usi
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
