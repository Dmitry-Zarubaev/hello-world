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

            // OOP example
            Point p1 = new Point {X = 1, Y = 3, Symbol = '*'};
            p1.Draw();

            Point p2 = new Point {X = 4, Y = 5, Symbol = '#'};
            p2.Draw();

            Console.ReadLine();
        }
    }
}
