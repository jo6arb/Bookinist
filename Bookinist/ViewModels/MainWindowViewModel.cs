using Bookinist.DAL.Entity;
using Bookinist.Interfaces;
using Bookinist.Services.interfaces;
using MathCore.WPF.ViewModels;

namespace Bookinist.ViewModels;

class MainWindowViewModel : ViewModel
{
    private readonly IRepository<Book> _BooksRepository;
    private readonly IRepository<Deal> _DealRepository;
    private readonly IRepository<Seller> _Sellers;
    private readonly IRepository<Buyer> _Buyers;
    private readonly ISalesService _SalesService;

    #region Title : string - Заголовок окна

    /// <summary>Заголовок окна</summary>
    private string _Title = "Главное окно программы";

    /// <summary>Заголовок окна</summary>
    public string Title { get => _Title; set => Set(ref _Title, value); }

    #endregion

    public MainWindowViewModel(
        IRepository<Book> BooksRepository,
        IRepository<Deal> DealRepository,
        IRepository<Seller> Sellers,
        IRepository<Buyer> Buyers,
        ISalesService SalesService)
    {
        _BooksRepository = BooksRepository;
        _DealRepository = DealRepository;
        _Sellers = Sellers;
        _Buyers = Buyers;
        _SalesService = SalesService;

       
    }

    /*private async void Test()
    {
        var deal_count = _SalesService.Deals.Count();

        var book = await _BooksRepository.GetAsync(5);
        var buyer = await _Buyers.GetAsync(4);
        var seller = await _Sellers.GetAsync(6);

        var deal = _SalesService.MakeAdeal(book.Name, seller, buyer, 100m);

        var deal_count1 = _SalesService.Deals.Count();
    }*/
}