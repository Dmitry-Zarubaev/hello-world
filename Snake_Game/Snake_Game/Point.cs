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
            // Allow to shift a point through the window borders plus symbolic rectangle
            switch (direction) {
                case Direction.UP:
                    if (Y - 1 == 0) {
                        Y = Console.WindowHeight - 3;
                    } else {
                        Y--;
                    }
                    break;
                case Direction.DOWN:
                    if (Y + 1 == Console.WindowHeight - 2) {
                        Y = 1;
                    } else {
                        Y++;
                    }
                    break;
                case Direction.LEFT:
                    if (X - 1 == 0) {
                        X = Console.WindowWidth - 2;
                    } else {
                        X--;
                    }
                    break;
                case Direction.RIGHT:
                    if (X + 1 >= Console.WindowWidth - 2) {
                        X = 1;
                    } else {
                        X++;
                    }
                    break;
            }
            Draw();
        }

        public bool isSamePosition(Point point) {
            return point.X == X && point.Y == Y;
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
