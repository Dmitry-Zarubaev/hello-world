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
            Point p1 = new Point(1, 3, '*');
            p1.Draw();

            Point p2 = new Point(4, 5, '#');
            p2.Draw();

            Console.ReadLine();
        }
    }
}
