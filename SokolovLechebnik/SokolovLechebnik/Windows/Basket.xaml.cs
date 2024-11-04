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
        private readonly string initialText = "Вы находитесь в каталоге препаратов, где можно посмотреть товары;)\nУ каждого товара имеется назначение при определённой болезни, симптомах, тип приема, тип препарата, тип агрегатного состояния и стоимость)\nЕсли хотите найти конкретный препарат по названию, симптому, цене и так далее, то введите в текстовое поле подо мной;)";
        private int currentUserId;
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

        // Обработчик нажатия на OrderButton
        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)dataGrid.SelectedItem;
                int idMedicine = Convert.ToInt32(selectedRow["id_medicine"]);
                string productsName = selectedRow["products_name"].ToString();
                decimal cost = Convert.ToDecimal(selectedRow["cost"]);

                // Получаем количество товара из таблицы Carts (предполагаем, что это значение есть)
                int quantityInCart = GetQuantityFromCart(idMedicine);

                // Открываем окно для ввода количества, указываем количество из корзины по умолчанию
                string inputQuantity = Microsoft.VisualBasic.Interaction.InputBox("Введите количество для заказа:", "Заказать товар", quantityInCart.ToString());

                // Проверяем, что введено корректное количество
                if (int.TryParse(inputQuantity, out int quantity) && quantity > 0)
                {
                    // Добавляем заказ в таблицу Orders
                    AddToOrders(idMedicine, quantity);
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректное количество.");
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для заказа.");
            }
        }

        // Метод для получения количества товара в корзине
        private int GetQuantityFromCart(int idMedicine)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT quantity FROM Carts WHERE id_medicine = @idMedicine";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idMedicine", idMedicine);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при получении количества: " + ex.Message);
                    }
                }
            }

            // Если количество не найдено, возвращаем 1 по умолчанию
            return 1;
        }

        // Метод для добавления данных в таблицу Orders
        private void AddToOrders(int idMedicine, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string insertQuery = @"INSERT INTO Orders (id_customer, id_medicine, quantity, order_date, final_price, id_method) VALUES (@idCustomer, @idMedicine, @quantity, @orderDate, @finalPrice, @idMethod)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Пример id_customer (авторизованного пользователя), нужно заменить на реальный идентификатор пользователя
                        command.Parameters.AddWithValue("@idCustomer", currentUserId);
                        command.Parameters.AddWithValue("@idMedicine", idMedicine);
                        command.Parameters.AddWithValue("@quantity", quantity);
                        command.Parameters.AddWithValue("@orderDate", DateTime.Now);
                        command.Parameters.AddWithValue("@finalPrice", GetFinalPrice(idMedicine, quantity));
                        command.Parameters.AddWithValue("@idMethod", GetPaymentMethodId());

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Заказ успешно оформлен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при оформлении заказа: " + ex.Message);
                }
            }
        }

        // Метод для расчета общей стоимости
        private decimal GetFinalPrice(int idMedicine, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT cost FROM Products WHERE id_medicine = @idMedicine";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idMedicine", idMedicine);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            decimal cost = Convert.ToDecimal(result);
                            return cost * quantity;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при получении стоимости: " + ex.Message);
                    }
                }
            }
            return 0;
        }

        // Метод для получения id метода оплаты (например, по умолчанию, первый метод)
        private int GetPaymentMethodId()
        {
            return 1; // Используйте реальную логику для выбора метода оплаты
        }

        // Обработчик нажатия на DelButton
        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                // Подтверждение удаления
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить этот товар из корзины?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    DataRowView selectedRow = (DataRowView)dataGrid.SelectedItem;
                    int idMedicine = Convert.ToInt32(selectedRow["id_medicine"]);

                    DeleteFromCart(idMedicine);
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления.");
            }
        }

        // Метод для удаления товара из таблицы Carts
        private void DeleteFromCart(int idMedicine)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM Carts WHERE id_medicine = @idMedicine";
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@idMedicine", idMedicine);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Товар успешно удалён из корзины.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении товара из корзины: " + ex.Message);
                }
            }
        }
        private void LoadData(string searchTerm)
        {

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

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
