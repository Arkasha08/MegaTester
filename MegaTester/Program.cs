using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaTester
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Admin x = new Admin("sd", "ds");
            x.AddUser(UserType.Moderator, "New", "New");

            x.DeleteUser("New");


            Application.Run(new Form1());
        }

        // Should not be public
        public static List<User> userList = new List<User>();
        private static List<object> testList = new List<object>();

        private static bool IsUserAvailable(String login)
        {
            if (userList != null)
            {
                foreach (var user in userList)
                {
                    if (user.Login == login)
                        return true;
                }
            }
            return false;
        }

        public enum UserType { Admin, Moderator, Student, Guest };
        
        public static void AddUser(User admin, String login, String password, UserType type)
        {
            if(admin.GetType() == typeof(MegaTester.Admin))
            {
                if(IsUserAvailable(login))
                {
                    MessageBox.Show("Warning", "Subject login is already available", MessageBoxButtons.OK);
                    return;
                } 
                switch(type)
                {
                    case UserType.Admin:
                        userList.Add(new Admin(login, password));
                        break;
                    case UserType.Moderator:
                        userList.Add(new Moderator(login, password));
                        break;
                    case UserType.Student:
                        userList.Add(new Student(login, password));
                        break;
                }
            }
        }
        
        public static void DeleteUser(User admin, String login)
        {
            if (admin.Login == login)
            {
                MessageBox.Show("Warning", "You cannot delete admin account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (admin.GetType() == typeof(MegaTester.Admin) && userList != null)
            {
                int index = 0;
                foreach(var user in userList)
                {
                    if (user.Login == login)
                        break;
                    index++;
                }
                userList.RemoveAt(index);
            }
        }
    }
}
