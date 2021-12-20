using System.Collections.Generic;

namespace Logic
{
    public class Methodist : IUser
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public List<Quize> Quizes { get; set; } // Тесты которые создал
    }
}