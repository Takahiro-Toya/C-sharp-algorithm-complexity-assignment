using System;

namespace CAB301Assignment {
    class Program {

        private static AppStatus appStatus = AppStatus.MainMenu;

        private static MovieCollection movieCollection = new  MovieCollection();
        private static MemberCollection memberCollection = new MemberCollection();

        private static string staffUsername = "staff";
        private static string staffPassword = "today123";

        private static bool staffVerified = false;
        private static bool memberVerified = false;

        private static Member user = null;

        private static void TESTaddMovie() {
            Movie[] movies = new Movie[] {
                new Movie("Starwars(m1)", "star1", "director1", 240, Genre.Action, Classification.General, 2009, 9),
                new Movie("Ponyo(m2)", "star1", "director1", 240, Genre.Adventure, Classification.General, 2009, 0),
                new Movie("Totoro(m3)", "star1", "director1", 240, Genre.Action, Classification.Mature, 2009, 3),
                new Movie("Someanime(m4)", "star1", "director1", 240, Genre.Action, Classification.General, 2009, 20),
                new Movie("Unchi(m5)", "star1", "director1", 240, Genre.Action, Classification.ParentalGuidance, 2009, 2),
                new Movie("Lalaland(m6)", "star1", "director1", 240, Genre.Comedy, Classification.ParentalGuidance, 2009, 1),
                new Movie("Chinchin(m7)", "star1", "director1", 240, Genre.Family, Classification.MatureAccompanied, 2009, 9),
                new Movie("Boringmovie(m8)", "star1", "director1", 240, Genre.Other, Classification.General, 2009, 6),
                new Movie("Kelkel(m9)", "star1", "director1", 240, Genre.Thriller, Classification.General, 2009, 9),
                new Movie("Goodmornig(m10)", "star1", "director1", 240, Genre.Action, Classification.General, 2009, 5),
                new Movie("AustraliaDocumentary(m11)", "star1", "director1", 240, Genre.Action, Classification.General, 2009, 9),
                new Movie("hahahahah(m12)", "star1", "director1", 240, Genre.Animated, Classification.Mature, 2009, 9),
            };
            foreach(Movie m in movies) {
                movieCollection.AddMovie(m);
            }
        }

        private static void TESTaddMember() {
            Member[] members = new Member[] {
                new Member("Takahiro", "Toya", "address1", "12345678", "1111"),
                new Member("Takashi", "Mochizuki", "address2", "23456789", "2222"),
                new Member("Richard", "Wang", "address3", "34567890", "3333"),
                new Member("Adam", "Susu", "address4", "45678901", "4444"),
                new Member("Hello", "Unko", "address5", "56789012", "5555"),
                new Member("Keiko", "Kitagawa", "address6", "67890123", "6666"),
                new Member("Good", "Morning", "address7", "78901234", "7777"),
                new Member("Sydney", "Australia", "address8", "89012345", "8888"),
            };
            foreach (Member m in members) {
                memberCollection.RegisterMember(m);
            }
        }

        static void Main(string[] args) {
            TESTaddMovie();
            TESTaddMember();
            while (appStatus != AppStatus.Exit) {
                switch (appStatus) {
                    case AppStatus.MainMenu:
                        MainMenu();
                        break;
                    case AppStatus.StaffMenu:
                        StaffMenu();
                        break;
                    case AppStatus.MemberMenu:
                        MemberMenu();
                        break;
                    case AppStatus.Staff1:
                        Staff1Package();
                        break;
                    case AppStatus.Staff2:
                        Staff2Package();
                        break;
                    case AppStatus.Staff3:
                        Staff3Package();
                        break;
                    case AppStatus.Staff4:
                        Staff4Package();
                        break;
                    case AppStatus.Member1:
                        Member1Package();
                        break;
                    case AppStatus.Member2:
                        Member2Package();
                        break;
                    case AppStatus.Member3:
                        Member3Package();
                        break;
                    case AppStatus.Member4:
                        Member4Package();
                        break;
                    case AppStatus.Member5:
                        Member5Package();
                        break;
                    default:
                        MainMenu();
                        break;
                }      
            }
        }
    

        static void MainMenu() {
            staffVerified = false;
            memberVerified = false;
            Console.WriteLine(
                "\nWelcome to the Community Library\n" +
                "===========Main Menu============\n" +
                "1. Staff Login\n" +
                "2. Member Login\n" +
                "0. Exit\n" +
                "================================");
            switch (Reusables.waitUserResponse("\n Please make a selection (1-2, or 0 to exit): ", new int[] { 0, 1, 2 })) {
                case 0:
                    appStatus = AppStatus.Exit;
                    break;
                case 1:
                    appStatus = AppStatus.StaffMenu;
                    break;
                case 2:
                    appStatus = AppStatus.MemberMenu;
                    break;
                default:
                    appStatus = AppStatus.Exit;
                    break;
            }
        }

        static void StaffMenu() {
            if (!staffVerified) {
                StaffLogin();
            } else {
                Console.WriteLine(
                    "\n=============Staff Menu==========\n" +
                    "1. Add a new movie DVD\n" +
                    "2. Remove a movie DVD\n" +
                    "3. Register a new Member\n" +
                    "4. Find a registered member's phone number\n" +
                    "0. Return to main menu\n" +
                    "=================================");
                switch (Reusables.waitUserResponse("\n Please make a selection (1-4 or 0 to return to main menu): ", new int[] { 0, 1, 2, 3, 4 })) {
                    case 0:
                        appStatus = AppStatus.MainMenu;
                        break;
                    case 1:
                        appStatus = AppStatus.Staff1;
                        break;
                    case 2:
                        appStatus = AppStatus.Staff2;
                        break;
                    case 3:
                        appStatus = AppStatus.Staff3;
                        break;
                    case 4:
                        appStatus = AppStatus.Staff4;
                        break;
                    default:
                        appStatus = AppStatus.MainMenu;
                        break;
                }
            }
        }

        static void MemberMenu() {
            if (!memberVerified) {
                MemberLogin();
            } else {
                Console.WriteLine(
                    "\n==============Member Menu=========\n" +
                    "1. Dispaly all movies\n" +
                    "2. Borrow a movie DVD\n" +
                    "3. Return a moive DVD\n" +
                    "4. List current borrowed movie DVDs\n" +
                    "5. Display top 10 most popular movies\n" +
                    "0. Return to main menu\n" +
                    "===================================");
                switch (Reusables.waitUserResponse("\n Please make a selection (1-5 or 0 to return to main menu): ", new int[] { 0, 1, 2, 3, 4, 5 })) {
                    case 0:
                        appStatus = AppStatus.MainMenu;
                        break;
                    case 1:
                        appStatus = AppStatus.Member1;
                        break;
                    case 2:
                        appStatus = AppStatus.Member2;
                        break;
                    case 3:
                        appStatus = AppStatus.Member3;
                        break;
                    case 4:
                        appStatus = AppStatus.Member4;
                        break;
                    case 5:
                        appStatus = AppStatus.Member5;
                        break;
                    default:
                        appStatus = AppStatus.MainMenu;
                        break;
                }
            }
        }

        static void StaffLogin() {
            while (true) {
                Console.Write("username: ");
                if (Console.ReadLine() == staffUsername) {
                    break;
                } else {
                    Console.WriteLine("\n ** username is wrong ** \n");
                }
            }

            while (true) {
                Console.Write("password: ");
                if (Console.ReadLine() == staffPassword) {
                    break;
                } else {
                    Console.WriteLine("\n ** password is wrong ** \n");
                }
            }
            staffVerified = true;
        }

        static void MemberLogin() {
            if (memberCollection.NumMembers == 0) {
                Console.WriteLine("\n ** No member registered ** \n");
                appStatus = AppStatus.MainMenu;
                return;
            } else {
                Member search = null;
                while(true) {
                    Console.Write("username: ");
                    search = memberCollection.FindMember(Console.ReadLine());
                    if (search == null) {
                        Console.WriteLine("\n ** member not found ** \n");
                    } else {
                        break;
                    }
                }
                while (true) {
                    Console.Write("password: ");
                    if (search.password == Console.ReadLine()) {
                        break;
                    } else {
                        Console.WriteLine("\n ** password is wrong ** \n");
                    }
                }
                user = search;
                memberVerified = true;
            }
           
        }


        // W.I.P
        /// <summary>
        /// Add a new movie DVD
        /// </summary>
        static void Staff1Package() {
            Movie m = StaffOptions.Staff1();
            if (movieCollection.AddMovie(m)) {
                Console.WriteLine("\n !!! Movie added !!! \n");
            } else {
                Console.WriteLine("\n ** Movie already exists ** \n");
            }
            appStatus = AppStatus.StaffMenu;
        }

        // W.I.P
        /// <summary>
        /// Remove a movie DVD
        /// </summary>
        static void Staff2Package() {
            Movie[] movies = movieCollection.GetAllMovies();
            if (movies.Length == 0) {
                Console.WriteLine("\n ** No movies available ** \n");
                return;
            } else {
                string title = StaffOptions.Staff2(movies);
                movieCollection.RemoveMovie(title);
                Console.WriteLine("\n !!! Movie DVD removed !!! \n");
            }
            appStatus = AppStatus.StaffMenu;
        }


        /// <summary>
        /// Register a new Member
        /// </summary>
        static void Staff3Package() {
            Member m = StaffOptions.Staff3();
            memberCollection.RegisterMember(m);
            Console.WriteLine("\n !!! Member registered !!! \n");
            appStatus = AppStatus.StaffMenu;
        }

        /// <summary>
        /// Find a registered member's phone number
        /// </summary>
        static void Staff4Package() {
            string ph = memberCollection.FindMemberPhoneNumber(StaffOptions.Staff4());
            Console.WriteLine("\n Phone number is: {0} \n", ph);
            appStatus = AppStatus.StaffMenu;
        }

        /// <summary>
        /// Display all movies
        /// </summary>
        static void Member1Package() {
            Console.WriteLine(MemberOptions.Member1(movieCollection.GetAllMovies()));
            Reusables.waitUserPressEnter();
            appStatus = AppStatus.MemberMenu;
        }

        /// <summary>
        /// Borrow a movie DVD
        /// </summary>
        static void Member2Package() {
            Movie[] movies = movieCollection.GetAllMovies();
            if (movies.Length == 0) {
                Console.WriteLine("\n ** No movies available ** \n");
            } else {
                string title = MemberOptions.Member2(movies);
                Movie m = movieCollection.GetMovie(title);
                try {
                    // user already borrow this movie
                    if (user.ContainsMovie(m)) {
                        Console.WriteLine("\n ** You already have been borrowing this movie** \n");
                    // user does not hold this movie, AND;
                    } else {
                        // movie is available
                        if (m.IsAvailable) {
                            // fetch success code 
                            if (user.BorrowMovie(m)) {
                                m.Borrowed();
                                Console.WriteLine("\n !!! Successfully borrowed !!! \n");
                            // fetch error code after checking current number of borrowing in user account
                            } else {
                                Console.WriteLine("\n ** You reach maximum number of borrowing ** \n");
                            }
                        } else {
                            Console.WriteLine("\n ** No copies available ** \n");
                        }
                    }
                    // should not occur as the title is selected by index number
                } catch {
                    Console.WriteLine("\n ** Something wrong, borrow failed ** \n");
                }

            }
            appStatus = AppStatus.MemberMenu;
        }

        /// <summary>
        /// Return a movie DVD
        /// </summary>
        static void Member3Package() {
            if (user.NumBorrowing == 0) {
                Console.WriteLine("\n ** You have no movies borroing ** \n");
            } else {
                string title = MemberOptions.Member3(user.GetBorrowingMovies());
                user.ReturnMovie(title);
                movieCollection.GetMovie(title).Returned();
            }
            appStatus = AppStatus.MemberMenu;
        }

        /// <summary>
        /// List currently borrowing movie DVDs
        /// </summary>
        static void Member4Package() {
            if (user.NumBorrowing == 0) {
                Console.WriteLine("\n ** You have no movies borrowing ** \n");
            } else {
                Console.WriteLine(MemberOptions.Member4(user.GetBorrowingMovies()));
                Reusables.waitUserPressEnter();
            }
            appStatus = AppStatus.MemberMenu;
        }

        /// <summary>
        /// Display top 10 most popular movies
        /// </summary>
        static void Member5Package() {
            Console.WriteLine(MemberOptions.Member5(movieCollection.GetTopTenMovies()));
            Reusables.waitUserPressEnter();
            appStatus = AppStatus.MemberMenu;
        }


    }
}
