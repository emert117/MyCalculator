using MyCalculator.Business.Abstract;
using MyCalculator.Business.Concrete;

namespace MyCalculator.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IAdditionOperator, AdditionOperator>();
            builder.Services.AddScoped<IDivisionOperator, DivisionOperator>();
            builder.Services.AddScoped<IMultiplicationOperator, MultiplicationOperator>();
            builder.Services.AddScoped<ISubtractionOperator, SubtractionOperator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}