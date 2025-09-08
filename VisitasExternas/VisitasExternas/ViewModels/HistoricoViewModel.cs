using System.Collections.ObjectModel;
using VisitasExternas.Models;
using VisitasExternas.Services;

namespace VisitasExternas.ViewModels
{
    public class HistoricoViewModel
    {
        // Uma coleção especial que notifica a tela quando itens são adicionados ou removidos.
        public ObservableCollection<Visita> Visitas { get; set; } = new ObservableCollection<Visita>();

        private readonly VisitaService _visitaService;

        // O VisitaService será injetado aqui automaticamente (configuraremos isso no Passo 5)
        public HistoricoViewModel(VisitaService visitaService)
        {
            _visitaService = visitaService;
        }

        // Método para carregar as visitas do banco de dados
        public void CarregarVisitas()
        {
            Visitas.Clear(); // Limpa a lista antes de carregar para evitar duplicatas

            var visitasDoBanco = _visitaService.ObterHistoricoVisitas();

            // Adiciona as visitas na coleção que está ligada à tela
            foreach (var visita in visitasDoBanco)
            {
                Visitas.Add(visita);
            }
        }
    }
}