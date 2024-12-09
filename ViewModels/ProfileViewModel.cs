namespace NFCSetup.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel 
    {


        async Task BackClicked()
        {
            await App.Current!.MainPage!.Navigation.PopAsync();
        }
    }
}
