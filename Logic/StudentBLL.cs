using System.Collections.Generic;

namespace Logic
{
    public class StudentBLL : User
    {
        public string Group { get; set; } // Группа в которой учится
        public List<long> AppointmentQuizes { get; set; } // Список назначенных тестов
        public List<long> DoneQuizes { get; set; } // Список выполненных тестов

    }
}