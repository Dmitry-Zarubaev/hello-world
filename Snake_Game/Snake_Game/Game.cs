using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Game {
        static void Main(string[] args) {
            // Procedure example
            //DrawChar(1, 3, '*');
            //DrawChar(4, 5, '#');
            List<Point> pointsList = new List<Point>();
            char[] chars = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '=' };

            // OOP example
            for (int i = 0; i < chars.Length; i++) {
                Point point = new Point(i, i, chars.ElementAt(i));
                point.Draw();
                pointsList.Add(point);
            }

            Console.ReadLine();
        }
    }
}
