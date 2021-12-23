using System;
using Data;

namespace Logic
{
	public class Connecting
	{
        // Проверка пароля при авторизации
		public static UserBLL Authorization(string login, string password)
		{
			try
            {
                UserBLL user = HomeController.GetUser(login.ToLower());
                if (user.Hash != Encryptor.MD5Hash(password))
                    throw new KeyNotFoundException("Пароль неверный");
                return user;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
		}
        // Проверка логина при добавлении нового пользователя
        public static void CheckLogin(string login)
        {
            List<string> logins = HomeController.SomeMethod(); // List<string>
            if (!logins.Contains(login.ToLower()))
                throw new ArgumentException("Логин уже существует");
        }

	}
}
