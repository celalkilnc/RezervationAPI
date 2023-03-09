using Microsoft.Extensions.Configuration;

namespace TVSC.Persistance
{
    public static class Configurations
    {
        public static string ConnectionString
        {
            get
            {
                return GetConnectionString("../../Presentation/TVSC.PresentationAPI.API",
                    "appsettings.json", "SqlServer");
            }
        }

        public static string ConnectionStringLog
        {
            get
            {
                return GetConnectionString("../../Presentation/TVSC.PresentationAPI.API",
                    "appsettings.json", "LogServer");
            }
        }
        
        public static string GetConnectionString(string folder, string file, string key)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), folder));
            configurationManager.AddJsonFile(file);

            return configurationManager.GetConnectionString(key);
        }
    }
}
