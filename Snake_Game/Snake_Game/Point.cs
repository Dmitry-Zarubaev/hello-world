using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Point {
        public int X;
        public int Y;
        public char Symbol;

        public void Draw() {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }
    }
}
