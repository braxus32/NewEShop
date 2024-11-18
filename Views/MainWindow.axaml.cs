using System.Threading.Tasks;
using Avalonia.ReactiveUI;
using ReactiveUI;
using NewEShop.ViewModels;

namespace NewEShop.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
     public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(action =>
                            action(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
    }

    private async Task DoShowDialogAsync(InteractionContext<ShoppingCartViewModel, 
                                            ListingViewModel?> interaction)
    {
        var dialog = new ShoppingCartWindow();
        dialog.DataContext = interaction.Input;

        var result = await dialog.ShowDialog<ListingViewModel?>(this);
        interaction.SetOutput(result);
    }   
}