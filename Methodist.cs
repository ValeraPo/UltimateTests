using System.Collections.Generic;

namespace UltimateTests.Logics
{
    public class Methodist : IUser
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public List<Quize> Quizes { get; set; } // Тесты которые создал
    }
}