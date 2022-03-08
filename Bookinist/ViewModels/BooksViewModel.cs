using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Bookinist.DAL.Entity;
using Bookinist.Infrastructure.DebugServices;
using Bookinist.Interfaces;
using MathCore.WPF.ViewModels;

namespace Bookinist.ViewModels;

class BooksViewModel : ViewModel
{
    private readonly IRepository<Book> _BooksRepository;

    #region BookFilter : string - Искомое слово

    /// <summary>Искомое слово</summary>
    private string _BookFilter;

    /// <summary>Искомое слово</summary>
    public string BookFilter
    {
        get => _BookFilter;
        set
        {
            if(Set(ref _BookFilter, value))
                _BooksViewSource.View.Refresh();
        }
    }

    #endregion

    private readonly CollectionViewSource _BooksViewSource;
    public ICollectionView BooksView => _BooksViewSource.View;

    public IEnumerable<Book> Books => _BooksRepository.Items;
    public BooksViewModel()
    :this(new DebugBooksRepository())
    {
        if (!App.IsDesignTime)
            throw new InvalidOperationException("Данный конструктор не предназначен для использования вне дизайнера!");
        
    }

    public BooksViewModel(IRepository<Book> BooksRepository)
    {
        _BooksRepository = BooksRepository;

        _BooksViewSource = new CollectionViewSource
        {
            Source = _BooksRepository.Items.ToArray(),
            SortDescriptions =
            {
                new SortDescription(nameof(Book.Name), ListSortDirection.Ascending)
            }
        };

        _BooksViewSource.Filter += OnBooksFilter;


    }

    private void OnBooksFilter(object Sender, FilterEventArgs E)
    {
        if(!(E.Item is Book book) || string.IsNullOrEmpty(BookFilter)) return;

        if (!book.Name.Contains(BookFilter))
            E.Accepted = false;
    }
}