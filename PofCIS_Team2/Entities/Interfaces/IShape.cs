using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Point = PofCIS_Team2.Classes.Point;

namespace PofCIS_Team2.Entities.Interfaces
{
	public interface IShape : IFileManager
	{
		double SquareCalculation();

		double PerimeterCalculation();

		IEnumerable<Point> GetPoints();
	}
}