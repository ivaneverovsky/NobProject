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

        public string Client { get; set; }
        public string Admin { get; set; }
        public string ItemName { get; set; }

        public int Cost { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }

    }
}
