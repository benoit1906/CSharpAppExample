﻿// <copyright file="Startup.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Site
{
    using System.Text;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using Technocite.Irm.Weather.Business.Domains;
    using WeatherForecastApp.Business.Domains;
    using WeatherForecastApp.Business.Interfaces;
    using WeatherForecastApp.Data.Interfaces;
    using WeatherForecastApp.Data.Repositories;

    /// <summary>
    /// The startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configure services at startup.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http,
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = JwtBearerDefaults.AuthenticationScheme,
                                    Type = ReferenceType.SecurityScheme,
                                },
                            },
                            new List<string>()
                        },
                    });
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateActor = true,
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = this.Configuration["Jwt:Issuer"],
                            ValidAudience = this.Configuration["Jwt:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["Jwt:Key"])),
                            ClockSkew = TimeSpan.Zero,
                        };
                    });

            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<Core.Models.WeatherForecast, ViewModels.WeatherForecast>();
                cfg.CreateMap<ViewModels.WeatherForecastSearchParams, Core.Models.WeatherForecastSearchParams>();
                cfg.CreateMap<Core.Models.City, ViewModels.City>();
                cfg.CreateMap<ViewModels.Login, Core.Models.Login>();
            });

            // Domains
            services.AddScoped<IWeatherForecastDomain, WeatherForecastDomain>();
            services.AddScoped<ICityDomain, CityDomain>();
            services.AddTransient<IUserDomain, UserDomain>();

            // Repositories
            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        /// <summary>
        /// Configures the application and environment at startup.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
