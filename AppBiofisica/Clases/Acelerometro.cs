using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Essentials;

namespace AppBiofisica.Clases
{
    public class Acelerometro
    {
        public string Eje_X { get; set; }
        public string Eje_Y { get; set; }
        public string Eje_Z { get; set; }
        public void StarAccelerometre()
        {
            if (Accelerometer.IsMonitoring)
            {
                return;
            }

            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            Accelerometer.Start(SensorSpeed.UI);
        }

        public void StopAccelerometer()
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
            Eje_X = e.Reading.Acceleration.X.ToString();
            Eje_X = e.Reading.Acceleration.Y.ToString();
            Eje_X = e.Reading.Acceleration.Z.ToString();
        }

        
    }
}
