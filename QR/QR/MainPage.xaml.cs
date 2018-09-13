using QR.Services;
using System;   
using Xamarin.Forms;  
  
  
namespace QR
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnScan_Clicked(object sender, EventArgs e)
        {
            try
            {
                var scanner = DependencyService.Get<IQrScanningService>();
                var result = await scanner.ScanAsync();
                if (result != null)
                {
                    txtBarcode.Text = result;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("error", ex.ToString(), "ok");
                //throw;
            }
        }
    }
}