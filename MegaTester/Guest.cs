using System; 

namespace MegaTester
{
    [Serializable]
    class Guest:User
    {
        public Guest(String login, String password):base(login,password)
        {
            marks = null;
        }

        public override void AddMark(object test, object mark)
        { 
        }
          
    }
}
