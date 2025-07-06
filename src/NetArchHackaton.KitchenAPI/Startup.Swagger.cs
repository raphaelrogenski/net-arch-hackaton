using Microsoft.OpenApi.Models;

namespace NetArchHackaton.KitchenAPI
{
    public partial class Startup
    {
        private void ConfigureSwagger(WebApplicationBuilder builder)
        {
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Type 'Bearer' followed by your JWT token, like: 'Bearer abc123xyz'"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
		}

        private void UseSwagger(WebApplication app)
        {
			app.UseSwagger();
			app.UseSwaggerUI();
		}
    }
}
