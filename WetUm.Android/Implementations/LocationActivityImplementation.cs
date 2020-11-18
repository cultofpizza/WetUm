using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WetUm.Droid.Implementations;
using WetUm.Interfaces;
using WetUm.Droid;
using static Android.Provider.Settings;
using Android.Provider;

[assembly: Xamarin.Forms.Dependency(typeof(LocationActivityImplementation))]
namespace WetUm.Droid.Implementations
{
    class LocationActivityImplementation : ILocationActivity
    {
        public bool IsLocationEnabled()
        {
            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.P)
            {
                // This is new method provided in API 28
                LocationManager lm = (LocationManager)Android.App.Application.Context.GetSystemService(Service.LocationService);
                return lm != null && lm.IsLocationEnabled;
            }
            else
            {
                // This is Deprecated in API 28
                int mode = Secure.GetInt(Android.App.Application.Context.ContentResolver, Secure.LocationMode);
                return (mode != (int)SecurityLocationMode.Off);
            }
        }
    }
}