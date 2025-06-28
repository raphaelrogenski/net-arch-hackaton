namespace NetArchHackaton.MenuAPI
{
    public partial class Startup
    {
        private void ConfigureSettings(WebApplicationBuilder builder)
        {
            builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            builder.Configuration.AddEnvironmentVariables();
        }
    }
}
