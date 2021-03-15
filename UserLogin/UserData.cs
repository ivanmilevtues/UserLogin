using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace UserLogin
{
    static class UserData
    {
        public static List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        private static List<User> _testUsers;

        private static void ResetTestUserData()
        {
            _testUsers = new List<User>();
            _testUsers.Add(new User("admin", "admin", "121218022", UserRoles.ADMIN, DateTime.Now - new TimeSpan(24, 15, 0), DateTime.MaxValue));
            _testUsers.Add(new User("Ivan", "pass", "121218022", UserRoles.STUDENT, DateTime.Now - new TimeSpan(12, 10, 20), DateTime.MaxValue));
            _testUsers.Add(new User("Mitak", "pass2", "121218022", UserRoles.INSPECTOR, DateTime.Now - new TimeSpan(2, 10, 0), DateTime.MaxValue));
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            return (from user in TestUsers where user.Password.Equals(password) && user.Username.Equals(username) select user).FirstOrDefault();
        }

        public static void SetUserActiveTo(string username, DateTime newActiveTo)
        {
            foreach(var user in TestUsers)
            {
                if(user.Username.Equals(username))
                {
                    user.ActiveDue = newActiveTo;
                    Logger.LogActivity("Промяна на активност на " + username);
                    break;
                }
            }
        }

        public static void AssignUserRole(string username, UserRoles newRole)
        {
            foreach(var user in TestUsers)
            {
                if(user.Username.Equals(username))
                {
                    user.Role = newRole;
                    Logger.LogActivity("Промяна на роля на " + username);
                    break;
                }
            }
        }
    }
}
