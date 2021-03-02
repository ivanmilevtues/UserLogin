using System;

namespace UserLogin
{
    class User
    {
        public String Username { get { return _username; } set { _username = value; } }
        public String Password { get { return _password; } set { _password = value; } }
        public String FakNum { get { return _fakNum; } set { _fakNum = value; } }
        public UserRoles Role { get { return _role; } set { _role = value; } }

        private String _username;
        private String _password;
        private String _fakNum;
        private UserRoles _role;

        public User(String username, String password, String fakNum, UserRoles role)
        {
            Username = username;
            Password = password;
            FakNum = fakNum;
            Role = role;
        }
    }
}