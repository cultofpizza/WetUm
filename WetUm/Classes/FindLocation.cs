using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WetUm.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WetUm
{
    public class WetUmData
    {
        public async static Task<WeatherDataShort.Root> GetBindingData()
        {
            var cord = await GetCordAsync();
            var region = await GetRegionAsync(cord.lat, cord.lon);
            return GetWetherData(cord.lat, cord.lon, region);

        }

        private static async Task<(double lat, double lon)> GetCordAsync()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                    return (lat: location.Latitude, location.Longitude);
                else
                    return (lat: 0, lon:0);
            }
            #region Exceptions
            catch (FeatureNotSupportedException fnsEx)
            {
                throw fnsEx; // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                throw fneEx; // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                throw pEx;   // Handle permission exception
            }
            catch (Exception ex)
            {
                throw ex;    // Unable to get location
            }
            #endregion
        }

        private static WeatherDataShort.Root GetWetherData(double lat, double lon, string RegionName)
        {
            API.Key = "251ecc83c9f9662f52e6f27f28de5962";
            API.units = "metric";
            string call = API.GetJSON(lat.ToString(), lon.ToString());
            var weather = WeatherDataShort.Parse(call);
            weather.Region = RegionName;
            return weather;
        }

        private static async Task<string> GetRegionAsync(double lat, double lon)
        {
            try
            {
                //var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);
                //string geocodeAddress = placemarks?.FirstOrDefault().Locality;
                //return geocodeAddress;
                return "Moscow";
                #region прикол
                //var placemark = 
                //if (placemark != null)
                //{

                //     geocodeAddress =
                //        $"AdminArea:       {placemark.AdminArea}\n" +
                //        $"CountryCode:     {placemark.CountryCode}\n" +
                //        $"CountryName:     {placemark.CountryName}\n" +
                //        $"FeatureName:     {placemark.FeatureName}\n" +
                //        $"Locality:        {placemark.Locality}\n" +
                //        $"PostalCode:      {placemark.PostalCode}\n" +
                //        $"SubAdminArea:    {placemark.SubAdminArea}\n" +
                //        $"SubLocality:     {placemark.SubLocality}\n" +
                //        $"SubThoroughfare: {placemark.SubThoroughfare}\n" +
                //        $"Thoroughfare:    {placemark.Thoroughfare}\n";

                //    return geocodeAddress;
                //    //lable1.Text = geocodeAddress;
                //}
                #endregion
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                throw fnsEx;// Feature not supported on device
            }
            catch (Exception ex)
            {
                throw ex;// Handle exception that may have occurred in geocoding
            }
        }
    }
}
