using NFCSetup.Pages;
using NFCSetup.ViewModels;
using TripBliss.Constants;

namespace NFCSetup
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(ApiConstants.syncFusionLicence);

            var vm = new LoginViewModel();
            var page = new LoginPage();
            page.BindingContext = vm;
            MainPage = new NavigationPage(page);  
        }
    }
}
