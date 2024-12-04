using NFCSetup.ViewModels;

namespace NFCSetup.Pages;

public partial class HomePage : Controls.CustomControl
{
	public HomePage()
	{
		InitializeComponent();
	}

    private void SfTabView_SelectionChanged(object sender, Syncfusion.Maui.TabView.TabSelectionChangedEventArgs e)
    {
		if (e.NewIndex == 1)
		{
			UsersView.BindingContext = new UsersiewModel();
		}
		else if (e.NewIndex == 3)
		{
			MoreView.BindingContext = new MoreViewModel();
		}
    }
}