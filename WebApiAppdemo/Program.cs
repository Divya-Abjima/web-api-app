using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebApiAppdemo.DBContexts;
using WebApiAppdemo.Services;

namespace WebApiAppdemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
               
                
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IMailService,LocalMailService>();
            builder.Services.AddSingleton<DinosaurRepository>();
            builder.Services.AddDbContext<DinosaurDetailContext>(dbContextOptions =>
            
                dbContextOptions.UseSqlServer(
                    builder.Configuration["ConnectionStrings:DinosaurDBConnectionString"]));

            builder.Services.AddScoped<IDinoaurDetailRepository, DinosaurDetailRepository>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true, 
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Authentication:Issuer"],
                        ValidAudience = builder.Configuration["Auhtentication:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
                    };
                });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("MustBeAdmin", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("admin", "true");
                });
            });
            builder.Services.AddSwaggerGen(setupAction =>
            {
                setupAction.AddSecurityDefinition("ApiBearerAuth", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    Description = "Enter a valid token for access"
                });
                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "ApiBearerAuth"
                            } }, new List<string>() 
                        }
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
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


            app.MapControllers();

            app.Run();
        }
    }
}