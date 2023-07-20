using Microsoft.EntityFrameworkCore;
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
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

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