using System;
using Data.Controllers;
    
namespace Logic
{
    public abstract class UserBLL
    {
        private string  _login;

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
    }
}