using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PofCIS_Team2.Entities.Interfaces;

namespace PofCIS_Team2.Classes
{
	public class Triangle : IShape
	{
		private Point[] _points;

		private const int PointsAmount = 3;

		public Triangle()
		{
		}

		public Triangle(Point[] points)
		{
			if (points == null)
			{
				throw new NullReferenceException("points is null");
			}

			if (points.Length != PointsAmount)
			{
				throw new InvalidDataException("invalid square points count");
			}

			if (!PointsAreValid(points))
			{
				throw new InvalidDataException("invalid square");
			}

			_points = points;
		}

		private bool PointsAreValid(IReadOnlyList<Point> points)
		{
			if (points == null)
			{
				throw new ArgumentNullException(nameof(points) + "points is null");
			}

			if (points.Count != PointsAmount)
				return false;

			var a = Point.DistanceCalculation(points[0], points[1]);
			var b = Point.DistanceCalculation(points[1], points[2]);
			var c = Point.DistanceCalculation(points[2], points[0]);

			return a < b + c && b < a + c && c < b + a;
		}


		public bool Parse(string data)
		{
			var parsedPoints = ParseHelper.ParseShapePoints(
				data, @"Triangle\{\s*((-?\d+\s+){5}-?\d+)\s*\}", ParseHelper.Const.CoordinatesPerPoint, PointsAmount);

			if (parsedPoints == null)
			{
				return false;
			}

			if (!PointsAreValid(parsedPoints))
			{
				return false;
			}

			_points = parsedPoints.ToArray();

			return true;
		}

		public double SquareCalculation()
		{
			if (_points == null)
			{
				throw new ArgumentException(nameof(_points) + "points is null");
			}

			var halfPerimeter = PerimeterCalculation() / 2;
			var expr = halfPerimeter;

			for (uint i = 0; i < _points.Length; i++)
			{
				expr *= halfPerimeter - Point.DistanceCalculation(_points[i], _points[(i + 1) % _points.Length]);
			}

			return Math.Sqrt(expr);
		}

		public double PerimeterCalculation()
		{
			if (_points == null)
			{
				throw new ArgumentException(nameof(_points) + "points is null");
			}

			return _points.Select((current, i) => Point.DistanceCalculation(current, _points[(i + 1) % _points.Length]))
				.Sum();
		}

		public IEnumerable<Point> GetPoints()
		{
			if (_points == null)
			{
				throw new ArgumentException(nameof(_points) + "points is null");
			}

			return _points;
		}

		public override string ToString()
		{
			if (_points == null)
			{
				throw new ArgumentException(nameof(_points) + "points is null");
			}

			var resultStr = "Triangle:";
			uint i = 1;
			foreach (var point in _points)
			{
				resultStr += $"{Environment.NewLine} 	Point {i}: x={point.X}, y={point.Y}";
				i++;
			}

			return resultStr;
		}
	}
}