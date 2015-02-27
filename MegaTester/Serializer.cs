using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Exception;
using System.Runtime.Serialization.Formatters.Binary;

namespace MegaTester
{
    static class Serializer
    {
        public static void Serialize(List<User> userList)
        {
            if(userList != null)
            {
                using(FileStream fs = new FileStream("password.dat",FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter BF = new BinaryFormatter();
                    BF.Serialize(fs, userList);
                }  
                 MessageBox.Show("Ascess error, file with passwrods wasn't found. Application will be terminated", "ACSESS ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public static List<User> Deserialize()
        {
                try 
                { 
                    using (FileStream fs = new FileStream("password.dat", FileMode.Open, FileAccess.Read))
                    {
                        BinaryFormatter BF = new BinaryFormatter();
                        return (List<User>)BF.Deserialize(fs);
                    }
                }
                catch
                {
                    MessageBox.Show("Ascess error.\n Application will be terminated", "ACSESS ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            return null;
         }
            
        }

    }
}
