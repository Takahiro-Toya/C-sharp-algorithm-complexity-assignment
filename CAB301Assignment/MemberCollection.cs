using System;
namespace CAB301Assignment {
    public class MemberCollection {

        private const int MAX_MEMBERS = 10;

        /// <summary>
        /// This must use an ARRAY
        /// </summary>
        private Member[] members = new Member[MAX_MEMBERS];

        private int numMembers = 0;
        public int NumMembers {
            get { return numMembers; }
        }

        public MemberCollection()
        {
        }

        public Member[] TESTGetMembers() {
            return members;
        }

        /// <summary>
        /// Staff will use this function
        /// return false if member aleady exists OR number of members exceeds 10
        /// </summary>
        /// <param name="member"></param>
        public bool RegisterMember(Member member) {
            if (FindMember(member.username) != null) {
                return false;
            }
            for (int i = 0; i < MAX_MEMBERS; i++) {
                if (numMembers >= 10) {
                    return false;
                } else {
                    members[numMembers] = member;
                    numMembers++;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Staff will use this function
        /// </summary>
        /// <param name="familyName"></param>
        /// <param name="givenName"></param>
        /// <returns></returns>
        public string FindMemberPhoneNumber(string username) {
            Member member = FindMember(username);
            if (member == null) {
                return "User not found";
            } else {
                return member.phoneNumber;
            }
        }

        /// <summary>
        /// return success code (true or false)
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool BorrowMovie(Movie movie, string username) {
            Member member = FindMember(username);
            return member.BorrowMovie(movie);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="familyName"></param>
        /// <param name="givenName"></param>
        public bool ReturnMovie(string title, string username) {
            Member member = FindMember(username);
            return member.ReturnMovie(title);
        }

        public Movie[] GetMoviesCurrentlyBorrowing(string username) {
            Member member = FindMember(username);
            return member.GetBorrowingMovies();
        }

        public Member FindMember(string username) {
            foreach (Member m in members) {
                try {
                    if (m.username == username) {
                        return m;
                    }
                } catch {
                    return null;
                }
 
            }
            return null;
        }

    }
}
