using VisitasExternas.Services;

namespace VisitasExternas
{
    public partial class MainPage : ContentPage
    {

        private IGeolocation _geolocation;
        private VisitaService _visitaService;
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public MainPage()   
        {
            InitializeComponent();
            _geolocation = Geolocation.Default;
            _visitaService = new VisitaService();
        }

        private async void OnRegistrarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ClienteEntry.Text))
            {
                StatusLabel.Text = "Digite o nome do cliente";
                StatusLabel.TextColor = Colors.Red;
                return;
            }

            StatusLabel.Text = "Obtendo localização...";
            StatusLabel.TextColor = Colors.Blue;

            try
            {
                var location = await GetCurrentLocation();

                if (location != null)
                {
                    Latitude = location.Latitude;
                    Longitude = location.Longitude;

                    LocationLabel.Text = $"Lat: {Latitude:F6}, Lon: {Longitude:F6}";

                    var sucesso = await _visitaService.ProcessarNovaVisita(ClienteEntry.Text, Latitude, Longitude);

                    if (sucesso)
                    {
                        StatusLabel.Text = $"Visita salva no banco para {ClienteEntry.Text}";
                        StatusLabel.TextColor = Colors.Green;
                        ClienteEntry.Text = "";
                    }
                    else
                    {
                        StatusLabel.Text = "Erro ao salvar no banco";
                        StatusLabel.TextColor = Colors.Red;
                    }
                }
                else
                {
                    StatusLabel.Text = "Não foi possível obter a localização";
                    StatusLabel.TextColor = Colors.Red;
                }
            }
            catch (Exception ex)
            {
                StatusLabel.Text = $"Erro: {ex.Message}";
                StatusLabel.TextColor = Colors.Red;
            }
        }

        private async Task<Location?> GetCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(10)
                };

                var location = await _geolocation.GetLocationAsync(request);
                return location;
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
