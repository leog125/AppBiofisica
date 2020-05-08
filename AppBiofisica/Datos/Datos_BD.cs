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
        }

        public Task<int> GuardarPaciente(Paciente paciente)
        {
            return _database.InsertAsync(paciente);
        }

    }
}
