using System.Collections.Generic;

namespace Logic
{
    public class Student : IUser
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Group { get; set; } // Группа в которой учится
        public List<(Quize,bool)> Quizes { get; set; } // Список назначенных тестов
        // и их статус (выполнен/невыполнен)

    }
}