using System;
namespace CAB301Assignment {
    public static class StaffOptions {

        /// <summary>
        /// Helps input menu for staff to add a movie
        /// This simply create a movie object based on the input
        /// No duplication check
        /// </summary>
        /// <returns>Movie object</returns>
        public static Movie Staff1() {
            Console.WriteLine("\n=====Add Movie=====");
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Starring: ");
            string starring = Console.ReadLine();
            Console.Write("Director: ");
            string director = Console.ReadLine();
            int duration = Reusables.waitUserIntegerResponse("Duration(minutes): ");
            Genre genre = (Reusables.waitUserResponse("Genre:\n" +
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
            Classification classification = (Reusables.waitUserResponse("Classification:\n" +
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
            int releaseDate = Reusables.waitUserIntegerResponse("Release date (year): ");
            int numCopies = Reusables.waitUserIntegerResponse("Number of copies: ");
            return new Movie(title, starring, director, duration, genre, classification, releaseDate, numCopies);
        }


        /// <summary>
        /// Helps input for staff to remove movie
        /// It returns title of the movie, selected by the index number
        /// So, no need to check its validity
        /// </summary>
        /// <param name="movies">array of movies that are currently registered</param>
        /// <returns>title of the movie to be removed</returns>
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

        /// <summary>
        /// Helps input for staff to register new member
        /// This simply creates a member object, and so
        /// the duplication check should be performed after getting a value returned from this method
        /// </summary>
        /// <returns>Member object</returns>
        public static Member Staff3() {
            Console.WriteLine("\n=====Add new member===");
            Console.Write("Given name: ");
            string givenName = Console.ReadLine();
            Console.Write("Family name: ");
            string familyName = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Phone number: ");
            string phoneNumber = Console.ReadLine();
            string password = Reusables.waitUserSetPassword("Password: ");
            return new Member(givenName, familyName, address, phoneNumber, password);
        }

        /// <summary>
        /// Helps input for staff to find phone number of the movie
        /// This method asks member's username that the staff wants to find phone number
        /// </summary>
        /// <returns>the username of member</returns>
        public static string Staff4() {
            Console.WriteLine("\n=====Find phone number=====");
            Console.Write("Username: ");
            return Console.ReadLine();
        }
    }
}
