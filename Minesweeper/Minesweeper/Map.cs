using System;

namespace Minesweeper {

    public class Map {

        public Map(string map,int width,int height) {
            ValidMap(map,width,height);
        }

        private bool ValidMap(string map, int width,int height) {
            if(width * height != map.Length)
                throw new ArgumentException("Invalid size");
            foreach(char c in map) {
                if(c != '.' && c != '*')
                    throw new ArgumentException("Invalid map");
            }
            return true;
        }
    }
}