using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    public class Food : Point {
        // borders
        int Left, Right, Top, Bottom;
        Snake Snake;

        public Food(int left, int right, int top, int bottom, Snake snake, char symbol) {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
            Snake = snake;
            Symbol = symbol;
        }

        public Point Craft() {
            Random random = new Random();
            while (true) {
                int x = random.Next(Left, Right);
                int y = random.Next(Top, Bottom);
                bool collision = Snake.Body.Exists(p => p.X == x && p.Y == y);

                if (!collision) {
                    X = x;
                    Y = y;
                    break;
                }
            }
            Draw();
            return getBase();
        }
    }
}
