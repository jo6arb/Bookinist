using Bookinist.DAL.Context;
using Bookinist.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Bookinist.DAL;

class BookRepository : DbRepository<Book>
{
    public override IQueryable<Book> Items => base.Items.Include(item => item.Category);
    public BookRepository(BookinistDb db) : base(db) {}
    
}