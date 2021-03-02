using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
    static class UserData
    {
        public static User[] TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        private static User[] _testUsers;

        private static void ResetTestUserData()
        {
            _testUsers = new User[3];
            _testUsers[0] = new User("admin", "admin", "121218022", UserRoles.ADMIN);
            _testUsers[1] = new User("Ivan", "pass", "121218022", UserRoles.STUDENT);
            _testUsers[2] = new User("Mitak", "pass2", "121218022", UserRoles.INSPECTOR);
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            foreach (var user in TestUsers)
            {
                if(user.Password.Equals(password) && user.Username.Equals(username))
                {
                    return user;
                }
            }

            return null;
        }
    }
}
