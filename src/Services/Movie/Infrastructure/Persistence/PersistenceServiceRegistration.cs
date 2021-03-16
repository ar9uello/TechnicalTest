using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechnicalTest.Movie.Application.Contracts.Persistence;
using TechnicalTest.Movie.Application.Contracts.Persistence.Base;
using TechnicalTest.Movie.Persistence.Repositories;
using TechnicalTest.Movie.Persistence.Repositories.Base;

namespace TechnicalTest.Movie.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TechnicalTestDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TechnicalTestConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IMovieBuyRepository, MovieBuyRepository>();
            services.AddScoped<IMovieInventoryRepository, MovieInventoryRepository>();
            services.AddScoped<IMovieLikeRepository, MovieLikeRepository>();
            services.AddScoped<IMovieRentalRepository, MovieRentalRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
