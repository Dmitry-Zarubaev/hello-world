using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    public class PlainLine : Point {
        protected int Length;

        public PlainLine(Point initialPoint) : base(initialPoint) {}

        public PlainLine(int length, Point initialPoint) : base(initialPoint) {
            Length = length;
        }

        public void SetLength(int length) {
            Length = length;
        }
        public void DrawHorizontal() {
            for (int i = 1; i <= Length; i++) {
                Point point = new Point(X + i, Y, Symbol);
                point.Draw();
            }
        }

        public void DrawHorizontal(int length) {
            if (length > 0) {
                Length = length;
                DrawHorizontal();
            } else {
                throw new ArithmeticException("Length should be greater than zero");
            }
        }

        public void DrawVertical() {
            for (int i = 1; i <= Length; i++) {
                Point point = new Point(X, Y + i, Symbol);
                point.Draw();
            }
        }

        public void DrawVertical(int length) {
            if (length > 0) {
                Length = length;
                DrawVertical();
            } else {
                throw new ArithmeticException("Length should be greater than zero");
            }
        }
    }
}
