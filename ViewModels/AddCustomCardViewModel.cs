using CommunityToolkit.Mvvm.Input;
using Mopups.Services;
using NFCSetup.Pages.MainPopups;

namespace NFCSetup.ViewModels
{
    public partial class AddCustomCardViewModel : BaseViewModel
    {

        [RelayCommand]
        async Task AddImageClick()
        {
            await MopupService.Instance.PushAsync(new AddAttachmentsPopup());
        }
        [RelayCommand]
        async Task BackClicked()
        {
            await App.Current!.MainPage!.Navigation.PopAsync();
        }
    }
}
