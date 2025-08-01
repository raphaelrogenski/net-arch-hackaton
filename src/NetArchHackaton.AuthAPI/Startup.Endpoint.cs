﻿namespace NetArchHackaton.AuthAPI
{
    public partial class Startup
    {
        private void ConfigureEndpoint(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
        }

        private void UseEndpoint(WebApplication app)
        {
            app.UseHttpsRedirection();
            app.MapControllers();
        }
    }
}
