using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {

    public class Rectangle : PlainLine {
        protected Point BottomRight;
        protected RectangleType Type = RectangleType.CUSTOM;
        public enum RectangleType {
            CUSTOM,
            FULL_WINDOW
        }

        public Rectangle(char symbol, RectangleType type = RectangleType.CUSTOM) : base(new Point(Console.WindowLeft, Console.WindowTop, symbol)) {
            Type = type;
        }

        public Rectangle(Point topLeft, Point bottomRight) : base(0, topLeft) {
            BottomRight = bottomRight;
        }

        public void DrawRectangle() {
            switch (Type) {
                case RectangleType.CUSTOM:
                    DrawHorizontal(BottomRight.X);
                    DrawVertical(BottomRight.Y);
                    SetPosition(BottomRight.X, Y);
                    DrawVertical();
                    SetPosition(X, BottomRight.Y);
                    DrawHorizontal(BottomRight.X);
                    break;
                case RectangleType.FULL_WINDOW:
                    Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
                    int width = Console.WindowWidth - 1;
                    int height = Console.WindowHeight - 2;
                    DrawHorizontal(width);
                    DrawVertical(height);
                    SetPosition(width, 0);
                    DrawVertical(height);
                    SetPosition(0, height);
                    DrawHorizontal(width);
                    break;
            }
        }
    }
}
