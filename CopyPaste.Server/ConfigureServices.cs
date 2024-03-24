using System.Reflection;

namespace CopyPaste.Server
{
    public static class ConfigureServices
    {
        public static void AddScopedDerivedClasses<TBaseType, TRegisterAs>(this IServiceCollection services, Assembly assembly)
        {
            var baseType = typeof(TBaseType);
            var registerAsType = typeof(TRegisterAs);

            var derivedTypes = assembly.GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract && baseType.IsAssignableFrom(x));

            foreach (var type in derivedTypes)
            {
                services.AddScoped(registerAsType, type);
            }
        }

        public static void AddAppSettings(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.Configure<DefaultSettings>(configurationManager.GetSection("DefaultSettings"));
            services.Configure<ConnectionStrings>(configurationManager.GetSection("ConnectionStrings"));
            services.Configure<CacheExpirySettings>(configurationManager.GetSection("CacheExpirySettings"));
        }
    }
}
