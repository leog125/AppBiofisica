using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using AppBiofisica.Modelos;
using System.Threading.Tasks;

namespace AppBiofisica.Datos
{
    public class Datos_BD
    {
        readonly SQLiteAsyncConnection _database;

        public Datos_BD(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Paciente>().Wait();
            _database.CreateTableAsync<Medidas>().Wait();
        }

        public Task<int> GuardarPaciente(Paciente paciente)
        {
            return _database.InsertAsync(paciente);
        }

        public Task<Medidas> GuardarMedicion(Medidas medida)
        {
            _database.InsertAsync(medida);
            return _database.Table<Medidas>().OrderByDescending(i => i.Id_Medida).FirstOrDefaultAsync();
        }

        public Task<Medidas> BuscarHistorial(int idmedida)
        {
            return _database.Table<Medidas>().Where(i => i.Id_Medida == idmedida).FirstOrDefaultAsync();
        }

        public Task<Paciente> BuscarPaciente(int DocumentoPaciente) 
        {
            return _database.Table<Paciente>().Where(i => i.NumeroDocumento == DocumentoPaciente).FirstOrDefaultAsync();
        }

    }
}
