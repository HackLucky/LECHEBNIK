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
using System.Windows.Input;
namespace SokolovLechebnik.Windows
{
    public partial class DiseaseBook : Window
    {
        private bool isLight = true;
        private bool isClick = true;
        private readonly string initialText = "Вы находитесь в книге болезней, где можно посмотреть...белезни)\nТакже здесь указаны их симптомы и способы лечения)\nПод таблицей имеются кнопки для сортировки данных в колонках по алфавиту и против.\n\nПервая кнопка выбирает колонку, в которой будет выполняться сортировка.\nВторая кнопка выбирает сортировку по алфавиту или против.\nТретья кнопка запускает сортировку)\n\nЕсли нужно найти конкретную болезнь, симптом или способ лечения, то воспользуйтесь текстовым полем подо мной)";
        private string selectedColumn = "diseases_name";
        private bool sortAscending = true;
        public DiseaseBook()
        {
            InitializeComponent();
            LoadData("");
            TextBlockAvatar.Text = initialText;
            SetupComboBox();
            TextBoxForAvatar.KeyDown += TextBoxForAvatar_KeyDown;
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
            ToggleTheme(!isLight);
            ToggleButtonImage(ButtonOnOff, isLight ? "pack://application:,,,/Resources/light_mode.png" : "pack://application:,,,/Resources/dark_mode.png");
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
        private void TextBoxForAvatar_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле можете ввести название болезни или симптом или способ лечения;)\n\nВведя в поле ваш запрос, нажмите клавишу [Enter] или кнопку СКАЗАТЬ рядом с текстовым полем)";
        }
        private void TextBoxForAvatar_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText;
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
        private void ButtonOrders_Click(object sender, RoutedEventArgs e) => OpenWindowAndCloseCurrent<Orders>();
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
            comboBoxColumns.Items.Add("Название болезни");
            comboBoxColumns.Items.Add("Симптомы");
            comboBoxColumns.Items.Add("Лечение");
            comboBoxColumns.SelectedItem = "Название болезни";
        }
        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = TextBoxForAvatar.Text.Trim();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                LoadData(searchTerm);
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите то, что хотите спросить у Лечи, например, болезнь, симптом или лечение.");
            }
        }
        private void TextBoxForAvatar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Получаем текст из TextBoxForAvatar
                string searchTerm = TextBoxForAvatar.Text.Trim();
                LoadData(searchTerm); // Загружаем данные с учетом фильтра
            }
        }
        private void LoadData(string searchTerm)
        {
            string connectionString = "Server=SPECTRAPRIME;Database=LECHEBNIK;Integrated Security=True;";
            string query = "SELECT diseases_name, symptoms, cure FROM dbo.Diseases_book WHERE diseases_name LIKE @searchTerm OR symptoms LIKE @searchTerm OR cure LIKE @searchTerm";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                DataTable dataTable = new DataTable();
                try
                {
                    dataAdapter.Fill(dataTable);
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
