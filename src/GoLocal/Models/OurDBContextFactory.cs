using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MySQL.Data.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoLocal.Models
{
    public class OurDBContextFactory 
    {
        public static OurDBContext Create ()
        {

            var optionsBuilder = new DbContextOptionsBuilder<OurDBContext>();
            optionsBuilder.UseMySQL("server=45.55.240.59;userid=go2016;pwd=fall2016;port=3306;database=golocalapp;sslmode=none;convert zero datetime=true;allow zero datetime=true");

            //Ensure database creation
            var context = new OurDBContext(optionsBuilder.Options);
            var ret = context.Database.EnsureCreated();

            return context;
        }
              
    }
}
