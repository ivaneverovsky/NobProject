using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data
{
    public class Repository
    {


        //здесь будут листы, которые мы будем показывать

        //Каталог, который показываем клиенту
        public List<Catalogue> CompanyCatalogue()
        {
            using (Context c = new Context())
            {
                var a = from b in c.Catalogue
                        orderby b.Price
                        select b;
                return a.ToList();
            }
        }

        //Список Заказов, показываем Админу и Поставщику
        public List<Orders> CompanyOrders()
        {
            using (Context c = new Context())
            {
                var a = from b in c.Orders
                        orderby b.ItemName descending
                        select b;
                return a.ToList();
            }
        }

        //Список клиентов
        public List<Client> ListOfClients()
        {
            using (Context c = new Context())
            {
                var a = from b in c.Clients
                        where b.Surname[0] == 'A'  //eng -> A in sort
                        select b;
                return a.ToList();
            }
        }

        //Cписок админов
        public List<Admin> ListOfAdmins()
        {
            using (Context c = new Context())
            {
                var a = from b in c.Admins
                        where b.Surname[0] == 'A'
                        select b;
                return a.ToList();
            }
        }

        //Cписок саплеров
        public List<Supplier> ListOfSuppliers()
        {
            using (Context c = new Context())
            {
                var a = from b in c.Suppliers
                        where b.Surname[0] == 'A'
                        select b;
                return a.ToList();
            }
        }

        //список удаленных айтэмов из показа каталога
        public List<string> DeletedItems = new List<string>();

        //public void  AuthorizationClient()   //хочу в этот метод потом засунуть логику реализации
        //{
        //    Dictionary<string, string> dictAuthClients = new Dictionary<string, string>();
        //    using (var c = new Context())
        //    {
        //        foreach (var login in c.Clients)
        //        {
        //            dictAuthClients.Add(login.login, login.password);
        //        }
        //    }
        //}
        //public void AuthorizationAdmin()   //хочу в этот метод потом засунуть логику реализации
        //{
        //    Dictionary<string, string> dictAuthAdmins = new Dictionary<string, string>();
        //    using (var c = new Context())
        //    {
        //        foreach (var login in c.Admins)
        //        {
        //            dictAuthAdmins.Add(login.login, login.password);
        //        }
        //    }
        //}
        //public void AuthorizationSupplier()
        //{
        //    Dictionary<string, string> dictAuthSupplier = new Dictionary<string, string>();
        //    using (var c = new Context())
        //    {
        //        foreach (var login in c.Suppliers)
        //        {
        //            dictAuthSupplier.Add(login.login, login.password);
        //        }
        //    }
        //}

    }
}
