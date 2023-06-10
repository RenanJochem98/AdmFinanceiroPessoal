namespace backend.Svc
{
    public class SvcAppSettings
    {
        private static IConfiguration configuration;

        static SvcAppSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
        }

        //TODO: Usar cache para salvar a string sem precisar ler o arquivo sempre
        public static string GetConnectionString()
        {
            return configuration.GetSection("ConnectionStrings").GetSection("postgres").Value!;
        }
        public static string GetJwtTokenKey()
        {
            return "1234456678891234567778";
            //return configuration.GetSection("JwtTokenKey").Value!;
        }
    }
}
