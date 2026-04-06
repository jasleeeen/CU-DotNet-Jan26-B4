using Microsoft.EntityFrameworkCore;
using Serilog;
using DBFirstSerilog.Data;

namespace DBFirstSerilog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("DBContext");
            builder.Services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(connectionString));

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.WithMachineName()    
                .Enrich.WithThreadId()       
                .WriteTo.Console()
                .WriteTo.File("logs/library-log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            builder.Host.UseSerilog();

            var app = builder.Build();

            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Unhandled exception occurred");
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("Internal Server Error");
                }
            });

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSerilogRequestLogging();

            app.MapControllers();

            app.Run();
        }
    }
}