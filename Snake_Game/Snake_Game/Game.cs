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
            int left = 2, right = 60, top = 2, bottom = 30;


            Console.WindowHeight = bottom;
            Console.WindowWidth = right;
            Console.CursorVisible = false;
            bool gameover = false;
            int sensivity = 250;
            int level = 1;
            int score = 0;

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

            Snake snake = new Snake(new Point(10, 10, '@'), 5, Direction.LEFT);
            Food food = new Food(left, right - 1, top, bottom - 2, snake, 'Ж');
            Point foodPlace = food.Craft();

            while (!gameover) {

                switch (snake.Crawl(foodPlace)) {
                    case CrawlResult.DEATH:
                        food.Undraw();
                        gameover = true;
                        break;
                    case CrawlResult.FOOD:
                        score++;
                        if (sensivity > 100 && score % 3 == 0) {
                            level++;
                            sensivity -= 25;
                        }
                        foodPlace = food.Craft();
                        break;
                    case CrawlResult.SAFE:
                        break;
                }

                Thread.Sleep(sensivity);
            }
            string messageGameOver = "GAME OVER";
            Console.SetCursorPosition((Console.WindowWidth - 2 - messageGameOver.Length) / 2, Console.WindowHeight / 2);
            Console.WriteLine(messageGameOver);
            string messageScore = $"score: {score}, level: {level}";
            Console.SetCursorPosition((Console.WindowWidth - 2 - messageScore.Length) / 2, (Console.WindowHeight / 2) + 1);
            Console.WriteLine(messageScore);
            Console.ReadLine();
        }
    }
}
