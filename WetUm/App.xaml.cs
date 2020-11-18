using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WetUm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            //var a = new FindLocation();
            //a.GetLocation();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
