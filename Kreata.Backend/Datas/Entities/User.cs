using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Kreata.Backend.Datas.Entities
{
    public class User
    {
        public User(Guid id,
            string userName,
            string userPassword,
            string firstName,
            string lastName,
            string email,
            string company,
            Boolean admin
            )
        {
            Id = id;
            UserName = userName;
            UserPassword = userPassword;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Company = company;
            Admin = admin;
        }

        public User()
        {
            Id = Guid.Empty;
            UserName = string.Empty;
            UserPassword = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Company = string.Empty;
            Admin = false;
        }

        public Guid Id { set; get; }
        public string UserName { set; get; }
        public string UserPassword { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string Company { set; get; }
        public Boolean Admin { set; get; }

        public override string ToString()
        {
            string admin = Admin ? "igen" : "nem";
            return $"Id: ${Id}, Felhasznalonev: {UserName}, Nev: {FirstName} {LastName}, Email: {Email}, Cég: {Company}, Admin: {admin}";
        }
    }
}
