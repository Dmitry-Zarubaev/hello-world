using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake {
    public enum NextCrawl {
        SAFE,
        FOOD,
        DEATH
    }
    public class Snake : Point {
        public List<Point> Body = new List<Point>();
        private Direction Direction;

        public Snake(Point head, int length, Direction direction) : base(x: head.X, y: head.Y, symbol: head.Symbol, color: ConsoleColor.Red) {
            Direction = direction;

            Body.Add(getBase()); // A snake begins from a head

            switch (direction) {
                case Direction.UP:
                    /*
                        H X:Y
                        b
                        b
                        b X:Y+length
                     */
                    for (int y = Y + 1; y <= Y + length; y++) {
                        Body.Add(new Point(X, y, Symbol));
                    }
                    break;
                case Direction.DOWN:
                    /*
                        b X:Y-length
                        b
                        b
                        H X:Y
                     */
                    for (int y = Y - 1; y >= Y - length; y--) {
                        Body.Add(new Point(X, y, Symbol));
                    }
                    break;
                case Direction.RIGHT:
                    /*
                            b  b   b   H
                         X-length:Y     X:Y
                     */
                    for (int x = X - 1; x >= X - length; x--) {
                        Body.Add(new Point(x, Y, Symbol));
                    }
                    break;
                case Direction.LEFT:
                    /*
                            H  b   b   b
                         X:Y     X+length:Y
                     */
                    for (int x = X + 1; x <= X + length; x++) {
                        Body.Add(new Point(x, Y, Symbol));
                    }
                    break;

            }

            foreach (Point point in Body) {
                point.Draw();
            }
        }

        internal void Kill() {
            foreach (Point segment in Body) {
                segment.Undraw();
            }
        }

        internal NextCrawl plotNextCrawl() {
            throw new NotImplementedException();
        }

        private void KeyListener() {
            if (Console.KeyAvailable) {
                ConsoleKeyInfo info = Console.ReadKey();

                switch (info.Key) {
                    case ConsoleKey.NumPad8:
                    case ConsoleKey.UpArrow:
                        Direction = Direction.UP;
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.DownArrow:
                        Direction = Direction.DOWN;
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.LeftArrow:
                        Direction = Direction.LEFT;
                        break;
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.RightArrow:
                        Direction = Direction.RIGHT;
                        break;
                    default:
                        break;
                }
            }
        }

        public void Crawl(bool grow = false) {
            Point head = Body[0];
            int headX = head.X;
            int headY = head.Y;
            head.Shift(Direction);
            Body.Remove(head);

            if (!grow) {
                Point tail = Body[Body.Count - 1];
                tail.Undraw();
                Body.Remove(tail);
            }

            Point neck = new Point(headX, headY, head.Symbol);
            neck.Draw();
            Body.Insert(0, neck);
            Body.Insert(0, head);
        }
    }
}
