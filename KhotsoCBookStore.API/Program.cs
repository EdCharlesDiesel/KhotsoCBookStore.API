using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KhotsoCBookStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            // var services = new ServiceCollection()
            //                     .AddDataProtection()
            //                     .Services.BuildServiceProvider();
            // var protecterProvider = services.GetService<IDataProtectionProvider>();
            // var protector = protecterProvider.CreateProtector("AwesomePurpose");
            // while (true)
            // {
            //     Console.Write($"Type something sensitive: ");
            //     var input = Console.ReadLine();
            //     var protectedInput = protector.Protect(input);
            //     Console.WriteLine($"Protected: {protectedInput}");
            //     var unprotectedInput = protector.Unprotect(protectedInput);
            //     Console.WriteLine($"Unprotected: {unprotectedInput}");
            //     Console.WriteLine();
            // }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

}
