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
    public partial class DiseaseBook : Window
    {
        private bool isLight = true;
        private bool isClick = true;
        public DiseaseBook()
        {
            InitializeComponent();
        }
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        { this.Close(); }
        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPopup.IsOpen = !MenuPopup.IsOpen; // Переключение состояния Popup
            if (isClick)
            {
                ButtonMenu.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/LechebnikLogoMainX.png")),
                    Stretch = Stretch.Uniform
                };
            }
            else
            {
                ButtonMenu.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/LechebnikLogoMain.png")),
                    Stretch = Stretch.Uniform
                };
            }
            isClick = !isClick;
        }
        private void ButtonOnOff_Click(object sender, RoutedEventArgs e)
        {
            if (isLight)
            {
                // Устанавливаем темный цвет RGB
                GridMain.Background = new SolidColorBrush(Color.FromRgb(25, 25, 25)); // Темно-серый
                ButtonOnOff.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/light_mode.png"))
                };
            }
            else
            {
                // Устанавливаем светлый цвет RGB
                GridMain.Background = new SolidColorBrush(Color.FromRgb(175, 175, 175)); // Светло-серый
                ButtonOnOff.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/dark_mode.png"))
                };
            }
            isLight = !isLight;
        }
        private void ButtonProfile_Click(object sender, RoutedEventArgs e)
        {
            var myForm = new Profile();
            myForm.Show();
            this.Close();
        }
        private void ButtonCatalog_Click(object sender, RoutedEventArgs e)
        {
            var myForm = new Catalog();
            myForm.Show();
            this.Close();
        }
        private void ButtonBasket_Click(object sender, RoutedEventArgs e)
        {
            var myForm = new Basket();
            myForm.Show();
            this.Close();
        }
        private void ButtonMain_Click(object sender, RoutedEventArgs e)
        {
            var myForm = new Main();
            myForm.Show();
            this.Close();
        }
        private void ButtonPotion_Click(object sender, RoutedEventArgs e)
        {
            var myForm = new PotionBook();
            myForm.Show();
            this.Close();
        }
        private void ButtonSpell_Click(object sender, RoutedEventArgs e)
        {
            var myForm = new SpellBook();
            myForm.Show();
            this.Close();
        }
        private void ButtonAbout_Click(object sender, RoutedEventArgs e)
        {
            var myForm = new About();
            myForm.Show();
            this.Close();
        }
    }
}
