using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using Xunit;
using PofCIS_Team2.Classes;

namespace PofCIS_Team2Tests.Classes
{
	public class TestTriangle
	{
		[Theory]
		[MemberData(nameof(TriangleData.CalcPerimeterData), MemberType = typeof(TriangleData))]
		public void TestCalcPerimeter(Triangle triangle, double expected)
		{
			var actual = triangle.PerimeterCalculation();
			Assert.Equal(expected, actual);
		}

		[Theory]
		[MemberData(nameof(TriangleData.CalcSquareData), MemberType = typeof(TriangleData))]
		public void TestCalcSquare(Triangle triangle, double expected)
		{
			var actual = triangle.SquareCalculation();
			Assert.Equal(expected, actual);
		}

		[Theory]
		[MemberData(nameof(TriangleData.PointsAreValidData), MemberType = typeof(TriangleData))]
		public void TestPointsAreValid(Point[] points, bool expected)
		{
			var actual = Triangle.PointsAreValid(points);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[MemberData(nameof(TriangleData.ConstructorData), MemberType = typeof(TriangleData))]
		public void TestConstructor(Point[] points, Point[] expected)
		{
			var triangle = new Triangle(points);
			var actual = triangle.GetPoints();
			var enumerable = actual as Point[] ?? actual.ToArray();
			Assert.Equal(expected[0].X, enumerable[0].X);
			Assert.Equal(expected[0].Y, enumerable[0].Y);
			Assert.Equal(expected[1].X, enumerable[1].X);
			Assert.Equal(expected[1].Y, enumerable[1].Y);
		}
		
		[Theory]
		[MemberData(nameof(TriangleData.GetPointsData), MemberType = typeof(TriangleData))]
		public void TestGetPoints(Triangle triangle, Point[] expected)
		{
			var actual = triangle.GetPoints();
			var enumerable = actual as Point[] ?? actual.ToArray();
			Assert.Equal(expected[0].X, enumerable[0].X);
			Assert.Equal(expected[0].Y, enumerable[0].Y);
			Assert.Equal(expected[1].X, enumerable[1].X);
			Assert.Equal(expected[1].Y, enumerable[1].Y);
		}
		
		[Theory]
		[MemberData(nameof(TriangleData.ParseData), MemberType = typeof(TriangleData))]
		public void TestParse(string line, bool expected)
		{
			var circle = new Triangle();
			var actual = circle.Parse(line);
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void TestConstructorThrowsNullReferenceException()
		{
			Assert.Throws<NullReferenceException>(() => new Triangle(null));
		}
		
		[Fact]
		public void TestConstructorThrowsInvalidDataException()
		{
			Assert.Throws<InvalidDataException>(() => new Triangle(new[] { new Point(0, 0), new Point(0, 0) }));
		}
		
		[Fact]
		public void TestCalcConstructorThrowsInvalidDataException()
		{
			Assert.Throws<InvalidDataException>(() => new Triangle(new[] { new Point(0, 0), new Point(0, 0), new Point(0, 0) }));
		}
		
		private class TriangleData
		{
			public static IEnumerable<object[]> CalcPerimeterData => new List<object[]>
			{
				new object[]
				{
					new Triangle(new[]
					{
						new Point(0, 0), new Point(1, 1), new Point(3, 0)
					}),
					Math.Sqrt(2) + 3 + Math.Sqrt(5)
				},
				new object[]
				{
					new Triangle(new[]
					{
						new Point(0, 0), new Point(1, 1), new Point(0, 3)
					}),
					Math.Sqrt(2) + 3 + Math.Sqrt(5)
				},
				new object[]
				{
					new Triangle(new[]
					{
						new Point(0, 0), new Point(0, 3), new Point(4, 0)
					}),
					12
				},
			};

			public static IEnumerable<object[]> CalcSquareData => new List<object[]>
			{
				new object[]
				{
					new Triangle(new[]
					{
						new Point(0, 0), new Point(0, 2), new Point(10, 0)
					}),
					10.0
				},
				new object[]
				{
					new Triangle(new[]
					{
						new Point(0, 0), new Point(0, 3), new Point(4, 0)
					}),
					6.0
				},
			};

			public static IEnumerable<object[]> GetPointsData => new List<object[]>
			{
				new object[]
				{
					new Triangle(new[]
					{
						new Point(0, 0),
						new Point(0, 1),
						new Point(1, 1)
					}),
					new[]
					{
						new Point(0, 0),
						new Point(0, 1),
						new Point(1, 1)
					}				
				},

				new object[]
				{
					new Triangle(new[]
					{
						new Point(0, 0),
						new Point(0, 4),
						new Point(5, 1)
					}),
					new[]
					{
						new Point(0, 0),
						new Point(0, 4),
						new Point(5, 1)
					}				
				},

				new object[]
				{
					new Triangle(new[]
					{
						new Point(0, 0),
						new Point(0, 10),
						new Point(-6, 1)
					}),
					new[]
					{
						new Point(0, 0),
						new Point(0, 10),
						new Point(-6, 1)
					}				
				},

				new object[]
				{
					new Triangle(new[]
					{
						new Point(0, 0),
						new Point(0, 5),
						new Point(46, 1)
					}),
					new[]
					{
						new Point(0, 0),
						new Point(0, 5),
						new Point(46, 1)
					}
				}
			};
			
			public static IEnumerable<object[]> ParseData => new List<object[]>
			{
				new object[]
				{
					"Triangle{0 0 1 1 2 0}", true
				},

				new object[]
				{
				"Triangle {0 0 1 1 2 0}", false
				},

				new object[]
				{
					"Triangle { 0 0 1 1 2 0}", false
				},

				new object[]
				{
					"Triangle{ 0 0 1 1 2 0}", true
				},

				new object[]
				{
					"Triangle{0 0 1 1 2 0 }", true
				},
				
				new object[]
				{
					"0, 0, 1, 1, 2, 0", false
				},
				new object[]
				{
					string.Empty, false
				},
				new object[]
				{
					"Triangle{0, 0, 1, 1, 2, 0}", false
				},
				new object[]
				{
					"Triangle{0 0 1 1 2 2}", false
				}
			};

			public static IEnumerable<object[]> ConstructorData => new List<object[]>
			{
				new object[]
				{
					new[]
					{
						new Point(0, 0),
						new Point(0, 1),
						new Point(1, 1)
					},
					new[]
					{
						new Point(0, 0),
						new Point(0, 1),
						new Point(1, 1)
					}				
				},

				new object[]
				{
					new[]
					{
						new Point(0, 0),
						new Point(0, 4),
						new Point(5, 1)
					},
					new[]
					{
						new Point(0, 0),
						new Point(0, 4),
						new Point(5, 1)
					}				
				},

				new object[]
				{
					new[]
					{
						new Point(0, 0),
						new Point(0, 10),
						new Point(-6, 1)
					},
					new[]
					{
						new Point(0, 0),
						new Point(0, 10),
						new Point(-6, 1)
					}				
				},

				new object[]
				{
					new[]
					{
						new Point(0, 0),
						new Point(0, 5),
						new Point(46, 1)
					},
					new[]
					{
						new Point(0, 0),
						new Point(0, 5),
						new Point(46, 1)
					}
				}
			};

			public static IEnumerable<object[]> PointsAreValidData => new List<object[]>
			{
				new object[]
				{
					new[]
					{
						new Point(0, 0),
						new Point(0, 1),
						new Point(1, 1)
					},
					true
				},

				new object[]
				{
					new[]
					{
						new Point(0, 0),
						new Point(0, 4),
						new Point(5, 1)
					},
					true
				},

				new object[]
				{
					new[]
					{
						new Point(0, 0),
						new Point(0, 10),
						new Point(-6, 1)
					},
					true
				},

				new object[]
				{
					new[]
					{
						new Point(0, 0),
						new Point(0, 5),
						new Point(46, 1)
					},
					true
				},

				new object[]
				{
					new[]
					{
						new Point(0, 0),
						new Point(0, 0),
						new Point(46, 1)
					},
					false
				},
				
				new object[]
				{
					new[]
					{
						new Point(0, 0),
						new Point(0, 0),
						new Point(0, 0)
					},
					false
				},
				new object[]
				{
					new[]
					{
						new Point(0, 0),
						new Point(1, 1),
						new Point(-1, -1)
					},
					false
				},
				new object[]
				{
					new[]
					{
						new Point(0, 0),
						new Point(1, 0),
						new Point(0.5, 0)
					},
					false
				}
			};
		}
	}
}