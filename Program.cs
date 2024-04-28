
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
using AppRestSeam.Models;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Windows.Forms;

/// "Диференційна діагностика стану нездужання людини-SEAM" 
/// Розробник Стариченко Олександр Павлович тел.+380674012840, mail staric377@gmail.com

namespace AppRestSeam
{
    public class Program
    {
        public static string UnloadString, connection,Upload;

        public static void Main(string[] args)
        {

            bool isNew;
            var mutex = new Mutex(true, "AppRestSeam", out isNew);
            if (!isNew)
            { 
                mutex.Dispose();
                Environment.Exit(0);
            }
               
 
            // получаем строку подключения

            // надо проверить

            //var optionsBuilder = new DbContextOptionsBuilder<DbContextSeam>();
            //var options = optionsBuilder.UseSqlServer(connectionString).Options;

            Upload = "false";
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true)
            .Build();

            UnloadString = Directory.GetCurrentDirectory()+@"\"+ config.GetSection("ConnectionStrings:UnloadString").Value + @"\";
            connection = config.GetSection("ConnectionStrings:DefaultConnection").Value;
            Upload = config.GetSection("ConnectionStrings:UploadBd").Value;
            var host = new WebHostBuilder()
                .UseKestrel(options => options.AddServerHeader = false)
                .UseConfiguration(config)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
 

            //CreateHostBuilder(args).Build().Run();
        }

        //public static IConfiguration config = new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile("appsettings.json", true)
        //    .Build();

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
            
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseKestrel(options => options.AddServerHeader = false);
        //            webBuilder.UseConfiguration(config);
        //            webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
        //            webBuilder.UseIISIntegration();
        //            webBuilder.UseStartup<Startup>();
        //        });
        
    }
}
