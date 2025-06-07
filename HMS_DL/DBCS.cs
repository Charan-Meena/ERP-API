using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HMS_DL
{
    public class DBCS
    {
        public static string GetConnectionString()
        {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json"), optional: false)
           .Build();

            var str = configuration.GetSection("ConnectionString:DBCS").Value;
            return str;
        }
        public static string GetBaseURL()
        {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json"), optional: false)
           .Build();

            var str = configuration.GetSection("AppSettings:baseUrl").Value;
            return str;
        }

    }
}
