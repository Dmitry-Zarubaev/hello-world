using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {

	class RAM {
		public static void Func1(int value) {

		}

		public static void Func2(int value) {
			value = value + 1;
		}

		public static void Func3(int x) {
			x = x + 1;
		}

		public static void Move(Point p, int dx, int dy) {
			p.X = p.X + dx;
			p.Y = p.Y + dy;
		}

		public static void Update(Point p) {
			p = new Point();
		}

		public void DoExample() {
			int x = 1;
			Func1(x);
			Console.WriteLine("Call Func1. x = " + x);

			x = 1;
			Func2(x);
			Console.WriteLine("Call Func2. x = " + x);

			x = 1;
			Func3(x);
			Console.WriteLine("Call Func3. x = " + x);

			Point p1 = new Point(1, 3, '*');
			Move(p1, 10, 10);
			Console.WriteLine("Call Move. p1.X = " + p1.X + ", p1.Y = " + p1.Y);

			Point p2 = new Point(4, 5, '#');
			p1 = p2;
			p2.X = 8;
			p2.Y = 8;
			Console.WriteLine("p1 = p2. p1.X = " + p1.X + ", p1.Y = " + p1.Y + "; p2.X = " + p2.X + ", p2.Y = " + p2.Y);

			p1 = new Point(1, 3, '*');
			Update(p1);
			Console.WriteLine("Call Move. p1.X = " + p1.X + ", p1.Y = " + p1.Y);

			Console.ReadLine();
		}
	}
}
