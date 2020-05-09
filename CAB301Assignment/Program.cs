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

        static void kain(string[] args) {
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
                        MainMenu();
                        break;
                    case AppStatus.Member2:
                        MainMenu();
                        break;
                    case AppStatus.Member3:
                        MainMenu();
                        break;
                    case AppStatus.Member4:
                        MainMenu();
                        break;
                    case AppStatus.Member5:
                        MainMenu();
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
            switch (Reusables.waitUserResponse(" Please make a selection (1-2, or 0 to exit): ", new int[] { 0, 1, 2 })) {
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
            }
            Console.WriteLine(
                "\n=============Staff Menu==========\n" +
                "1. Add a new movie DVD\n" +
                "2. Remove a movie DVD\n" + 
                "3. Register a new Member\n" +
                "4. Find a registered member's phone number\n" +
                "0. Return to main menu\n" +
                "=================================");
            switch (Reusables.waitUserResponse(" Please make a selection (1-4 or 0 to return to main menu): ", new int[] { 0, 1, 2, 3, 4 })) {
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

        static void MemberMenu() {
            //if (!memberVerified) {
            //    MemberLogin();
            //}
            Console.WriteLine(
                "\n==============Member Menu=========\n" +
                "1. Dispaly all movies\n" +
                "2. Borrow a movie DVD\n" +
                "3. Return a moive DVD\n" +
                "4. List current borrowed movie DVDs\n" +
                "5. Display top 10 most popular movies\n" +
                "0. Return to main menu\n" +
                "===================================");
            switch (Reusables.waitUserResponse(" Please make a selection (1-5 or 0 to return to main menu): ", new int[] { 0, 1, 2, 3, 4, 5 })) {
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

        static void StaffLogin() {
            while (true) {
                Console.Write("username: ");
                if (Console.ReadLine() == staffUsername) {
                    break;
                } else {
                    Console.WriteLine("** username is wrong **");
                }
            }

            while (true) {
                Console.Write("password: ");
                if (Console.ReadLine() == staffPassword) {
                    break;
                } else {
                    Console.WriteLine("** password is wrong **");
                }
            }
            staffVerified = true;
        }

        static void MemberLogin() {

            memberVerified = true;
        }


        // W.I.P
        /// <summary>
        /// Add a new movie DVD
        /// </summary>
        static void Staff1Package() {
            Movie m = StaffOptions.Staff1();
            movieCollection.AddMovie(m);
            appStatus = AppStatus.StaffMenu;
        }

        // W.I.P
        /// <summary>
        /// Remove a movie DVD
        /// </summary>
        static void Staff2Package() {
            string title = StaffOptions.Staff2(movieCollection.GetAllMovieTitle());
            movieCollection.RemoveMovie(title);
            appStatus = AppStatus.StaffMenu;
        }


        /// <summary>
        /// Register a new Member
        /// </summary>
        static void Staff3Package() {
            Member m = StaffOptions.Staff3();
            memberCollection.RegisterMember(m);
            appStatus = AppStatus.StaffMenu;
        }

        /// <summary>
        /// Find a registered member's phone number
        /// </summary>
        static void Staff4Package() {
            string[] fg = StaffOptions.Staff4();
            string ph = memberCollection.FindMemberPhoneNumber(fg[0], fg[1]);
            Console.WriteLine("TEST:" + ph);
            Console.WriteLine("TEST----");
            foreach(Member m in memberCollection.TESTGetMembers()) {
                Console.WriteLine(m.familyName + " " +  m.username + " " + m.phoneNumber);
            }
            appStatus = AppStatus.StaffMenu;
        }

        /// <summary>
        /// Display all movies
        /// </summary>
        static void Member1Package() {

            appStatus = AppStatus.MemberMenu;
        }

        /// <summary>
        /// Borrow a movie DVD
        /// </summary>
        static void Member2Package() {
            // movie title in array that they want to borrow
            string title = MemberOptions.Member2(new Movie[] { });
            Movie m = movieCollection.GetMovie(title);
            user.BorrowMovie(m);
            appStatus = AppStatus.MemberMenu;
        }

        /// <summary>
        /// Return a movie DVD
        /// </summary>
        static void Member3Package() {
            // index of movie in Member's borrowing list
            int index = MemberOptions.Member3(new Movie[] { });

            appStatus = AppStatus.MemberMenu;
        }

        /// <summary>
        /// List current borrowed movie DVDs
        /// </summary>
        static void Member4Package() {
            Console.WriteLine();
            appStatus = AppStatus.MemberMenu;
        }

        /// <summary>
        /// Display top 10 most popular movies
        /// </summary>
        static void Member5Package() {
            Console.WriteLine(movieCollection.GetTop10List());
            appStatus = AppStatus.MemberMenu;
        }


    }
}
