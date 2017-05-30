using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Minesweeper {

    public class Map {

        public Map(string map,int width,int height) {
            ValidMap(map,width,height);
        }

        private bool ValidMap(string map,int width,int height) {
            if(width * height != map.Length)
                throw new ArgumentException("Invalid size");
            foreach(char c in map) {
                if(c != '.' && c != '*')
                    throw new ArgumentException("Invalid map");
            }
            return true;
        }

        public static Map ParseMap(string[] lines) {
            Regex r = new Regex(@"(\d+)\s+(\d+)");
            var matches = r.Match(lines[0]);

            var width = Convert.ToInt32( matches.Groups[1].Value);
            var height = Convert.ToInt32(matches.Groups[2].Value);

            var mapLayout = string.Join("",lines.ToList().Skip(1).ToArray());

            return new Map(string.Join("",mapLayout),width,height);
        }
    }
}