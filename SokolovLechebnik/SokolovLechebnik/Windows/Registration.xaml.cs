using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private bool isLight = true;
        private string initialText = "Приветствую!\nМеня зовут Леча!\nДавайте авторизируем Вас, чтобы дальше пользоваться программой!\nЯ помогу Вам войти в учётную запись!\n\nВы можете поговорить со мной через текстовое поле снизу, задав мне вопросы:\nкто ты? как дела? что делаешь? напишешь факт?\n\nВы всегда сможете вернуться к этому сообщению, тыкнув на меня;)";

        public Registration()
        {
            InitializeComponent();
            TextBlockAvatar.Text = initialText; // Устанавливаем изначальный текст
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
            if (isLight)
            {
                // Устанавливаем темный цвет RGB
                GridMain.Background = new SolidColorBrush(Color.FromRgb(25, 25, 25)); // Темно-серый
                ButtonOnOff.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/light_mode.png"))
                };
            }
            else
            {
                // Устанавливаем светлый цвет RGB
                GridMain.Background = new SolidColorBrush(Color.FromRgb(175, 175, 175)); // Светло-серый
                ButtonOnOff.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/dark_mode.png"))
                };
            }
            isLight = !isLight;
        }
        private void TextBoxName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести Ваше прекрасное имя;)";
        }
        private void TextBoxName_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText; // Восстанавливаем изначальный текст
        }
        private void TextBoxFamilia_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести Вашу прекрасную фамилию;)";
        }
        private void TextBoxFamilia_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText; // Восстанавливаем изначальный текст
        }
        private void TextBoxOtchestvo_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести Ваше прекрасное отчество;) Если его нет, то поставьте пробел";
        }
        private void TextBoxOtchestvo_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText; // Восстанавливаем изначальный текст
        }
        private void TextBoxTelephone_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести Ваш номер телефона. Он нужен для верификации и возможности связи. Конечно, хочется услышать Ваш голос, но я всегда на службе здесь и, увы, не имею такой возможности;)";
        }
        private void TextBoxTelephone_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText; // Восстанавливаем изначальный текст
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
        private void TextBoxRetryPass_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = "Подсказка: в это текстовое поле нужно ввести Ваш придуманный ранее пароль повторно для проверки правильности его написания и запоминания его Вами. Конечно, Вы можете восстановить доступ позже;)";
        }
        private void TextBoxRetryPass_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlockAvatar.Text = initialText; // Восстанавливаем изначальный текст
        }
    }
}
