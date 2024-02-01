using NotesHub.Entities;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NotesHub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ConnectionstringKey = "postgres";
        public MainWindow()
        {
            InitializeComponent();

            var configuration = NotesHubContext.ReadConfiguration();
            var connectionString = configuration.ConnectionString[ConnectionstringKey];
            IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString);
        }

        private void LoginField(object sender, TextChangedEventArgs e)
        {

        }

        private void RegisterData(object sender, TextChangedEventArgs e)
        {

        }

        private void RegisterPasswordValidation(object sender, TextChangedEventArgs e)
        {

        }
        private void PasswordValidation(object sender, TextChangedEventArgs e)
        {
            
        }

        private void RegisterButton(object sender, RoutedEventArgs e)
        {

        }

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            
        }
    }
}