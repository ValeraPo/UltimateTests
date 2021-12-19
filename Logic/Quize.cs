namespace Logic
{
    public class Quize
    {
        public Quize(Dictionary<string, List<(string, bool)>> test, uint scores)
        {
            Test = test;
            Scores = scores;
        }

        // Тест - словарь вида
        // Вопрос1: (ответ1, false), (ответ1, true), (ответ1, false), ...; 
        // Вопрос2: (ответ1, true), (ответ1, false), (ответ1, false), ...; 
        // Вопрос3: (ответ1, false), (ответ1, false), (ответ1, true), ...; 
        // ...
        public Dictionary<string, List<(string, bool)>> Test { get; set; }
        public uint Scores { get; set; } // Баллы за прохождение

        public bool CheckAnswer(string question, string answer)
        {
            //Пока не буду писать, вдруг тут не словарь вовсе будет
            return true;
        }
    }
}