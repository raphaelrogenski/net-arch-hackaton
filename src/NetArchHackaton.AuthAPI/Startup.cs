namespace NetArchHackaton.AuthAPI
{
    public partial class Startup
    {
        // S3nhaF0rte!
        public void Run(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureSettings(builder);

            ConfigureInfrastructure(builder);
            ConfigureApplication(builder);

            ConfigureAuth(builder);
            ConfigureEndpoint(builder);
            ConfigureSwagger(builder);

            var app = builder.Build();

            UseMigrations(app);
            UseSwagger(app);
            UseAuth(app);
            UseEndpoint(app);
            UsePrometheus(app);

            app.Run();
        }
    }
}
