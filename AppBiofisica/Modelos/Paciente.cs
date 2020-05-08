using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppBiofisica.Modelos
{
    public class Paciente
    {
        [PrimaryKey, AutoIncrement]
        public int Id_Paciente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public int Estatura { get; set; }
        public int Peso { get; set; }
    }
}
