using System;
namespace CAB301Assignment {
    public static class MemberOptions {

        /// <summary>
        /// Supports output of member option 1 (display all movies)
        /// </summary>
        /// <param name="movies">movie collection</param>
        /// <returns>text contains all movie information</returns>
        public static string Member1(Movie[] movies) {
            Console.WriteLine("\n=====All movies=====");
            string text = "";
            foreach (Movie m in movies) {
                text += String.Format(
                        "Title: {0} \n" +
                        "  -Starring: {1} \n" +
                        "  -Director: {2} \n" +
                        "  -Duration: {3} \n" +
                        "  -Genre: {4} \n" +
                        "  -Classification: {5} \n" +
                        "  -Release date: {6} \n" +
                        "  -Availability {7} \n" +
                        "  -Number of rented {8} \n",
                        m.title, m.starring, m.director, m.duration,
                        GenreMethods.toString(m.genre), ClassificationMethods.toString(m.classification),
                        m.releaseDate, m.NumCopies, m.NumBorrowed);
                text += "\n";
            }

            return text;
        }

        /// <summary>
        /// Supports input for borrowing movie 
        /// </summary>
        /// <param name="movies">all available movies in Movie Collection</param>
        /// <returns>title of the movie that is selected by the member</returns>
        public static string Member2(Movie[] movies) {
            Console.WriteLine("\n=====Borrow movie=====");
            // display all movie title in the store
            for (int i=0; i < movies.Length; i++) {
                Console.WriteLine("{0}. {1}", i + 1, movies[i].title);
            }
            // ask which title they want to borrow (input by number)
            int res = Reusables.waitUserResponse("Select by number: ", Reusables.createIntArray(1, movies.Length));
            // return title
            return movies[res - 1].title;
        }

        /// <summary>
        /// Supports input for returning movie
        /// </summary>
        /// <param name="borrowing">All movies that the user is currently borrowing</param>
        /// <returns>title of movie to be returned</returns>
        public static string Member3(Movie[] borrowing) {
            Console.WriteLine("\n=====Return movie=====");
            // remove null value and create new array for easy handling
            Movie[] nullRemoved = new Movie[0];
            foreach(Movie m in borrowing) {
                if (m != null) {
                    Array.Resize(ref nullRemoved, nullRemoved.Length + 1);
                    nullRemoved[nullRemoved.Length - 1] = m;
                }
            }
            for(int i = 0; i < nullRemoved.Length; i++) {
                Console.WriteLine("{0}. {1}", i + 1, nullRemoved[i].title);
            }
            // ask which title they want to borrow (input by number)
            int res = Reusables.waitUserResponse("Select by number: ", Reusables.createIntArray(1, nullRemoved.Length));
            // return title
            return nullRemoved[res - 1].title;
        }

        /// <summary>
        /// Supports output to dispaly all movies that the member is currently borrowing
        /// </summary>
        /// <param name="borrowing">all movies that the member is currently borrowing</param>
        /// <returns>text of all movie information</returns>
        public static string Member4(Movie[] borrowing) {
            Console.WriteLine("\n=====Your borrowings=====");
            string text = "";
            foreach (Movie m in borrowing) {
                if (m != null) {
                    text += string.Format(
                            "Title: {0} \n" +
                            "  -Starring: {1} \n" +
                            "  -Director: {2} \n" +
                            "  -Duration: {3} \n" +
                            "  -Genre: {4} \n" +
                            "  -Classification: {5} \n" +
                            "  -Release date: {6} \n",
                            m.title, m.starring, m.director, m.duration,
                            GenreMethods.toString(m.genre), ClassificationMethods.toString(m.classification),
                            m.releaseDate);
                    text += "\n";
                }
            }

            return text;
        }

        /// <summary>
        /// Supports output for displaying top 10 movies
        /// </summary>
        /// <param name="rank">collection of Ranking objects (in this case, the array size must be 10 !!!</param>
        /// <returns>top 10 text</returns>
        public static string Member5(Ranking[] rank) {
            Console.WriteLine("\n=====Top 10 list=====");

            string text = "";
            // for rank (1 ~ 10)
            for (int i = 0; i< 10; i++) {
                // current rank does not have any movies in
                if (rank[i].movies.Length == 0) {
                    text += string.Format("{0}. -----\n", i + 1);
                    continue;
                }
                // iterate over inside the current rank 
                for (int j = 0; j<rank[i].Counter; j++) {
                    // for first object of the rank, display rank number
                    if (j == 0) {
                        text += string.Format("{0}. {1} ({2})\n", i + 1, rank[i].movies[j].title, rank[i].movies[j].NumBorrowed);
    // for duplicates, do not display rank number, instead dispaly "|" so that it is clear that they are in same rank
                    } else {
                        text += string.Format(" | {0} ({1})\n", rank[i].movies[j].title, rank[i].movies[j].NumBorrowed);
                    }
                }
            }
            return text;
        }
    }
}
