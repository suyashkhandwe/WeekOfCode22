using System;

namespace HR.WOC22.Day01.CookieParty {
    internal class CookiePartyMain {
        /// <summary>
        /// Input 'n' : which is the number of guests (n GREATER THAN OR EQUAL TO 1)
        /// </summary>
        private static int N { get; set; }

        /// <summary>
        /// Input 'm' : which is the number of cookies made (m LESSER OR EQUAL TO 10^9)
        /// </summary>
        private static int M { get; set; }

        /// <summary>
        /// Entry point of the code
        /// </summary>
        /// <param name="args"></param>
        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args) {
            try {
                CaptureInput();
                var extraCookiesRequired = CalculateCookies();
                Console.WriteLine(extraCookiesRequired);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Calculates the extra cookies required to be made
        /// </summary>
        /// <returns>Extra cookies required</returns>
        private static int CalculateCookies() {
            if (N == M || N == 0 || M == 0 || M == 1) {
                return 0;
            }
            int remainder;
            if (N < M) {
                remainder = M%N;
                if (remainder == 0) {
                    return 0;
                }
                return N - remainder;
            }

            remainder = N%M;
            if (remainder == 0) {
                return N - M;
            }
            return remainder;
        }

        /// <summary>
        /// Capture user input
        /// </summary>
        private static void CaptureInput() {
            try {
                var readLine = Console.ReadLine();
                if (readLine == null) {
                    throw new Exception("No input provided");
                }
                var inputTokens = readLine.Split(' ');
                if (inputTokens.Length != 2) {
                    throw new Exception("Invalid input provided. Input should be in the format of 2 number separated by space (n m).");
                }

                try {
                    N = Convert.ToInt32(inputTokens[0]);
                    if (N < 0) {
                        throw new Exception("The value of 'n' can't be less than 1");
                    }
                    if (N > 1000000000) {
                        throw new Exception("The value of 'n' can't be greater than 1000000000 since 'm' is restricted to 1000000000");
                    }
                }
                catch {
                    throw new Exception("Failed to convert 'n' to integer value");
                }

                try {
                    M = Convert.ToInt32(inputTokens[1]);
                    if (M < 0) {
                        throw new Exception("The value of 'm' can't be less than 0 since negative cookies can't be distributed");
                    }
                    if (M > 1000000000) {
                        throw new Exception("The value of 'm' can't be greater than 1000000000");
                    }
                }
                catch {
                    throw new Exception("Failed to convert 'm' to integer value");
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}