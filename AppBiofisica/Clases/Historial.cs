using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppBiofisica.Modelos;

namespace AppBiofisica.Clases
{
    public class Historial
    {
        public async Task<string> CrearHistorial(Medidas medida) 
        {
            var paciente = await App.Database.BuscarPacienteHistorial(medida.Id_Paciente_Medida);
            string textHistorial = "Historial Nº " + medida.Id_Medida;
            textHistorial += Environment.NewLine;
            textHistorial += "Paciente: " + paciente.Nombre + " " + paciente.Apellido;
            textHistorial += Environment.NewLine;
            textHistorial += "En proceso :)";
            return textHistorial;
                
        }
    }
}
