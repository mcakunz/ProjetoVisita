using Microsoft.Extensions.Logging;
using VisitasExternas.Pages; // Adicionar using para Pages
using VisitasExternas.Services; // Adicionar using para Services
using VisitasExternas.Repositories; // Adicionar using para Repositories
using VisitasExternas.ViewModels; // Adicionar using para ViewModels
//teste maroto
namespace VisitasExternas
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            // --- INÍCIO DAS MODIFICAÇÕES ---

            // Registrando seus serviços e repositórios como Singleton 
            // (haverá apenas uma instância deles em todo o app)
            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddSingleton<VisitaRepository>();
            builder.Services.AddSingleton<VisitaService>();

            // Registrando a página de registro principal e a nova página de histórico
            builder.Services.AddSingleton<MainPage>(); // Se sua MainPage tiver dependências
            builder.Services.AddTransient<HistoricoPage>(); // Transient: cria uma nova instância toda vez que é solicitada

            // Registrando o novo ViewModel
            builder.Services.AddTransient<HistoricoViewModel>();

            // --- FIM DAS MODIFICAÇÕES ---

            return builder.Build();
        }
    }
}