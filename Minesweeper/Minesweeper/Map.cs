using System;

namespace Minesweeper {

    public class Map {

        public Map(string map,int size) {
            ValidMap(map,size);
        }

        private bool ValidMap(string map, int size) {
            if(Math.Pow(size,2) != map.Length)
                throw new ArgumentException("Invalid size");
            foreach(char c in map) {
                if(c != '.' && c != '*')
                    throw new ArgumentException("Invalid map");
            }
            return true;
        }
    }
}