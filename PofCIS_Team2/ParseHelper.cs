using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using PofCIS_Team2.Classes;

namespace PofCIS_Team2
{
	public static class ParseHelper
	{
		public static double StringToDouble(string strNum)
		{
			if (!double.TryParse(strNum, out var doubleNum))
			{
				throw new InvalidDataException("string contains non-number chars");
			}

			return doubleNum;
		}

        
        public static Point[] ParseShapePoints(string line, string regexStr, int coordsPerP, int pointsCount)
		{
			if (line == null)
			{
				throw new IOException("can't read data from stream");
			}

			var result = Regex.Match(line, regexStr);
			if (!result.Success)
			{
				return null;
			}

			var data = result.Groups[1].ToString().Split(' ');
			if (data.Length != pointsCount * coordsPerP)
			{
				throw new InvalidDataException("invalid triangle points count");
			}
			
			var points = new List<Point>();  

			for (var i = 0; i < pointsCount * coordsPerP; i += coordsPerP)
			{
				points.Add(new Point(StringToDouble(data[i]), StringToDouble(data[i + 1])));
			}

			return points.ToArray();
		}
		
		
		public struct Const
		{
			private const string DataRoot = "/Users/roman/RiderProjects/PofCIS_Team2/PofCIS_Team2/Data/";
			
			public const string InputDataRoot = DataRoot + "Input/";
		
			public const string OutputDataRoot = DataRoot + "Output/";

			public const int CoordinatesPerPoint = 2;
		}
	}
}