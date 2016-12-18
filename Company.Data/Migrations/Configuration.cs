namespace Company.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Company.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
            //данные, которые всегда будут в базе, хочу добавить возможность регистрации нового человека,
            //в качестве любого из пользователей и регистрации/удаления нового продукта (возможно потребуется переписка
            //кода для Каталога).
            context.Clients.AddOrUpdate(a => a.Name, new Client
            {
                Name = "Ivan",
                Surname = "Kiselev",
                login = "kisel",
                password = "qwerty"
            });
            context.Admins.AddOrUpdate(a => a.Name, new Admin
            {
                Name = "Ivan",
                Surname = "Sereda",
                login = "Ivsereda97",
                password = "1488"
            });
            context.Suppliers.AddOrUpdate(a => a.Name, new Supplier
            {
                Name = "Andrew",
                Surname = "Koreshev",
                login = "koresh",
                password = "vip2016"
            });
            context.Catalogue.AddOrUpdate(a => a.ItemName, new Catalogue
            {
                ItemName = "ThankYou",
                Price = 100
            });
            context.Catalogue.AddOrUpdate(a => a.ItemName, new Catalogue
            {
                ItemName = "Silver",
                Price = 1000
            });
            context.Catalogue.AddOrUpdate(a => a.ItemName, new Catalogue
            {
                ItemName = "Gold",
                Price = 100500
            });
            context.SaveChanges();
        }
    }
}
