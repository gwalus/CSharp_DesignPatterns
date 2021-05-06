using System;

namespace Prototype_Coding_Exercies
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = new Line(new Point(2, 2), new Point(3, 3));

            var copy = line.DeepCopy();
            copy.Start = new Point(5, 5);

            Console.WriteLine(line);
            Console.WriteLine(copy);
        }
    }

    public class Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point()
        {

        }

        public Point DeepCopy()
        {
            return new Point(X, Y);
        }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public Line DeepCopy()
        {
            return new Line(Start.DeepCopy(), End.DeepCopy());
        }

        public override string ToString()
        {
            return $"{nameof(Start)}: {Start}, {nameof(End)}: {End}";
        }
    }
}
