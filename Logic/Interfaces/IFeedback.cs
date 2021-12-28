using System;

namespace Logic.Interfaces
{
	public interface IFeedback
	{
        public string Text { get; set; }
        public long IDUser { get; set; } // Автор фидбэка
        public DateTime Date { get; set; } // Когда добавили
        
    }
}
