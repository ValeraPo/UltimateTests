using System;

namespace Logic.DTO
{
    public class AttemptDTO
    {
        public AttemptDTO(long id, int score, TimeSpan transitTime, DateTime dateTime, string nameQuiz, string nameUser)
        {
            Id          = id;
            Score       = score;
            TransitTime = transitTime;
            DateTime    = dateTime;
            NameQuiz    = nameQuiz;
            NameUser    = nameUser;
        }
        public AttemptDTO(int score, int maxScore, TimeSpan transitTime, DateTime dateTime, string nameQuiz, string nameUser)
        {
            Score       = score;
            MaxScore    = maxScore;
            TransitTime = transitTime;
            DateTime    = dateTime;
            NameQuiz    = nameQuiz;
            NameUser    = nameUser;
            Percent     = (byte)((double)Score / MaxScore);
        }
        public AttemptDTO(Data.Maps.Attempt attempt)
        {
            Id          = attempt.ID_Try;
            Score       = attempt.Score;
            MaxScore    = attempt.Quizze.MaxPoints;
            TransitTime = attempt.TransitTime;
            DateTime    = attempt.DateTime;
            NameQuiz    = attempt.Quizze.Name;
            NameUser    = attempt.User.FullName;
            Percent     = (byte)((double)Score / MaxScore);
        }


        public long     Id          {get; set;}
        public int      Score       {get; set;}
        public int      MaxScore    {get; set;}
        public TimeSpan TransitTime {get; set;}
        public DateTime DateTime    {get; set;}
        public string   NameQuiz    {get; set;}
        public string   NameUser    {get; set;}
        public byte     Percent     {get; set;}
    }
}