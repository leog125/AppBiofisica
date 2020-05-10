using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppBiofisica.Modelos
{
    public class Medidas
    {
        [PrimaryKey, AutoIncrement]
        public int Id_Medida { get; set; }
        public int Diametro_Columna { get; set; }
        public int Diametro_Cervical { get; set; }
        public int Diametro_Dorsal { get; set; }
        public int Diametro_Lumbar { get; set; }

        //Deteccion Cifosis Lordosis
        public int Angulo_Cervical_Central_Superior { get; set; }
        public int Angulo_Cervical_Central_Inferior { get; set; }
        public int Angulo_Dorsal_Central_Superior { get; set; }
        public int Angulo_Dorsal_Central_Inferior { get; set; }
        public int Angulo_Lumbar_Central_Superior { get; set; }
        public int Angulo_Lumbar_Central_Inferior { get; set; }

        //Deteccion Escoliosis
        public int Angulo_Cervical_Central_Superior2 { get; set; }
        public int Angulo_Cervical_Central_Inferior2 { get; set; }
        public int Angulo_Dorsal_Central_Superior2 { get; set; }
        public int Angulo_Dorsal_Central_Inferior2 { get; set; }
        public int Angulo_Lumbar_Central_Superior2 { get; set; }
        public int Angulo_Lumbar_Central_Inferior2 { get; set; }

        //Diagnostico
        public Boolean Diag_Lordosis_Cervical { get; set; }
        public Boolean Diag_Cifosis_Dorsal { get; set; }
        public Boolean Diag_Lordosis_Lumbar { get; set; }
        public Boolean Diag_Escoliosis_Cervical { get; set; }
        public Boolean Diag_Escoliosis_Dorsal { get; set; }
        public Boolean Diag_Escoliosis_Lumbar { get; set; }
    }
}
