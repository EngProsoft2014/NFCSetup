using Mopups.Services;

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


}