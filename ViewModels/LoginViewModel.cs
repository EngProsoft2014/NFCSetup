using CommunityToolkit.Mvvm.Input;
using NFCSetup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCSetup.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [RelayCommand]
        async Task LoginClick()
        {
            var vm = new HomeViewModel();
            var page = new HomePage();
            page.BindingContext = vm;
            await App.Current!.MainPage!.Navigation.PushAsync(page);
        }
    }
}
