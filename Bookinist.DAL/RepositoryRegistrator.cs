using Bookinist.DAL.Entity;
using Bookinist.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Bookinist.DAL;

    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDb(this IServiceCollection services) => services
           .AddTransient<IRepository<Book>, BookRepository>()
           .AddTransient<IRepository<Category>, DbRepository<Category>>()
           .AddTransient<IRepository<Seller>, DbRepository<Seller>>()
           .AddTransient<IRepository<Buyer>, DbRepository<Buyer>>()
           .AddTransient<IRepository<Deal>, DealRepository>()
        ;
    }


