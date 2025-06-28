namespace NetArchHackaton.MenuAPI
{
    public partial class Startup
    {
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

            UseSwagger(app);
            UseAuth(app);
            UseEndpoint(app);
            UsePrometheus(app);

            app.Run();
        }
    }
}
