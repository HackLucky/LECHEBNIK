using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;
namespace SokolovLechebnik.Windows
{
    public partial class Basket : Window
    {
        private string connectionString = "Server=SPECTRAPRIME;Database=LECHEBNIK;Integrated Security=True;";
        private readonly string initialText = "Вы находитесь в корзине, где можно посмотреть товары, отложенные для заказа;)\nМожете нажать кнопку ЗАКАЗАТЬ для покупки препарата, ИЗМЕНИТЬ КОЛ для изменения количества выбранного товара или УДАЛИТЬ для удаления товара из списка\nЕсли хотите найти конкретный препарат по названию, симптому, цене и так далее, то введите в текстовое поле подо мной;)";
        private bool isLight = true;
        private bool isClick = true;
        public Basket()
        {
            InitializeComponent();
            TextBlockAvatar.Text = initialText; // Устанавливает начальный текст для TextBlock аватара.
            TextBoxForAvatar.KeyDown += TextBoxForAvatar_KeyDown; // Добавляет обработчик события для ввода текста.
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
        private void OpenWindowAndCloseCurrent<T>() where T : Window, new()
        {
            new T().Show();
            Close();
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
        private void ButtonMain_Click(object sender, RoutedEventArgs e) => OpenWindowAndCloseCurrent<Main>();
        private void ButtonProfile_Click(object sender, RoutedEventArgs e) => OpenWindowAndCloseCurrent<Profile>();
        private void ButtonCatalog_Click(object sender, RoutedEventArgs e) => OpenWindowAndCloseCurrent<Catalog>();
        private void ButtonOrders_Click(object sender, RoutedEventArgs e) => OpenWindowAndCloseCurrent<Orders>();
        private void ButtonDisease_Click(object sender, RoutedEventArgs e) => OpenWindowAndCloseCurrent<DiseaseBook>();
        private void ButtonAbout_Click(object sender, RoutedEventArgs e) => OpenWindowAndCloseCurrent<About>();

        private void LoadData(string searchTerm)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Исправленный SQL-запрос
                    string query = @"
                    SELECT 
                        c.id_cart AS 'ID отложенного', 
                        p.products_name AS 'Название препарата', 
                        p.cost AS 'Цена за единицу', 
                        c.quantity AS 'Количество', 
                        (p.cost * c.quantity) AS 'Конечная стоимость'
                    FROM Carts c
                    INNER JOIN Products p ON c.id_medicine = p.id_medicine
                    WHERE c.id_customer = @id_customer";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id_customer", Login.currentUserId);
                        command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                        // Отладочное сообщение для проверки параметров
                        MessageBox.Show($"Идентификатор клиента: {Login.currentUserId}, Поисковый запрос: {searchTerm}");

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Привязка данных к DataGrid
                        dataGrid.ItemsSource = dataTable.DefaultView;
                        dataGrid.Items.Refresh();

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Нет данных для отображения.");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Ошибка SQL: {ex.Message}");
                }
            }
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

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
