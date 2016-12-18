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
        public List<Orders> _SortedClients()
        {
            using (var c = new Context())
            {
                var a = from b in c.Orders
                        orderby b.Client
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
        public List<string> ListOfClients()
        {
            using (Context c = new Context())
            {
                var a = from b in c.Clients
                            //where b.Surname[0] == 'A'  //eng -> A in sort
                        select b.Name + " " + b.Surname + " (" + b.login + ")";
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


        ////список заказов
        //public List<Orders> ORDERS()
        //{
        //    using (Context c = new Context())
        //    {
        //        var a = from b in c.Orders
        //                select b;
        //        return a.ToList();
        //    }
        //}
        //список удаленных айтэмов из показа каталога
        public List<string> DeletedItems = new List<string>();

       

        public Dictionary<string, string> DictAuthClient()
        {
            Dictionary<string, string> dictAuthClient = new Dictionary<string, string>();
            using (var c = new Context())
                foreach (var login in c.Clients)
                    dictAuthClient.Add(login.login, login.password);

            Dictionary<string, string> dictAuthAdmin = new Dictionary<string, string>();
            using (var c = new Context())
                foreach (var login in c.Admins)
                    dictAuthAdmin.Add(login.login, login.password);

            Dictionary<string, string> dictAuthSupplier = new Dictionary<string, string>();
            using (var c = new Context())
                foreach (var login in c.Suppliers)
                    dictAuthSupplier.Add(login.login, login.password);
            return dictAuthClient;
        }

        public Dictionary<string, string> DictAuthAdmin()
        {
            Dictionary<string, string> dictAuthAdmin = new Dictionary<string, string>();
            using (var c = new Context())
                foreach (var login in c.Admins)
                    dictAuthAdmin.Add(login.login, login.password);
            return dictAuthAdmin;
        }

        public Dictionary<string, string> DictAuthSupplier()
        {
            Dictionary<string, string> dictAuthSupplier = new Dictionary<string, string>();
            using (var c = new Context())
                foreach (var login in c.Suppliers)
                    dictAuthSupplier.Add(login.login, login.password);
            return dictAuthSupplier;
        }

        public Dictionary<string, string> DictNameSupplier()
        {
            Dictionary<string, string> dictSuppliersName = new Dictionary<string, string>();
            using (var c = new Context())
                foreach (var field in c.Suppliers)
                    dictSuppliersName.Add(field.login, field.Name);
            return dictSuppliersName;
        }

        public Dictionary<string, string> DictSurnameSupplier()
        {
            Dictionary<string, string> dictSuppliersSurname = new Dictionary<string, string>();
            using (var c = new Context())
                foreach (var field in c.Suppliers)
                    dictSuppliersSurname.Add(field.login, field.Surname);
            return dictSuppliersSurname;
        }

        public Dictionary<string, string> DictNameClient()
        {
            Dictionary<string, string> dictClientsName = new Dictionary<string, string>();
            using (var c = new Context())
                foreach (var field in c.Clients)
                    dictClientsName.Add(field.login, field.Name);
            return dictClientsName;
        }

        public Dictionary<string, string> DictSurnameClient()
        {
            Dictionary<string, string> dictClientsSurname = new Dictionary<string, string>();
            using (var c = new Context())
                foreach (var field in c.Clients)
                    dictClientsSurname.Add(field.login, field.Surname);
            return dictClientsSurname;
        }

        public Dictionary<string, string> DictNameAdmin()
        {
            Dictionary<string, string> dictAdminsName = new Dictionary<string, string>();
            using (var c = new Context())
                foreach (var field in c.Admins)
                    dictAdminsName.Add(field.login, field.Name);
            return dictAdminsName;
        }

        public Dictionary<string, string> DictSurnameAdmin()
        {
            Dictionary<string, string> dictAdminsSurname = new Dictionary<string, string>();
            using (var c = new Context())
                foreach (var field in c.Admins)
                    dictAdminsSurname.Add(field.login, field.Surname);
            return dictAdminsSurname;
        }
    }
}




