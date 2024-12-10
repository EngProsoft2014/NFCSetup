using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;
using NFCSetup.Mode_s.Card;
using NFCSetup.Pages.MainPopups;

namespace NFCSetup.ViewModels
{
    public partial class AddCustomCardViewModel : BaseViewModel
    {
        #region Prop
        [ObservableProperty]
        public CardRequest request = new CardRequest();
        [ObservableProperty]
        public int isProfileImageAdded = 1;
        [ObservableProperty]
        public int isCoverImageAdded = 1;
        #endregion

        #region RelayCommand
        [RelayCommand]
        async Task AddProfileImageClick()
        {
            var page = new AddAttachmentsPopup();
            page.ImageClose += async (img, imgPath) =>
            {
                if (!string.IsNullOrEmpty(img))
                {
                    byte[] bytes = Convert.FromBase64String(img);
                    Request.ImgFileProfile = bytes;
                    Request.ImgProfileFile = ImageSource.FromStream(() => new MemoryStream(bytes));
                    Request.ExtensionProfile = Path.GetExtension(imgPath);
                    IsProfileImageAdded = 2;
                    await MopupService.Instance.PopAsync();
                }
            };
            await MopupService.Instance.PushAsync(page);
        }
        [RelayCommand]
        async Task AddCoverImageClick()
        {
            var page = new AddAttachmentsPopup();
            page.ImageClose += async (img, imgPath) =>
            {
                if (!string.IsNullOrEmpty(img))
                {
                    byte[] bytes = Convert.FromBase64String(img);
                    Request.ImgFileCover = bytes;
                    Request.ImgCoverFile = ImageSource.FromStream(() => new MemoryStream(bytes));
                    Request.ExtensionCover = Path.GetExtension(imgPath);
                    IsCoverImageAdded = 2;
                    await MopupService.Instance.PopAsync();
                }
            };
            await MopupService.Instance.PushAsync(page);
        }
        
        [RelayCommand]
        async Task SaveClick()
        {

        }
        #endregion
    }
}
