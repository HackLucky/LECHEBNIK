using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SokolovLechebnik.Windows
{
    /// <summary>
    /// Логика взаимодействия для StartSplash.xaml
    /// </summary>
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
