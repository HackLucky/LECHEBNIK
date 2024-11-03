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
    // Класс Catalog представляет собой окно WPF, которое отображает каталог товаров.
    public partial class Catalog : Window
    {
        // Переменная для отслеживания текущего состояния темы (true - светлая, false - темная).
        private bool isLight = true;

        // Переменная для отслеживания состояния кнопки меню (true, если кликнута, false в противном случае).
        private bool isClick = true;

        // Начальный текст приветствия для аватара, отображающий подсказку по использованию каталога.
        private readonly string initialText = "Вы находитесь в каталоге препаратов, где можно посмотреть товары;)\nУ каждого товара имеется назначение при определённой болезни, симптомах, тип приема, тип препарата, тип агрегатного состояния и стоимость)\nЕсли хотите найти конкретный препарат по названию, симптому, цене и так далее, то введите в текстовое поле подо мной;)";

        // Выбранный столбец для сортировки данных в DataGrid.
        private string selectedColumn = "products_name";

        // Переменная для отслеживания порядка сортировки (true - по возрастанию, false - по убыванию).
        private bool sortAscending = true;

        // Конструктор для инициализации окна, загрузки данных, настройки ComboBox и добавления обработчиков событий.
        public Catalog()
        {
            InitializeComponent(); // Инициализирует все UI-компоненты.
            LoadData(""); // Загружает данные без фильтрации.
            SetupComboBox(); // Настраивает элементы ComboBox для выбора столбца.
            TextBlockAvatar.Text = initialText; // Устанавливает начальный текст для TextBlock аватара.
            TextBoxForAvatar.KeyDown += TextBoxForAvatar_KeyDown; // Добавляет обработчик события для ввода текста.
        }

        // Обработчик события для кнопки выхода, закрывающий текущее окно.
        private void ButtonExit_Click(object sender, RoutedEventArgs e) => Close();

        // Обработчик события для кнопки главного меню, открывающий и закрывающий всплывающее меню.
        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPopup.IsOpen = !MenuPopup.IsOpen; // Переключает состояние отображения всплывающего меню.
            ToggleButtonImage(ButtonMenu, isClick ? "pack://application:,,,/Resources/LechebnikLogoMainX.png" : "pack://application:,,,/Resources/LechebnikLogoMain.png"); // Переключает изображение кнопки меню.
            isClick = !isClick; // Изменяет состояние клика.
        }

        // Обработчик события для кнопки переключения темы (светлая/темная).
        private void ButtonOnOff_Click(object sender, RoutedEventArgs e)
        {
            ToggleTheme(!isLight); // Переключает тему.
            ToggleButtonImage(ButtonOnOff, isLight ? "pack://application:,,,/Resources/light_mode.png" : "pack://application:,,,/Resources/dark_mode.png"); // Переключает изображение кнопки для текущей темы.
            isLight = !isLight; // Изменяет состояние темы.
        }

        // Метод переключения темы, изменяющий цвет фона главной сетки.
        private void ToggleTheme(bool isLightTheme)
        {
            GridMain.Background = new SolidColorBrush(Color.FromRgb(isLightTheme ? (byte)175 : (byte)25, isLightTheme ? (byte)175 : (byte)25, isLightTheme ? (byte)175 : (byte)25)); // Устанавливает цвет фона.
        }

        // Метод для изменения изображения кнопки, используя указанный URI изображения.
        private void ToggleButtonImage(Button button, string imageUri)
        {
            button.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(imageUri)), // Загружает изображение из указанного URI.
                Stretch = Stretch.Uniform // Растягивает изображение, сохраняя пропорции.
            };
        }

        // Обработчик события для фокуса на TextBox, отображающий подсказку в TextBlock аватара.
        private void TextBoxForAvatar_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле можете ввести название болезни или симптом или способ лечения;)\n\nВведя в поле ваш запрос, нажмите клавишу [Enter] или кнопку СКАЗАТЬ рядом с текстовым полем)";
        }

        // Обработчик события для потери фокуса TextBox, восстанавливающий начальный текст в TextBlock аватара.
        private void TextBoxForAvatar_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText;
        }

        // Метод для открытия нового окна и закрытия текущего, параметризованный типом окна.
        private void OpenWindowAndCloseCurrent<T>() where T : Window, new()
        {
            new T().Show(); // Открывает новое окно указанного типа.
            Close(); // Закрывает текущее окно.
        }

        // Обработчики для кнопок, открывающие соответствующие окна.
        private void ButtonMain_Click(object sender, RoutedEventArgs e) => OpenWindowAndCloseCurrent<Main>();
        private void ButtonProfile_Click(object sender, RoutedEventArgs e) => OpenWindowAndCloseCurrent<Profile>();
        private void ButtonBasket_Click(object sender, RoutedEventArgs e) => OpenWindowAndCloseCurrent<Basket>();
        private void ButtonDisease_Click(object sender, RoutedEventArgs e) => OpenWindowAndCloseCurrent<Catalog>();
        private void ButtonAbout_Click(object sender, RoutedEventArgs e) => OpenWindowAndCloseCurrent<About>();

        // Метод загрузки данных из базы с использованием переданного поискового запроса.
        private void LoadData(string searchTerm)
        {
            string connectionString = "Server=SPECTRAPRIME;Database=LECHEBNIK;Integrated Security=True;"; // Строка подключения к базе данных.

            // SQL-запрос с объединением таблиц для извлечения информации о товарах и связанных данных.
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
                    Diseases_book d ON p.id_disease = d.id_disease
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

            // Подключение к базе данных и выполнение запроса.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection); // Адаптер данных для выполнения запроса.
                dataAdapter.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%"); // Добавляет параметр поиска.
                DataTable dataTable = new DataTable(); // Таблица для хранения результатов запроса.
                try
                {
                    dataAdapter.Fill(dataTable); // Заполняет таблицу результатами запроса.

                    // Переименовывает колонки для отображения в DataGrid.
                    dataTable.Columns["products_name"].ColumnName = "Название препарата";
                    dataTable.Columns["diseases_name"].ColumnName = "Название болезни";
                    dataTable.Columns["symptoms"].ColumnName = "Симптомы";
                    dataTable.Columns["taking_type"].ColumnName = "Способ применения";
                    dataTable.Columns["aggregate_state"].ColumnName = "Агрегатное состояние";
                    dataTable.Columns["products_type"].ColumnName = "Тип препарата";
                    dataTable.Columns["suppliers_name"].ColumnName = "Название поставщика";
                    dataTable.Columns["country"].ColumnName = "Страна";
                    dataTable.Columns["cost"].ColumnName = "Цена";

                    dataGrid.ItemsSource = dataTable.DefaultView; // Привязывает данные к DataGrid.
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}"); // Обработка ошибки при запросе.
                }
            }
        }

        // Метод для настройки ComboBox, добавляя возможные столбцы для сортировки.
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
            comboBoxColumns.SelectedItem = "Название препарата"; // Устанавливает начальный выбранный элемент.
        }

        // Обработчик для кнопки поиска, выполняющий поиск по введенному тексту.
        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = TextBoxForAvatar.Text.Trim(); // Извлекает и очищает текст запроса.
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                LoadData(searchTerm); // Загружает данные с учетом поискового запроса.
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите то, что хотите спросить у Лечи, например, название препарата, болезнь, симптом, способ применения, агрегатное состояние, тип препарата, название поставщика, страну изготовления или цену."); // Предупреждение об отсутствии текста.
            }
        }

        // Обработчик для нажатия клавиши Enter в TextBox, выполняющий поиск.
        private void TextBoxForAvatar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string searchTerm = TextBoxForAvatar.Text.Trim(); // Получает текст запроса.
                LoadData(searchTerm); // Выполняет поиск с указанным запросом.
            }
        }

        // Обработчик изменения выбора столбца в ComboBox.
        private void ComboBoxColumns_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxColumns.SelectedItem != null)
            {
                selectedColumn = comboBoxColumns.SelectedItem.ToString(); // Устанавливает выбранный столбец для сортировки.
            }
        }

        // Обработчик для кнопки сортировки, который применяет выбранный порядок сортировки.
        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            sortAscending = checkBoxAscending.IsChecked == true; // Устанавливает порядок сортировки.
            SortData(); // Применяет сортировку.
        }

        // Метод сортировки данных в DataGrid.
        private void SortData()
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource); // Получает представление данных.

            if (dataView != null)
            {
                dataView.SortDescriptions.Clear(); // Очищает текущие параметры сортировки.
                dataView.SortDescriptions.Add(new SortDescription(selectedColumn, sortAscending ? ListSortDirection.Ascending : ListSortDirection.Descending)); // Применяет новую сортировку.
            }
        }
    }
}