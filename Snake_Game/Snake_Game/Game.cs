using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Game {
        static void DrawChar(int x, int y, char symbol) {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
        static void Main(string[] args) {
            DrawChar(1, 3, '*');
            DrawChar(4, 5, '#');

            Console.ReadLine();
        }
    }
}
