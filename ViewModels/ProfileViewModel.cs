using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Controls.UserDialogs.Maui;
using NFCSetup.Constants;
using NFCSetup.Helpers;
using NFCSetup.Mode_s.ApplicationUser;
using Plugin.NFC;
using System.Text;

namespace NFCSetup.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        #region prop
        [ObservableProperty]
        public ApplicationUserResponse userResponse = new ApplicationUserResponse(); 
        #endregion

        #region Service
        readonly IGenericRepository Rep;
        readonly Services.Data.ServicesService _service;
        #endregion

        #region Cons
        public ProfileViewModel(IGenericRepository GenericRep, Services.Data.ServicesService service)
        {
            Rep = GenericRep;
            _service = service;
            Init();
        }
        #endregion

        #region Methods
        async void Init()
        {
            await GetProfileData();
        }
        async Task GetProfileData()
        {
            string UserToken = await _service.UserToken();
            if (!string.IsNullOrEmpty(UserToken))
            {
                UserDialogs.Instance.ShowLoading();
                var json = await Rep.GetAsync<ApplicationUserResponse>(ApiConstants.UserProfileApi, UserToken);
                UserDialogs.Instance.HideHud();
                if (json != null)
                {
                    UserResponse = json;
                }
            }
        }

        #endregion
  
    }
}
