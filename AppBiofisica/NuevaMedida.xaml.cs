using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppBiofisica.Modelos;

namespace AppBiofisica
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevaMedida : ContentPage
    {
        public int Docuemntopaciente = 0;
        public NuevaMedida(int documentopaciente)
        {
            InitializeComponent();
            IniciarSensorAcelerometro();
            Docuemntopaciente = documentopaciente;

        }

        private async void Btn_Siguiente_Clicked(object sender, EventArgs e)
        {
            PacienteInformacion PacienteInformacion = new PacienteInformacion();
            //Datos de verificacion para flujo de la app
            Medidas medida = new Medidas
            {
                Id_Paciente_Medida = Docuemntopaciente,
                Diametro_Columna = Convert.ToInt32(txt_DiametroColumna.Text),
                Diametro_Cervical = Convert.ToInt32(txt_DiametroCervical.Text),
                Diametro_Dorsal = Convert.ToInt32(txt_DiametroDorsal.Text),
                Diametro_Lumbar = Convert.ToInt32(txt_DiametroLumbar.Text),
                Angulo_Cervical_Central_Superior = Convert.ToInt32(lbCervicalSuperior1_v2.Text),
                Angulo_Cervical_Central_Inferior = Convert.ToInt32(lbCervicalInferior1_v2.Text),
                Angulo_Dorsal_Central_Superior = Convert.ToInt32(lbDorsalSuperior1_v2.Text),
                Angulo_Dorsal_Central_Inferior = Convert.ToInt32(lbDorsalInferior1_v2.Text),
                Angulo_Lumbar_Central_Superior = Convert.ToInt32(lbLumbarSuperior1_v2.Text),
                Angulo_Lumbar_Central_Inferior = Convert.ToInt32(lbLumbarInferior1_v2.Text)
            };
            DetenerSensorAcelerometro();
            await Navigation.PushAsync(new PacienteInformaciocentral(medida));
        }

        private void IbCervicalSuperior_Clicked(object sender, EventArgs e)
        {
            lbCervicalSuperior1_v2.Text = lbCervicalSuperior.Text;
        }

        private void IbCervicalInferior_Clicked(object sender, EventArgs e)
        {
            lbCervicalInferior1_v2.Text = lbCervicalInferior.Text;
        }

        private void IbDorsalSuperior_Clicked(object sender, EventArgs e)
        {
            lbDorsalSuperior1_v2.Text = lbDorsalSuperior.Text;
        }

        private void IbDorsalInferior_Clicked(object sender, EventArgs e)
        {
            lbDorsalInferior1_v2.Text = lbDorsalInferior.Text;
        }

        private void IbLumbarSuperior_Clicked(object sender, EventArgs e)
        {
            lbLumbarSuperior1_v2.Text = lbLumbarSuperior.Text;
        }

        private void IbLumbarInferior_Clicked(object sender, EventArgs e)
        {
            lbLumbarInferior1_v2.Text = lbLumbarInferior.Text;
        }

        #region Sensor Acelerometro
        private void IniciarSensorAcelerometro()
        {
            if (Accelerometer.IsMonitoring)
            {
                return;
            }

            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            Accelerometer.Start(SensorSpeed.UI);
        }

        private void DetenerSensorAcelerometro()
        {
            if (!Accelerometer.IsMonitoring)
            {
                return;
            }

            Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
            Accelerometer.Stop();

        }

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            //recopilacion de informacion del sensor acelerometro
            lbCervicalSuperior.Text = Convert.ToInt32(Math.Asin(e.Reading.Acceleration.Y) * (180 / Math.PI)).ToString();
            lbCervicalInferior.Text = Convert.ToInt32(Math.Asin(e.Reading.Acceleration.Y) * (180 / Math.PI)).ToString();
            lbDorsalSuperior.Text = Convert.ToInt32(Math.Asin(e.Reading.Acceleration.Y) * (180 / Math.PI)).ToString();
            lbDorsalInferior.Text = Convert.ToInt32(Math.Asin(e.Reading.Acceleration.Y) * (180 / Math.PI)).ToString();
            lbLumbarSuperior.Text = Convert.ToInt32(Math.Asin(e.Reading.Acceleration.Y) * (180 / Math.PI)).ToString();
            lbLumbarInferior.Text = Convert.ToInt32(Math.Asin(e.Reading.Acceleration.Y) * (180 / Math.PI)).ToString();
        }
        #endregion

        #region Sensor Orientacion

        private void IniciarSensorOrientacion()
        {
            if (OrientationSensor.IsMonitoring) 
            {
                return;
            }

            OrientationSensor.ReadingChanged += OrientationSensor_ReadingChanged;
            OrientationSensor.Start(SensorSpeed.UI);

        }

        private void DetenerSensorOrientacion()
        {
            if (!OrientationSensor.IsMonitoring)
            {
                return;
            }

            OrientationSensor.ReadingChanged -= OrientationSensor_ReadingChanged;
            OrientationSensor.Stop();

        }

        private void OrientationSensor_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
        {
            //recopilacion de informacion del sensor de orintacion
            lbCervicalSuperior.Text = (Math.Asin(e.Reading.Orientation.W)*100).ToString("0.00");
            lbCervicalInferior.Text = (Math.Asin(e.Reading.Orientation.X) * 100).ToString("0.00");
            lbDorsalSuperior.Text = (Math.Asin(e.Reading.Orientation.Y) * 100).ToString("0.00");
            lbDorsalInferior.Text = (Math.Asin(e.Reading.Orientation.Z) * 100).ToString("0.00");

            Console.WriteLine(e.Reading.Orientation);

        }

        #endregion
    }
}