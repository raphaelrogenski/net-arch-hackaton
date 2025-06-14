namespace NetArchHackaton.AuthAPI
{
    public partial class Startup
    {
        private void ConfigureSwagger(WebApplicationBuilder builder)
        {
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
		}

        private void UseSwagger(WebApplication app)
        {
			app.UseSwagger();
			app.UseSwaggerUI();
		}
    }
}
