using System;
using System.Collections; 

namespace MegaTester
{
    class Moderator:User
    {
        public Moderator(String login, String password):base(login,password)
        {
            marks = null;
        }

        public override void AddMark(object test, object mark)
        { 
        }
          
    }
}
