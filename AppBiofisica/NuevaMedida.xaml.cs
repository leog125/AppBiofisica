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
            //IniciarSensorOrientacion();
            //IniciarSensorAcelerometro();
            Docuemntopaciente = documentopaciente;
            lbCervicalSuperior.Text = "-25";
            lbCervicalInferior.Text = "25";
            lbDorsalSuperior.Text = "-10";
            lbDorsalInferior.Text = "-10";
            lbLumbarSuperior.Text = "15";
            lbLumbarInferior.Text = "-15";

        }

        private async void Btn_Siguiente_Clicked(object sender, EventArgs e)
        {
            PacienteInformacion PacienteInformacion = new PacienteInformacion();
            //Datos de verificacion para flujo de la app
            Medidas medida = new Medidas();

            medida.Id_Paciente_Medida = Docuemntopaciente;
            medida.Diametro_Columna = Convert.ToInt32(txt_DiametroColumna.Text);
            medida.Diametro_Cervical = Convert.ToInt32(txt_DiametroCervical.Text);
            medida.Diametro_Dorsal = Convert.ToInt32(txt_DiametroDorsal.Text);
            medida.Diametro_Lumbar = Convert.ToInt32(txt_DiametroLumbar.Text);
            medida.Angulo_Cervical_Central_Superior = Convert.ToInt32(lbCervicalSuperior.Text);
            medida.Angulo_Cervical_Central_Inferior = Convert.ToInt32(lbCervicalInferior.Text);
            medida.Angulo_Dorsal_Central_Superior = Convert.ToInt32(lbDorsalSuperior.Text);
            medida.Angulo_Dorsal_Central_Inferior = Convert.ToInt32(lbDorsalInferior.Text);
            medida.Angulo_Lumbar_Central_Superior = Convert.ToInt32(lbLumbarSuperior.Text);
            medida.Angulo_Lumbar_Central_Inferior = Convert.ToInt32(lbLumbarInferior.Text);

            await Navigation.PushAsync(new PacienteInformaciocentral(medida));
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

        private void DetenerSensorAcelerometro(object sender, EventArgs e)
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
            lbLumbarSuperior.Text = (Math.Abs(e.Reading.Acceleration.X) * 100).ToString("0.00");
            lbLumbarInferior.Text = (Math.Abs(e.Reading.Acceleration.Y) * 100).ToString("0.00");
            btn_Siguiente.Text = (Math.Abs(e.Reading.Acceleration.Z) * 100).ToString("0.00");
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
            lbCervicalSuperior.Text = (Math.Abs(e.Reading.Orientation.W)*100).ToString("0.00");
            lbCervicalInferior.Text = (Math.Abs(e.Reading.Orientation.X) * 100).ToString("0.00");
            lbDorsalSuperior.Text = (Math.Abs(e.Reading.Orientation.Y) * 100).ToString("0.00");
            lbDorsalInferior.Text = (Math.Abs(e.Reading.Orientation.Z) * 100).ToString("0.00");

            Console.WriteLine(e.Reading.Orientation);

        }

        #endregion

    }
}