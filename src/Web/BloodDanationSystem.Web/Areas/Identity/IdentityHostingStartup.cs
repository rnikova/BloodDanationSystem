﻿using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(BloodDanationSystem.Web.Areas.Identity.IdentityHostingStartup))]

namespace BloodDanationSystem.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
