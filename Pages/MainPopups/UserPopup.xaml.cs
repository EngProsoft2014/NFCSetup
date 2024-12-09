using Mopups.Services;
using NFCSetup.ViewModels;

namespace NFCSetup.Pages.MainPopups;

public partial class UserPopup : Mopups.Pages.PopupPage
{
    public UserPopup()
	{
        InitializeComponent();
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		await MopupService.Instance.PopAsync();
    }

    private async void TapGestureRecognizer_Custom_Vcard(object sender, TappedEventArgs e)
    {
        var vm = new AddCustomCardViewModel();
        var page = new AddCustomCardPage();
        page.BindingContext = vm;
        await App.Current!.MainPage!.Navigation.PushAsync(page);
        await MopupService.Instance.PopAsync();
    }

    private void TapGestureRecognizer_CreateLink(object sender, TappedEventArgs e)
    {

    }
}