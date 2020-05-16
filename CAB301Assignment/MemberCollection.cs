using System;
namespace CAB301Assignment {
    public class MemberCollection {

        private const int MAX_MEMBERS = 10;

        private Member[] members = new Member[MAX_MEMBERS];

        // To keep track of how many members are currently registetered
        private int numMembers = 0;
        public int NumMembers {
            get { return numMembers; }
        }


        /// <summary>
        /// Register a new member 
        /// </summary>
        /// <param name="member">New member object</param>
        public bool RegisterMember(Member member) {
            // if member already exists (username must be unique in the system)
            // OR if the number members registered in the system is 10
            if ((GetMember(member.username) != null) || numMembers >= 10) {
                return false;
            } else {
                for (int i = 0; i < MAX_MEMBERS; i++) {
                    members[numMembers] = member;
                    numMembers++;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Search member's phonenumber given username
        /// </summary>
        /// <param name="username">username of the member whose phone number being looked for</param>
        /// <returns>member's phone number</returns>
        public string FindMemberPhoneNumber(string username) {
            Member member = GetMember(username);
            // member does not exist 
            if (member == null) {
                return "User not found";
            } else {
                return member.phoneNumber;
            }
        }

        /// <summary>
        /// Get member object, given username
        /// </summary>
        /// <param name="username">member's username</param>
        /// <returns>member object with username</returns>
        public Member GetMember(string username) {
            for(int i=0; i<numMembers; i++) {
                if (members[i].username == username) {
                    return members[i];
                }
            }
            return null;
        }

    }
}
