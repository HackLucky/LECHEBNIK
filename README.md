# LECHEBNIK

## Описание

**LECHEBNIK** - это приложение для управления учетными записями пользователей, предназначенное для медицинских учреждений. Программа позволяет пользователям регистрироваться, входить в свои учетные записи и управлять своими данными. Она включает в себя базу данных, которая хранит информацию о пользователях и обеспечивает безопасность данных.

## Функциональные возможности

- Регистрация нового пользователя с указанием:
  - Фамилия
  - Имя
  - Отчество
  - Номер телефона
  - Электронная почта
  - Пароль
- Вход в систему для зарегистрированных пользователей
- Валидация ввода для обеспечения корректности данных
- Генерация кода восстановления для сброса пароля
- Смена темной и светлой темы интерфейса

## База данных

### Структура базы данных

**LECHEBNIK** использует Microsoft SQL Server для хранения данных пользователей. Таблица `Users` имеет следующую структуру:

| Поле             | Тип данных      | Описание                                                |
|------------------|-----------------|---------------------------------------------------------|
| `id_customer`             | INT (PRIMARY KEY, AUTO_INCREMENT) | Уникальный идентификатор пользователя |
| `second_name`    | NVARCHAR(50)    | Фамилия пользователя                                    |
| `first_name`     | NVARCHAR(50)    | Имя пользователя                                        |
| `patronymic`     | NVARCHAR(50)    | Отчество пользователя                                   |
| `phone_number`   | NVARCHAR(15)    | Номер телефона (начинается с +7 или 8)                  |
| `mail`           | NVARCHAR(100)   | Электронная почта                                       |
| `password`       | NVARCHAR(256)   | Хэшированный пароль                                     |
| `recovery_code`  | NVARCHAR(6)     | Код для восстановления пароля                           |

## Установка и настройка
Вариант №1
1. Скачайте репазиторий LECHEBNIK с сайта https://github.com/HackLucky/LECHEBNIK

2. Вставьте файлы базы данных в папку Data папки MSSQL. Местоположение папок базы данных может отличаться. Чтобы проверить путь к базам данных, нужно вызвать контекстное меню базы данных в MSSQL, выбрать "Свойства" и обратить внимане на строку "Путь".

3. SQLQuery может быть распакована в любом месте на компьютере.

4. Папка SokolovLechebnik должна быть распакована в корневом каталоге решений Visual Studio. По умолчанию: C:/Users/[Name_of_user]/source/repos/

Варивнт №2
1. Клонируйте репозиторий:
   ```bash
   git clone <URL_репозитория>

2. Убедитесь, что у вас установлен .NET Framework и Microsoft SQL Server.

3. Настроить
private readonly string connectionString = "Server=[Имя_вашего_сервера];Database=LECHEBNIK;Integrated Security=True;";

4. Создайте базу данных LECHEBNIK и таблицу Пользователей с вышеописанной структурой.

5. Запустите приложение и следуйте инструкциям на экране для регистрации и входа.

Использование
1. При запуске приложения пользователь видит приветственное сообщение.

2. Для регистрации нового пользователя заполните все обязательные поля:
    Фамилия
    Имя
    Отчество (можно оставить пустым)
    Номер телефона (в формате +7XXXXXXXXXX или 8XXXXXXXXXX)
    Электронная почта
    Пароль (не менее 8 символов)

3. После успешной регистрации пользователь может войти в свою учетную запись.

Лицензия
Данная программа распространяется под лицензией MIT. Пожалуйста, ознакомьтесь с файлом LICENSE для получения дополнительной информации.

Контакты
Если у вас есть вопросы или предложения, пожалуйста, свяжитесь с разработчиком по адресу: [ваш_Электронная почта.с].

### Обратите внимание:
- Замените `<URL_репозитория>` на URL вашего репозитория.
- Добавьте свой адрес электронной почты в секции контактов.
- При необходимости обновите раздел установки и настройки, если у вас есть дополнительные шаги или требования.