using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using PofCIS_Team2.Entities.Interfaces;

namespace PofCIS_Team2.Classes
{
	public class Square : IShape
	{
		private Point[] _points;

		private const int PointsAmount = 4;

		public Square()
		{
		}

		public Square(Point[] points)
		{
			if (points == null)
			{
				throw new ArgumentNullException("points is null");
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
			var c = Point.DistanceCalculation(points[2], points[3]);
			var d = Point.DistanceCalculation(points[3], points[0]);

			return a.Equals(b) & b.Equals(c) && c.Equals(d) && d.Equals(a);
		}

		public bool Parse(string data)
		{
			var parsedPoints = ParseHelper.ParseShapePoints(
				data, @"Square\{\s*((-?\d+\s+){7}-?\d+)\s*\}", ParseHelper.Const.CoordinatesPerPoint, PointsAmount);

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

			return Math.Pow(Point.DistanceCalculation(_points[0], _points[1]), 2);
		}

		public double PerimeterCalculation()
		{
			if (_points == null)
			{
				throw new ArgumentException(nameof(_points) + "points is null");
			}

			return Point.DistanceCalculation(_points[0], _points[1]) * 4;
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

			var resultStr = "Square: ";
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