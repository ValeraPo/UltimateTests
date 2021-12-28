using System.Collections.Generic;

namespace Logic
{
    public class TeacherBLL : User
    {
        public List<string> Groups { get; set; } // Группы, которые курирует
    }
}