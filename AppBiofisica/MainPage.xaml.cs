using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Xamarin.Essentials;
using AppBiofisica.Clases;

namespace AppBiofisica
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

        //private void btn_Start_Clicked(object sender, EventArgs e)
        //{
        //    if (Accelerometer.IsMonitoring)
        //    {
        //        return;
        //    }

        //    Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
        //    Accelerometer.Start(SensorSpeed.UI);
        //}

        //private void btn_Stop_Clicked(object sender, EventArgs e)
        //{
        //    if (!Accelerometer.IsMonitoring)
        //    {
        //        return;
        //    }

        //    Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
        //    Accelerometer.Stop();

        //}

        //private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        //{
        //    Label_X.Text = e.Reading.Acceleration.X.ToString("0.00");
        //    Label_Y.Text = e.Reading.Acceleration.Y.ToString("0.00");
        //    Label_Z.Text = e.Reading.Acceleration.Z.ToString("0.00");
        //}

        private async void btn_Registro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroPaciente());
        }

        private async void btn_Buscar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PacienteInformacion());
        }

    }
}
