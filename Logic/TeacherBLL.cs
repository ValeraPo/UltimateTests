using System.Collections.Generic;

namespace Logic
{
    public class TeacherBLL : UserBLL
    {
        public List<string> Groups { get; set; } // Группы, которые курирует
    }
}