using ERPTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPTest.Context
{
    public class BuyerDbContext:DbContext
    {
        public BuyerDbContext(DbContextOptions<BuyerDbContext> options):base (options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<BuyerPersonalInfo> BuyerPersonalInfos { get; set; }
        public DbSet<BuyerContactInfo> BuyerContactInfos { get; set; }
    }
}
