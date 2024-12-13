﻿using Akavache;
using CommunityToolkit.Mvvm.Input;
using NFCSetup.Helpers;
using NFCSetup.Pages;
using Plugin.NFC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCSetup.ViewModels
{
    public partial class MoreViewModel : BaseViewModel
    {
        #region Service
        readonly IGenericRepository Rep;
        readonly Services.Data.ServicesService _service;
        #endregion

        #region Cons
        public MoreViewModel(IGenericRepository GenericRep, Services.Data.ServicesService service)
        {
            Rep = GenericRep;
            _service = service;
        }
        #endregion

       

        #region RelayCommand
        [RelayCommand]
        async Task ProfileClick()
        {
            var vm = new ProfileViewModel(Rep,_service);
            var page = new ProfilePage(vm);
            page.BindingContext = vm;
            await App.Current!.MainPage!.Navigation.PushAsync(page);
        }

        [RelayCommand]
        [Obsolete]
        Task ExitClick()
        {
            Action action = async () =>
            {
                string LangValueToKeep = Preferences.Default.Get("Lan", "en");
                Preferences.Default.Clear();
                await BlobCache.LocalMachine.InvalidateAll();
                await BlobCache.LocalMachine.Vacuum();

                Preferences.Default.Set("Lan", LangValueToKeep);
                var vm = new LoginViewModel(Rep, _service);
                var page = new LoginPage();
                page.BindingContext = vm;
                await Application.Current!.MainPage!.Navigation.PushAsync(page);
            };
            Controls.StaticMember.ShowSnackBar("Do you want to Logout", Controls.StaticMember.SnackBarColor, Controls.StaticMember.SnackBarTextColor, action);
            return Task.CompletedTask;
        }
        #endregion
    }
}
