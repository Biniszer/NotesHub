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
        private const string ConnectionstringKey = "postgres";
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var configuration = new ConfigurationBuilder()
                //.SetBasePath(Directory.GetCurrentDirectory())
                //.AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
                .Build();

            //var serviceProvider = new ServiceCollection()
            //    .AddDbContext<NotesHubContext>(options =>
            //        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")))
            //    .BuildServiceProvider();
            
        
            //var mainWindow = serviceProvider.GetRequiredService<LoginWindow>();
            //mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            var configuration = NotesHubContext.ReadConfiguration();
            var connectionString = configuration.ConnectionString[ConnectionstringKey];
            // Konfiguracja kontekstu bazy danych
            services.AddDbContext<NotesHubContext>(options =>
                options.UseSqlServer(connectionString));
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




