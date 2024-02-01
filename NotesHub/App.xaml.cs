using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotesHub.Entities;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace NotesHub
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IConfiguration configuration = new ConfigurationBuilder()
                .AddConfiguration((IConfiguration)NotesHubContext.ReadConfiguration())
                .Build();

            var serviceProvider = new ServiceCollection()
                .AddDbContext<NotesHubContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")))
                .BuildServiceProvider();

            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }




    /* private const string ConnectionstringKey = "postgres";
     private void ConfigureServices(IServiceCollection services)
     {
         var configuration = NotesHubContext.ReadConfiguration();
         var connectionString = configuration.ConnectionString[ConnectionstringKey];
         // Konfiguracja kontekstu bazy danych
         services.AddDbContext<NotesHubContext>(options =>
             options.UseSqlServer(connectionString));

         // Dodaj inne usługi, jeśli są potrzebne
         services.AddTransient<MainWindow>(); // Przykład dla głównego okna */
}




