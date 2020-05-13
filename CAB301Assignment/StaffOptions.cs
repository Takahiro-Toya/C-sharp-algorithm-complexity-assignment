using System;
namespace CAB301Assignment {
    public static class StaffOptions {

        public static Movie Staff1() {

            string title = "";
            string starring = "";
            string director = "";
            int duration = 0;
            int numCopies = 0;
            Genre genre = Genre.Drama;
            Classification classification = Classification.General;
            int releaseDate = 2000;

            Console.WriteLine("\n=====Add Movie=====");
            Console.Write("Title: ");
            title = Console.ReadLine();
            Console.Write("Starring: ");
            starring = Console.ReadLine();
            Console.Write("Director: ");
            director = Console.ReadLine();
            duration = Reusables.waitUserIntegerResponse("Duration(minutes): ");
            genre = (Reusables.waitUserResponse("Genre:\n" +
                                                   "1. Drama\n" +
                                                   "2. Adventure\n" +
                                                   "3. Family\n" +
                                                   "4. Action\n" +
                                                   "5. Sci-Fi\n" +
                                                   "6. Comedy\n" +
                                                   "7. Animated\n" +
                                                   "8. Thriller\n" +
                                                   "9. Other\n" +
                                                   "Select: ", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })) switch
            {
                1 => Genre.Drama,
                2 => Genre.Adventure,
                3 => Genre.Family,
                4 => Genre.Action,
                5 => Genre.SciFi,
                6 => Genre.Comedy,
                7 => Genre.Animated,
                8 => Genre.Thriller,
                9 => Genre.Other,
                _ => Genre.Other,
            };
            classification = (Reusables.waitUserResponse("Classification:\n" +
                                                   "1. General (G)\n" +
                                                   "2. Parental Guidance (PG)\n" +
                                                   "3. Mature (M15+)\n" +
                                                   "4. Mature Accompanies (MA15+)\n" +
                                                   "Select: ", new int[] { 1, 2, 3, 4 })) switch
            {
                1 => Classification.General,
                2 => Classification.ParentalGuidance,
                3 => Classification.Mature,
                4 => Classification.MatureAccompanied,
                _ => Classification.General,
            };
            releaseDate = Reusables.waitUserIntegerResponse("Release date (year): ");
            numCopies = Reusables.waitUserIntegerResponse("Number of copies: ");
            return new Movie(title, starring, director, duration, genre, classification, releaseDate, numCopies);
        }



        public static string Staff2(Movie[] movies) {
            // ask what movie title they want to remove
            Console.WriteLine("\n====Remove movie=====");
            // display all movie title in the store
            for (int i = 0; i < movies.Length; i++) {
                Console.WriteLine("{0}. {1}", i + 1, movies[i].title);
            }
            // ask which title they want to borrow (input by number)
            int res = Reusables.waitUserResponse("Select by number: ", Reusables.createIntArray(1, movies.Length));
            // return title
            return movies[res - 1].title;
        }

        public static Member Staff3() {
            // ask member detail
            string givenName;
            string familyName;
            string address;
            string phoneNumber;
            string password;
            Console.WriteLine("\n=====Add new member===");
            Console.Write("Given name: ");
            givenName = Console.ReadLine();
            Console.Write("Family name: ");
            familyName = Console.ReadLine();
            Console.Write("Address: ");
            address = Console.ReadLine();
            Console.Write("Phone number: ");
            phoneNumber = Console.ReadLine();
            password = Reusables.waitUserSetPassword("Password: ");
            return new Member(givenName, familyName, address, phoneNumber, password);
        }

        public static string Staff4() {
            Console.WriteLine("\n=====Find phone number=====");
            Console.Write("Username: ");
            return Console.ReadLine();
        }
    }
}
