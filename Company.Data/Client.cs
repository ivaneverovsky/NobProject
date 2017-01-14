using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public List<Orders> Orders { get; set; }

    }
}
