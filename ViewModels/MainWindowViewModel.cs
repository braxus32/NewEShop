
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Windows.Input;
using ReactiveUI;
using NewEShop.ViewModels;

namespace NewEShop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            ShowDialog = new Interaction<ShoppingCartViewModel, ListingViewModel?>();

            ViewCartCommand = ReactiveCommand.Create(async () =>
            {
                var cart = new ShoppingCartViewModel();

                var result = await ShowDialog.Handle(cart);
            });
        }
        
        public ICommand ViewCartCommand { get; }

        public Interaction<ShoppingCartViewModel, ListingViewModel?> ShowDialog { get; }

    }
}