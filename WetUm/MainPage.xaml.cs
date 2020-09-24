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
            SetLightTheme();
            App.Current.Resources["defaultBG"] = App.Current.Resources["nightBG"];
            App.Current.Resources["defaultBG"] = App.Current.Resources["cloudBG"];
        }

        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            HourlyScrollLayout.TranslationY = -dailyScroll.ScrollY / 3.5;
            dailyScroll.TranslationY = -dailyScroll.ScrollY / 3.5;
            dailyBorderTop.TranslationY = -dailyScroll.ScrollY / 3.5;
            dailyBorderBottom.TranslationY = -dailyScroll.ScrollY / 3.5;

            labelCurrentInfo.Opacity = 1 + dailyScroll.TranslationY/45;
            labelCurrentDescription.Opacity = 1 + dailyScroll.TranslationY/45;
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            label1.Text = dailyScroll.Height.ToString();
            label2.Text = dailyScroll.TranslationY.ToString();
        }

        void Dark_Clicked(object sender, EventArgs e)
        {
            SetDarkTheme();
        }
        void Light_Clicked(object sender, EventArgs e)
        {
            SetLightTheme();
        }

        public void SetDarkTheme()
        {
            App.Current.Resources["defaultLabel"] = App.Current.Resources["lightLabel"];
            App.Current.Resources["cloud"] = App.Current.Resources["cloud_light"];
            App.Current.Resources["cloudy"] = App.Current.Resources["cloudy_light"];
            App.Current.Resources["cloudy_day"] = App.Current.Resources["cloudy_day_light"];
            App.Current.Resources["cloudy_night"] = App.Current.Resources["cloudy_night_light"];
            App.Current.Resources["cold"] = App.Current.Resources["cold_light"];
            App.Current.Resources["eclipse"] = App.Current.Resources["eclipse_light"];
            App.Current.Resources["hot"] = App.Current.Resources["hot_light"];
            App.Current.Resources["humidity"] = App.Current.Resources["humidity_light"];
            App.Current.Resources["mist"] = App.Current.Resources["mist_light"];
            App.Current.Resources["rain"] = App.Current.Resources["rain_light"];
            App.Current.Resources["rainbow"] = App.Current.Resources["rainbow_light"];
            App.Current.Resources["rainy"] = App.Current.Resources["rainy_light"];
            App.Current.Resources["snow"] = App.Current.Resources["snow_light"];
            App.Current.Resources["snowy"] = App.Current.Resources["snowy_light"];
            App.Current.Resources["sun"] = App.Current.Resources["sun_light"];
            App.Current.Resources["sunrise"] = App.Current.Resources["sunrise_light"];
            App.Current.Resources["sunset"] = App.Current.Resources["sunset_light"];
            App.Current.Resources["thunder"] = App.Current.Resources["thunder_light"];
            App.Current.Resources["tornado"] = App.Current.Resources["tornado_light"];
            App.Current.Resources["umbrella"] = App.Current.Resources["umbrella_light"];
        }
        public void SetLightTheme()
        {
            App.Current.Resources["defaultLabel"] = App.Current.Resources["darkLabel"];
            App.Current.Resources["cloud"] = App.Current.Resources["cloud_dark"];
            App.Current.Resources["cloudy"] = App.Current.Resources["cloudy_dark"];
            App.Current.Resources["cloudy_day"] = App.Current.Resources["cloudy_day_dark"];
            App.Current.Resources["cloudy_night"] = App.Current.Resources["cloudy_night_dark"];
            App.Current.Resources["cold"] = App.Current.Resources["cold_dark"];
            App.Current.Resources["eclipse"] = App.Current.Resources["eclipse_dark"];
            App.Current.Resources["hot"] = App.Current.Resources["hot_dark"];
            App.Current.Resources["humidity"] = App.Current.Resources["humidity_dark"];
            App.Current.Resources["mist"] = App.Current.Resources["mist_dark"];
            App.Current.Resources["rain"] = App.Current.Resources["rain_dark"];
            App.Current.Resources["rainbow"] = App.Current.Resources["rainbow_dark"];
            App.Current.Resources["rainy"] = App.Current.Resources["rainy_dark"];
            App.Current.Resources["snow"] = App.Current.Resources["snow_dark"];
            App.Current.Resources["snowy"] = App.Current.Resources["snowy_dark"];
            App.Current.Resources["sun"] = App.Current.Resources["sun_dark"];
            App.Current.Resources["sunrise"] = App.Current.Resources["sunrise_dark"];
            App.Current.Resources["sunset"] = App.Current.Resources["sunset_dark"];
            App.Current.Resources["thunder"] = App.Current.Resources["thunder_dark"];
            App.Current.Resources["tornado"] = App.Current.Resources["tornado_dark"];
            App.Current.Resources["umbrella"] = App.Current.Resources["umbrella_dark"];
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
                else
                {

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
                Console.WriteLine("ошибОЧКА: " + fneEx);
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
