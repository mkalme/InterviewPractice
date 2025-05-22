using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace InterviewPractice
{
    public static class Practice
    {
        //Get most frequant integer
        public static int GetMostFrequentInteger(int[] array) {
            if (array.Length < 1) throw new Exception("Cannot accept an empty array.");

            Dictionary<int, int> commonDict = new Dictionary<int, int>();
            foreach (int i in array) {
                if (!commonDict.ContainsKey(i)) commonDict.Add(i, 0);

                commonDict[i]++;
            }

            return commonDict.GetValuePairWithHighestValue().Key;
        }
        private static KeyValuePair<int, int> GetValuePairWithHighestValue(this Dictionary<int, int> input) {
            if (input.Count < 1) throw new Exception("Cannot accept an empty dictionary.");

            KeyValuePair<int, int> output = input.ElementAt(0);
            foreach (var pair in input) {
                if (pair.Value > output.Value) output = pair;
            }

            return output;
        }

        //Reverse string but keep punctuation
        public static string ReverseWithPunctuation(this string input) {
            string[] words = input.Split(' ');

            StringBuilder output = new StringBuilder();

            string seperator = "";
            for (int i = words.Length - 1; i > -1; i--) {
                output.Append(seperator + words[i]);

                seperator = " ";
            }

            return output.ToString();
        }

        //Get k amount of nearest points
        public static List<Point> GetNearestPoints(List<Point> points, Point vertex, int k) {
            if (points.Count < k) throw new Exception("The list is too small.");

            List<KeyValuePair<float, Point>> distances = new List<KeyValuePair<float, Point>>();
            foreach (var point in points) {
                distances.Add(new KeyValuePair<float, Point>(point.GetDistanceSquared(vertex), point));
            }
            distances = distances.OrderBy(x => x.Key).ToList();

            List<Point> closestPoints = new List<Point>();
            for (int i = 0; i < k; i++) {
                closestPoints.Add(distances[i].Value);
            }

            return closestPoints;
        }
    }

    public struct Point {
        public float X { get; set; }
        public float Y { get; set; }

        public Point(float x, float y) {
            X = x;
            Y = y;
        }
        public float GetDistanceSquared(Point point) {
            float x = point.X - X;
            float y = point.Y - Y;

            return x * x + y * y;
        }
    }
}
