using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PofCIS_Team2.Classes;
using PofCIS_Team2.Entities.Interfaces;

namespace PofCIS_Team2.BL
{
	public static class Task1
	{
		public static void Execute()
		{
			try
			{
				if (!Directory.Exists(ParseHelper.Const.OutputDataRoot))
				{
					Directory.CreateDirectory(ParseHelper.Const.OutputDataRoot);
				}

				var shapes = ReadFromFile(ParseHelper.Const.InputDataRoot + "Shapes.txt");

				var sortedBySquares = shapes.OrderBy(shape => shape.SquareCalculation()).ToList();

				WriteToFile(ParseHelper.Const.OutputDataRoot + "SortedBySquares.txt", sortedBySquares);

				var shapesFromThirdQuarter = new List<IShape>();
				foreach (var shape in shapes)
				{
					if (IsInThirdQuarter(shape))
					{
						shapesFromThirdQuarter.Add(shape);
					}
				}

				var sortedByPerimeters =
					shapesFromThirdQuarter.OrderByDescending(shape => shape.PerimeterCalculation()).ToList();

				WriteToFile(ParseHelper.Const.OutputDataRoot + "SortedByPerimeters.txt", sortedByPerimeters);
			}
			catch (NullReferenceException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (InvalidDataException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static List<IShape> ReadFromFile(string fileName)
		{
			if (!File.Exists(fileName))
			{
				throw new IOException("file does not exist");
			}

			var reader = new StreamReader(fileName);
			var list = new List<IShape>();

			while (!reader.EndOfStream)
			{
				var triangle = new Triangle();
				var square = new Square();
				var circle = new Circle();
				var line = reader.ReadLine();
				if (triangle.Parse(line))
				{
					list.Add(triangle);
				}
				else if (square.Parse(line))
				{
					list.Add(square);
				}
				else if (circle.Parse(line))
				{
					list.Add(circle);
				}
			}

			reader.Close();
			return list;
		}

		public static void WriteToFile(string fileName, List<IShape> shapes)
		{
			var writer = new StreamWriter(fileName);
			for (var i = 0; i < shapes.Count; i++)
			{
				writer.Write(shapes[i] + Environment.NewLine);
				if (i != shapes.Count - 1)
				{
					writer.Write(Environment.NewLine);
				}
			}

			writer.Close();
		}


		public static bool IsInThirdQuarter(IShape shape)
		{
			if (typeof(IShape) != typeof(Circle))
			{
				return shape.GetPoints().All(point => !(point.X > 0) && !(point.Y > 0));
			}

			var circle = (Circle) shape;
			var center = circle.GetPoints().ToArray()[0];
			var radius = circle.RadiusCalculation();
			return center.X < 0 &&
			       center.Y < 0 &&
			       Point.DistanceCalculation(center, new Point(center.X, 0)) >= radius &&
			       Point.DistanceCalculation(center, new Point(0, center.Y)) >= radius;
		}
	}
}