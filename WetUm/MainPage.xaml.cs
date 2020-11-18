using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Newtonsoft.Json;
using WetUm.Interfaces;

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
            Button_Clicked(null, null);
        }

        public async void Button_Clicked(object sender, EventArgs e)
        {
            if(!DependencyService.Get<ILocationActivity>().IsLocationEnabled())
            {
                var reaction = await DisplayAlert("Ошибка", "Включите геолокацию", "ОК", "Отмена");
                if (reaction)
                    DependencyService.Get<IOpenLocationSettings>().OpenSettings();
            }
            else
            {
                BindingContext = await WetUmData.GetBindingData();
            }
        }

        #region Это Сделал Саша
        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            HourlyScrollLayout.TranslationY = -dailyScroll.ScrollY / 3.5;
            dailyScroll.TranslationY = -dailyScroll.ScrollY / 3.5;
            dailyBorderTop.TranslationY = -dailyScroll.ScrollY / 3.5;
            dailyBorderBottom.TranslationY = -dailyScroll.ScrollY / 3.5;

            labelCurrentInfo.Opacity = 1 + dailyScroll.TranslationY / 45;
            labelCurrentDescription.Opacity = 1 + dailyScroll.TranslationY / 45;
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
        #endregion
        #region Это я закоментил
        //public async void GetLocation()
        //{
        //    try
        //    {
        //        var request = new GeolocationRequest(GeolocationAccuracy.Medium);
        //        var location = await Geolocation.GetLocationAsync(request);

        //        if (location != null)
        //        {
        //            await GetRegionAsync(location.Latitude, location.Longitude);
        //        }
        //    }
        //    catch (FeatureNotSupportedException fnsEx)
        //    {
        //        // Handle not supported on device exception
        //        Console.WriteLine("ошибОЧКА: " + fnsEx);
        //    }
        //    catch (FeatureNotEnabledException fneEx)
        //    {
        //        // Handle not enabled on device exception
        //        var reaction = await DisplayAlert("Ошибка", "Включите геолокацию", "ОК", "Отмена");
        //        if (reaction)
        //            DependencyService.Get<IOpenLocationSettings>().OpenSettings();
        //    }
        //    catch (PermissionException pEx)
        //    {
        //        // Handle permission exception
        //        Console.WriteLine("ошибОЧКА: " + pEx);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Unable to get location
        //        Console.WriteLine("ошибОЧКА: " + ex);
        //    }
        //}

        //private async Task GetRegionAsync(double lat, double lon)
        //{
        //    API.Key = "251ecc83c9f9662f52e6f27f28de5962";
        //    API.units = "metric";
        //    string call = API.GetJSON(lat.ToString(), lon.ToString());
        //    var weather = WeatherDataShort.Parse(call);
        //    this.BindingContext = weather;
        //    try
        //    {
        //        var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);

        //        var placemark = placemarks?.FirstOrDefault();
        //        if (placemark != null)
        //        {

        //            var geocodeAddress =
        //                $"AdminArea:       {placemark.AdminArea}\n" +
        //                $"CountryCode:     {placemark.CountryCode}\n" +
        //                $"CountryName:     {placemark.CountryName}\n" +
        //                $"FeatureName:     {placemark.FeatureName}\n" +
        //                $"Locality:        {placemark.Locality}\n" +
        //                $"PostalCode:      {placemark.PostalCode}\n" +
        //                $"SubAdminArea:    {placemark.SubAdminArea}\n" +
        //                $"SubLocality:     {placemark.SubLocality}\n" +
        //                $"SubThoroughfare: {placemark.SubThoroughfare}\n" +
        //                $"Thoroughfare:    {placemark.Thoroughfare}\n" +
        //                $"Ветер:    {weather.current.wind_speed}\n" +
        //                $"Дневная температура через 2 дня:    {weather.daily[1].temp.day}\n";

        //            //lable1.Text = geocodeAddress;
        //        }
        //    }
        //    catch (FeatureNotSupportedException fnsEx)
        //    {
        //        // Feature not supported on device
        //        Console.WriteLine(fnsEx);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exception that may have occurred in geocoding
        //        Console.WriteLine(ex);
        //    }
        //}
        #endregion
    }
}
