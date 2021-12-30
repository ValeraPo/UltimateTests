using System;

namespace Logic.DTO
{
    public class AttemptDTO
    {
        public AttemptDTO(long id, int score, TimeSpan transitTime, DateTime dateTime, string nameQuiz)
        {
            Id = id;
            Score = score;
            TransitTime = transitTime;
            DateTime = dateTime;
            NameQuiz = nameQuiz;
        }
        public AttemptDTO(Data.Maps.Attempt attempt)
        {
            Id          = attempt.ID_Try;
            Score       = attempt.Score;
            TransitTime = attempt.TransitTime;
            DateTime    = attempt.DateTime;
            NameQuiz    = attempt.Quizze.Name;
        }
        
        
        public long Id {get; set;}
        public int Score {get; set;}
        public TimeSpan TransitTime {get; set;}
        public DateTime DateTime    {get; set;}
        public string NameQuiz {get; set;}
    }
}