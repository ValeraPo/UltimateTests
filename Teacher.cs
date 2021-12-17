using System.Collections.Generic;

namespace UltimateTests.Logics
{
    public class Teacher : IUser
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public List<string> Groups { get; set; } // Группы, которые курирует
    }
}