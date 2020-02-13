using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake {
    public enum CrawlResult {
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

        internal void Die() {
            foreach (Point segment in Body) {
                segment.Undraw();
            }
        }

        private void KeyListener() {
            if (Console.KeyAvailable) {
                ConsoleKeyInfo info = Console.ReadKey(true);

                // Snake can't turn on opposite direction
                switch (info.Key) {
                    case ConsoleKey.NumPad8:
                    case ConsoleKey.UpArrow:
                        Direction = Direction == Direction.DOWN ? Direction.DOWN : Direction.UP;
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.DownArrow:
                        Direction = Direction == Direction.UP ? Direction.UP : Direction.DOWN;
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.LeftArrow:
                        Direction = Direction == Direction.RIGHT ? Direction.RIGHT : Direction.LEFT;
                        break;
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.RightArrow:
                        Direction = Direction == Direction.LEFT ? Direction.LEFT : Direction.RIGHT;
                        break;
                    default:
                        break;
                }
            }
        }

        public CrawlResult Crawl(Point food) {
            KeyListener();

            Point head = Body[0];
            Point tail = Body[Body.Count - 1];
            Body.Remove(head);

            Point neck = new Point(head.X, head.Y, head.Symbol, ConsoleColor.White);
            Body.Insert(0, neck);

            head.Shift(Direction);
            neck.Draw();

            if (Body.Exists(p => p.isSamePosition(head))) {
                Die();
                return CrawlResult.DEATH;
            } else if (head.isSamePosition(food)) {
                Body.Insert(0, head);
                return CrawlResult.FOOD;
            } else {
                tail.Undraw();
                Body.Insert(0, head);
                Body.Remove(tail);
                return CrawlResult.SAFE;
            }
        }
    }
}
