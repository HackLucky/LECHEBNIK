using System; // Подключение стандартной библиотеки C# для базовых функций и типов данных
using System.Data.SqlClient; // Подключение библиотеки для работы с базой данных SQL Server
using System.Security.Cryptography; // Подключение библиотеки для криптографических операций, например, для хеширования паролей
using System.Text; // Подключение библиотеки для работы с текстовыми строками
using System.Text.RegularExpressions; // Подключение библиотеки для регулярных выражений, которые будут использованы для валидации
using System.Threading.Tasks; // Подключение библиотеки для работы с асинхронным программированием
using System.Windows; // Подключение библиотеки для создания оконных приложений WPF
using System.Windows.Media; // Подключение библиотеки для работы с графикой и цветом в WPF
using System.Windows.Media.Imaging; // Подключение библиотеки для работы с изображениями в WPF
namespace SokolovLechebnik.Windows // Объявление пространства имен для организации кода в логическую группу
{
    public partial class Registration : Window // Определение класса Registration, наследующегося от WPF-класса Window
    {
        private bool isLight = true; // Переменная, отвечающая за режим цвета (светлый или темный)
        // Строка с приветственным текстом, которая показывается пользователю при открытии окна
        private readonly string initialText = "Приветствую!\nМеня зовут Леча!\nДавайте авторизируем Вас, чтобы дальше пользоваться программой!\nЯ помогу Вам войти в учётную запись!\n\nВы можете поговорить со мной через текстовое поле снизу, задав мне вопросы:\nкто ты? как дела? что делаешь? напишешь факт?\n\nВы всегда сможете вернуться к этому сообщению, тыкнув на меня;)";
        private readonly string connectionString = "Server=SPECTRAPRIME;Database=LECHEBNIK;Integrated Security=True;"; // Строка подключения к базе данных, содержит имя сервера, название базы данных и метод аутентификации
        public Registration() // Конструктор класса Registration
        {
            InitializeComponent(); // Инициализация компонентов интерфейса WPF
            TextBlockAvatar.Text = initialText; // Устанавливает начальный текст для TextBlock, показывающего приветственное сообщение
        }
        private void ButtonVoity_Click(object sender, RoutedEventArgs e) // Обработчик для кнопки "Войти", который открывает окно логина
        {
            var myForm = new Login(); // Создание нового окна для логина
            myForm.Show(); // Показ нового окна логина
            this.Close(); // Закрытие текущего окна
        }
        private void ButtonExit_Click(object sender, RoutedEventArgs e) // Обработчик для кнопки "Выход", который закрывает текущее окно
        {
            this.Close(); // Закрытие текущего окна
        }
        private void ButtonOnOff_Click(object sender, RoutedEventArgs e) // Обработчик для кнопки переключения между светлым и темным режимом
        { 
            GridMain.Background = isLight ? new SolidColorBrush(Color.FromRgb(25, 25, 25)) : new SolidColorBrush(Color.FromRgb(175, 175, 175)); // Изменение фона основного Grid в зависимости от текущего режима (светлый/темный)
            ButtonOnOff.Background = new ImageBrush // Изменение изображения на кнопке переключения между режимами
            {
                ImageSource = new BitmapImage(new Uri(isLight ? "pack://application:,,,/Resources/light_mode.png" : "pack://application:,,,/Resources/dark_mode.png"))
            };
            isLight = !isLight; // Переключение состояния переменной isLight на противоположное значение
        }
        private void TextBoxFamilia_GotFocus(object sender, RoutedEventArgs e) // Обработчики для текстового поля фамилии: изменение текста подсказки при получении фокуса
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести Вашу прекрасную фамилию;)";
        }
        private void TextBoxFamilia_LostFocus(object sender, RoutedEventArgs e) // Восстановление исходного текста подсказки при потере фокуса
        {
            TextBlockAvatar.Text = initialText;
        } 
        private void TextBoxName_GotFocus(object sender, RoutedEventArgs e) // Аналогичные обработчики для текстового поля имени
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести Ваше прекрасное имя;)";
        }
        private void TextBoxName_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText;
        }        
        private void TextBoxOtchestvo_GotFocus(object sender, RoutedEventArgs e) // Аналогичные обработчики для текстового поля отчества
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести Ваше прекрасное отчество;) Если его нет, то поставьте пробел";
        }
        private void TextBoxOtchestvo_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText;
        }       
        private void TextBoxTelephone_GotFocus(object sender, RoutedEventArgs e) // Подсказки для текстового поля номера телефона
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести Ваш номер телефона. Он нужен для верификации и возможности связи.";
        }

        private void TextBoxTelephone_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText;
        }       
        private void TextBoxMail_GotFocus(object sender, RoutedEventArgs e) // Подсказки для текстового поля электронной почты
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести Вашу почту. Она нужна для восстановления пароля.";
        }
        private void TextBoxMail_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText;
        }
        private void TextBoxPass_GotFocus(object sender, RoutedEventArgs e) // Подсказки для поля ввода пароля
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести придуманный Вами пароль для входа в личный кабинет.";
        }
        private void TextBoxPass_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText;
        }
        private void TextBoxRetryPass_GotFocus(object sender, RoutedEventArgs e) // Подсказки для повторного ввода пароля
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести Ваш придуманный ранее пароль повторно для проверки правильности его написания.";
        }
        private void TextBoxRetryPass_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText;
        }
        private async void ButtonReg_Click(object sender, RoutedEventArgs e) // Обработчик кнопки "Зарегистрироваться"
        {
            if (!ValidateInput()) // Проверка на корректность ввода
            {
                return; // Выход, если валидация не пройдена
            }
            // Получение значений из текстовых полей
            string secondName = TextBoxFamilia.Text.Trim();
            string firstName = TextBoxName.Text.Trim();
            string patronymic = TextBoxOtchestvo.Text.Trim();
            string phoneNumber = TextBoxTelephone.Text.Trim();
            string mail = TextBoxMail.Text.Trim();
            string password = TextBoxPass.Password;
            string recoveryCode = GenerateRecoveryCode(); // Генерация кода восстановления
            try
            {
                if (await UserExistsAsync(phoneNumber, mail)) // Проверка существования пользователя с таким номером телефона или почтой
                {
                    MessageBox.Show("Пользователь с таким номером телефона или почтой уже зарегистрирован.", "ОШИБКА РЕГИСТРАЦИИ");
                    return;
                }
                await InsertUserToDatabaseAsync(secondName, firstName, patronymic, phoneNumber, mail, password, recoveryCode); // Добавление нового пользователя в базу данных
                var myForm = new Main(); // Переход на основное окно программы
                myForm.Show();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Сервер базы данных недоступен. Попробуйте позже.", "ОШИБКА СЕРВЕРА");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "ОШИБКА СЕРВЕРА");
            }
        }
        private bool ValidateInput() // Метод для проверки корректности введенных данных
        {
            if (string.IsNullOrWhiteSpace(TextBoxFamilia.Text) || string.IsNullOrWhiteSpace(TextBoxName.Text) || string.IsNullOrWhiteSpace(TextBoxTelephone.Text) || string.IsNullOrWhiteSpace(TextBoxMail.Text) || string.IsNullOrWhiteSpace(TextBoxPass.Password)) // Проверка, что обязательные поля не пусты
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля корректно.", "ОШИБКА ВВОДА");
                return false;
            }
            if (TextBoxPass.Password.Length < 8) // Проверка длины пароля
            {
                MessageBox.Show("Пароль должен содержать не менее 8 символов.", "ОШИБКА ВВОДА");
                return false;
            }
            if (!Regex.IsMatch(TextBoxMail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) // Проверка формата электронной почты
            {
                MessageBox.Show("Неправильный формат электронной почты.", "ОШИБКА ВВОДА");
                return false;
            }
            if (!Regex.IsMatch(TextBoxTelephone.Text, @"^(\+7|8)\d{10}$")) // Проверка формата номера телефона
            {
                MessageBox.Show("Неправильный формат номера телефона. Введите номер, начинающийся с +7 или 8, затем 10 цифр.", "ОШИБКА ВВОДА");
                return false;
            }

            return true;
        }
        private static string GenerateRecoveryCode() // Метод для генерации шестизначного кода восстановления
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[4];
                rng.GetBytes(data);
                int code = Math.Abs(BitConverter.ToInt32(data, 0) % 1000000);
                return code.ToString("D6");
            }
        }
        // Асинхронный метод для проверки существования пользователя с указанным телефоном или почтой
        private async Task<bool> UserExistsAsync(string phoneNumber, string mail)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT COUNT(*) FROM Users WHERE phone_number = @phoneNumber OR mail = @mail";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@mail", mail);

                        int userCount = (int)await command.ExecuteScalarAsync();
                        return userCount > 0;
                    }
                }
            }
            catch (SqlException) // Обработка ошибок сервера
            {
                MessageBox.Show("Ошибка при проверке существования пользователя. Сервер недоступен.", "ОШИБКА СЕРВЕРА");
                return false;
            }
            catch (Exception ex) // Обработка ошибок проверки пользователя
            {
                MessageBox.Show($"Ошибка при проверке пользователя: {ex.Message}", "ОШИБКА СЕРВЕРА");
                return false;
            }
        }
        private async Task InsertUserToDatabaseAsync(string secondName, string firstName, string patronymic, string phoneNumber, string mail, string password, string recoveryCode) // Асинхронный метод для добавления нового пользователя в базу данных
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string query = @"INSERT INTO Users (second_name, first_name, patronymic, phone_number, mail, password, recovery_code) VALUES (@secondName, @firstName, @patronymic, @phoneNumber, @mail, @password, @recoveryCode)";
                        using (SqlCommand command = new SqlCommand(query, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@secondName", secondName);
                            command.Parameters.AddWithValue("@firstName", firstName);
                            command.Parameters.AddWithValue("@patronymic", patronymic);
                            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                            command.Parameters.AddWithValue("@mail", mail);
                            command.Parameters.AddWithValue("@password", HashPassword(password));
                            command.Parameters.AddWithValue("@recoveryCode", recoveryCode);

                            await command.ExecuteNonQueryAsync();
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Ошибка при добавлении пользователя: {ex.Message}", "ОШИБКА РЕГИСТРАЦИИ");
                    }
                    finally
                    {
                        transaction.Dispose();
                        connection.Close();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка при записи в базу данных. Сервер базы данных недоступен.", "ОШИБКА СЕРВЕРА");
                    throw new Exception("Ошибка подключения к серверу базы данных.", ex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Неизвестная ошибка: {ex.Message}", "ОШИБКА");
                    throw;
                }
            }
        }
        private static string HashPassword(string password) // Метод для хеширования пароля с использованием алгоритма SHA-256
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}