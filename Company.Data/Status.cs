using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data
{
    public class Status
    {
        public int Id { get; set; }
        public int StatusValue { get; set; }

        public Supplier Supplier { get; set; }
        public Admin Admin { get; set; }
    }
}
