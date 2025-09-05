using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitasExternas.Models;
using VisitasExternas.Repositories;

namespace VisitasExternas.Services
{
    public class VisitaService
    {
        private VisitaRepository _visitaRepository;

        public VisitaService()
        {
            _visitaRepository = new VisitaRepository();
        }

        public async Task<bool> ProcessarNovaVisita(string nomeCliente, double latitude, double longitude)
        {

            var sucesso = _visitaRepository.RegistrarVisita(nomeCliente, latitude, longitude);

            if(sucesso)
            {
                // integraçao com sms pessoa 3
                var ultimaVisita = _visitaRepository.ObterUltimaVisita;
                return ultimaVisita != null;
            }

            return false;
        }
        public List<Visita> ObterHistoricoVisitas()
        {
            return _visitaRepository.ObterTodasVisitas();
        }

        public string FormatarDadosParaSMS(Visita visita)
        {
            if (visita == null)
                return string.Empty;
            return $"Visita Registrada:\nCliente: {visita.NomeCliente}\nLocalização: ({visita.Latitude}, {visita.Longitude})\nData: {visita.DataVisita}";
        }
    }
}
