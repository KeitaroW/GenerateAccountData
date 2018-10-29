using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bogus.DataSets.Name;

namespace Uebung03_GenerateAccountData
{

    class User
    {
        int userId;

        Gender gender;

        string firstName;

        string lastName;

        string loginname;

        string password;

        public User(int userId)
        {
            this.UserId = userId;
        }

        public Gender Gender { get => gender; set => gender = value; }
        public int UserId { get => userId; set => userId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Loginname { get => loginname; set => loginname = value; }
        public string Password { get => password; set => password = value; }

        public override string ToString()
        {
            return UserId + ", " + Gender + ", " + FirstName + ", " + LastName + ", " + Loginname + ", " + Password;
        }
    }

    class RegistrationDay
    {
        int rows;
        int index;
        DateTime registrationDate;
        string path;

        public RegistrationDay(int rows, int index, DateTime registrationDate)
        {
            this.rows = rows;
            this.index = index;
            this.registrationDate = registrationDate;
        }

        public RegistrationDay(int rows, int index, DateTime registrationDate, string path)
        {
            this.rows = rows;
            this.index = index;
            this.registrationDate = registrationDate;
            this.path = path;
        }

        public void GenerateAccountData()
        {
            List<Account> accounts = new List<Account>();
            Account temp;
            registrationDate = new DateTime(registrationDate.Year, registrationDate.Month, registrationDate.Day, 0, 0, 0);
            for (int i = index * rows; i < (index+1) * rows; i++)
            {
                temp = new Account(registrationDate);
                var testUsers = new Faker<User>()
                    //Optional: Call for objects that have complex initialization
                    .CustomInstantiator(f => new User(i))
                    //Use an enum outside scope.
                    .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
                    //Basic rules using built-in generators
                    .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName(u.Gender))
                    .RuleFor(u => u.LastName, (f, u) => f.Name.LastName(u.Gender))
                    .RuleFor(u => u.Loginname, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
                    .RuleFor(u => u.Password, (f, u) => f.Internet.Password())
                    //Optional: After all rules are applied finish with the following action
                    .FinishWith((f, u) =>
                    {
                        Console.WriteLine("User Created! Id={0}", u.UserId);
                    });

                var user = testUsers.Generate();
                Console.WriteLine(user);
                
            }
        }
    }
}
