using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSC.Persistance
{
    static class Configurations
    {
        public static string ConnectionString
        {
            get
            {
               return GetConnectionString("../../Presentation/TVSC.PresentationAPI.API",
                   "appsettings.json", "SqlServer");
            }
        }

        public static string GetConnectionString(string folder,string file, string key)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), folder));
            configurationManager.AddJsonFile(file);

            return configurationManager.GetConnectionString(key);
        }
    }
}
