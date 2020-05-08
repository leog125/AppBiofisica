using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppBiofisica.Datos;
using System.IO;

namespace AppBiofisica
{
    public partial class App : Application
    {

        static Datos_BD database;

        public static Datos_BD Database
        {
            get
            {
                if (database == null)
                {
                    database = new Datos_BD(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AppBiofisica.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
