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
                Name = "Sergey",
                Surname = "Mosyakov",
                login = "SerMos",
                password = "hse2016"
            });
            context.Catalogue.AddOrUpdate(a => a.ItemName, new Catalogue
            {
                ItemName = "Brick",
                Price = 100
            });
            context.Catalogue.AddOrUpdate(a => a.ItemName, new Catalogue
            {
                ItemName = "Tor",
                Price = 1000
            });
            context.Catalogue.AddOrUpdate(a => a.ItemName, new Catalogue
            {
                ItemName = "Green Shit",
                Price = 100500
            });
        }
    }
}
