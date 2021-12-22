using System.Collections.Generic;

namespace Logic
{
    public class MethodistBLL : IUser
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Hash { get; set; }
        public string ID { get; set; }

        public List<QuizeBLL> Quizes { get; set; } // Тесты которые создал

    }
}