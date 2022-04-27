using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(StarPeaceAdminHub.Areas.Identity.IdentityHostingStartup))]
namespace StarPeaceAdminHub.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}