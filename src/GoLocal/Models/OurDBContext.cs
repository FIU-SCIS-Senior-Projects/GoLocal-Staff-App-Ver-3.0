using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GoLocal.Models
{
    public class OurDBContext: DbContext
    {
        public DbSet<registered_staff> registered_staff { get; set; }

        public OurDBContext(DbContextOptions<OurDBContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<registered_staff>().HasKey(m => m.StaffID);

            // shadow properties
            //builder.Entity<registered_staff>().Property<DateTime>("UpdatedTimestamp");

            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            updateUpdatedProperty<registered_staff>();

            return base.SaveChanges();

        }

        private void updateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo = ChangeTracker.Entries<T>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            //foreach (var entry in modifiedSourceInfo)
            //{
            //    entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
            //}
        }


        

    }
}
