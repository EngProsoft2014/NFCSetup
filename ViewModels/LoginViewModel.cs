using Akavache;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Controls.UserDialogs.Maui;
using NFCSetup.Helpers;
using NFCSetup.Mode_s.ApplicationUser;
using NFCSetup.Pages;
using NFCSetup.Services.Data;
using System.Reactive.Linq;
using NFCSetup.Constants;

namespace NFCSetup.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        #region Prop
        [ObservableProperty]
        public ApplicationUserLoginRequest loginRequest = new ApplicationUserLoginRequest();
        [ObservableProperty]
        public ApplicationUserResponse userResponse = new ApplicationUserResponse();
        #endregion

        #region Service
        readonly IGenericRepository Rep;
        readonly Services.Data.ServicesService _service;
        #endregion

        #region Cons
        public LoginViewModel(IGenericRepository GenericRep, Services.Data.ServicesService service)
        {
            Rep = GenericRep;
            _service = service;
        } 
        #endregion

        #region RelayCommand
        [RelayCommand]
        async Task LoginClick(ApplicationUserLoginRequest model)
        {
            IsEnable = false;
            UserDialogs.Instance.ShowLoading();

            var json = await Rep.PostTRAsync<ApplicationUserLoginRequest, ApplicationUserResponse>(ApiConstants.LoginApi, model);

            if (json.Item1 != null)
            {
                UserResponse = json.Item1;

                if (!string.IsNullOrEmpty(UserResponse?.Id))
                {
                    Controls.StaticMember.WayOfTab = 0;

                    Preferences.Default.Set(ApiConstants.userid, UserResponse.Id);
                    Preferences.Default.Set(ApiConstants.email, UserResponse.Email);
                    Preferences.Default.Set(ApiConstants.username, UserResponse.UserName);
                    Preferences.Default.Set(ApiConstants.userPermision, UserResponse.UserPermision);
                    Preferences.Default.Set(ApiConstants.userCategory, UserResponse.UserCategory);
                    Preferences.Default.Set(ApiConstants.AccountId, UserResponse.AccountId);

                    await BlobCache.LocalMachine.InsertObject(ServicesService.UserTokenServiceKey, UserResponse?.Token, DateTimeOffset.Now.AddMinutes(43200));

                    var vm = new HomeViewModel();
                    var page = new HomePage();
                    page.BindingContext = vm;
                    await App.Current!.MainPage!.Navigation.PushAsync(page);
                }
            }
            else
            {

                var toast = Toast.Make($"{json.Item2?.errors?.FirstOrDefault().Value}", CommunityToolkit.Maui.Core.ToastDuration.Long, 15);
                await toast.Show();

                var vm = new HomeViewModel();
                var page = new HomePage();
                page.BindingContext = vm;
                await App.Current!.MainPage!.Navigation.PushAsync(page);
            }

            UserDialogs.Instance.HideHud();

            IsEnable = true;
        } 
        #endregion
    }
}
