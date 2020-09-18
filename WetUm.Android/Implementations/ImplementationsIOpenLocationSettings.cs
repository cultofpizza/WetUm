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
using Xamarin.Forms;

[assembly: Dependency(typeof(ImplementationsIOpenLocationSettings))]
namespace WetUm.Droid.Implementations
{
    class ImplementationsIOpenLocationSettings : IOpenLocationSettings
    {
        public void OpenSettings()
        {
            LocationManager LM = (LocationManager)Forms.Context.GetSystemService(Context.LocationService);
            if (LM.IsProviderEnabled(LocationManager.GpsProvider) == false)
            {
                Context ctx = Forms.Context;
                ctx.StartActivity(new Intent(Android.Provider.Settings.ActionLocationSourceSettings));
            }
            else
            {
                //this is handled in the PCL
            }
        }
    }
}