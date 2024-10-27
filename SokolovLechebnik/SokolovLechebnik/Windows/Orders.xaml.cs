using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SokolovLechebnik.Windows
{
    public partial class Orders : Window
    {
        private bool isLight = true;
        private bool isClick = true;
        private readonly string initialText = "Вы находитесь в каталоге продуктов, где можно посмотреть...\nТакже здесь указаны болезни и их симптомы...\n";
        private string selectedColumn = "products_name";
        private bool sortAscending = true;

        public Orders()
        {
            InitializeComponent();
            LoadData(""); // Загружаем данные без фильтра
            SetupComboBox();
            TextBlockAvatar.Text = initialText;
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
        private void ButtonAbout_Click(object sender, RoutedEventArgs e) => OpenWindowAndCloseCurrent<About>();

        private void LoadData(string searchTerm)
        {
            string connectionString = "Server=SPECTRAPRIME;Database=LECHEBNIK;Integrated Security=True;";
            // Запрос с объединениями таблиц
            string query = @"
                SELECT 
                    p.products_name, 
                    d.diseases_name, 
                    d.symptoms, 
                    t.taking_type, 
                    pc.aggregate_state, 
                    pt.products_type, 
                    s.suppliers_name, 
                    s.country, 
                    p.cost 
                FROM 
                    Products p
                LEFT JOIN 
                    Diseases_book d ON p.id_reason = d.id_disease
                LEFT JOIN 
                    Taking_types t ON p.id_taking = t.id_taking
                LEFT JOIN 
                    Product_conditions_type pc ON p.id_state = pc.id_state
                LEFT JOIN 
                    Products_type pt ON p.id_type = pt.id_type
                LEFT JOIN 
                    Suppliers s ON p.id_supplier = s.id_supplier
                WHERE 
                    p.products_name LIKE @searchTerm OR 
                    d.diseases_name LIKE @searchTerm OR 
                    d.symptoms LIKE @searchTerm OR 
                    t.taking_type LIKE @searchTerm OR 
                    pc.aggregate_state LIKE @searchTerm OR 
                    pt.products_type LIKE @searchTerm OR 
                    s.suppliers_name LIKE @searchTerm OR 
                    s.country LIKE @searchTerm OR 
                    p.cost LIKE @searchTerm";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                DataTable dataTable = new DataTable();
                try
                {
                    dataAdapter.Fill(dataTable);

                    // Переименование колонок
                    dataTable.Columns["products_name"].ColumnName = "Название препарата";
                    dataTable.Columns["diseases_name"].ColumnName = "Название болезни";
                    dataTable.Columns["symptoms"].ColumnName = "Симптомы";
                    dataTable.Columns["taking_type"].ColumnName = "Способ применения";
                    dataTable.Columns["aggregate_state"].ColumnName = "Агрегатное состояние";
                    dataTable.Columns["products_type"].ColumnName = "Тип препарата";
                    dataTable.Columns["suppliers_name"].ColumnName = "Название поставщика";
                    dataTable.Columns["country"].ColumnName = "Страна";
                    dataTable.Columns["cost"].ColumnName = "Цена";

                    dataGrid.ItemsSource = dataTable.DefaultView;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}");
                }
            }
        }
        private void SetupComboBox()
        {
            comboBoxColumns.Items.Add("Название препарата");
            comboBoxColumns.Items.Add("Название болезни");
            comboBoxColumns.Items.Add("Симптомы");
            comboBoxColumns.Items.Add("Способ применения");
            comboBoxColumns.Items.Add("Агрегатное состояние");
            comboBoxColumns.Items.Add("Тип препарата");
            comboBoxColumns.Items.Add("Название поставщика");
            comboBoxColumns.Items.Add("Страна");
            comboBoxColumns.Items.Add("Цена");
            comboBoxColumns.SelectedItem = "Название препарата";
        }

        // Остальные методы остаются без изменений...

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = TextBoxForAvatar.Text.Trim();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                LoadData(searchTerm);
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите то, что хотите спросить у Лечи, например, название препарата, болезнь, симптом, способ применения, агрегатное состояние, тип препарата, название поставщика, страну изготовления или цену.");
            }
        }

        private void TextBoxForAvatar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string searchTerm = TextBoxForAvatar.Text.Trim();
                LoadData(searchTerm);
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
