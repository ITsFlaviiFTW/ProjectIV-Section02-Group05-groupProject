using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StormSocial_Server.Classes
{
    public class Profile
    {
        private string firstName;
        private string lastName;
        Login log_in;
        Contacts contacts;

         public Profile(string firstName, string lastName, Login log_in)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.log_in = log_in;
            this.setContacts();
        }
        public Profile()
        {
            this.log_in.setEmail(string.Empty);
            this.log_in.setPassword(string.Empty);
            this.firstName = string.Empty;
            this.lastName = string.Empty;
            this.setContacts();
        }


        /***********SETTERS AND GETTERS******************************************/
        public void setFirstName(string firstName) { this.firstName = firstName; }
        public void setLastName(string lastName) {  this.lastName = lastName; }
        public void setLogin(Login login) { this.log_in=login; }
        public string getFirstName() { return this.firstName;}
        public string getLastName() { return this.lastName;}
        public Login GetLogin() { return this.log_in;}
        /***********SETTERS AND GETTERS******************************************/



        public void saveProfileToFile()
        {
            string fileName = "profiles.txt";

            if(File.Exists(fileName))
            {
                using(StreamWriter fout = new StreamWriter(fileName, true)) //append to the file
                {
                    fout.WriteLine(this.GetLogin().getEmail() + ";" + this.GetLogin().getPassword() + ";" + this.getFirstName() + ";" + this.getLastName() + ";"); //wirte all the profiel info
                }
            }
            else
            {
                using (FileStream stream = File.Create(fileName)); //create new file if one does not exist
                saveProfileToFile(); // re-call the function to save the info
            }
        }
        private void setContacts()
        {
            this.contacts.populateContactsFromFile(this.GetLogin().getEmail());
        }
    }
}
