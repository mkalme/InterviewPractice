using System;
using System.Collections.Generic;
using InterviewPractice;

namespace InterviewPracticeUI {
    class Program {
        static void Main(string[] args)
        {
            List<Point> points = new List<Point>() { 
                new Point(1, 1),
                new Point(2, 2),
                new Point(-1, 1),
                new Point(1, -1),
                new Point(-2, -2),
            };

            List<Point> clsosetPoints = Practice.GetNearestPoints(points, new Point(3.5F, 3.5F), 3);
            foreach (var point in clsosetPoints) {
                Console.WriteLine(point.X + ", " + point.Y);
            }

            Console.ReadLine();
        }
    }
}
