using System;

namespace Minesweeper {

    public class Map {

        public Map(string map,int size) {
            if(map.Length != size * size) {
                throw new ArgumentException("Invalid input");
            }
        }
    }
}