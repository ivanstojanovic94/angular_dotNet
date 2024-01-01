using System;
using System.Collections.Generic;
using System.Linq;
using angular_dotNet.Entities;
using Microsoft.EntityFrameworkCore;


namespace angular_dotNet.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
