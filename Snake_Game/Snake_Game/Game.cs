using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake {
    public enum Direction {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    class Game {
        static void Main(string[] args) {
            Console.WindowHeight = 40;
            Console.WindowWidth = 150;
            Console.CursorVisible = false;
            bool gameover = false;
            int sensivity = 250;

            while (true) {
                if (Console.KeyAvailable) {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter) {
                        break;
                    }
                }
                Thread.Sleep(500);
            }

            // OOP example
            Rectangle borders = new Rectangle('+', Rectangle.RectangleType.FULL_WINDOW);
            borders.DrawRectangle();

            Snake snake = new Snake(new Point(10, 10, '@'), 5, Direction.RIGHT);
            Food food = new Food(2, 148, 3, 39, snake, '+');

            while (!gameover) {


                switch (snake.plotNextCrawl()) {
                    case NextCrawl.DEATH:
                        snake.Kill();
                        gameover = true;
                        break;
                    case NextCrawl.FOOD:
                        snake.Crawl(true);
                        break;
                    case NextCrawl.SAFE:
                        snake.Crawl();
                        break;
                }

                Thread.Sleep(sensivity);
            }
        }
    }
}
