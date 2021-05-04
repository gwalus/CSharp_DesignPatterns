using System;
using System.Threading.Tasks;

namespace Inner_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var point = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(point);

            var originPoint = Point.Origin2;
        }

        

        public class Point
        {
            private double x, y;

            private Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public override string ToString()
            {
                return $"{x}, {y}";
            }

            //public static PointFactory Factory => new PointFactory();

            //public static Point Origin => new Point(0, 0);
            public static Point Origin2 = new Point(0, 0); // better

            public static class Factory
            {
                public static Point NewCartesianPoint(double x, double y)
                {
                    return new Point(x, y);
                }

                public static Point NewPolarPoint(double rho, double theta)
                {
                    return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
                }
            }
        }
    }
}
