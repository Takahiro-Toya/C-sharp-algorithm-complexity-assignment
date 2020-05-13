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
        private Movie[] borrowingMovies = new Movie[BORROW_LIMIT];
        private int numBorrowing = 0;
        public int NumBorrowing {
            get { return numBorrowing; }
        }

        public Member(string givenName, string familyName, string address, string phoneNumber, string password) {
            this.givenName = Reusables.ToTitleCase(givenName);
            this.familyName = Reusables.ToTitleCase(familyName);
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.username = Reusables.ToTitleCase(familyName) + Reusables.ToTitleCase(givenName);
            this.password = password;
        }

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


        public bool ReturnMovie(string title) {
            for (int i=0; i<borrowingMovies.Length; i++) {
                if (borrowingMovies[i].title == title) {
                    borrowingMovies[i] = null;
                    numBorrowing--;
                    return true;
                }
            }
            return false;
        }

        public Movie[] GetBorrowingMovies() {

            return borrowingMovies;
        }

        public int CompareTo(Member other) {
            return string.Compare(this.username, other.username);
        }
    }
}
