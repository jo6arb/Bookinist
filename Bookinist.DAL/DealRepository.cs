using Bookinist.DAL.Context;
using Bookinist.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Bookinist.DAL;

class DealRepository : DbRepository<Deal>
{
    public override IQueryable<Deal> Items => base.Items
       .Include(item => item.Book)
       .Include(item => item.Seller)
       .Include(item => item.Buyer);
    public DealRepository(BookinistDb db) : base(db) { }

}