using System;

namespace UserLogin
{
    class Program
    {

        static void printError(String msg)
        {
            Console.WriteLine("!!!!" + msg + "!!!!");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter username:");
            var username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            var password = Console.ReadLine();

            var validation = new LoginValidation(username, password, printError);
            User user = null;
            if(validation.ValidateUserInput(ref user))
            {
                Console.WriteLine(String.Format("Logged in user {0} with password {1} and role {2} ", user.Username, user.Password, user.Role));
                switch(user.Role)
                {
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("You are logged in as anonymous user");
                        break;
                    case UserRoles.ADMIN:
                        Console.WriteLine("You are logged in as administrator user");
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("You are logged in as inspector user");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("You are logged in as student user");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("You are logged in as professor user");
                        break;
                }
            }
        }
    }
}
