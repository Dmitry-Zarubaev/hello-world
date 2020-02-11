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
            PlainLine line = new PlainLine(new Point(5, 5, '#'), Console.WindowWidth - 15);
            line.DrawHorizontal();
            line.SetLine(new Point(5, 5, '#'), Console.WindowHeight - 15);
            line.DrawVertical();

            Console.ReadLine();
        }
    }
}
