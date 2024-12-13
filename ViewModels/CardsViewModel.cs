using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Controls.UserDialogs.Maui;
using Kotlin.Jvm.Internal;
using Mopups.Services;
using NFCSetup.Constants;
using NFCSetup.Helpers;
using NFCSetup.Mode_s.Card;
using NFCSetup.Pages;
using NFCSetup.Pages.MainPopups;
using System.Collections.ObjectModel;

namespace NFCSetup.ViewModels
{
    public partial class CardsViewModel : BaseViewModel
    {
        #region Prop
        [ObservableProperty]
        ObservableCollection<CardResponse> cardLst = new ObservableCollection<CardResponse>(); 
        #endregion

        #region Service
        readonly IGenericRepository Rep;
        readonly Services.Data.ServicesService _service;
        #endregion

        #region Cons
        public CardsViewModel(IGenericRepository GenericRep, Services.Data.ServicesService service)
        {
            Rep = GenericRep;
            _service = service;
        } 
        #endregion

        #region RelayCommand
        [RelayCommand]
        async Task AddCardClick()
        {
            await MopupService.Instance.PushAsync(new UserPopup());
        }
        [RelayCommand]
        async Task CardPreViewClick()
        {
            var vm = new CardPreViewViewModel();
            var page = new CardPreViewPage();
            page.BindingContext = vm;
            await App.Current!.MainPage!.Navigation.PushAsync(page);
        }
        [RelayCommand]
        async Task ShareCardClick()
        {
            await MopupService.Instance.PushAsync(new QrCodePopup());
        }
        #endregion

        #region Methodes
        async void Init()
        {
            await GetAllCards();
        }

        async Task GetAllCards()
        {
            string UserToken = await _service.UserToken();
            if (!string.IsNullOrEmpty(UserToken))
            {
                UserDialogs.Instance.ShowLoading();
                var json = await Rep.GetAsync<ObservableCollection<CardResponse>>(ApiConstants.UserProfileApi, UserToken);
                UserDialogs.Instance.HideHud();
                if (json != null)
                {
                    CardLst = json;
                }
            }
        } 
        #endregion
    }
}
