using NFCSetup.Helpers;
using NFCSetup.ViewModels;

namespace NFCSetup.Pages;

public partial class HomePage : Controls.CustomControl
{

    #region Service
    readonly IGenericRepository Rep;
    readonly Services.Data.ServicesService _service;
    #endregion
    public HomePage(IGenericRepository GenericRep, Services.Data.ServicesService service)
	{
		InitializeComponent();
        Rep = GenericRep;
        _service = service;
    }

    private void SfTabView_SelectionChanged(object sender, Syncfusion.Maui.TabView.TabSelectionChangedEventArgs e)
    {
		if (e.NewIndex == 1)
		{
            CardsView.BindingContext = new CardsViewModel(Rep,_service);
		}
		else if (e.NewIndex == 2)
		{
			ContactView.BindingContext = new ContactViewModel();
		}
		else if (e.NewIndex == 3)
		{
			MoreView.BindingContext = new MoreViewModel(Rep,_service);
		} 
    }

    [Obsolete]
    protected override bool OnBackButtonPressed()
    {
        // Run the async code on the UI thread
        Dispatcher.Dispatch(() =>
        {
            Action action = () => Application.Current!.Quit();
            Controls.StaticMember.ShowSnackBar("Do you want to exit the program", Controls.StaticMember.SnackBarColor, Controls.StaticMember.SnackBarTextColor, action);
        });

        // Return true to prevent the default behavior
        return true;
    }
}