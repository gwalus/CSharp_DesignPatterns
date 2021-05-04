using System;

namespace Point_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var point = Point.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(point);
        }

        public enum CoordinateSystem
        {
            Cartesian,
            Polar
        }


        /// <summary>
        /// Initializer a point from EITHER cartesian or polar
        /// </summary>
        /// <param name="a">x if cartesian, rho if polar</param>
        /// <param name="b"></param>
        /// <param name="sys tem">x</param>
        public class Point
        {
            private double x, y;

            // factory method
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho*Math.Cos(theta), rho*Math.Sin(theta));
            }

            //public Point(double a, double b, CoordinateSystem system = CoordinateSystem.Cartesian)
            private Point(double x, double y)
            {
                this.x = x;
                this.y = y;
                //this.x = x;
                //this.y = y;

                //switch (system)
                //{
                //    case CoordinateSystem.Cartesian:
                //        x = a;
                //        y = b;
                //        break;
                //    case CoordinateSystem.Polar:
                //        x = a * Math.Cos(b);
                //        y = a * Math.Sin(b);
                //        break;
                //    default:
                //        break;
                //}
            }

            public override string ToString()
            {
                return $"{x}, {y}";
            }
        }
    }
}
