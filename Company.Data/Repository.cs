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

        //Список клиентов, который показываем Админу
        public List<Client> CompanyClients()
        {
            using (Context c = new Context())
            {
                var a = from b in c.Clients
                        where b.Surname[0] == 'A'  //eng -> A in sort
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
        public List<Client> ListOfClients()
        {
            using (Context c = new Context())
            {
                var a = from b in c.Clients
                       
                        select b;
                return a.ToList();
                
            }
        }
        public List<Admin> ListOfAdmins()
        {
            using (Context c = new Context())
            {
                var a = from b in c.Admins
                        select b;
                return a.ToList();
            }
        }





        //public  Authorization()  // хочу в этот метод потом засунуть логику реализации
        //{
        //    foreach (var item in AuthDic)
        //    {

        //    }
        //}

    }
}   
