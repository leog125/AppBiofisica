﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppBiofisica.Modelos;

namespace AppBiofisica.Clases
{
    public class Historial
    {
        public string  CrearHistorial(Medidas medida) 
        {
            var paciente = App.Database.BuscarPacienteHistorial(medida.Id_Paciente_Medida).Result;
            string textHistorial = "Historial Nº " + medida.Id_Medida;
            textHistorial += Environment.NewLine;
            textHistorial += "Paciente: " + paciente.Nombre + " " + paciente.Apellido;
            textHistorial += Environment.NewLine;
            textHistorial += "Documento: " + paciente.NumeroDocumento + Environment.NewLine;
            textHistorial += "-------------------------------------------------------" + Environment.NewLine;
            textHistorial += "Dimetros Columna" + Environment.NewLine;
            textHistorial += "Columna vertebral: " + medida.Diametro_Columna + Environment.NewLine;
            textHistorial += "Diametro Cervical: " + medida.Diametro_Cervical + Environment.NewLine;
            textHistorial += "Diametro Dorsal: " + medida.Diametro_Dorsal + Environment.NewLine;
            textHistorial += "Diametro Lumbar: " + medida.Diametro_Lumbar + Environment.NewLine;
            textHistorial += "-------------------------------------------------------" + Environment.NewLine;
            textHistorial += "Deteccion de cifosis y lordosis" + Environment.NewLine;
            textHistorial += "Angulos Zona Cervical" + Environment.NewLine;
            textHistorial += "Superior: " + medida.Angulo_Cervical_Central_Superior + Environment.NewLine;
            textHistorial += "Inferior: " + medida.Angulo_Cervical_Central_Inferior + Environment.NewLine;
            textHistorial += "Angulos Zona Dorsal" + Environment.NewLine;
            textHistorial += "Superior: " + medida.Angulo_Dorsal_Central_Superior + Environment.NewLine;
            textHistorial += "Inferior: " + medida.Angulo_Dorsal_Central_Inferior + Environment.NewLine;
            textHistorial += "Angulos Zona Lumbar" + Environment.NewLine;
            textHistorial += "Superior: " + medida.Angulo_Lumbar_Central_Superior + Environment.NewLine;
            textHistorial += "Inferior: " + medida.Angulo_Lumbar_Central_Inferior + Environment.NewLine;
            textHistorial += "-------------------------------------------------------" + Environment.NewLine;
            textHistorial += "Deteccion Escoliosis" + Environment.NewLine;
            textHistorial += "Angulos Zona Cervical" + Environment.NewLine;
            textHistorial += "Superior: " + medida.Angulo_Cervical_Central_Superior2 + Environment.NewLine;
            textHistorial += "Inferior: " + medida.Angulo_Cervical_Central_Inferior2 + Environment.NewLine;
            textHistorial += "Angulos Zona Dorsal" + Environment.NewLine;
            textHistorial += "Superior: " + medida.Angulo_Dorsal_Central_Superior2 + Environment.NewLine;
            textHistorial += "Inferior: " + medida.Angulo_Dorsal_Central_Inferior2 + Environment.NewLine;
            textHistorial += "Angulos Zona Lumbar" + Environment.NewLine;
            textHistorial += "Superior: " + medida.Angulo_Lumbar_Central_Superior2 + Environment.NewLine;
            textHistorial += "Inferior: " + medida.Angulo_Lumbar_Central_Inferior2 + Environment.NewLine;
            textHistorial += "-------------------------------------------------------" + Environment.NewLine;
            textHistorial += "Diagnostico" + Environment.NewLine;
            if (medida.Diag_Lordosis_Cervical) textHistorial += "Lordosis Cervical" + Environment.NewLine;
            if (medida.Diag_Cifosis_Dorsal) textHistorial += "Cifosis Dorsal"+Environment.NewLine;
            if (medida.Diag_Lordosis_Lumbar) textHistorial += "Lordosis Lumbar" + Environment.NewLine;
            if (medida.Diag_Escoliosis_Cervical) textHistorial += "Escoliosis Cervical" + Environment.NewLine;
            if (medida.Diag_Escoliosis_Dorsal) textHistorial += "Escoliosis Dorsal" + Environment.NewLine;
            if (medida.Diag_Escoliosis_Lumbar) textHistorial += "Escoliosis Lumbar" + Environment.NewLine;
            if(!medida.Diag_Lordosis_Cervical && !medida.Diag_Cifosis_Dorsal && !medida.Diag_Lordosis_Lumbar && !medida.Diag_Escoliosis_Cervical  && !medida.Diag_Escoliosis_Dorsal && !medida.Diag_Escoliosis_Lumbar) textHistorial += "Sin deformaciones en la columna vertebral" + Environment.NewLine;
            //textHistorial += "En proceso :)";
            return textHistorial;
                
        }
    }
}
