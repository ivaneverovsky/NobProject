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

        //Каталог, который показываем клиенту, сделал сортировку по убыванию цены,
        //возможно надо указать входные параметры для листа, я узнаю позже подробнее
        public List<Catalogue> CompanyCatalogue()
        {
            using (Context c = new Context())
            {
                var a = from b in c.Catalogue
                        orderby b.Price descending
                        select b;
                return a.ToList();
            }
        }

        //Список клиентов, который показываем Админу, должен сортировать по фамилии, начиная с буквы А
        public List<Client> CompanyClients()
        {
            using (Context c = new Context())
            {
                var a = from b in c.Clients
                        orderby b.Surname['A'] descending
                        select b;
                return a.ToList();
            }
        }
    }
}
