using CommunityToolkit.Mvvm.Input;
using Mopups.Services;
using NFCSetup.Pages.MainPopups;

namespace NFCSetup.ViewModels
{
    public partial class UsersiewModel : BaseViewModel
    {

        [RelayCommand]
        async Task AddUserClick()
        {
            await MopupService.Instance.PushAsync(new UserPopup());
        }
    }
}
