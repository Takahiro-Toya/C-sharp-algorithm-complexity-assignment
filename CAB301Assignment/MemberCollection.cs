using System;
namespace CAB301Assignment {
    public class MemberCollection {

        private const int MAX_MEMBERS = 10;

        /// <summary>
        /// This must use an ARRAY
        /// </summary>
        private Member[] members = new Member[MAX_MEMBERS];

        public MemberCollection()
        {
        }

        public Member[] TESTGetMembers() {
            return members;
        }

        /// <summary>
        /// Staff will use this function
        /// </summary>
        /// <param name="member"></param>
        public bool RegisterMember(Member member) {
            for (int i=0; i< MAX_MEMBERS; i++) {
                if (members[i] == null) {
                    members[i] = member;
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
        public string FindMemberPhoneNumber(string familyName, string givenName) {
            Member member = findMember(Reusables.ToUserName(familyName, givenName));
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
            Member member = findMember(username);
            return member.BorrowMovie(movie);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="familyName"></param>
        /// <param name="givenName"></param>
        public bool ReturnMovie(string title, string username) {
            Member member = findMember(username);
            return member.ReturnMovie(title);
        }

        public Movie[] GetMoviesCurrentlyBeingLent(string username) {
            Member member = findMember(username);
            return member.GetBorrowingMovies();
        }

        private Member findMember(string username) {
            foreach(Member m in members) {
                if (m.username == username) {
                    return m;
                }
            }

            return null;
        }

    }
}
