using BeginnerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeginnerApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        //type ctor and press tab twice
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Trophy> Trophies { get; set; }

        public DbSet<Auction> Auctions { get; set; }

        public DbSet<Player> Players { get; set; }
    }
}
