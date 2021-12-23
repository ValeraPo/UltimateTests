using System.Collections.Generic;

namespace Logic
{
    public class StudentBLL : UserBLL
    {
        
        public string Group { get; set; } // Группа в которой учится
        public List<long> AssignedQuizzes { get; set; } // Список назначенных тестов
        public List<long> PerformedQuizzes { get; set; } // Список выполненных тестов


    }
}