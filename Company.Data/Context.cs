using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data
{
    public class Context : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Catalogue> Catalogue { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Status> Status { get; set; }

        public Context() : base("localsql")
        {

        }
    }
}
