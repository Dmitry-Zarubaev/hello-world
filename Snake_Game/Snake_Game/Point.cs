using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    public class Point {
        public int X;
        public int Y;
        public char Symbol;
        public ConsoleColor Color = ConsoleColor.White;

        public Point() {}

        public Point(int x, int y, char symbol) {
            SetPosition(x, y);
            Symbol = symbol;
        }

        public Point(int x, int y, char symbol, ConsoleColor color) {
            SetPosition(x, y);
            Symbol = symbol;
            Color = color;
        }

        public Point(Point point) {
            X = point.X;
            Y = point.Y;
            Symbol = point.Symbol;
            Color = point.Color;
        }

        internal void SetPosition(int x, int y) {
            X = x;
            Y = y;
        }

        protected Point getBase() {
            return this;
        }

        public void Shift(Direction direction) {
            Undraw();
            switch (direction) {
                case Direction.UP:
                    Y--;
                    break;
                case Direction.DOWN:
                    Y++;
                    break;
                case Direction.LEFT:
                    X--;
                    break;
                case Direction.RIGHT:
                    X++;
                    break;
            }
            Draw();
        }

        public void Move(int x, int y) {
            if (x != X || y != Y) {
                Undraw();
                SetPosition(x, y);
                Draw();
            }
        }

        public void Undraw() {
            Console.SetCursorPosition(X, Y);
            Console.Write('\u0000');
        }

        public void Draw() {
            Console.SetCursorPosition(X, Y);
            if (Color.Equals(null) || Color == ConsoleColor.White) {
                Console.Write(Symbol);
            } else {
                Console.ForegroundColor = Color;
                Console.Write(Symbol);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
