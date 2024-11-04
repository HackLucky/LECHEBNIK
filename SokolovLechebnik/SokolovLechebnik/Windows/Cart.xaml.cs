using System;
using System.Data.SqlClient;
using System.Windows;

namespace SokolovLechebnik.Windows
{
    public partial class Cart : Window
    {
        private readonly string connectionString = "Server=SPECTRAPRIME;Database=LECHEBNIK;Integrated Security=True;";

        // Конструктор формы
        public Cart()
        {
            InitializeComponent();
            LoadCartData(); // Загрузка данных корзины при инициализации формы
        }
        // Метод для открытия нового окна и закрытия текущего, параметризованный типом окна.
        private void OpenWindowAndCloseCurrent<T>() where T : Window, new()
        {
            new T().Show(); // Открывает новое окно указанного типа.
            Close(); // Закрывает текущее окно.
        }
        // Обработчики для кнопок, открывающие соответствующие окна.
        private void ButtonAbout_Click(object sender, RoutedEventArgs e) => OpenWindowAndCloseCurrent<Catalog>();
        // Метод для загрузки данных корзины для текущего пользователя
        private void LoadCartData()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                // SQL-запрос для получения данных из таблицы Carts для авторизованного пользователя
                string query = "SELECT Products.products_name, Carts.quantity, Products.cost " +
                               "FROM Carts " +
                               "JOIN Products ON Carts.id_medicine = Products.id_medicine " +
                               "WHERE Carts.id_customer = @currentUserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Передаем значение currentUserId в SQL-запрос
                    command.Parameters.AddWithValue("@currentUserId", Login.currentUserId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Обрабатываем данные корзины и выводим их в DataGrid или другой элемент управления
                        while (reader.Read())
                        {
                            string productName = reader.GetString(0);
                            int quantity = reader.GetInt32(1);
                            decimal cost = reader.GetDecimal(2);

                            // Пример: добавляем полученные данные в DataGrid (нужно заранее создать элемент DataGrid в XAML)
                            CartDataGrid.Items.Add(new
                            {
                                ProductName = productName,
                                Quantity = quantity,
                                Cost = cost
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}");
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        // Обработчик для кнопки "Оформить заказ"
        private void ButtonOrder_Click(object sender, RoutedEventArgs e)
        {
            // Здесь может быть логика оформления заказа, которая использует currentUserId
            MessageBox.Show("Заказ оформлен для пользователя с ID: " + Login.currentUserId);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
