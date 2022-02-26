using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bookinist.DAL.Context;
using Bookinist.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bookinist.Data;

class DbInitializer
{
    private readonly BookinistDb _db;
    private readonly ILogger<DbInitializer> _Logger;

    public DbInitializer( BookinistDb db, ILogger<DbInitializer> Logger)
    {
        _db = db;
        _Logger = Logger;
    }

    public async Task InitializeAsync()
    {
        var timer = Stopwatch.StartNew();
        _Logger.LogInformation("Инициализация БД....");

        _Logger.LogInformation("Удаление существующей БД....");
        await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);
        _Logger.LogInformation("Удаление существующей БД выполнено за {0} мс", timer.ElapsedMilliseconds);
        

        _Logger.LogInformation("Миграция БД....");
        await _db.Database.MigrateAsync();
        _Logger.LogInformation("Миграция БД выполнена за {0} мс", timer.ElapsedMilliseconds);

        if (await _db.Books.AnyAsync()) return;

        await InitializeCategoriesAsync();
        await InitializeBooksAsync();
        await InitializeSellersAsync();
        await InitializeBuyersAsync();
        await InitializeDealsAsync();

        _Logger.LogInformation("Инициализация БД выполнено за {0} мс", timer.Elapsed.TotalSeconds);
    }

    private const int __CategoriesCount = 10;
    private Category[] _Categories;

    private async Task InitializeCategoriesAsync()
    {
        var timer = Stopwatch.StartNew();
        _Logger.LogInformation("Инициализация категорий....");

        _Categories = new Category[__CategoriesCount];
        for (var i = 0; i < __CategoriesCount; i++)
            _Categories[i] = new Category { Name = $"Категория {i + 1}"};
        await _db.Categories.AddRangeAsync(_Categories);
        await _db.SaveChangesAsync();

        _Logger.LogInformation("Инициализация категорий выполнено за {0} мс", timer.Elapsed.TotalSeconds);

    }

    private Book[] _Books;
    private const int __BooksCount = 10;

    private async Task InitializeBooksAsync()
    {
        var timer = Stopwatch.StartNew();
        _Logger.LogInformation("Инициализация книг....");

        var rnd = new Random();
        _Books = Enumerable.Range(1, __BooksCount)
           .Select(i => new Book
            {
                Name = $"Книга {i} ",
                Category = rnd.NextItem(_Categories)
            })
           .ToArray();

        await _db.Books.AddRangeAsync(_Books);
        await _db.SaveChangesAsync();

        _Logger.LogInformation("Инициализация книг выполнено за {0} мс", timer.Elapsed.TotalSeconds);

    }

    private Buyer[] _Buyers;
    private const int _BuyersCount = 10;

    private async Task InitializeBuyersAsync()
    {
        var timer = Stopwatch.StartNew();
        _Logger.LogInformation("Инициализация покупателей....");

        var rnd = new Random();
        _Buyers = Enumerable.Range(1, _BuyersCount)
           .Select(i => new Buyer
            {
                Name = $"Покупатель - имя {i} ",
                Surname = $"Покупатель - Фамилия {i} ",
                Pathromyc = $"Покупатель - Отчество {i} "
            })
           .ToArray();

        await _db.Buyers.AddRangeAsync(_Buyers);
        await _db.SaveChangesAsync();

        _Logger.LogInformation("Инициализация покупателей выполнено за {0} мс", timer.Elapsed.TotalSeconds);

    }

    private Seller[] _Sellers;
    private const int _SellersCount = 10;

    private async Task InitializeSellersAsync()
    {
        var timer = Stopwatch.StartNew();
        _Logger.LogInformation("Инициализация продавцов....");

        var rnd = new Random();
        _Sellers = Enumerable.Range(1, _SellersCount)
           .Select(i => new Seller
            {
                Name = $"Продавец - имя {i} ",
                Surname = $"Продавец  - Фамилия {i} ",
                Pathromyc = $"Продаве - Отчество {i} "
            })
           .ToArray();

        await _db.Sellers.AddRangeAsync(_Sellers);
        await _db.SaveChangesAsync();

        _Logger.LogInformation("Инициализация продавцов выполнено за {0} мс", timer.Elapsed.TotalSeconds);

    }

    private const int __DealsCount = 1000;
    private async Task InitializeDealsAsync()
    {
        var timer = Stopwatch.StartNew();
        _Logger.LogInformation("Инициализация сделок....");

        var rnd = new Random();

        var deals = Enumerable.Range(1, __DealsCount)
           .Select(
                i => new Deal
                {
                    Book = rnd.NextItem(_Books),
                    Seller = rnd.NextItem(_Sellers),
                    Buyer = rnd.NextItem(_Buyers),
                    Price = (decimal)(rnd.NextDouble() * 4000 + 700)
                });

        await _db.Deals.AddRangeAsync(deals);
        await _db.SaveChangesAsync();

        _Logger.LogInformation("Инициализация сделок выполнено за {0} мс", timer.Elapsed.TotalSeconds);


    }
}