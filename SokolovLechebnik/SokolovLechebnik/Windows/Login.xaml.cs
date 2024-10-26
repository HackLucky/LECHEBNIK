using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace SokolovLechebnik.Windows
{
    public partial class Login : Window
    {
        private bool isLight = true;
        private readonly string initialText = "Приветствую!\nМеня зовут Леча!\nДавайте авторизируем Вас, чтобы дальше пользоваться программой!\nЯ помогу Вам войти в учётную запись!\n\nВы можете поговорить со мной через текстовое поле снизу, задав мне вопросы:\nкто ты? как дела? что делаешь? напишешь факт?\n\nВы всегда сможете вернуться к этому сообщению, тыкнув на меня;)";
        private readonly string connectionString = "Server=SPECTRAPRIME;Database=LECHEBNIK;Integrated Security=True;";
        public Login()
        {
            InitializeComponent();
            TextBlockAvatar.Text = initialText;
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
            GridMain.Background = isLight? new SolidColorBrush(Color.FromRgb(25, 25, 25)): new SolidColorBrush(Color.FromRgb(175, 175, 175));
            ButtonOnOff.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(isLight? "pack://application:,,,/Resources/light_mode.png": "pack://application:,,,/Resources/dark_mode.png"))
            };
            isLight = !isLight;
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
        private void ButtonVoity_Click(object sender, RoutedEventArgs e)
        {
            string email = TextBoxMail.Text.Trim();
            string password = TextBoxPass.Password;
            if (AuthenticateUser(email, password))
            {
                var myForm = new Main();
                myForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный email или пароль.");
            }
        }
        private bool AuthenticateUser(string email, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT password FROM Users WHERE mail = @mail";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@mail", email);
                        var storedPasswordHash = command.ExecuteScalar() as string;

                        if (string.IsNullOrEmpty(storedPasswordHash))
                        {
                            return false;
                        }

                        string passwordHash = HashPassword(password);
                        return storedPasswordHash == passwordHash;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Ошибка подключения к базе данных: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
                return false;
            }
        }

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
