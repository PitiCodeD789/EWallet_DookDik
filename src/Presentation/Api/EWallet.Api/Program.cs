﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace EWallet.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseUrls("http://*:30000")
                .UseStartup<Startup>();
    }
}