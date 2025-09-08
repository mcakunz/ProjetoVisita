using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitasExternas.Services
{
    public class DatabaseService
    {
        private SQLiteConnection _database;
        private readonly string _dbPath;

        public DatabaseService()
        {
            _dbPath = Path.Combine(FileSystem.AppDataDirectory, "visitas.db3");
            _database = new SQLiteConnection(_dbPath);
            _database.CreateTable<Models.Visita>();
        }


        public int SalvarVisita(Models.Visita visita)
        {
            return _database.Insert(visita);
        }
        
        public List<Models.Visita> ObterTodasVisitas()
        {
            return _database.Table<Models.Visita>().ToList();
        }

        public List<Models.Visita> ObterVisitaPorId(int id)
        {
            return _database.Table<Models.Visita>().Where(v => v.Id == id).ToList();
        }

        public int AtualizarVisita(Models.Visita visita)
        {
            return _database.Update(visita);
        }

        public int DeletarVisita(Models.Visita visita)
        {
            return _database.Delete(visita);
        }

        public void FecharConexao()
        {
            _database.Close();
        }
    }
}
