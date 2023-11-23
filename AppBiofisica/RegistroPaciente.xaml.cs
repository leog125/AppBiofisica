using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppBiofisica.Modelos;

namespace AppBiofisica
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroPaciente : ContentPage
    {
        public RegistroPaciente()
        {
            InitializeComponent();
        }

        private async void btn_Guardar_Clicked(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                Paciente paciente = new Paciente { 
                    Nombre = Paciente_Nombre.Text,
                    Apellido = Paciente_Apellido.Text,
                    TipoDocumento = Paciente_TipoDocumento.SelectedItem.ToString(),
                    NumeroDocumento = Convert.ToInt32(Paciente_NumeroDocumento.Text),
                    Correo = Paciente_Correo.Text,
                    Edad = Convert.ToInt32(Paciente_Edad.Text),
                    Sexo = Paciente_Sexo.SelectedItem.ToString(),
                    Estatura = Convert.ToInt32(Paciente_Estatura.Text),
                    Peso = Convert.ToInt32(Paciente_Peso.Text),
                };
                await App.Database.GuardarPaciente(paciente);
                await DisplayAlert("Registro", "Paciente registrado con exito!", "Ok");
                await Navigation.PushAsync(new PacienteInformacion());
            }
            else
                await DisplayAlert("Advertencia", "Campos no validos o vacios", "Ok");
        }

        public Boolean ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(Paciente_Nombre.Text))
                return false;
            else if (!Paciente_Nombre.Text.ToCharArray().All(char.IsLetter))
                return false;

            if (string.IsNullOrWhiteSpace(Paciente_Apellido.Text))
                return false;
            else if (!Paciente_Apellido.Text.ToCharArray().All(char.IsLetter))
                return false;

            if (Paciente_TipoDocumento.SelectedIndex == -1)
                return false;

            if (string.IsNullOrWhiteSpace(Paciente_NumeroDocumento.Text))
                return false;
            else if (!Paciente_NumeroDocumento.Text.ToCharArray().All(char.IsDigit))
                return false;
            
            if (string.IsNullOrWhiteSpace(Paciente_Correo.Text))
                return false;
            else
            {
                bool isEmail = Regex.IsMatch(Paciente_Correo.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (!isEmail)
                    return false;
            }

            if (string.IsNullOrWhiteSpace(Paciente_Edad.Text))
                return false;
            else if (!Paciente_Edad.Text.ToCharArray().All(char.IsDigit))
                return false;
            
            if (Paciente_Sexo.SelectedIndex == -1)
                return false;

            if (string.IsNullOrWhiteSpace(Paciente_Estatura.Text))
                return false;
            else if (!Paciente_Estatura.Text.ToCharArray().All(char.IsDigit))
                return false;

            if (string.IsNullOrWhiteSpace(Paciente_Peso.Text))
                return false;
            else if (!Paciente_Peso.Text.ToCharArray().All(char.IsDigit))
                return false;

            return true;
        }

    }
}