using System;
using System.Collections; 

namespace MegaTester
{
    [Serializable]
    class Student:User
    {
        public Student(String login, String password):base(login,password)
        { 
        }
    }
}
