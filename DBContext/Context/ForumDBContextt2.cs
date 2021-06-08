using ClassContext.Entities;
using DBContext.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassContextt2.Context
{
   public class ForumDBContextt2 : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet <Post> Posts { get; set; }

        public DbSet<Thread> Threads { get; set; }

    }
    
}
