using Microsoft.Extensions.DependencyInjection;

namespace Bookinist.ViewModels;

public class ViewModelLocator
{
    public MainWindowViewModel MainWindowViewModel => App.Services.GetRequiredService<MainWindowViewModel>();
}