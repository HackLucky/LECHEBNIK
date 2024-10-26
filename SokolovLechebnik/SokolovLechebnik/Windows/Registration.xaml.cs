using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace SokolovLechebnik.Windows
{
    public partial class Registration : Window
    {
        private bool isLight = true;
        private readonly string initialText = "Приветствую!\nМеня зовут Леча!\nДавайте авторизируем Вас, чтобы дальше пользоваться программой!\nЯ помогу Вам войти в учётную запись!\n\nВы можете поговорить со мной через текстовое поле снизу, задав мне вопросы:\nкто ты? как дела? что делаешь? напишешь факт?\n\nВы всегда сможете вернуться к этому сообщению, тыкнув на меня;)";
        private readonly string connectionString = "Server=SPECTRAPRIME;Database=LECHEBNIK;Integrated Security=True;";
        public Registration()
        {
            InitializeComponent();
            TextBlockAvatar.Text = initialText;
        }
        private void ButtonVoity_Click(object sender, RoutedEventArgs e)
        {
            var myForm = new Login();
            myForm.Show();
            this.Close();
        }
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ButtonOnOff_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Background = isLight? new SolidColorBrush(Color.FromRgb(25, 25, 25)): new SolidColorBrush(Color.FromRgb(175, 175, 175));
            ButtonOnOff.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(isLight?"pack://application:,,,/Resources/light_mode.png":"pack://application:,,,/Resources/dark_mode.png"))
            };
            isLight = !isLight;
        }
        private void TextBoxFamilia_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести Вашу прекрасную фамилию;)";
        }
        private void TextBoxFamilia_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText;
        }
        private void TextBoxName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести Ваше прекрасное имя;)";
        }
        private void TextBoxName_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText;
        }
        private void TextBoxOtchestvo_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести Ваше прекрасное отчество;) Если его нет, то поставьте пробел";
        }
        private void TextBoxOtchestvo_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText;
        }
        private void TextBoxTelephone_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести Ваш номер телефона. Он нужен для верификации и возможности связи. Конечно, хочется услышать Ваш голос, но я всегда на службе здесь и, увы, не имею такой возможности;)";
        }
        private void TextBoxTelephone_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText;
        }
        private void TextBoxMail_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести Вашу почту. Она нужна для восстановления пароля и рассылки об обновлении статуса заказа. Я могу писать Вам, но к сожалению времени у меня не так много:(";
        }
        private void TextBoxMail_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText;
        }
        private void TextBoxPass_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести придуманный Вами пароль для входа в личный кабинет. Не стоит волноваться, пароли я, конечно, запоминаю, но не использую где-либо за пределами моего дома - программы...";
        }
        private void TextBoxPass_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText;
        }
        private void TextBoxRetryPass_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести Ваш придуманный ранее пароль повторно для проверки правильности его написания и запоминания его Вами. Конечно, Вы можете восстановить доступ позже;)";
        }
        private void TextBoxRetryPass_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText;
        }
        private async void ButtonReg_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля корректно.");
                return;
            }
            string secondName = TextBoxFamilia.Text.Trim();
            string firstName = TextBoxName.Text.Trim();
            string patronymic = TextBoxOtchestvo.Text.Trim();
            string phoneNumber = TextBoxTelephone.Text.Trim();
            string mail = TextBoxMail.Text.Trim();
            string password = TextBoxPass.Password;
            string recoveryCode = GenerateRecoveryCode();
            try
            {
                if (await UserExistsAsync(phoneNumber, mail))
                {
                    MessageBox.Show("Пользователь с таким номером телефона или почтой уже зарегистрирован.");
                    return;
                }
                await InsertUserToDatabaseAsync(secondName, firstName, patronymic, phoneNumber, mail, password, recoveryCode);

                var myForm = new Main();
                myForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}");
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(TextBoxFamilia.Text)||string.IsNullOrWhiteSpace(TextBoxName.Text)||string.IsNullOrWhiteSpace(TextBoxTelephone.Text)||string.IsNullOrWhiteSpace(TextBoxMail.Text)||string.IsNullOrWhiteSpace(TextBoxPass.Password))
            {
                return false;
            }
            if (!Regex.IsMatch(TextBoxMail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Неправильный формат электронной почты.");
                return false;
            }
            if (!Regex.IsMatch(TextBoxTelephone.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Неправильный формат номера телефона.");
                return false;
            }
            return true;
        }
        private static string GenerateRecoveryCode()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[4];
                rng.GetBytes(data);
                int code = BitConverter.ToInt32(data, 0) % 1000000;
                return Math.Abs(code).ToString("D6");
            }
        }
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
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке пользователя: {ex.Message}");
                return false;
            }
        }
        private async Task InsertUserToDatabaseAsync(string secondName, string firstName, string patronymic,
                                                     string phoneNumber, string mail, string password, string recoveryCode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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
                    MessageBox.Show($"Ошибка при добавлении пользователя: {ex.Message}");
                }
            }
        }
        private static string HashPassword(string password)
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