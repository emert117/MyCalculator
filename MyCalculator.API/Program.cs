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

            builder.Services.AddScoped<IOperator<double>, AdditionOperator>();
            builder.Services.AddScoped<IOperator<double>, DivisionOperator>();
            builder.Services.AddScoped<IOperator<double>, MultiplicationOperator>();
            builder.Services.AddScoped<IOperator<double>, SubtractionOperator>();

            builder.Services.AddScoped<IDictionary<string, IOperator<double>>>(provider =>
                provider.GetServices<IOperator<double>>().ToDictionary(k => k.OperatorSymbol));


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

            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.Run();
        }
    }
}