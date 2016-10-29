using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using GoLocal.Models;

namespace GoLocal
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();


        }
    }
}
