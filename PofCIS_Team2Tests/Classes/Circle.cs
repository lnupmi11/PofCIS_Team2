using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using PofCIS_Team2.Classes;

namespace PofCIS_Team2Tests.Classes
{
    public class TestCircle
    {
        [Theory]
        [MemberData(nameof(CircleData.RadiusCalculationData), MemberType = typeof(CircleData))]
        public void TestCalcRadius(Circle circle, double expected)
        {
            var actual = circle.RadiusCalculation();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(CircleData.SquareCalculationData), MemberType = typeof(CircleData))]
        public void TestSquareCalculation(Circle circle, double expected)
        {
            var actual = circle.SquareCalculation();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(CircleData.PerimeterCalculationData), MemberType = typeof(CircleData))]
        public void TestPerimeterCalculation(Circle circle, double expected)
        {
            var actual = circle.PerimeterCalculation();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(CircleData.GetPointsData), MemberType = typeof(CircleData))]
        public void TestGetPoints(Circle circle, Point[] expected)
        {
            var actual = circle.GetPoints();
            var enumerable = actual as Point[] ?? actual.ToArray();
            Assert.Equal(expected[0].X, enumerable[0].X);
            Assert.Equal(expected[0].Y, enumerable[0].Y);
            Assert.Equal(expected[1].X, enumerable[1].X);
            Assert.Equal(expected[1].Y, enumerable[1].Y);
        }

        [Fact]
        public void TestConstructorThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => new Circle(null));
        }

        private class CircleData
        {
            public static IEnumerable<object[]> RadiusCalculationData => new List<object[]>
            {
                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0), new Point(0, 1)
                    }),
                    1
                },
                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0), new Point(1, 1)
                    }),
                    Math.Sqrt(2)
                },
                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0), new Point(4, 4)
                    }),
                    Math.Sqrt(32)
                },
                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0), new Point(5, 0)
                    }),
                    5
                },
                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(1, 0), new Point(0, 1)
                    }),
                    Math.Sqrt(2)
                },
            };

            public static IEnumerable<object[]> ParseData => new List<object[]>
            {
                new object[]
                {
                    "Circle{0 0 1 1}", true
                },

                new object[]
                {
                    "Circle {0 0 1 1}", false
                },

                new object[]
                {
                    "Circle { 0 0 1 1}", false
                },

                new object[]
                {
                    "Circle{ 0 0 1 1}", true
                },

                new object[]
                {
                    "Circle{0 0 1 1 }", true
                },

                new object[]
                {
                    "Triangle{5 0 0 1 1 5}", false
                },
                new object[]
                {
                    "0, 0, 1, 1", false
                },
                new object[]
                {
                    string.Empty, false
                },
                new object[]
                {
                    "Circle{0, 0, 1, 0}", false
                },
                new object[]
                {
                    "Circle{0 0 0 0}", false
                },
            };

            public static IEnumerable<object[]> SquareCalculationData => new List<object[]>
            {
                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0),
                        new Point(0, 1)
                    }),
                    Math.PI
                },

                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0),
                        new Point(0, 4)
                    }),
                    Math.PI * 16
                },

                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0),
                        new Point(0, 10)
                    }),
                    Math.PI * 100
                },

                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0),
                        new Point(0, 5)
                    }),
                    Math.PI * 25
                }
            };

            public static IEnumerable<object[]> PerimeterCalculationData => new List<object[]>
            {
                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0),
                        new Point(0, 1)
                    }),
                    Math.PI * 2
                },

                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0),
                        new Point(0, 4)
                    }),
                    Math.PI * 8
                },

                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0),
                        new Point(0, 10)
                    }),
                    Math.PI * 20
                },

                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0),
                        new Point(0, 5)
                    }),
                    Math.PI * 10
                }
            };

            public static IEnumerable<object[]> GetPointsData => new List<object[]>
            {
                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0),
                        new Point(0, 1)
                    }),
                    new[]
                    {
                        new Point(0, 0),
                        new Point(0, 1)
                    }
                },

                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0),
                        new Point(0, 4)
                    }),
                    new[]
                    {
                        new Point(0, 0),
                        new Point(0, 4)
                    }
                },

                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0),
                        new Point(0, 10)
                    }),
                    new[]
                    {
                        new Point(0, 0),
                        new Point(0, 10)
                    }
                },

                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0),
                        new Point(0, 5)
                    }),
                    new[]
                    {
                        new Point(0, 0),
                        new Point(0, 5)
                    }
                }
            };

            public static IEnumerable<object[]> ToStringData => new List<object[]>
            {
                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0), new Point(0, 1)
                    }),
                    $"Circle:{Environment.NewLine}  Radius: 1{Environment.NewLine}  Points:{Environment.NewLine}    Point 0: x=0, y=0{Environment.NewLine}    Point 1: x=0, y=1"
                },
                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0), new Point(1, 1)
                    }),
                    $"Circle:{Environment.NewLine}  Radius: {Math.Sqrt(2)}{Environment.NewLine}  Points:{Environment.NewLine}    Point 0: x=0, y=0{Environment.NewLine}    Point 1: x=1, y=1"
                },
                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0), new Point(4, 4)
                    }),
                    $"Circle:{Environment.NewLine}  Radius: {Math.Sqrt(32)}{Environment.NewLine}  Points:{Environment.NewLine}    Point 0: x=0, y=0{Environment.NewLine}    Point 1: x=4, y=4"
                },
                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(0, 0), new Point(5, 0)
                    }),
                    $"Circle:{Environment.NewLine}  Radius: 5{Environment.NewLine}  Points:{Environment.NewLine}    Point 0: x=0, y=0{Environment.NewLine}    Point 1: x=5, y=0"
                },
                new object[]
                {
                    new Circle(new[]
                    {
                        new Point(1, 0), new Point(0, 1)
                    }),
                    $"Circle:{Environment.NewLine}  Radius: {Math.Sqrt(2)}{Environment.NewLine}  Points:{Environment.NewLine}    Point 0: x=1, y=0{Environment.NewLine}    Point 1: x=0, y=1"
                },
            };
        }
    }
}