using VisitasExternas.ViewModels;

namespace VisitasExternas.Pages;

public partial class HistoricoPage : ContentPage
{
    private readonly HistoricoViewModel _viewModel;

    public HistoricoPage(HistoricoViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;

        // Define o ViewModel como o contexto de dados da página,
        // permitindo que o XAML acesse suas propriedades (como a lista 'Visitas')
        BindingContext = _viewModel;
    }

    // Este método é chamado toda vez que a página aparece na tela
    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Chama o método para carregar ou atualizar a lista de visitas
        _viewModel.CarregarVisitas();
    }
}