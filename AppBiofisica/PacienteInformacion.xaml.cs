using AppBiofisica.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBiofisica
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PacienteInformacion : ContentPage
    {
        public int idPaciente = 0;
        public PacienteInformacion()
        {
            InitializeComponent();
            btn_NuevaMedida.IsEnabled = false;
            btn_HistorialPaciente.IsEnabled = false;
            txt_HistorialPaciente.IsEnabled = false;
        }

        private async void Btn_BuscarPaciente_Clicked(object sender, EventArgs e)
        {
            var paciente = await App.Database.BuscarPaciente(Convert.ToInt32(txt_BuscarPaciente.Text));
            if (paciente != null) 
            {
                btn_NuevaMedida.IsEnabled = true;
                btn_HistorialPaciente.IsEnabled = true;
                txt_HistorialPaciente.IsEnabled = true;
                idPaciente = paciente.Id_Paciente;
                lb_Paciente.Text += paciente.Nombre;
            }
            else 
            {
                txt_BuscarPaciente.Text = "";
                btn_NuevaMedida.IsEnabled = false;
                btn_HistorialPaciente.IsEnabled = false;
                txt_HistorialPaciente.IsEnabled = false;
                idPaciente = -1;
                lb_Paciente.Text += "";
                await DisplayAlert("", "Paciente no encontrado", "Ok");
            }
        }

        private async void Btn_NuevaMedida_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new NuevaMedida(idPaciente));
        }

        private async void Btn_HistorialPaciente_Clicked(object sender, EventArgs e)
        {
            var dt = await App.Database.BuscarHistorial(Convert.ToInt32(txt_HistorialPaciente.Text));
            if (dt != null) 
            {
                lb_test.Text = "Historial N°" + dt.Id_Medida + " Encontrado -> " + dt.Diametro_Columna.ToString() + " - " + dt.Diametro_Lumbar.ToString();
            }
            else 
            {
                lb_test.Text = "No existe el historial";
            }
        }
    }
}