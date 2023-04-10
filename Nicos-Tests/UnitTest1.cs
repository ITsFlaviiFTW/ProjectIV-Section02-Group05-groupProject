namespace StormSocial_Server
{
    [TestClass]
    public class UnitTest1
    {
        private string email = "unitTest@email.com";
        private string password = "password";
        private string fName = "fName";
        private string lName = "lName";

        [TestMethod]
        public void ParameteizedProfileConstructorTest()
        {
            var login = new Login();
            login.setEmail(email);
            login.setPassword(password);

            var profile = new Profile(fName, lName, login);

            Assert.AreEqual(fName, profile.getFirstName());
            Assert.AreEqual(lName, profile.getLastName());
            Assert.AreEqual(login, profile.GetLogin());
        }

        [TestMethod]
        public void saveProfileToFileTest()
        {
            var login = new Login();
            login.setEmail(email);
            login.setPassword(password);
            var profile = new Profile(fName, lName, login);

            profile.saveProfileToFile();

            var expectedProfileData = $"{email};{password};{fName};{lName};";
            var actualProfileData = File.ReadAllLines("profiles.txt").Last();
            Assert.AreEqual(expectedProfileData, actualProfileData);

            // Cleanup
            //File.Delete("profiles.txt");
        }
        [TestMethod]
        public void DefaultContactConstructor()
        {
            string email = "test@test.com";
            List<string> expectedContacts = new List<string>() { "contact1@test.com", "contact2@test.com" };

            Contacts contacts = new Contacts(email);

            CollectionAssert.AreEqual(expectedContacts, contacts.getContacts());
        }
        [TestMethod]
        public void addNewContactTest()
        {
            string email = "test@test.com";
            string newContact = "newcontact@test.com";
            List<string> expectedContacts = new List<string>() { "contact1@test.com", "contact2@test.com", newContact };
            Contacts contacts = new Contacts(email);

            contacts.addNewContact(newContact);

            CollectionAssert.AreEqual(expectedContacts, contacts.getContacts());
        }
        [TestMethod]
        public void loadingContactsFromFile()
        {
            string email = "test@test.com";
            List<string> expectedContacts = new List<string>() { "contact1@test.com", "contact2@test.com" };
            Contacts contacts = new Contacts(email);

            List<string> actualContacts = contacts.populateContactsFromFile(email);

            CollectionAssert.AreEqual(expectedContacts, actualContacts);
        }
        [TestMethod]
        public void randomCodeReturn6digitsTest()
        {
            var login = new Login();

            var result = login.randomCode();

            Assert.IsTrue(result >= 100000 && result <= 999999);    //unitTest@email.com
        }
        [TestMethod]
        public void CheckForExistingEmailReturningTrueWhenEmailExists()
        {
            // Arrange
            var login = new Login();
            var existingEmail = "unitTest@email.com";

            // Act
            var result = login.checkForExistingEmailInFile(existingEmail);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CheckForExistingEmailReturningFalseWhenEmailDoesNotExists()
        {
            // Arrange
            var login = new Login();
            var existingEmail = "nonexistant@email.com";

            // Act
            var result = login.checkForExistingEmailInFile(existingEmail);

            // Assert
            Assert.IsFalse(result);
        }

    }
}