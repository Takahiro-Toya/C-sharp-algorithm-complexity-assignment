using System;
namespace CAB301Assignment {
    public static class StaffOptions {

        public static Movie Staff1() {

            string title = "";
            string starring = "";
            string director = "";
            string duration = "0";
            int numCopies = 0;
            Genre genre = Genre.Drama;
            Classification classification = Classification.General;
            string releaseDate = "01-01-2000";

            Console.WriteLine("\n=====Add Movie=====");
            Console.Write("Title: ");
            title = Console.ReadLine();
            Console.Write("Starring: ");
            starring = Console.ReadLine();
            Console.Write("Director: ");
            director = Console.ReadLine();
            Console.Write("Duration (minutes): ");
            duration = Console.ReadLine();
            switch (Reusables.waitUserResponse("Genre:\n" +
                                                   "1. Drama\n" +
                                                   "2. Adventure\n" +
                                                   "3. Family\n" +
                                                   "4. Action\n" +
                                                   "5. Sci-Fi\n" +
                                                   "6. Comedy\n" +
                                                   "7. Animated\n" +
                                                   "8. Thriller\n" +
                                                   "9. Other\n" +
                                                   "Select: ", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })) {
                case 1:
                    genre = Genre.Drama;
                    break;
                case 2:
                    genre = Genre.Adventure;
                    break;
                case 3:
                    genre = Genre.Family;
                    break;
                case 4:
                    genre = Genre.Action;
                    break;
                case 5:
                    genre = Genre.SciFi;
                    break;
                case 6:
                    genre = Genre.Comedy;
                    break;
                case 7:
                    genre = Genre.Animated;
                    break;
                case 8:
                    genre = Genre.Thriller;
                    break;
                case 9:
                    genre = Genre.Other;
                    break;
                default:
                    genre = Genre.Other;
                    break;
            }
            switch (Reusables.waitUserResponse("Classification:\n" +
                                                   "1. General (G)\n" +
                                                   "2. Parental Guidance (PG)\n" +
                                                   "3. Mature (M15+)\n" +
                                                   "4. Mature Accompanies (MA15+)\n" +
                                                   "Select: ", new int[] {1,2,3,4})) {
                case 1:
                    classification = Classification.General;
                    break;
                case 2:
                    classification = Classification.ParentalGuidance;
                    break;
                case 3:
                    classification = Classification.Mature;
                    break;
                case 4:
                    classification = Classification.MatureAccompanied;
                    break;
                default:
                    classification = Classification.General;
                    break;
            }
            Console.Write("Release date: (DD-MM-YYYY): ");
            releaseDate = Console.ReadLine();
            numCopies = Reusables.waitUserIntegerResponse("Number of copies: ");
            return new Movie(title, starring, director, duration, genre, classification, releaseDate, numCopies);
        }



        public static string Staff2(string[] movies) {
            // ask what movie title they want to remove
            Console.WriteLine("\n====Remove movie=====");
            int choice = Reusables.waitUserResponse(Reusables.formtToList(movies), Reusables.createIntArray(1, movies.Length));
            return movies[choice];
        }

        public static Member Staff3() {
            // ask member detail¥
            string givenName;
            string familyName;
            string address;
            string phoneNumber;
            int password;
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

        public static string[] Staff4() {
            // ask member family & given name
            string givenName;
            string familyName;
            Console.WriteLine("\n=====Find phone number=====");
            Console.Write("Family name: ");
            familyName = Console.ReadLine();
            Console.Write("Given name: ");
            givenName = Console.ReadLine();
            return new string[2] { Reusables.ToTitleCase(familyName), Reusables.ToTitleCase(givenName)};
        }
    }
}
