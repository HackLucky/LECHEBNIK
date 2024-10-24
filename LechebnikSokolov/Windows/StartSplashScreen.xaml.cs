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

namespace LechebnikSokolov
{
    /// <summary>
    /// Логика взаимодействия для StartSplashScreen.xaml
    /// </summary>
    public partial class StartSplashScreen : Window
    {
        public StartSplashScreen()
        {
            InitializeComponent();
            Loaded += StartSplashScreen_Loaded;
        }

        private async void StartSplashScreen_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(3000); // Эмулируем загрузку
            var mainAppWindow = new RegisterWindow();
            mainAppWindow.Show();
            this.Close();
        }
    }
}
