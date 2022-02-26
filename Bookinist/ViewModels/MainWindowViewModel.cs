using System.Linq;
using Bookinist.DAL.Entity;
using Bookinist.Interfaces;
using MathCore.WPF.ViewModels;

namespace Bookinist.ViewModels;

public class MainWindowViewModel : ViewModel
{
    private readonly IRepository<Book> _BooksRepository;

    #region Title : string - Заголовок окна

    /// <summary>Заголовок окна</summary>
    private string _Title = "Главное окно программы";

    /// <summary>Заголовок окна</summary>
    public string Title { get => _Title; set => Set(ref _Title, value); }

    #endregion

    public MainWindowViewModel(IRepository<Book> BooksRepository)
    {
        _BooksRepository = BooksRepository;
        
        var books = BooksRepository.Items.Take(10).ToArray();
    }
}