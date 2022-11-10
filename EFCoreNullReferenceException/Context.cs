using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreNullReferenceException
{
    internal class Context : DbContext
    {
        public DbSet<Call> Calls { get; set; }
        public DbSet<User> Users { get; set; }

        //public Context(DbContextOptions<Context> options) : base(options) { }
        public Context() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("inMemory");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Call>() //configure the many-to-many relationship with an explicitly defined join table. for more information, see: https://youtu.be/BIImyq8qaD4?list=PLdo4fOcmZ0oVWop1HEOml2OdqbDs6IlcI&t=673
                .HasMany(x => x.CCUsers)
                .WithMany(x => x.Calls)
                .UsingEntity<CCUserCallJoin>(
                j => j.HasOne(c => c.User).WithMany(c => c.CCUserCallJoins),
                j => j.HasOne(c => c.Call).WithMany(c => c.CCUserCallJoins));
            modelBuilder.Entity<Call>() //do the same for follow up users
                .HasMany(x => x.FollowUpUsers)
                .WithMany(x => x.Calls)
                .UsingEntity<FollowUpUserCallJoin>(
                j => j.HasOne(f => f.User).WithMany(f => f.FollowUpUserCallJoins),
                j => j.HasOne(f => f.Call).WithMany(f => f.FollowUpUserCallJoins));
            //modelBuilder.Entity<Call>() //do the same for follow up users
            //    .HasMany(x => x.FollowUpUsers)
            //    .WithMany(x => x.Calls)
            //    .UsingEntity<FollowUpUserCallJoin>();
        }
    }
}
