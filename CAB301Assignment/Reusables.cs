using System;
using System.Text.RegularExpressions;

namespace CAB301Assignment {
    public static class Reusables {
        public static int waitUserResponse(string text, int[] choices) {
            int input;
            while (true) {
                Console.Write(text);
                if (int.TryParse(Console.ReadLine(), out input)) {
                    if (Array.IndexOf(choices, input) > -1) {
                        break;
                    } else {
                        Console.WriteLine("Response: {0} is not a option", input);
                    }
                } else {
                    Console.WriteLine("Response: Input must be a numeric value");
                }
            }
            return input;
        }

        public static int waitUserIntegerResponse(string text) {
            int input;
            while (true) {
                Console.Write(text);
                if (int.TryParse(Console.ReadLine(), out input)) {
                    break;
                } else {
                    Console.WriteLine("Please input number");
                }
            }
            return input;
        }

        public static string waitUserSetPassword(string text) {
            string input = "aaaa";
            while (true) {
                Console.Write(text);
                input = Console.ReadLine();
                if (Regex.IsMatch(input, @"\d{4,4}")) {
                    break;
                } else {
                    Console.WriteLine("Please input 4 digit numer");
                }
            }
            return input;
        }

        public static void waitUserPressEnter() {
            Console.Write("\n  Press Enter to go back...");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }

        //public static string formatToList(string[] options) {
        //    string list = "";
        //    for(int i=1; i<options.Length; i++) {
        //        list += string.Format("{0}. {1}\n", i, options[i - 1]);
        //    }
        //    return list;
        //}

        public static int[] createIntArray(int start, int end) {
            int[] array = new int[end - start + 1];
            var count = 0;
            for(int i = start; i<=end; i++) {
                array[count] = i;
                count++;
            }
            return array;
        }

        public static string ToTitleCase(string text) {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }

        public static string ToUserName(string familyName, string givenName) {
            return ToTitleCase(familyName) + ToTitleCase(givenName);
        }

    }
}
