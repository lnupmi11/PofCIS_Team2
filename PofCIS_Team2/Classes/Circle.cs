using System;
using System.Collections.Generic;
using System.IO;
using PofCIS_Team2.Entities.Interfaces;

namespace PofCIS_Team2.Classes
{
	public class Circle : IShape
	{
		private Point[] _points;

		private double _radius;

		private const int PointsAmount = 2;

		public Circle()
		{
		}

		public Circle(Point[] points)
		{
			if (points == null)
			{
				throw new NullReferenceException("points is null");
			}

			if (points[0].Equals(points[1]))
			{
				throw new InvalidDataException("no circle entered");
			}

			_points = points;
			_radius = RadiusCalculation();
		}

		public double RadiusCalculation()
		{
			if (_points == null)
			{
				throw new ArgumentException(nameof(_points) + "points is null");
			}

			return Point.DistanceCalculation(_points[0], _points[1]);
		}

		public bool Parse(string data)
		{
			var parsedPoints = ParseHelper.ParseShapePoints(
				data, @"Circle\{\s*((-?\d+\s+){3}-?\d+)\s*\}", ParseHelper.Const.CoordinatesPerPoint, PointsAmount);

			if (parsedPoints == null)
			{
				return false;
			}

			if (parsedPoints[0].Equals(parsedPoints[1]))
			{
				return false;
			}

			_points = parsedPoints;
			_radius = RadiusCalculation();

			return true;
		}

		public double SquareCalculation()
		{
			if (_points == null)
			{
				throw new ArgumentException(nameof(_points) + "points is null");
			}

			return Math.PI * Math.Pow(_radius, 2);
		}

		public double PerimeterCalculation()
		{
			if (_points == null)
			{
				throw new ArgumentException(nameof(_points) + "points is null");
			}

			return Math.PI * 2 * _radius;
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

			var resultStr = $"Circle:{Environment.NewLine} 	Radius:{_radius}{Environment.NewLine} Points:";
			uint i = 1;
			foreach (var point in _points)
			{
				resultStr += $"{Environment.NewLine} 	Point {i}: x ={point.X}, y= {point.Y}";
				i++;
			}

			return resultStr;
		}
	}
}