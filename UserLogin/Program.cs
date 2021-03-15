using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
    class Program
    {

        static void printError(String msg)
        {
            Console.WriteLine("!!!!" + msg + "!!!!");
        }

        static void AdminMenu()
        {
            Console.WriteLine("Изберете опция:");
            Console.WriteLine("0: Изход");
            Console.WriteLine("1: Промяна на роля на потребител");
            Console.WriteLine("2: Промяна на активност на потребител");
            Console.WriteLine("3: Списък на потребителите");
            Console.WriteLine("4: Преглед на лог на активност");
            Console.WriteLine("5: Преглед на текуща активност");

            int option = Int32.Parse(Console.ReadLine());
            String username;
            switch(option)
            {
                case 0:
                    return;
                case 1:
                    Console.Write("Потребителско име:");
                    username = Console.ReadLine();
                    Console.Write(String.Format("Роля от: {0}[{1}], {2}[{3}], {4}[{5}], {6}[{7}], {8}[{9}]:", 
                        UserRoles.ADMIN, (int) UserRoles.ADMIN,
                        UserRoles.ANONYMOUS, (int) UserRoles.ANONYMOUS,
                        UserRoles.INSPECTOR, (int) UserRoles.INSPECTOR,
                        UserRoles.PROFESSOR, (int) UserRoles.PROFESSOR,
                        UserRoles.STUDENT, (int) UserRoles.STUDENT));

                    var role = (UserRoles)Int32.Parse(Console.ReadLine());
                    UserData.AssignUserRole(username, role);
                    break;
                case 2:
                    Console.Write("Потребителско име:");
                    username = Console.ReadLine();
                    Console.Write("Нова крайна дата:");
                    var date = DateTime.Parse(Console.ReadLine());
                    UserData.SetUserActiveTo(username, date);
                    break;
                case 3:
                    break;
                case 4:
                    printLines(Logger.GetLogs("admin"));
                    break;
                case 5:
                    printLines(Logger.GetCurrentSessionActivities());
                    break;
                default:
                    return;
            }
        }

        static private void printLines(IEnumerable<String> lines)
        {
            foreach(var line in lines)
            {
                Console.WriteLine(line);
            }
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
                Console.WriteLine(String.Format("Logged in user {0} ", user.Username));
                switch(user.Role)
                {
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("You are logged in as anonymous user");
                        break;
                    case UserRoles.ADMIN:
                        Console.WriteLine("You are logged in as administrator user");
                        AdminMenu();
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
