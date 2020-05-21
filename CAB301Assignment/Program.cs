using System;

namespace CAB301Assignment {
    class Program {

        // keep track of current page
        private static AppStatus appStatus = AppStatus.MainMenu;

        private static MovieCollection movieCollection = new  MovieCollection();
        private static MemberCollection memberCollection = new MemberCollection();

        // staff login info
        private static string staffUsername = "staff";
        private static string staffPassword = "today123";

        // verification code
        private static bool staffVerified = false;
        private static bool memberVerified = false;

        // holds user object
        private static Member user = null;


        /// <summary>
        /// TEST only
        /// </summary>
        //private static void TESTaddMovie() {
        //    Movie[] movies = new Movie[] {
        //        new Movie("Hello world", "star1", "director1", 240, Genre.Action, Classification.General, 2009, 50),
        //        new Movie("Jave world", "star1", "director1", 240, Genre.Adventure, Classification.General, 2009, 50),
        //        new Movie("C# world", "star1", "director1", 240, Genre.Action, Classification.Mature, 1996, 50),
        //        new Movie("C language", "star1", "director1", 240, Genre.Action, Classification.General, 1998, 50),
        //        new Movie("cab301", "star1", "director1", 240, Genre.Action, Classification.ParentalGuidance, 2009, 50),
        //        new Movie("The Python story", "star1", "director1", 240, Genre.Comedy, Classification.ParentalGuidance, 2009, 50),
        //        new Movie("JavaScript land", "star1", "director1", 240, Genre.Family, Classification.MatureAccompanied, 2005, 50),
        //        new Movie("Swift wars", "star1", "director1", 240, Genre.Other, Classification.General, 2017, 50),
        //        new Movie("Sydney documentary", "star1", "director1", 240, Genre.Thriller, Classification.General, 2009, 50),
        //        new Movie("Brisbane movie", "star1", "director1", 240, Genre.Action, Classification.General, 2018, 50),
        //        new Movie("C++++++++++", "star1", "director1", 240, Genre.Action, Classification.General, 2009, 50),
        //        new Movie("Australian wildlife", "star1", "director1", 240, Genre.Animated, Classification.Mature, 2003, 0),
        //        new Movie("Brisbane romance", "star1", "director1", 240, Genre.Drama, Classification.General, 2019, 50),
        //        new Movie("Sydney romance", "star1", "director1", 240, Genre.Thriller, Classification.Mature, 2016, 50),
        //        new Movie("Some movie", "star1", "director1", 240, Genre.Animated, Classification.Mature, 2019, 50),
        //        new Movie("The life of chinese president", "star1", "director1", 240, Genre.Comedy, Classification.ParentalGuidance, 2020, 50),
        //        new Movie("Some movie 2", "star1", "director1", 240, Genre.Comedy, Classification.General, 2016, 50),
        //        new Movie("Some movie 3", "star1", "director1", 240, Genre.Drama, Classification.General, 2020, 50)
        //    };
        //    int counter = 40;
        //    foreach (Movie m in movies) {
        //        movieCollection.Add(m);
        //        for(int j=0; j<counter; j++) {
        //            m.Borrowed();
        //        }
        //        counter--;
        //    }
        //}

        /// <summary>
        /// TEST only
        /// </summary>
        //private static void TESTaddMember() {
        //    // pre-set 9 members
        //    Member[] members = new Member[] {
        //        new Member("Brisbane", "Australia", "brisbane", "12345678", "1111"),
        //        new Member("Sydney", "Australia", "sydney", "23456789", "2222"),
        //        new Member("Perth", "Australia", "perth", "34567890", "3333"),
        //        new Member("Cairns", "Australia", "cairns", "45678901", "4444"),
        //        new Member("Melbourne", "Australia", "melobourne", "56789012", "5555"),
        //        new Member("GoldCoast", "Australia", "gold coast", "67890123", "6666"),
        //        new Member("Darwin", "Australia", "darwin", "78901234", "7777"),
        //        new Member("Hobart", "Australia", "hobart", "89012345", "8888"),
        //        new Member("Adelaide", "Australia", "adelaide", "90123456", "9999")
        //    };
        //    foreach (Member m in members) {
        //        memberCollection.RegisterMember(m);
        //    }
        //}


        /// <summary>
        /// Includes TEST functions at first two lines
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            // comment out or delete below two lines (TEST function)
            //TESTaddMovie();
            //TESTaddMember();
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
    
        /// <summary>
        /// Landing page
        /// </summary>
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
            appStatus = (Reusables.waitUserResponse("\n Please make a selection (1-2, or 0 to exit): ", new int[] { 0, 1, 2 })) switch
            {
                0 => AppStatus.Exit,
                1 => AppStatus.StaffMenu,
                2 => AppStatus.MemberMenu,
                _ => AppStatus.Exit,
            };
        }

        /// <summary>
        /// Staff menu
        /// </summary>
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
                appStatus = (Reusables.waitUserResponse("\n Please make a selection (1-4 or 0 to return to main menu): ", new int[] { 0, 1, 2, 3, 4 })) switch
                {
                    0 => AppStatus.MainMenu,
                    1 => AppStatus.Staff1,
                    2 => AppStatus.Staff2,
                    3 => AppStatus.Staff3,
                    4 => AppStatus.Staff4,
                    _ => AppStatus.MainMenu,
                };
            }
        }

        /// <summary>
        /// Member menu
        /// </summary>
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

        /// <summary>
        /// Handles staff login
        /// </summary>
        static void StaffLogin() {
            // repeat until correct username is typed
            while (true) {
                Console.Write("username: ");
                if (Console.ReadLine() == staffUsername) {
                    break;
                } else {
                    Console.WriteLine("\n ** username is wrong ** \n");
                }
            }

            // repeat until correct password is typed
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

        /// <summary>
        /// Handles member login
        /// </summary>
        static void MemberLogin() {
            // back to main menu when there is no member registered
            if (memberCollection.NumMembers == 0) {
                Console.WriteLine("\n ** No member registered ** \n");
                appStatus = AppStatus.MainMenu;
                return;
            } else {
                Member search = null;
                while(true) {
                    Console.Write("username: ");
                    search = memberCollection.GetMember(Console.ReadLine());
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


        /// <summary>
        /// Add a new movie DVD
        /// </summary>
        static void Staff1Package() {
            Movie m = StaffOptions.Staff1();
            if (movieCollection.Add(m)) {
                Console.WriteLine("\n !!! Movie added ({0}) !!! \n", m.title);
            } else {
                Console.WriteLine("\n ** Movie already exists ** \n");
            }
            appStatus = AppStatus.StaffMenu;
        }

        /// <summary>
        /// Remove a movie DVD
        /// </summary>
        static void Staff2Package() {
            Movie[] movies = movieCollection.GetAlphabetical();
            if (movies.Length == 0) {
                Console.WriteLine("\n ** No movies available ** \n");
            } else {
                string title = StaffOptions.Staff2(movies);
                movieCollection.Remove(title);
                Console.WriteLine("\n !!! Movie DVD removed ({0}) !!! \n", title);
            }
            appStatus = AppStatus.StaffMenu;
        }


        /// <summary>
        /// Register a new Member
        /// </summary>
        static void Staff3Package() {
            Member m = StaffOptions.Staff3();
            if (memberCollection.RegisterMember(m)) {
                Console.WriteLine("\n !!! Member registered !!! \n");
            } else {
                Console.WriteLine("\n ** Member already exists ** \n");
            }
            appStatus = AppStatus.StaffMenu;
        }

        /// <summary>
        /// Find a registered member's phone number
        /// </summary>
        static void Staff4Package() {
            string username = StaffOptions.Staff4();
            Console.WriteLine(memberCollection.FindMemberPhoneNumber(username));
            appStatus = AppStatus.StaffMenu;
        }

        /// <summary>
        /// Display all movies
        /// </summary>
        static void Member1Package() {
            Console.WriteLine(MemberOptions.Member1(movieCollection.GetAlphabetical()));
            Reusables.waitUserPressEnter();
            appStatus = AppStatus.MemberMenu;
        }

        /// <summary>
        /// Borrow a movie DVD
        /// </summary>
        static void Member2Package() {
            Movie[] movies = movieCollection.GetAlphabetical(); // this is sorted alphabetically
            if (movies.Length == 0) {
                Console.WriteLine("\n ** No movies available ** \n");
            } else {
                string title = MemberOptions.Member2(movies);
                Movie m = movieCollection.GetMovie(title);
                try {
                    // user already borrow this movie
                    if (user.HoldsMovie(m.title)) {
                        Console.WriteLine("\n ** You already have been borrowing this movie ** \n");
                    // user does not hold this movie, AND;
                    } else {
                        // movie is available
                        if (m.IsAvailable) {
                            // make a copy of movie and fetch success code
                            // (false returned if user already has same title movid DVD)
                            if (user.BorrowMovie(m.MakeCopy())) {
                                m.Borrowed();
                                Console.WriteLine("\n !!! Successfully borrowed ({0}) !!! \n", m.title);
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
                    Console.WriteLine("\n ** Something went wrong, borrow failed ** \n");
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
                Movie movie = movieCollection.GetMovie(title);
                if (movie != null) {
                    movie.Returned();
                }
                Console.WriteLine("\n !!! Movie returned ({0}) !!! \n", title);
            }
            appStatus = AppStatus.MemberMenu;
        }

        /// <summary>
        /// List all movies that the member is currently borrowing
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
