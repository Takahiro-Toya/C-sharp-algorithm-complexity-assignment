using System;
namespace CAB301Assignment {
    public class Member: IComparable<Member> {

        public string givenName = "";
        public string familyName = "";
        public string address = "";
        public string phoneNumber = "";
        public string username = "";
        public string password = "0000";
        
        private const int BORROW_LIMIT = 10;

        // all the movies that this member is currently borrowing
        private Movie[] borrowingMovies = new Movie[BORROW_LIMIT];

        // To keep track of how many movies that this member is currently borrowing.
        private int numBorrowing = 0;
        public int NumBorrowing {
            get { return numBorrowing; }
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="givenName">member's given name</param>
        /// <param name="familyName">member's family name</param>
        /// <param name="address">member's address</param>
        /// <param name="phoneNumber">member's phone number</param>
        /// <param name="password">member's password</param>
        public Member(string givenName, string familyName, string address, string phoneNumber, string password) {
            this.givenName = Reusables.ToTitleCase(givenName);
            this.familyName = Reusables.ToTitleCase(familyName);
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.username = Reusables.ToTitleCase(familyName) + Reusables.ToTitleCase(givenName);
            this.password = password;
        }

        /// <summary>
        /// Borrow movie
        /// </summary>
        /// <param name="m">movie that this member wants to borrow</param>
        /// <returns>status code: true if borrow success</returns>
        public bool BorrowMovie(Movie m) {

            if (numBorrowing >= BORROW_LIMIT) { return false; }
            for(int i=0; i< BORROW_LIMIT; i++) {
             
                if (borrowingMovies[i] == null) {
                    borrowingMovies[i] = m;
                    numBorrowing++;
                    break;
                }
            }
            return true;
        }


        /// <summary>
        /// Returns movie, given title
        /// </summary>
        /// <param name="title">title of the movie that this member wants to return</param>
        /// <returns>status code if return success</returns>
        public bool ReturnMovie(string title) {
            for (int i=0; i<borrowingMovies.Length; i++) {
                if (borrowingMovies[i] != null && borrowingMovies[i].title == title) {
                    borrowingMovies[i] = null;
                    numBorrowing--;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Examine if this member holds movie, given the title
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>status code: true if this member holds the movie of the title</returns>
        public bool HoldsMovie(string title) {
            foreach(Movie m in borrowingMovies) {
                if (m != null) {
                    if (m.title == title) {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Get all borrowing movies
        /// </summary>
        /// <returns>array of movies that this member is currently borrowing</returns>
        public Movie[] GetBorrowingMovies() {

            return borrowingMovies;
        }

        /// <summary>
        /// Compares this member with others
        /// </summary>
        /// <param name="other">other member</param>
        /// <returns>
        /// -1 if this member should come before other member
        /// 0 if this member has same username with other member
        /// 1 if this member should come after other member
        /// </returns>
        public int CompareTo(Member other) {
            return string.Compare(this.username, other.username);
        }
    }
}
