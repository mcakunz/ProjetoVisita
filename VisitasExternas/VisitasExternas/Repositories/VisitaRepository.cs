using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitasExternas.Services;
using VisitasExternas.Models;


// return resultado > 0;
//Quando você faz um Insert, Update ou Delete usando o SQLite-net (a lib que você está usando), esses métodos (Insert, Update, Delete) retornam um int.

//Esse int representa quantas linhas da tabela foram afetadas pela operação.

//Então:

//Se deu certo → o valor será 1 (uma linha foi inserida/atualizada/deletada).

//Se deu errado → o valor será 0 (nenhuma linha foi afetada).
namespace VisitasExternas.Repositories
{
    public class VisitaRepository
    {
        private DatabaseService _databaseService;

        public VisitaRepository()
        {
            _databaseService = new DatabaseService();
        }

        
        public bool RegistrarVisita(string nomeCliente, double latitude, double longitude)
        {
            try
            {
                var visita = new Visita
                {
                    NomeCliente = nomeCliente,
                    Latitude = latitude,
                    Longitude = longitude,
                    DataVisita = DateTime.Now
                };

                var resultado = _databaseService.SalvarVisita(visita);
                return resultado > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<Visita> ObterTodasVisitas()
        {
            return _databaseService.ObterTodasVisitas();
        }

        public Visita ObterUltimaVisita()
        {
            try
            {
                var visitas = _databaseService.ObterTodasVisitas();
                return visitas.OrderByDescending(v => v.DataVisita).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public Visita ObterVisitaPorId(int id)
        {
            try
            {
                return _databaseService.ObterVisitaPorId(id).FirstOrDefault();
            }
            catch
            {
                return null;
            }

        }

        public bool AtualizarVisita(Visita visita)
        {
            try
            {
                var resultado = _databaseService.AtualizarVisita(visita);
                return resultado > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletarVisita(Visita visita)
        {
            try
            {
                var resultado = _databaseService.DeletarVisita(visita);
                return resultado > 0;
            }
            catch
            {
                return false;
            }
        }


    }
}
