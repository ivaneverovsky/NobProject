using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data
{
    public class Orders
    {
        public int Id { get; set; }

        public Client Client { get; set; }
        public Admin Admin { get; set; }
        public Catalogue ItemName { get; set; }

        public int Cost { get; set; }
        public Status Status { get; set; }
    }
}
