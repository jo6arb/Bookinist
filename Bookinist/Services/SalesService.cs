using System.Collections.Generic; 
using System.Threading.Tasks;
using Bookinist.DAL.Entity;
using Bookinist.Interfaces;
using Bookinist.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookinist.Services;

class SalesService : ISalesService
{
    private readonly IRepository<Book> _Books;
    private readonly IRepository<Deal> _Deals;

    public IEnumerable<Deal> Deals => _Deals.Items;

    public SalesService(
        IRepository<Book> Books,
        IRepository<Deal> Deals)
    {
        _Books = Books;
        _Deals = Deals;
    }

    public async Task<Deal> MakeAdeal(string BookName, Seller Seller, Buyer Buyer, decimal Price)
    {
        var book = await _Books.Items.FirstOrDefaultAsync(b => b.Name == BookName).ConfigureAwait(false);
        if (book is null) return null;

        var deal = new Deal
        {
            Book = book,
            Seller = Seller,
            Buyer = Buyer,
            Price = Price
        };

        return await _Deals.AddAsync(deal);
    }
}