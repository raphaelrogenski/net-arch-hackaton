﻿using NetArchHackaton.Shared.Application.Menu.Commands;
using NetArchHackaton.Shared.Application.Menu.Queries;
using NetArchHackaton.Shared.Contracts.Menu.Commands;
using NetArchHackaton.Shared.Contracts.Menu.Queries;

namespace NetArchHackaton.MenuAPI
{
    public partial class Startup
    {
        private void ConfigureApplication(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IGetMenuHandler, GetMenuHandler>();
            builder.Services.AddScoped<IGetMenuItemHandler, GetMenuItemHandler>();
            builder.Services.AddScoped<ICreateMenuItemHandler, CreateMenuItemHandler>();
            builder.Services.AddScoped<IUpdateMenuItemHandler, UpdateMenuItemHandler>();
            builder.Services.AddScoped<IDeleteMenuItemHandler, DeleteMenuItemHandler>();
        }
    }
}
