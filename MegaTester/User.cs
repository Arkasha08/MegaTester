using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaTester
{
    abstract class User
    {
        protected String login;
        protected String password;
        protected readonly DateTime creationDate;
        protected Hashtable marks;
        
        public String Login { get {return login;} }
        public String Passord { get { return password; } }
        
        public User(String login, String password)
        {
            this.login = login;
            this.password = password;
            creationDate = DateTime.Now;
            marks = new Hashtable();
        }

        public virtual void AddMark(object test, object mark)
        {
            if (marks != null)
                marks.Add(test, mark);
        }
        
        // Checking if Test is available in list of marks
        public bool IsTestPassed(object test)
        {
            if (marks != null)
                if (marks.Contains(test))
                    return true; 
            return false;
        }

        public String GetMarks()
        {
            StringBuilder result = new StringBuilder();
            if (marks != null)
                foreach (var x in marks.Keys)
                {
                    result.AppendFormat("Test: {0} Grade: {1}\n", x.ToString(), marks[x].ToString());
                }
            return result.ToString();
        }

        public String GetMarks(object test)
        { 
            if (marks != null)
                return String.Format("Test: {0} Grade: {1}\n", test.ToString(), marks[test].ToString());
            return "";
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Name: {0}\nDate of Creation: {1}\nType: {2}\n************\n\n", this.login.ToString(),this.creationDate.ToShortDateString(),this.GetType().Name.ToString()); 
            if (marks != null)
                foreach (var x in marks.Keys)
                {
                    result.AppendFormat("Test: {0} Grade: {1}\n", x.ToString(), marks[x].ToString());
                }
            return result.ToString();
        } 

    }
}
