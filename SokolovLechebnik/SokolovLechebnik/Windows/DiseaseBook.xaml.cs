using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
namespace SokolovLechebnik.Windows
{
    public partial class DiseaseBook : Window
    {
        private bool isLight = true;
        private bool isClick = true;
        private string selectedColumn = "diseases_name"; // Колонка по умолчанию для сортировки
        private bool sortAscending = true; // Порядок сортировки (по возрастанию)
        public DiseaseBook()
        {
            InitializeComponent();
            LoadData(); // Загрузка данных при запуске окна
            SetupComboBox(); // Настройка ComboBox для выбора колонок
        }
        private void ButtonExit_Click(object sender, RoutedEventArgs e) => Close();
        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPopup.IsOpen = !MenuPopup.IsOpen;
            ToggleButtonImage(ButtonMenu, isClick ? "pack://application:,,,/Resources/LechebnikLogoMainX.png" : "pack://application:,,,/Resources/LechebnikLogoMain.png");
            isClick = !isClick;
        }
        private void ButtonOnOff_Click(object sender, RoutedEventArgs e)
        {
            ToggleTheme(isLight);
            ToggleButtonImage(ButtonOnOff, isLight ? "pack://application:,,,/Resources/dark_mode.png" : "pack://application:,,,/Resources/light_mode.png");
            isLight = !isLight;
        }
        private void ToggleTheme(bool isLightTheme)
        {
            GridMain.Background = new SolidColorBrush(Color.FromRgb(isLightTheme ? (byte)175 : (byte)25, isLightTheme ? (byte)175 : (byte)25, isLightTheme ? (byte)175 : (byte)25));
        }
        private void ToggleButtonImage(Button button, string imageUri)
        {
            button.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(imageUri)),
                Stretch = Stretch.Uniform
            };
        }
        private void OpenWindowAndCloseCurrent<T>() where T : Window, new()
        {
            new T().Show();
            Close();
        }
        private void ButtonMain_Click(object sender, RoutedEventArgs e) => OpenWindowAndCloseCurrent<Main>();
        private void ButtonProfile_Click(object sender, RoutedEventArgs e) => OpenWindowAndCloseCurrent<Profile>();
        private void ButtonCatalog_Click(object sender, RoutedEventArgs e) => OpenWindowAndCloseCurrent<Catalog>();
        private void ButtonBasket_Click(object sender, RoutedEventArgs e) => OpenWindowAndCloseCurrent<Basket>();
        private void ButtonAbout_Click(object sender, RoutedEventArgs e) => OpenWindowAndCloseCurrent<About>();

        private void LoadData()
        {
            string connectionString = "Server=SPECTRAPRIME;Database=LECHEBNIK;Integrated Security=True;";
            string query = "SELECT diseases_name, symptoms, cure FROM dbo.Diseases_book";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    dataAdapter.Fill(dataTable);

                    // Переименование колонок
                    dataTable.Columns["diseases_name"].ColumnName = "Название болезни";
                    dataTable.Columns["symptoms"].ColumnName = "Симптомы";
                    dataTable.Columns["cure"].ColumnName = "Лечение";

                    dataGrid.ItemsSource = dataTable.DefaultView;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}");
                }
            }
        }
        private Dictionary<string, string> columnMap = new Dictionary<string, string>
        {
            { "Название болезни", "diseases_name" },
            { "Симптомы", "symptoms" },
            { "Лечение", "cure" }
        };
        private void SetupComboBox()
        {
            // Заполнение ComboBox русскоязычными названиями колонок
            comboBoxColumns.Items.Add("Название болезни");
            comboBoxColumns.Items.Add("Симптомы");
            comboBoxColumns.Items.Add("Лечение");

            // Установка колонки по умолчанию
            comboBoxColumns.SelectedItem = "Название болезни";
        }

        private void ComboBoxColumns_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxColumns.SelectedItem != null)
            {
                selectedColumn = comboBoxColumns.SelectedItem.ToString();
            }
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            sortAscending = checkBoxAscending.IsChecked == true;
            SortData();
        }

        private void SortData()
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);

            if (dataView != null)
            {
                dataView.SortDescriptions.Clear();
                dataView.SortDescriptions.Add(new SortDescription(selectedColumn, sortAscending ? ListSortDirection.Ascending : ListSortDirection.Descending));
            }
        }
    }
}
