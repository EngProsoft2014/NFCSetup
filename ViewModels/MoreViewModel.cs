using CommunityToolkit.Mvvm.Input;
using NFCSetup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCSetup.ViewModels
{
    public partial class MoreViewModel : BaseViewModel
    {

        #region RelayCommand
        [RelayCommand]
        async Task ProfileClick()
        {
            var vm = new ProfileViewModel();
            var page = new ProfilePage();
            page.BindingContext = vm;
            await App.Current!.MainPage!.Navigation.PushAsync(page);
        } 
        #endregion
    }
}
