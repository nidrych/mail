using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedMail.EntityFramework
{
    public class FeedMailContext : DbContext
    {
        public DbSet<FeedReceiver> FeedReceivers { get; set; }

        public FeedMailContext(DbContextOptions<FeedMailContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}