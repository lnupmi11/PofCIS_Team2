using System.IO;
using System.Linq;
using System.Collections.Generic;

using Xunit;
using PofCIS_Team2.Classes;

namespace PofCIS_Team2Tests.Classes
{
	public class TestSquare
	{
		[Theory]
		[MemberData(nameof(ConstructorData.Success), MemberType = typeof(ConstructorData))]
		public void TestConstructorSuccess(Point[] input, Point[] expected)
		{
			var square = new Square(input);
			var actual = square.GetPoints().ToArray();
			Assert.NotNull(actual);
			Assert.Equal(actual.Length, expected.Length);
			for (var i = 0; i < expected.Length; i++)
			{
				Assert.Equal(actual[i].X, expected[i].X);
				Assert.Equal(actual[i].Y, expected[i].Y);
			}
		}
		
		[Theory]
		[MemberData(nameof(ConstructorData.Throws), MemberType = typeof(ConstructorData))]
		public void TestConstructorThrows(Point[] input)
		{
			Assert.Throws<InvalidDataException>(() => new Square(input));
		}

		private class ConstructorData
		{
			public static IEnumerable<object[]> Success => new List<object[]>
			{
				new object[]
				{
					new[]
					{
						new Point(1, 1), 
						new Point(2, 1), 
						new Point(2, 2), 
						new Point(1, 2)
					},
					new[]
					{
						new Point(1, 1), 
						new Point(2, 1), 
						new Point(2, 2), 
						new Point(1, 2)	
					},
				},
				new object[]
				{
					new[]
					{
						new Point(0, 0), 
						new Point(5, 0), 
						new Point(5, 5), 
						new Point(0, 5)
					},
					new[]
					{
						new Point(0, 0), 
						new Point(5, 0), 
						new Point(5, 5), 
						new Point(0, 5)	
					},
				}
			};

			public static IEnumerable<object[]> Throws => new List<object[]>
			{
				new object[]
				{
					new[]
					{
						new Point(1, 1), 
						new Point(2, 1), 
						new Point(2, 2), 
						new Point(1, 3)
					}
				},
				new object[]
				{
					new[]
					{
						new Point(1, 1), 
						new Point(2, 1), 
						new Point(2, 2), 
						new Point(1, 2),
						new Point(0, 0)
					}
				}
			};
		}

		[Theory]
		[MemberData(nameof(PointsAreValidData.Success), MemberType = typeof(PointsAreValidData))]
		public void TestPointsAreValid(Point[] points, bool expected)
		{
			var actual = Square.PointsAreValid(points);
			Assert.Equal(expected, actual);
		}

		private class PointsAreValidData
		{
			public static IEnumerable<object[]> Success => new List<object[]>
			{
				new object[]
				{
					new[]
					{
						new Point(1, 1), 
						new Point(2, 1), 
						new Point(3, 3), 
						new Point(1, 3)
					},
					false
				},
				new object[]
				{
					new[]
					{
						new Point(0, 0), 
						new Point(5, 0), 
						new Point(5, 5), 
						new Point(0, 5)
					},
					true
				},
				new object[]
				{
					new[]
					{
						new Point(1, 1), 
						new Point(2, 1), 
						new Point(2, 2), 
						new Point(1, 3)
					},
					false
				},
				new object[]
				{
					new[]
					{
						new Point(1, 1), 
						new Point(2, 1), 
						new Point(2, 2), 
						new Point(1, 2),
						new Point(0, 0)
					},
					false
				}
			};
		}
		
		[Theory]
		[MemberData(nameof(CalcPerimeterData.Success), MemberType = typeof(CalcPerimeterData))]
		public void TestCalcPerimeter(Square square, double expected)
		{
			var actual = square.PerimeterCalculation();
			Assert.Equal(expected, actual);
		}
		
		private class CalcPerimeterData
		{
			public static IEnumerable<object[]> Success => new List<object[]>
			{
				new object[]
				{
					new Square(new[]
					{
						new Point(1, 1), 
						new Point(2, 1), 
						new Point(2, 2), 
						new Point(1, 2)
					}),
					4.0
				},
				new object[]
				{
					new Square(new[]
					{
						new Point(-1, -2),
						new Point(3, -2),  
						new Point(3, 2),
						new Point(-1, 2)
					}),
					16.0
				}
			};
		}

		[Theory]
		[MemberData(nameof(GetPointsData.Success), MemberType = typeof(GetPointsData))]
		public void TestGetPointsSuccess(Point[] points, Point[] expected)
		{
			var square = new Square(points);
			var actual = square.GetPoints().ToArray();
			Assert.Equal(actual.Length, expected.Length);
			for (var i = 0; i < expected.Length; i++)
			{
				Assert.Equal(expected[i].X, actual[i].X);
				Assert.Equal(expected[i].Y, actual[i].Y);
			}
		}

		private class GetPointsData
		{
			public static IEnumerable<object[]> Success => new List<object[]>
			{
				new object[]
				{
					new[]
					{
						new Point(1, 1), 
						new Point(2, 1), 
						new Point(2, 2), 
						new Point(1, 2)
					},
					new[]
					{
						new Point(1, 1), 
						new Point(2, 1), 
						new Point(2, 2), 
						new Point(1, 2)
					}
				}
			};
		}
        
		[Theory]
		[MemberData(nameof(ParseData.Success), MemberType = typeof(ParseData))]
		public void TestParseSuccess(string input, Square expected)
		{
			var actualSquare = new Square();
			Assert.True(actualSquare.Parse(input));
			var actualPoints = actualSquare.GetPoints().ToArray();
			var expectedPoints = expected.GetPoints().ToArray();
			Assert.Equal(actualPoints.Length, expectedPoints.Length);
			for (var i = 0; i < actualPoints.Length; i++)
			{
				Assert.Equal(expectedPoints[i].X, actualPoints[i].X);
				Assert.Equal(expectedPoints[i].Y, actualPoints[i].Y);
			}
		}

		[Theory]
		[MemberData(nameof(ParseData.ReturnsFalse), MemberType = typeof(ParseData))]
		public void TestParseReturnsFalse(string input)
		{
			Assert.False(new Square().Parse(input));
		}
		
		private class ParseData
		{
			public static IEnumerable<object[]> Success => new List<object[]>
			{
				new object[]
				{
					"Square{1 1 2 1 2 2 1 2}",
					new Square(new[]
					{
						new Point(1, 1), 
						new Point(2, 1), 
						new Point(2, 2), 
						new Point(1, 2) 
					})
				},
				new object[]
				{
					"Square{-2 -2 3 -2 3 3 -2 3}",
					new Square(new[]
					{
						new Point(-2, -2),
						new Point(3, -2),  
						new Point(3, 3),
						new Point(-2, 3)
					}), 
				}
			};

			public static IEnumerable<object[]> ReturnsFalse => new List<object[]>
			{
				new object[]
				{
					"Square{1 2 1 2 2 1 2}"
				},
				new object[]
				{
					"SSquare{1 2 1 2 2 1 2}"
				},
				new object[]
				{
					"Square{+-1 2 1 2 2 1 2}"
				},
				new object[]
				{
					"Square{1 1 2 1 2 2 1 3}"
				}
			};
		}
	}
}