using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Minesweeper {

    public class Map {
        public int Width;
        public int Height;
        public string MapLayout;

        public Map(string mapLayout,int width,int height) {
            ValidMap(mapLayout,width,height);
            Width = width;
            Height = height;
            MapLayout = mapLayout;
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

        public static List<Map> LoadMapFromFile(string path) {
            var fileContent = System.IO.File.ReadLines(path).ToArray();
            List<Map> maps = new List<Map>();
            int i = 0;
            while(i < fileContent.Length) {
                if(string.IsNullOrWhiteSpace(fileContent[i])) {
                    i++;
                    continue;
                }
                Regex r = new Regex(@"(\d+)\s+");
                var matches = r.Match(fileContent[i]);
                
                var height = Convert.ToInt32(matches.Groups[1].Value);
                if(height == 0) {
                    i++;
                    continue;
                }
                maps.Add(ParseMap(fileContent.Skip(i).Take(height+1).ToArray()));
                i = i + height + 1;
            }
            return maps;

        }

        public static Map ParseMap(string[] lines) {
            Regex r = new Regex(@"(\d+)\s+(\d+)");
            var matches = r.Match(lines[0]);

            var width = Convert.ToInt32(matches.Groups[1].Value);
            var height = Convert.ToInt32(matches.Groups[2].Value);

            var mapLayout = string.Join("",lines.ToList().Skip(1).ToArray());

            return new Map(string.Join("",mapLayout),width,height);
        }
    }
}