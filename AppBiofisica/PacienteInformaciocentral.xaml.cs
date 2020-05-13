using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppBiofisica.Modelos;

namespace AppBiofisica
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PacienteInformaciocentral : ContentPage
    {
        Medidas medidas = new Medidas();
        public PacienteInformaciocentral(Medidas medida)
        {
            InitializeComponent();
            medidas = medida;

            //Datos de validacion del funcionamiento del flujo de la app
            lbCervicalSuperior2.Text = "6";
            lbCervicalInferior2.Text = "7";
            lbDorsalSuperior2.Text = "4";
            lbDorsalInferior2.Text = "3";
            lbLumbarSuperior2.Text = "6";
            lbLumbarInferior2.Text = "3";

        }

        private async void Btn_Guardar_Clicked(object sender, EventArgs e)
        {
            medidas.Angulo_Cervical_Central_Superior2 = Convert.ToInt32(lbCervicalSuperior2.Text);
            medidas.Angulo_Cervical_Central_Inferior2 = Convert.ToInt32(lbCervicalInferior2.Text);
            medidas.Angulo_Dorsal_Central_Superior2 = Convert.ToInt32(lbDorsalSuperior2.Text);
            medidas.Angulo_Dorsal_Central_Inferior2 = Convert.ToInt32(lbDorsalInferior2.Text);
            medidas.Angulo_Lumbar_Central_Superior2 = Convert.ToInt32(lbLumbarSuperior2.Text);
            medidas.Angulo_Lumbar_Central_Inferior2 = Convert.ToInt32(lbLumbarInferior2.Text);

            var sad = App.Database.GuardarMedicion(medidas);
            await DisplayAlert("Historial Guardado", "Historial numero " + sad.Result.Id_Medida.ToString() + " Guardado.", "Ok");
            await Navigation.PushAsync(new PacienteInformacion());

        }

    }
}