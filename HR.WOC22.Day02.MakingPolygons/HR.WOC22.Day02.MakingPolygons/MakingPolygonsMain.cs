using System;
using System.Collections.Generic;
using System.Linq;

namespace HR.WOC22.Day02.MakingPolygons {
    internal class MakingPolygonsMain {

        /// <summary>
        /// No. of sticks - n
        /// </summary>
        private static int N { get; set; }

        /// <summary>
        /// Array of integers with the length of sticks - a[]
        /// </summary>
        private static List<int> A { get; set; }

        /// <summary>
        /// Code entry
        /// </summary>
        /// <param name="args"></param>
        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args) {
            try {
                CaptureInput();
                ValidateUserInput();
                ProcessInputToFindPolygons();

            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Processes the user input to find the required number of breaks
        /// </summary>
        private static void ProcessInputToFindPolygons() {
            int breaks;
            switch (N) {
                    //Any one stick can be broken twice to form a triangle 
                case 1:
                    breaks = 2;
                    break;
                    //Any 2 sticks can be broken once to form a triangle
                case 2:
                    breaks = 1;
                    break;
                default:
                    breaks = GetRequiredBreakCount();
                    break;
            }
            Console.WriteLine(breaks);
        }

        /// <summary>
        /// Gets the number of breaks required to form a polygon
        /// </summary>
        /// <returns></returns>
        private static int GetRequiredBreakCount() {
            var breaks = 0;
            while (true) {
                //Sort the array
                A.Sort();

                //Get the longest stick
                var longestStick = A.Max();
                var sumOfOtherSides = 0;
                for (var idx = 0; idx < A.Count - 1; idx++) sumOfOtherSides += A[idx];
                if (sumOfOtherSides > longestStick) {
                    return breaks;
                }
                //Remove the last element and split it into 2
                A.Remove(A.Count);
                if (sumOfOtherSides != longestStick) {
                    A.Add(sumOfOtherSides + 1);
                    A.Add(longestStick - sumOfOtherSides - 1);
                }
                else {
                    A.Add(longestStick - 1);
                    A.Add(1);
                }
                ++breaks;
            }
        }

        /// <summary>
        /// Validates user input as per the given requirements 
        /// </summary>
        private static void ValidateUserInput() {
            if (N < 1 || N > 50) {
                throw new Exception("'n' must be between 1 & 50 - both inclusive");
            }
            if (A.Any(a => a < 1 || a > 100)) {
                throw new Exception("Values of 'a' must be between 1 & 100 - both inclusive");
            }
        }

        /// <summary>
        /// Captures user input
        /// </summary>
        private static void CaptureInput() {
            try {
                N = Convert.ToInt32(Console.ReadLine());
            }
            catch {
                throw new Exception("Failed to capture the value for 'n'. 'n' must be an integer");
            }

            try {
                var readLine = Console.ReadLine();
                if (readLine != null) {
                    A = Array.ConvertAll(readLine.Split(' '), Int32.Parse).ToList();
                }
                else {
                    throw new Exception("'a' must be provided as a list of integers separated by spaces");
                }
            }
            catch {
                throw new Exception("Failed to capture the value for 'a'. 'a' must bean array of integers");
            }
        }
    }
}