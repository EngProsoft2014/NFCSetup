using CommunityToolkit.Mvvm.ComponentModel;
using NFCSetup.Mode_s.Card;

namespace NFCSetup.ViewModels
{
    public partial class CardPreViewViewModel : BaseViewModel
    {
        [ObservableProperty]
        CardResponse card = new CardResponse();
        public CardPreViewViewModel(CardResponse _Card)
        {
            Card = _Card;
        }
    }
}
