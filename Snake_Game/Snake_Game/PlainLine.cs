using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class PlainLine {
        private Point InitialPoint;
        private int Length;

        public PlainLine(Point _init, int _length) {
            SetLine(_init, _length);
        }

        public void SetLine(Point _init, int _length) {
            Length = _length;
            InitialPoint = _init;
        }


        public void DrawHorizontal() {
            for (int i = 1; i <= Length; i++) {
                Point point = new Point(InitialPoint.X + i, InitialPoint.Y, InitialPoint.Symbol);
                point.Draw();
            }
        }

        public void DrawVertical() {
            for (int i = 1; i <= Length; i++) {
                Point point = new Point(InitialPoint.X, InitialPoint.Y + i, InitialPoint.Symbol);
                point.Draw();
            }
        }
    }
}
