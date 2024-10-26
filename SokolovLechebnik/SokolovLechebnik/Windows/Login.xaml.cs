using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace SokolovLechebnik.Windows
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly string connectionString = "Server=SPECTRAPRIME;Database=LECHEBNIK;Integrated Security=True;";
        private bool isLight = true;
        private string initialText = "Приветствую!\nМеня зовут Леча!\nДавайте авторизируем Вас, чтобы дальше пользоваться программой!\nЯ помогу Вам войти в учётную запись!\n\nВы можете поговорить со мной через текстовое поле снизу, задав мне вопросы:\nкто ты? как дела? что делаешь? напишешь факт?\n\nВы всегда сможете вернуться к этому сообщению, тыкнув на меня;)";
        public Login()
        {
            InitializeComponent();
            TextBlockAvatar.Text = initialText; // Устанавливаем изначальный текст
        }
        private void ButtonReg_Click(object sender, RoutedEventArgs e)
        {
            var myForm = new Registration();
            myForm.Show();
            this.Close();
        }
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ButtonOnOff_Click(object sender, RoutedEventArgs e)
        {
            if (isLight)
            {
                // Устанавливаем темный цвет RGB
                GridMain.Background = new SolidColorBrush(Color.FromRgb(25, 25, 25)); // Темно-серый
                TurnNight.Source = new BitmapImage(new Uri("/light_mode.png", UriKind.Relative));
            }
            else
            {
                // Устанавливаем светлый цвет RGB
                GridMain.Background = new SolidColorBrush(Color.FromRgb(175, 175, 175)); // Светло-серый
                TurnNight.Source = new BitmapImage(new Uri("/dark_mode.png", UriKind.Relative));
            }
            isLight = !isLight;
        }
        private void TextBoxMail_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести Вашу почту. Она нужна для восстановления пароля и рассылки об обновлении статуса заказа. Я могу писать Вам, но к сожалению времени у меня не так много:(";
        }
        private void TextBoxMail_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText; // Восстанавливаем изначальный текст
        }
        private void TextBoxPass_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести придуманный Вами пароль для входа в личный кабинет. Не стоит волноваться, пароли я, конечно, запоминаю, но не использую где-либо за пределами моего дома - программы...";
        }
        private void TextBoxPass_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText; // Восстанавливаем изначальный текст
        }
        private void ButtonVoity_Click(object sender, RoutedEventArgs e)
        {
            string email = TextBoxMail.Text.Trim();
            string password = TextBoxPass.Password;
            if (AuthenticateUser(email, password))
            {
                var myForm = new Main();
                myForm.Show();
                // Открыть основное окно приложения
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный email или пароль.");
            }
        }
        // Метод авторизации пользователя по email и паролю
        private bool AuthenticateUser(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // SQL-запрос для поиска пользователя по email
                string query = "SELECT password FROM Users WHERE mail = @mail";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mail", email);
                    // Получаем хеш пароля из базы данных
                    var storedPasswordHash = command.ExecuteScalar() as string;
                    // Если пользователь с таким email не найден
                    if (string.IsNullOrEmpty(storedPasswordHash))
                    {
                        return false;
                    }
                    // Хешируем введенный пользователем пароль
                    string passwordHash = HashPassword(password);
                    // Сравниваем хеш введенного пароля с хешем в базе данных
                    return storedPasswordHash == passwordHash;
                }
            }
        }
        // Метод хеширования пароля с использованием SHA-256
        private string HashPassword(string password)
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
