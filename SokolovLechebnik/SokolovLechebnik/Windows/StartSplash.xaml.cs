using System.Threading.Tasks;
using System.Windows;
namespace SokolovLechebnik.Windows
{
    public partial class StartSplash : Window
    {
        public StartSplash()
        {
            InitializeComponent();
            Loaded += StartSplash_Loaded;
        }
        private async void StartSplash_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(3000); // Эмулируем загрузку
            var mainAppWindow = new Registration();
            mainAppWindow.Show();
            this.Close();
        }
    }
}
