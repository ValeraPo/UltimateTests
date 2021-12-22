using System;

namespace Logic
{
    public class FeedbackBLL
    {
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                if (value.Length > 280)
                    throw new ArgumentOutOfRangeException("Размер превышает допустимый");
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Собщение не может быть пустым");
                _text = value;
            }
        }
        public int IDUser { get; set; } // Автор фидбэка
        public DateTime Date { get; set;  } // Когда добавили
        
    }
}