using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;

namespace customerAPI
{
    /// <summary>
    /// Main Entry
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="args">(sic)</param>
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// Build Web Host
        /// </summary>
        /// <param name="args">(sic)</param>
        /// <returns>IWebHost</returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.UseKestrel(options => options.Listen(IPAddress.Parse("0.0.0.0"), 5000))
                //.UseKestrel(options => options.Listen(IPAddress.Loopback, 5000))
                .UseKestrel(options => options.Listen(new IPEndPoint(IPAddress.Parse("0.0.0.0"), 5000)))
                .UseStartup<Startup>()
                .Build();
    }
}
