using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class DnDManagerDBContext : DbContext
    {
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
