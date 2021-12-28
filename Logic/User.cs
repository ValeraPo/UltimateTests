using System;
using Logic.Interfaces;

namespace Logic
{
    public abstract class User : IUser
    {
        private string _login;

        public string Login
        {
            get => _login;
            set
            {
                Connecting.CheckLogin(value);
                if (value.Length > 280)
                    throw new ArgumentOutOfRangeException("Размер превышает допустимый");
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Собщение не может быть пустым");
                _login = value;
            }
        }
        public string Name { get; set; }
        public string Hash { get; set; }
        public long ID { get; set; }
        public string Email { get; set; }
    }
}
