using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace SokolovLechebnik.Windows
{
    
    public partial class Login : Window // Класс Login представляет собой окно для входа в систему.
    {
        // Поле для отслеживания текущего состояния темы (true - светлая, false - темная).
        private bool isLight = true;

        // Начальный текст приветствия для аватара, который содержит подсказки для пользователя.
        private readonly string initialText = "Приветствую!\nМеня зовут Леча!\nДавайте авторизируем Вас, чтобы дальше пользоваться программой!\nЯ помогу Вам войти в учётную запись!\n\nВы можете поговорить со мной через текстовое поле снизу, задав мне вопросы:\nкто ты? как дела? что делаешь? напишешь факт?\n\nВы всегда сможете вернуться к этому сообщению, тыкнув на меня;)";

        // Строка подключения к базе данных.
        private readonly string connectionString = "Server=SPECTRAPRIME;Database=LECHEBNIK;Integrated Security=True;"; // Строка подключения к базе данных.
        
        // Переменная для хранения ID авторизованного пользователя
        public static int currentUserId;
        
        // Конструктор для инициализации окна и установки текста приветствия в TextBlock аватара.
        public Login()
        {
            InitializeComponent(); // Инициализирует компоненты интерфейса.
            TextBlockAvatar.Text = initialText; // Устанавливает начальный текст для аватара.
        }

        // Обработчик для кнопки регистрации, открывающий окно регистрации.
        private void ButtonReg_Click(object sender, RoutedEventArgs e)
        {
            var myForm = new Registration(); // Создает новое окно регистрации.
            myForm.Show(); // Показывает окно регистрации.
            this.Close(); // Закрывает текущее окно (окно входа).
        }

        // Обработчик для кнопки выхода, который закрывает окно входа.
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Закрывает текущее окно.
        }

        // Обработчик для кнопки переключения темы (светлая/темная).
        private void ButtonOnOff_Click(object sender, RoutedEventArgs e)
        {
            // Устанавливает цвет фона GridMain: темный, если isLight=true, иначе светлый.
            GridMain.Background = isLight ? new SolidColorBrush(Color.FromRgb(25, 25, 25)) : new SolidColorBrush(Color.FromRgb(175, 175, 175));

            // Меняет изображение кнопки в зависимости от текущей темы.
            ButtonOnOff.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(isLight ? "pack://application:,,,/Resources/light_mode.png" : "pack://application:,,,/Resources/dark_mode.png"))
            };

            // Переключает состояние isLight (меняет тему).
            isLight = !isLight;
        }

        // Обработчик фокуса на TextBox для ввода почты, отображающий подсказку в TextBlock аватара.
        private void TextBoxMail_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести Вашу почту. Она нужна для восстановления пароля и рассылки об обновлении статуса заказа. Я могу писать Вам, но к сожалению времени у меня не так много:(";
        }

        // Обработчик потери фокуса на TextBox для почты, восстанавливающий текст приветствия в TextBlock аватара.
        private void TextBoxMail_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText; // Возвращает начальный текст аватара.
        }

        // Обработчик фокуса на TextBox для ввода пароля, отображающий подсказку в TextBlock аватара.
        private void TextBoxPass_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести придуманный Вами пароль для входа в личный кабинет. Не стоит волноваться, пароли я, конечно, запоминаю, но не использую где-либо за пределами моего дома - программы...";
        }

        
        private void TextBoxPass_LostFocus(object sender, RoutedEventArgs e) // Обработчик потери фокуса на TextBox для пароля, восстанавливающий текст приветствия в TextBlock аватара.
        {
            TextBlockAvatar.Text = initialText; // Возвращает начальный текст аватара.
        }
        // Метод для аутентификации пользователя и сохранения его ID
        private bool AuthenticateUser(string email, string password)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString); // Подключение к базе данных
                connection.Open();

                // Запрос на выборку данных пользователя по email и паролю (хэш)
                string query = "SELECT id_customer, password FROM Users WHERE mail = @mail AND is_active = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mail", email); // Добавление параметра email в запрос

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Проверяем, что пользователь с данным email найден
                        {
                            int idCustomer = reader.GetInt32(0); // Получаем id_customer
                            string storedPasswordHash = reader.GetString(1); // Получаем хэш пароля из базы данных

                            // Хэшируем введённый пароль для сравнения с базой данных
                            string passwordHash = HashPassword(password);

                            // Отладочное сообщение: Выводим email, хэшированный пароль и значение из базы
                            MessageBox.Show($"Email: {email}\nВведенный хэш: {passwordHash}\nХэш в базе данных: {storedPasswordHash}");

                            // Сравниваем хэши
                            if (storedPasswordHash == passwordHash)
                            {
                                // Сохраняем идентификатор текущего пользователя для сессии (переменная должна быть определена в коде)
                                currentUserId = idCustomer;
                                MessageBox.Show($"Аутентификация успешна для пользователя: {email}");
                                return true; // Если пароли совпадают, возвращаем true
                            }
                            else
                            {
                                MessageBox.Show("Пароль не совпадает.", "Ошибка аутентификации");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пользователь не найден или не активен.", "Ошибка аутентификации");
                        }
                    }
                }

                return false; // Если нет совпадений, возвращаем false
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка: {ex.Message}");
                return false;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close(); // Закрываем соединение с базой данных
                }
            }
        }

        // Обработчик кнопки для входа в систему
        private void ButtonVoity_Click(object sender, RoutedEventArgs e)
        {
            string email = TextBoxMail.Text.Trim(); // Получаем email из текстового поля TextBoxMail
            string password = TextBoxPass.Password; // Получаем пароль из поля PasswordBox (TextBoxPass)

            if (AuthenticateUser(email, password)) // Проверяем введённые данные через метод аутентификации
            {
                var myForm = new Main(); // Если данные верны, создаём и показываем основное окно программы
                myForm.Show();
                this.Close(); // Закрываем окно входа
            }
            else
            {
                // Если аутентификация не удалась, показываем сообщение об ошибке
                MessageBox.Show("Неправильный адрес электронной почты или пароль.", "ОШИБКА ВВОДА");
            }
        }

        // Метод для хэширования пароля с использованием алгоритма SHA-256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password)); // Преобразуем пароль в хэш
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Преобразуем байты в шестнадцатеричное представление
                }
                return builder.ToString(); // Возвращаем хэш пароля
            }
        }
    }
}