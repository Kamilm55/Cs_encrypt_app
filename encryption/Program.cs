using System.Text;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

class Program
{
    public static async Task Main()
    {
        string loc = @"C:\Users\User\OneDrive\Desktop\data.txt";
        string newLoc = @"C:\Users\User\OneDrive\Desktop\encData.txt";
        


        User user1 = new User("Abdullayev", "Anar", " a.anar@microsoft.com", " a.anar", "3545");
        User user2 = new User("Isayev", "Saleh", " i.saleh @facebook.com", " i.saleh", "9783");
        User user3 = new User("Kazimov", "Aykhan", "k.aykhan@yahoo.com", "  k.aykhan", "6878");
        User user4 = new User("Aliyeva", "Elvina", "a.elvina @amazon.com", "a.elvina", "2352");

        List<User> userList = new List<User>();
        userList.Add(user1);
        userList.Add(user2);
        userList.Add(user3);
        userList.Add(user4);

        string initialInform = "";

        foreach (User user in userList)
        {
            initialInform += user.ToString();
        }

        try
        {
            // Use await to wait for the asynchronous task to complete
             WriteFileAsync(loc, initialInform);

            string encStr = "";

            List<User> encryptedUserList = encrypt(userList);

            foreach (User user in encryptedUserList)
            {
                encStr += user.ToString();
            }

            // Use await to wait for the asynchronous task to complete
             WriteFileAsync(newLoc, encStr);

            Console.WriteLine("\nTask ended successfully!You can see result in files \n");

            Console.WriteLine("Old data file location: " + loc);
            Console.WriteLine("Encrypted data file location: " + newLoc);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    static  void WriteFileAsync(string loc, string inform)
    {
        try
        {
            File.WriteAllText(loc,inform);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error writing to file: " + ex.Message);
            throw; 
        }
    }


    static List<User> encrypt(List<User> userList)
    {
        foreach (User user in userList)
        {
            string n = user.Id;

            string newId = "";

            for (int i = 0; i < n.Length; i++)
            {
                char c = (char)n[i];

                // encrypt + 7
                c = (char)(c + 7);
                newId += c.ToString();
            }
            Console.WriteLine(newId);


            user.Id = newId;
        }

        return userList;
    }

    class User
    {
        private string lastName;
        private string firstName;
        private string email;
        private string shortName;
        private string id;

        public override string ToString()
        {
            return lastName + ", " + firstName + ", " + email + ", " + shortName + ", " + id + "\n";
        }

        public User(string lastName, string firstName, string email, string shortName, string id)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.email = email;
            this.shortName = shortName;
            this.id = id;
        }

        public string Id { get => id; set => id = value; }
        public string ShortName { get => shortName; set => shortName = value; }
        public string Email { get => email; set => email = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
    }
}
