using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Datas.Enums;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Context
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            User user1 = new User {
                Id = Guid.NewGuid(),
                UserName = "hegzi",
                UserPassword = "securePassword123",
                FirstName = "Hegyi",
                LastName = "Herka",
                Email = "hegzi@example.com",
                Company = "Example Corp",
                Admin = false
            };

            User user2 = new User
            {
                Id = Guid.NewGuid(),
                UserName = "szabi",
                UserPassword = "anotherSecurePassword",
                FirstName = "Szabó",
                LastName = "Miklós",
                Email = "szabo@example.com",
                Company = "Another Corp",
                Admin = true
            };

            Item item1 = new Item
            {
                Id = Guid.NewGuid(),
                Name = "tej"
            };

            Item item2 = new Item
            {
                Id = Guid.NewGuid(),
                Name = "wc papir"
            };

            Order order1 = new Order
            {
                OrderId = Guid.NewGuid(),
                BuyerName = user1.FirstName + user1.LastName,
                CreatedAt = DateTime.Now,
                DeliverTo = "6750 Szeged Zágráb utca 54/2",
                Products = item1.Name
            };

            Order order2 = new Order
            {
                OrderId = Guid.NewGuid(),
                BuyerName = user2.FirstName + user2.LastName,
                CreatedAt = DateTime.Now,
                DeliverTo = "6720 Szeged Eszterga utca 56",
                Products = item1.Name+","+item2.Name 
            };

            List<Student> students = new List<Student>
            {
                new Student
                {
                    Id=Guid.NewGuid(),
                    FirstName="János",
                    LastName="Jegy",
                    BirthsDay=new DateTime(2022,10,10),
                    SchoolYear=9,
                    SchoolClass = SchoolClassType.ClassA,
                    EducationLevel="érettségi"
                },
                new Student
                {
                    Id=Guid.NewGuid(),
                    FirstName="Szonja",
                    LastName="Stréber",
                    BirthsDay=new DateTime(2021,4,4),
                    SchoolYear=10,
                    SchoolClass = SchoolClassType.ClassB,
                    EducationLevel="érettségi"
                }
            };

            List<Parent> parents = new List<Parent>
            {
                new Parent
                {
                    Id=Guid.NewGuid(),
                    FirstName="Hegyi",
                    LastName="Herka",
                    Address="6750 Szeged Zágráb utca 54/2",
                    IsWoomen = false,
                },
                new Parent
                {
                    Id=Guid.NewGuid(),
                    FirstName="Illés",
                    LastName="Ákos",
                    Address="6850 Algyő Bartók Béla utca 59",
                    IsWoomen = true,
                }
            };

            List<Order> orders = new List<Order>
            {
                order1, order2
            };

            List<User> users = new List<User>
            {
                user1,user2
            };

            List<Item> items = new List<Item>
            {
                item1,item2
            };

            // Students
            modelBuilder.Entity<Student>().HasData(students);
            modelBuilder.Entity<Parent>().HasData(parents);
            modelBuilder.Entity<Order>().HasData(orders);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Item>().HasData(items);
        }
    }
}
