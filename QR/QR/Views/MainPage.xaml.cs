using QR.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

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
            var scan = new ZXingScannerPage();
            await QR.App.Current.MainPage.Navigation.PushModalAsync(scan);
            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await QR.App.Current.MainPage.Navigation.PopModalAsync();
                    if (!string.IsNullOrEmpty(result.Text))
                        txtBarCode.Text = result.Text;
                });
            };
        }


        private async void btnHistory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new History() 
            {
                BackgroundColor = Color.DarkGray

            }, false);
        }

    }
}
