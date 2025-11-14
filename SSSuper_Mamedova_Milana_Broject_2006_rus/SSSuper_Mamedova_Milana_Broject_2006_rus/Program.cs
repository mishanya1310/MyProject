using DataAccess.Wrapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.OpenApi.Models;

namespace SSSuper_Mamedova_Milana_Broject_2006_rus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<MilanaDbContext>(
                                options => options.UseSqlServer(
                                          "Server= DESKTOP-K6LFJKO ;Database= Milana_DB ;User Id= sa ;Password= 12345 ; TrustServerCertificate= True ;"));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IActiveService, ActiveService>();
            builder.Services.AddScoped<IPoolsService, PoolsService>();
            builder.Services.AddScoped<IPriceHistoryService, PriceHistoryService>();
            builder.Services.AddScoped<IPortfoliosService, PortfoliosService>();
            builder.Services.AddScoped<IProtocolsService, ProtocolsService>();
            builder.Services.AddScoped<IRiskProfileService, RiskProfileService>();
            builder.Services.AddScoped<IRecommendationsService, RecommendationsService>();
            builder.Services.AddScoped<ICompositionService, CompositionService>();
            builder.Services.AddScoped<ITypesService, TypesService>();
            builder.Services.AddScoped<ITransactionsService, TransactionsService>();



            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
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
