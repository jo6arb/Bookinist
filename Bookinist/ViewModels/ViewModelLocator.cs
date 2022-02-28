using Microsoft.Extensions.DependencyInjection;

namespace Bookinist.ViewModels;

class ViewModelLocator
{
    public MainWindowViewModel MainWindowViewModel => App.Services.GetRequiredService<MainWindowViewModel>();
}