using AService.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AService.DAL
{
    public class UserDbContext : DbContext
    {
        public UserDbContext()
            : base("name=WcfContext")
        {           
        }

        public DbSet<User> Users { get; set; }
    }
}
