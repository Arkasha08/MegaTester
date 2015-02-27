using System;
using System.Collections; 

namespace MegaTester
{
    class Admin:User
    {
        public Admin(String login, String password):base(login,password)
        {
            marks = null;
        }

        public override void AddMark(object test, object mark)
        { 
        }

        public void AddUser(Program.UserType UserType, String login, String password)
        {
            Program.AddUser(this, login, password, UserType);
        }

        public void DeleteUser(String login)
        {
            Program.DeleteUser(this, login);
        }
          
    }
}
