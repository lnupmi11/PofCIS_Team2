using System;

namespace PofCIS_Team2.Classes
{
	public class Point
	{
		public double X { get; }
		public double Y { get; }

		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}

		public static double DistanceCalculation(Point first, Point second)
		{
			return Math.Sqrt(Math.Pow(first.X - second.X, 2) + Math.Pow(first.Y - second.Y, 2));
		}

		public bool Equal(Point point)
		{
			return Math.Abs(X - point.X) < 0.001 && Math.Abs(Y - point.Y) < 0.001;
		}
	}
}