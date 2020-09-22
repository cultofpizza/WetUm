using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Newtonsoft.Json;
using RGB.OneCallWeather;

namespace WetUm
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.Resources["defaultLabel"] = App.Current.Resources["lightLabel"];
            App.Current.Resources["defaultBG"] = App.Current.Resources["nightBG"];

            GetLocation();

        }



        public async void GetLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    label1.Text = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}";
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                Console.WriteLine("ошибОЧКА: " + fnsEx);
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                Console.WriteLine("ошибОЧКА: " + pEx);
            }
            catch (Exception ex)
            {
                // Unable to get location
                Console.WriteLine("ошибОЧКА: " + ex);
            }
        }
    }
}
