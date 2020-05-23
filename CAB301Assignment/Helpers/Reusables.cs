using System;

namespace CAB301Assignment {

    /// <summary>
    /// Collection of reusable methods (input handling methods)
    /// </summary>
    public static class Reusables {

        /// <summary>
        /// Use this when you need to let the user select index number
        /// </summary>
        /// <param name="text">option text</param>
        /// <param name="choices">all possible choices</param>
        /// <returns>integer value within the 'choices' option</returns>
        public static int waitUserResponse(string text, int[] choices) {
            int input;
            while (true) {
                Console.Write(text);
                if (int.TryParse(Console.ReadLine(), out input)) {
                    if (Array.IndexOf(choices, input) > -1) {
                        break;
                    } else {
                        Console.WriteLine("\n ** {0} is not a option ** \n", input);
                    }
                } else {
                    Console.WriteLine("\n ** Input must be a numeric value ** \n");
                }
            }
            return input;
        }

        /// <summary>
        /// Use this when you need to let the user input numeric value
        /// </summary>
        /// <param name="text">Prompt text</param>
        /// <returns>numeric response</returns>
        public static int waitUserIntegerResponse(string text) {
            int input;
            while (true) {
                Console.Write(text);
                if (int.TryParse(Console.ReadLine(), out input)) {
                    break;
                } else {
                    Console.WriteLine("\n ** Please input only numeric value ** \n");
                }
            }
            return input;
        }

        /// <summary>
        /// Use this for 4 digit password
        /// </summary>
        /// <param name="text">prompt text</param>
        /// <returns>4 digit as a string</returns>
        public static string waitUserSetPassword(string text) {
            string input = "aaaa";
            while (true) {
                Console.Write(text);
                char[] ic = Console.ReadLine().ToCharArray();
                // check if input is 4 char length
                if (ic.Length == 4) {
                    // check if the input is 4 digits
                    if (char.IsDigit(ic[0]) && char.IsDigit(ic[1]) && char.IsDigit(ic[2]) && char.IsDigit(ic[3])) {
                        input = ic[0].ToString() + ic[1].ToString() + ic[2].ToString() + ic[3].ToString();
                        break;
                    } else {
                        Console.WriteLine(" \n ** Please input 4 digit numer ** \n");
                    }
                } else {
                    Console.WriteLine(" \n ** Please input 4 digit numer ** \n");
                }
            }
            return input;
        }

        /// <summary>
        /// Use this if you need to let the user press Enter to proceed
        /// </summary>
        public static void waitUserPressEnter() {
            Console.Write("\n  Press Enter to go back...");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }

        /// <summary>
        /// Create an integer array between start and end, stepping by one
        /// </summary>
        /// <param name="start">first int of array</param>
        /// <param name="end">last int of array</param>
        /// <returns>array of integer</returns>
        public static int[] createIntArray(int start, int end) {
            int[] array = new int[end - start + 1];
            var count = 0;
            for(int i = start; i<=end; i++) {
                array[count] = i;
                count++;
            }
            return array;
        }

        /// <summary>
        /// Convert a string to title case (first character to be capital letter)
        /// i.e. "hello" -> "Hello"
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToTitleCase(string text) {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }

        /// <summary>
        /// Convert family name and given name to single user name
        /// </summary>
        /// <param name="familyName">family name</param>
        /// <param name="givenName">given name</param>
        /// <returns>user name as a single string</returns>
        public static string ToUserName(string familyName, string givenName) {
            return ToTitleCase(familyName) + ToTitleCase(givenName);
        }

    }
}
