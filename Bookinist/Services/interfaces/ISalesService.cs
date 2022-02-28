using System.Collections.Generic;
using System.Threading.Tasks;
using Bookinist.DAL.Entity;

namespace Bookinist.Services.interfaces;

interface ISalesService
{
    IEnumerable<Deal> Deals { get; }
    Task<Deal> MakeAdeal(string BookName, Seller Seller, Buyer Buyer, decimal Price);
}