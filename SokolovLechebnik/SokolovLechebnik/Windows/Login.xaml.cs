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

        
        private readonly string connectionString = "Server=SPECTRAPRIME;Database=LECHEBNIK;Integrated Security=True;"; // Строка подключения к базе данных.

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

        
        private void ButtonVoity_Click(object sender, RoutedEventArgs e) // Обработчик для кнопки входа в систему.
        {
            string email = TextBoxMail.Text.Trim(); // Получает текст из TextBox для почты и удаляет лишние пробелы.
            string password = TextBoxPass.Password; // Получает пароль из PasswordBox.

            
            if (AuthenticateUser(email, password)) // Проверяет учетные данные пользователя. Если верны, открывает главное окно.
            {
                var myForm = new Main(); // Создает новое главное окно.
                myForm.Show(); // Показывает главное окно.
                this.Close(); // Закрывает текущее окно (окно входа).
            }
            else
            {
                
                MessageBox.Show("Неправильный адрес электронной почты или пароль.", "ОШИБКА ВВОДА"); // Если учетные данные неверны, показывает сообщение об ошибке.
            }
        }

        
        private bool AuthenticateUser(string email, string password) // Метод для аутентификации пользователя, проверяющий почту и пароль.
        {
            SqlConnection connection = null; // Переменная для подключения к базе данных.
            try
            {
                connection = new SqlConnection(connectionString); // Создает новое подключение с использованием строки подключения.
                connection.Open(); // Открывает подключение.

                
                string query = "SELECT password FROM Users WHERE mail = @mail"; // SQL-запрос для получения хэшированного пароля пользователя по его почте.
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Добавляет параметр email к SQL-запросу.
                    command.Parameters.AddWithValue("@mail", email);

                    // Выполняет запрос и получает хэшированный пароль из базы данных.
                    var storedPasswordHash = command.ExecuteScalar() as string;

                    // Если хэшированный пароль пустой (пользователь не найден), возвращает false.
                    if (string.IsNullOrEmpty(storedPasswordHash))
                    {
                        return false;
                    }

                    // Генерирует хэш для введенного пользователем пароля.
                    string passwordHash = HashPassword(password);

                    // Сравнивает хэши: если совпадают, возвращает true (пароль верен).
                    return storedPasswordHash == passwordHash;
                }
            }
            catch (SqlException ex)
            {
                // Обрабатывает ошибки SQL-запроса и показывает сообщение.
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Обрабатывает любые другие ошибки и показывает сообщение.
                MessageBox.Show($"Неизвестная ошибка: {ex.Message}");
                return false;
            }
            finally
            {
                // Закрывает подключение к базе данных, если оно было открыто.
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
        
        private string HashPassword(string password) // Метод для хэширования пароля с использованием алгоритма SHA-256.
        {
            using (SHA256 sha256 = SHA256.Create()) // Создает новый экземпляр SHA-256.
            {
                
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password)); // Преобразует пароль в массив байтов и вычисляет хэш.


                StringBuilder builder = new StringBuilder(); // Строит строковое представление хэша.
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Преобразует каждый байт в шестнадцатеричную строку.
                }

                
                return builder.ToString(); // Возвращает итоговый хэш как строку.
            }
        }
    }
}