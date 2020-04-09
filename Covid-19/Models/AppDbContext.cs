using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Covid_19.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        { 
        
        }
        public DbSet<ConfirmTable> ConfirmTable { get; set; }
        public DbSet<DeathTable> DeathTable { get; set; }
        public DbSet<RecoveredTable> RecoveredTable { get; set; }
        public DbSet<TweetDataTable> TweetDataTable { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfirmTable>().ToTable("ConfirmTable");
            modelBuilder.Entity<DeathTable>().ToTable("DeathTable");
            modelBuilder.Entity<RecoveredTable>().ToTable("RecoveredTable");
            modelBuilder.Entity<TweetDataTable>().ToTable("TweetDataTable");
        }
    }
}
