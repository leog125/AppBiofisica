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
            var paciente = App.Database.BuscarPaciente(Convert.ToInt32(txt_BuscarPaciente.Text));
            if (paciente != null) 
            {
                btn_NuevaMedida.IsEnabled = true;
                btn_HistorialPaciente.IsEnabled = true;
                txt_HistorialPaciente.IsEnabled = true;
                idPaciente = paciente.Result.Id_Paciente;
            }
            else 
            {
                txt_BuscarPaciente.Text = "";
                await DisplayAlert("No Existe", "Documento no encontrado", "Ok");
            }
        }

        private async void Btn_NuevaMedida_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new NuevaMedida(idPaciente));
        }

        private void Btn_HistorialPaciente_Clicked(object sender, EventArgs e)
        {
            int idHistorial = Convert.ToInt32(txt_HistorialPaciente.Text);
            var dt = App.Database.BuscarHistorial(idHistorial);
            if (dt != null) 
            {
                lb_test.Text = dt.Result.Diametro_Columna.ToString() + " - " + dt.Result.Diametro_Lumbar.ToString();
            }
            else 
            {
                lb_test.Text = "No existe el historial";
            }
        }
    }
}