using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoLocal.Models
{
    public class OurDBContext: DbContext
    {
        public DbSet<registered_staff> registered_staff { get; set; }
        public DbSet<staff_type> staff_type { get; set; }

        public OurDBContext(DbContextOptions<OurDBContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<registered_staff>().HasKey(m => m.StaffID);
            builder.Entity<staff_type>().HasKey(m => m.StaffID);


            // shadow properties
            builder.Entity<registered_staff>().Property<DateTime>("UpdatedTimestamp");
            builder.Entity<staff_type>().Property<DateTime>("UpdatedTimestamp");

            base.OnModelCreating(builder);
        }
        public Task<int> SaveChanges<T>() where T : class
        {
            ChangeTracker.DetectChanges();

            updateUpdatedProperty<T>();
     
            return base.SaveChangesAsync(); ;

        }



        public void updateUpdatedProperty<T>() where T : class
        {
            ChangeTracker.DetectChanges();

            var modifiedSourceInfo = ChangeTracker.Entries<T>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
            }
        }        

    }
}
