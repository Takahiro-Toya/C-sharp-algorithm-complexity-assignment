using System;
namespace CAB301Assignment {
    public class Member: IComparable<Member> {

        public string givenName = "";
        public string familyName = "";
        public string address = "";
        public string phoneNumber = "";

        public string username = "";
        public int password = 0;

        private Movie[] borrowingMovies = new Movie[10];
        private int numBorrowing = 0;

        public Member(string givenName, string familyName, string address, string phoneNumber, int password) {
            this.givenName = Reusables.ToTitleCase(givenName);
            this.familyName = Reusables.ToTitleCase(familyName);
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.username = Reusables.ToTitleCase(familyName) + Reusables.ToTitleCase(givenName);
            this.password = password;
        }

        public bool BorrowMovie(Movie m) {

            if (numBorrowing >= 10) { return false; }
            for(int i=0; i<numBorrowing; i++) {
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
