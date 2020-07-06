using ForumMessenger.Models;
using System.Data.Entity;

namespace ForumMessenger.DAL
{
    public class DbInitializer : DropCreateDatabaseAlways<MessageExchangeContext>
    {        
        protected override void Seed(MessageExchangeContext db)
        {
            db.Users.Add(new User { Name = "Александр", Surname = "Шишкин", Login = "Alex", Password = "12345", Email = "alex@mail.ru", Role = "admin" });
            db.Users.Add(new User { Name = "Татьяна", Surname = "Петрова", Login = "Tanya", Password = "12345", Email = "petrova@gmail.com", Role = "user" });
            db.Users.Add(new User { Name = "Перт", Surname = "Сидоров", Login = "Petr", Password = "12345", Email = "petr@yandex.ru", Role = "user" });
            db.Users.Add(new User { Name = "Марина", Surname = "Ковалева", Login = "Marina", Password = "12345", Email = "kovaleva@yahoo.com", Role = "user" });           

            base.Seed(db);
        }
    }
}