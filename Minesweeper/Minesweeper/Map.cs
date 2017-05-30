using System;

namespace Minesweeper {

    public class Map {

        public Map(string map,int size) {
            if(map.Length != size * size || !ValidMap(map)) {
                throw new ArgumentException("Invalid input");
            }
            
        }

        private bool ValidMap(string map) {
            foreach(char c in map) {
                if(c != '.' && c != '*')
                    return false;
            }
            return true;
        }
    }
}