using NFCSetup.Helpers;
using NFCSetup.Pages;
using NFCSetup.ViewModels;
using NFCSetup.Constants;

namespace NFCSetup
{
    public partial class App : Application
    {
        #region Service
        readonly IGenericRepository Rep;
        readonly Services.Data.ServicesService _service;
        #endregion
        public App(IGenericRepository GenericRep, Services.Data.ServicesService service)
        {
            Rep = GenericRep;
            _service = service;
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(ApiConstants.syncFusionLicence);

            var vm = new LoginViewModel(Rep,_service);
            var page = new LoginPage();
            page.BindingContext = vm;
            MainPage = new NavigationPage(page);  
        }
    }
}
